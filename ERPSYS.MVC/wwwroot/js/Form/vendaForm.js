$(document).ready(function () {

    Pagina.CarregarSelect2Clientes();
    Pagina.CarregarSelect2FormaDePagamento();
    Pagina.CarregarSelect2Produtos();
    Pagina.AtualizarQtdItensVenda();
    Pagina.AtualizarPrecoTotalVenda();
    Pagina.AtualizarPontosCliente();

    $('#select_produtos').change(function () {
        let idSelecionado = $("#select_produtos").val();
        let produto = Lista.GetProdutoPorId(idSelecionado);
        let precoUnidade = Number.parseFloat(produto.precoVenda).toFixed(2).replace(".", ",");
        $('#preco_unidade').val('R$ ' + precoUnidade);
        $('#unidades').prop('max', produto.estoqueAtual);
    });

    $('#select_clientes').change(function () {
        let idClienteSelecionado = $('#select_clientes').val();
        
        if(idClienteSelecionado != null){
            Pagina.AdicionarTrocaPorPontosAoSelect2();
        }
        let cliente = Lista.GetClientePorId(idClienteSelecionado);
        Pagina.AtualizarPontosCliente();
    });

    $('#venda_add_item').click(function (event) {
        event.preventDefault();
        let mensagemValidacao = "";
        let idProdutoSelecionado = $('#select_produtos').val();
        let nomeProduto = $('#select2-select_produtos-container').text();
        let unidadesProduto = $('#unidades').val();
        let precoUnidade = $('#preco_unidade').val();
        let produto = Lista.GetProdutoPorId(idProdutoSelecionado);

        if (idProdutoSelecionado == "") {
            Notify.WarningNotify("Selecione um produto para a venda");
            return;
        }
        if (unidadesProduto == "") {
            Notify.WarningNotify("Selecione uma quantidade");
            return;
        }
        if (ItensDaVenda.ContemItem(idProdutoSelecionado)) {
            Notify.WarningNotify("Este produto já está cadastrado na venda");
            return;
        }
        if (unidadesProduto > produto.estoqueAtual) {
            Notify.WarningNotify("Há apenas " + produto.estoqueAtual + " unidades no estoque");
            return;
        }

        let unidades = Number.parseInt(unidadesProduto);
        let precoSubtotal = Number.parseFloat(unidades * produto.precoVenda).toFixed(2);
        ItensDaVenda.AddItem(produto.id, unidades, Number(precoSubtotal));

        Pagina.AdicionarItemNaTabela(produto.id, produto.nome, unidades, produto.precoVenda, precoSubtotal);
        Pagina.AtualizarPrecoTotalVenda();
        Pagina.AtualizarQtdItensVenda();
        Notify.SuccessNotify('Produto Adicionado com sucesso');
    });

    $('#emitir_venda').click(function (event) {
        event.preventDefault();
        let itensDaVenda = ItensDaVenda.GetItensDaVenda();
        let qtdItensDaVenda = ItensDaVenda.GetQtdItensVenda();
        let formaPagamento = $('#forma_pagamento').val();

        if (qtdItensDaVenda == "") {
            Notify.WarningNotify("Venda vazia");
            return;
        }
        if (formaPagamento == "" || formaPagamento == 0) {
            Notify.WarningNotify("Selecione uma forma de pagamento");
            return;
        }

        let idClienteSelecionado = $('#select_clientes').val();
        let cliente = Lista.GetClientePorId(idClienteSelecionado);
        
        let pontosNecessarios = Number.parseInt(Venda.GetDadosVenda().PrecoTotal * 100);
        if(formaPagamento == 4 && cliente.pontos < pontosNecessarios)
        {
            Notify.WarningNotify("O cliente precisa de " + pontosNecessarios + " para efetuar a troca por pontos");
        }
        
        let objVenda = Venda.GetDadosVenda();

        $.ajax({
            url: '/Venda/EmitirVenda',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(
                {
                    clienteId: objVenda.ClienteId,
                    formaPagamento: objVenda.FormaPagamento,
                    vendaItens: objVenda.VendaItens,
                    precoTotal: objVenda.PrecoTotal,
                    totalUnidades: objVenda.TotalUnidades
                }),
        }).done(function (response) {
            if (response.emitida) {
                Notify.SuccessNotify(response.mensagem);
                setTimeout(function() {
                   // window.history.back();
                }, 3000);
            } else {
                Notify.ErrorNotify(response.mensagem);
            }
        });
    });
});

