$(document).ready(function () {

    Pagina.CarregarSelect2Clientes();
    Pagina.CarregarSelect2FormaDePagamento();
    Pagina.CarregarSelect2Produtos();

    $("#select_produtos").change(function () {
        let idSelecionado = $("#select_produtos").val();
        let produto = Lista.GetProdutoPorId(idSelecionado);
        let precoUnidade = Number.parseFloat(produto.precoVenda).toFixed(2).replace(".", ",");
        $('#preco_unidade').val('R$ ' + precoUnidade);
    });

    $('#venda_add_item').click(function (event) {
        event.preventDefault();
        let mensagemValidacao = "";
        let idProdutoSelecionado = $('#select_produtos').val();
        let nomeProduto = $('#select2-select_produtos-container').text();
        let unidadesProduto = $('#unidades').val();
        let precoUnidade = $('#preco_unidade').val();

        if (idProdutoSelecionado == "") {
            AlertBox.Show("Selecione um produto para a venda");
            return;
        }
        if (unidadesProduto == "") {
            AlertBox.Show("Selecione uma quantidade");
            return;
        }
        if(ItensDaVenda.ContemItem(idProdutoSelecionado)){
            AlertBox.Show("Este produto já está cadastrado na venda");
            return;
        }
        
        let produto = Lista.GetProdutoPorId(idProdutoSelecionado);
        
        let unidades = Number(unidadesProduto);
        let precoSubtotal = unidades * produto.precoVenda
        ItensDaVenda.AddItem(produto.id, unidades, precoSubtotal);
        
        Pagina.AdicionarItemNaTabela(produto.id, produto.nome, unidades, produto.precoVenda, precoSubtotal);
        Pagina.AtualizarPrecoTotalVenda();
    });

    $('#emitir_venda').click(function (event) {

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

    function carregarSelect2FormaDePagamento() {
        $('#forma_pagamento').select2();
    }
    
    function atualizarPrecoTotalVenda(){
        let total = 0;
        $.each(ItensDaVenda.GetItensDaVenda(), function (i, item){
            total += item.precoTotalItem;
        });
        let totalEmDecimal = Number.parseFloat(total).toFixed(2).replace(".", ",");
        $('#precoTotal').val('R$ ' + totalEmDecimal);
    }

    return {
        AdicionarItemNaTabela: adicionarItemNaTabela,
        CarregarSelect2Clientes: carregarSelect2Clientes,
        CarregarSelect2Produtos: carregarSelect2Produtos,
        CarregarSelect2FormaDePagamento: carregarSelect2FormaDePagamento,
        AtualizarPrecoTotalVenda: atualizarPrecoTotalVenda
    };
})();

Venda = (function () {
    
    let venda = {
        FormaPagamento: 0,
        Data: "",
        TotalUnidades: 0,
        ClienteId: 0,
        PrecoTotal: 0,
    };


    function getDadosVenda() {
        atualizarValores();
        return this.venda;
    }


    function atualizarValores() {
        venda.FormaPagamento = $('#forma_pagamento').val();
        venda.Data = $('#data_venda').val();
        venda.TotalUnidades = $('#qtd_itens_venda').val();
        venda.ClienteId = $('#select_clientes').val();
        venda.PrecoTotal = $('#preco_total').val();
    }

    function validacoes() {
        atualizarValores();
        mensagemValidacao = "";

        if (venda.FormaPagamento == null
            || venda.FormaPagamento == undefined)
            mensagemValidacao = "Selecione uma de pagamento. \n";
        if (venda.PrecoTotal == null
            || venda.PrecoTotal == undefined)
            mensagemValidacao += "Preço total inválido. \n";
        if (venda.TotalUnidades == null
            || venda.TotalUnidades == undefined)
            mensagemValidacao += "Quantidade de itens da venda inválida";

        return mensagemValidacao;
    }


    return {};
})();

ItensDaVenda = (function () {

    let itensDaVenda = [];

    function getItensDaVenda() {
        return itensDaVenda;
    }

    function addItem(prodId, prodQuantidade, prodPrecoSubtotal) {
        itensDaVenda.push(
            {
                produtoId: prodId,
                unidades: prodQuantidade,
                precoTotalItem: prodPrecoSubtotal
            });
    }
    
    function removeItem(produtoId){
        itensDaVenda.splice(itensDaVenda.findIndex(p => p.produtoId == produtoId), 1);
    }
    
    function contemItem(id){
        let possui = false;
        $.each(itensDaVenda, function (i, item){
            if(item.produtoId == id)
                possui = true;
        });
        return possui;
    }

    return {
        GetItensDaVenda: getItensDaVenda,
        AddItem: addItem,
        RemoveItem: removeItem,
        ContemItem: contemItem
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
        let retorno =  this.objClientes[this.objClientes.findIndex(p => p.id == id)];
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