Pagina = (function () {

    function adicionarItemNaTabela(id, nome, quantidade, precoUnidade, precoTotal) {
        let botaoRemoverProduto = $("<button>").addClass("btn del btn-danger sales_item_delete").append(
            $("<i>").addClass("fa fa-trash"));

        botaoRemoverProduto.click(function (event) {
            event.preventDefault();
            var idSelecionado = $(this).parent().parent().find(".IdDoProduto").text();
            ItensDaVenda.RemoveItem(idSelecionado);
            $(this).parent().parent().remove();
            Pagina.AtualizarPrecoTotalVenda();
            Pagina.AtualizarQtdItensVenda();
            Notify.SuccessNotify("Produto removido com sucesso");
        });

        $("#tabela_venda").append(
            $("<tr>").append(
                $("<td>").text(id).addClass("IdDoProduto")
            ).append(
                $("<td>").text(nome)
            ).append(
                $("<td>").text(Number.parseFloat(quantidade).toFixed(2).replace('.', ','))
            ).append(
                $("<td>").text("R$ " + Number.parseFloat(precoUnidade).toFixed(2).replace(".", ","))
            ).append(
                $("<td>").text("R$ " + Number.parseFloat(precoTotal).toFixed(2).replace(".", ","))
            ).append(
                $("<td>").html(botaoRemoverProduto))
        );
    }

    function carregarSelect2Clientes() {
        $.ajax({
            type: "GET",
            url: "/Cliente/ListarClientesAtivos",
            data: {ListaClientes: $('#select_clientes').val()},
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            success: function (obj) {
                if (obj != null) {
                    var dado = obj.data;
                    var selectbox = $('#select_clientes').select2({
                        placeholder: "Selecione um Cliente"
                    });
                    selectbox.find('option').remove();
                    $('<option>').val("").appendTo(selectbox);
                    $.each(dado, function (i, d) {
                        $('<option>').val(d.id).text(d.pessoa.nome + ' - ' + d.pessoa.cpfcnpj).appendTo(selectbox);
                    });
                    Lista.AddClientes(dado);
                }
            },
        });
    }

    function carregarSelect2Produtos() {
        $.ajax({
            type: "GET",
            url: "/Produto/ListarProdutosAtivos",
            data: {ListaProdutos: $("#select_produtos").val()},
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            success: function (obj) {
                if (obj != null) {
                    var dado = obj.data;
                    var selectboxProduto = $('#select_produtos').select2({
                        placeholder: "Selecione um Produto"
                    });
                    selectboxProduto.find('option').remove();
                    $('<option>').val("").appendTo(selectboxProduto);
                    $.each(dado, function (i, d) {
                        $('<option>').val(d.id).text(d.nome).appendTo(selectboxProduto);
                    });
                    Lista.AddProdutos(dado);
                }
            }
        });
    }
    
    function adicionarTrocaPorPontosAoSelect2(){
        var formaPagamento = $('#forma_pagamento').select2();
        $('<option>').val(4).text("Troca por pontos").appendTo(formaPagamento);
    }

    function carregarSelect2FormaDePagamento() {
        $('#forma_pagamento').select2();
        $("#forma_pagamento option[value='4']").remove();
    }

    function atualizarPrecoTotalVenda() {
        let total = 0;
        $.each(ItensDaVenda.GetItensDaVenda(), function (i, item) {
            total += item.PrecoTotalItem;
        });
        let totalEmDecimal = Number.parseFloat(total).toFixed(2).replace(".", ",");
        $('#precoTotal').val('R$ ' + totalEmDecimal);
        $('#preco_total').val('R$ ' + totalEmDecimal);
    }

    function atualizarQtdItensVenda() {
        let quantidade = ItensDaVenda.GetQtdItensVenda();
        if (quantidade == 0) {
            $('#qtd_itens_venda').val('Nenhum item');
        } else if (quantidade == 1) {
            $('#qtd_itens_venda').val(quantidade + ' item');
        } else {
            $('#qtd_itens_venda').val(quantidade + ' itens');
        }
    }

    function atualizarPontosCliente() {
        let idClienteSelecionado = $('#select_clientes').val();
        if (idClienteSelecionado == null) {
            $('#pontos_cliente').val('Selecione um cliente');
            return;
        }
        let cliente = Lista.GetClientePorId(idClienteSelecionado);
        $('#pontos_cliente').val(cliente.pontos + ' pontos');
    }

    return {
        AdicionarItemNaTabela: adicionarItemNaTabela,
        CarregarSelect2Clientes: carregarSelect2Clientes,
        CarregarSelect2Produtos: carregarSelect2Produtos,
        CarregarSelect2FormaDePagamento: carregarSelect2FormaDePagamento,
        AtualizarPrecoTotalVenda: atualizarPrecoTotalVenda,
        AtualizarQtdItensVenda: atualizarQtdItensVenda,
        AtualizarPontosCliente: atualizarPontosCliente,
        AdicionarTrocaPorPontosAoSelect2: adicionarTrocaPorPontosAoSelect2
    };
})();

Venda = (function () {

    let venda =
        {
            Cliente: null,
            ClienteId: null,
            Data: null,
            DataAlteracao: null,
            Datainclusao: null,
            FormaPagamento: null,
            Id: null,
            PrecoTotal: 0,
            TotalUnidades: 0,
            UsuarioAlteracao: null,
            UsuarioAlteracaoId: null,
            UsuarioInclusao: null,
            UsuarioInclusaoId: null,
            VendaItens: Array(),
        };


    function getDadosVenda() {
        atualizarDados();
        return venda;
    }


    function atualizarDados(qtdItens, precoTotal) {
        venda.TotalUnidades = Number.parseInt(ItensDaVenda.GetQtdItensVenda());
        venda.PrecoTotal = ItensDaVenda.GetPrecoTotalVenda();
        venda.Cliente = Number.parseInt($('#select_clientes').val());
        venda.ClienteId = Number.parseInt($('#select_clientes').val());
        venda.VendaItens = ItensDaVenda.GetItensDaVenda();
        venda.FormaPagamento = Number.parseInt($('#forma_pagamento').val());
    }

    function setQtdItensVenda(qtdItens) {
        venda.TotalUnidades = qtdItens;
    }


    return {
        GetDadosVenda: getDadosVenda
    };
})();

ItensDaVenda = (function () {

    let itensDaVenda = [];

    function getItensDaVenda() {
        return itensDaVenda;
    }

    function addItem(prodId, prodQuantidade, prodPrecoSubtotal) {
        itensDaVenda.push(
            {
                ProdutoId: prodId,
                Unidades: prodQuantidade,
                PrecoTotalItem: prodPrecoSubtotal
            });
    }

    function removeItem(produtoId) {
        itensDaVenda.splice(itensDaVenda.findIndex(p => p.ProdutoId == produtoId), 1);
    }

    function contemItem(id) {
        let possui = false;
        $.each(itensDaVenda, function (i, item) {
            if (item.ProdutoId == id)
                possui = true;
        });
        return possui;
    }

    function getQtdItensVenda() {
        let contador = 0;
        $.each(itensDaVenda, function (i, item) {
            contador += item.Unidades;
        });
        return Number(contador);
    }

    function getPrecoTotalVenda() {
        let total = 0;
        $.each(itensDaVenda, function (i, item) {
            total += item.PrecoTotalItem;
        });
        let valor = Number.parseFloat(total).toFixed(2);
        return Number(valor);
    }

    return {
        GetItensDaVenda: getItensDaVenda,
        AddItem: addItem,
        RemoveItem: removeItem,
        ContemItem: contemItem,
        GetQtdItensVenda: getQtdItensVenda,
        GetPrecoTotalVenda: getPrecoTotalVenda
    };
})();


Lista = (function () {
    let objClientes = [];
    let objProdutos = [];

    function addClientes(data) {
        this.objClientes = data;
    }

    function addProdutos(data) {
        this.objProdutos = data;
    }

    function getProdutos() {
        return this.objProdutos;
    }

    function getClientes() {
        return this.objClientes;
    }

    function getProdutoPorId(id) {
        return this.objProdutos[this.objProdutos.findIndex(p => p.id == id)];
    }

    function getClientePorId(id) {
        let retorno = this.objClientes[this.objClientes.findIndex(p => p.id == id)];
        return retorno;
    }

    return {
        AddClientes: addClientes,
        GetClientes: getClientes,
        AddProdutos: addProdutos,
        GetProdutos: getProdutos,
        GetProdutoPorId: getProdutoPorId,
        GetClientePorId: getClientePorId
    };
})();
