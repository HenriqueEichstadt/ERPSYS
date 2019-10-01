$(document).ready(function () {

    Pagina.CarregarSelect2Clientes();
    Pagina.CarregarSelect2FormaDePagamento();
    Pagina.CarregarSelect2Produtos();

    $("#select_produtos").change(function () {
        let idSelecionado = $("#select_produtos").val(); 
        dadosProduto = ItensDaVenda.GetProdutoSelecionado(idSelecionado);
    });
        
    $('#venda_add_item').click(function (event){
        event.preventDefault();
        let mensagemValidacao = "";
        let idProdutoSelecionado = $('#select_produtos').val();
        let nomeProduto = $('#select2-select_produtos-container').text();
        let unidadesProduto = $('#unidades').val();
        let precoUnidade = $('#preco_unidade').val();
        if(idProdutoSelecionado == ""){
            mensagemValidacao = "Selecione um produto para a venda \n";
        }
        if(unidadesProduto == ""){
            mensagemValidacao += "Selecione uma quantidade \n";
        }
        
        
        
        produto.Id = idProdutoSelecionado;
        produto.Nome = nomeProduto;
        produto.Quantidade = unidadesProduto;
        produto.PrecoVenda = precoUnidade;
        produto.PrecoTotal = produto.Quantidade * produto.PrecoVenda;
        
            
        Pagina.AdicionarItemNaTabela(produto.Id, produto.Nome, produto.Quantidade, 
                                     produto.PrecoVenda, produto.PrecoTotal);
    });

    $('#emitir_venda').click(function (event) {

    });

});


Pagina = (function (){
    
    function adicionarItemNaTabela(id, nome, quantidade, precoUnidade, precoTotal){
        let botaoRemoverProduto = $("<button>").addClass("btn del btn-danger sales_item_delete").append(
            $("<i>").addClass("fa fa-trash"));
            
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
    
    function carregarSelect2Clientes(){
        $.ajax({
            type: "GET",
            url: "/Cliente/ListarClientesAtivos",
            data: { ListaClientes: $('#select_clientes').val() },
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
                        clientes.push({
                            Id: d.id,
                            Pontos: d.pontos
                        });
                    });
                }
            },
        });
    }
    
    function carregarSelect2Produtos(){
        $.ajax({
            type: "GET",
            url: "/Produto/ListarProdutosAtivos",
            data: { ListaProdutos: $("#select_produtos").val() },
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
                        produtos.push({
                            PrecoVenda: d.precoVenda,
                            Id: d.id,
                            Categoria: d.categoria,
                            EstoqueAtual: d.estoqueAtual
                        });
                    });
                }
            }
        });
    }
    
    function carregarSelect2FormaDePagamento(){
        $('#forma_pagamento').select2();
    }
    
    return {
        AdicionarItemNaTabela: adicionarItemNaTabela,
        CarregarSelect2Clientes: carregarSelect2Clientes,
        CarregarSelect2Produtos: carregarSelect2Produtos,
        CarregarSelect2FormaDePagamento: carregarSelect2FormaDePagamento
    };
})();

Venda = (function () {

    let pontosCliente = $('#pontos_cliente').val();

    let venda = {
        FormaPagamento: 0,
        Data: "",
        TotalUnidades: 0,
        ClienteId: 0,
        PrecoTotal: 0,
    };


    function getDadosVenda() {
        atualizarValores();
        return venda;
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
                ProdutoId: prodId,
                Unidades: prodQuantidade,
                PrecoTotalItem: prodPrecoSubtotal
            });
    }
    
    function getProdutoSelecionado(index){
        return produtos[produtos.findIndex(p => p.Id == index)];
    }

    return {
        GetItensDaVenda: getItensDaVenda,
        AddItem: addItem,
        GetProdutoSelecionado: getProdutoSelecionado
    };
})();

var produto = {
    Id: 0,
    Nome: "",
    Marca: "",
    Categoria: "",
    PrecoVenda: 0,
    PrecoCusto: 0,
    Descricao: "",
    EstoqueAtual: 0,
    LimiteEstoque: 0,
    QtdPontosProgFidelidade: 0,
    Quantidade: 0,
    PrecoTotal: 0
};

var clientes = [];
var produtos = [];
var dadosProduto = "";
var dadosCliente = "";

/*$(document).ready(function () {
    $(document).on('click', '#venda_add_item', function (event) {
        var sales_no = $('#sales_no').val();
        var sales_date = $('#sales_date').val();
        var customer_id = $('#customer_id').val();
        var item_id = $('#item_id').val();
        var quantity = $('#quantity').val();
        var price = $('#price').val();
        var notes = $('#notes').val();
        if (!item_id) {
            alert('Please select an Item.');
            return false;
        }
        if (!customer_id) {
            alert('Please select a Customer.');
            return false;
        }
        if (!quantity) {
            alert('Quantity must be greated than zero.');
            return false;
        }
        $.ajax({
            type: "POST",
            url: "inventory/sales_save",
            data: {
                sales_no: sales_no,
                sales_date: sales_date,
                customer_id: customer_id,
                item_id: item_id,
                quantity: quantity,
                price: price,
                notes: notes
            },
            success: function (msg) {
                sales_draft = true;
                if (msg == "invalid") {
                    alert("Not enough stock for sale!");
                } else {
                    $("#sales_details").children().remove();
                    $("#sales_details").html(msg);
                    $("#data_table").dataTable();
                }
            }
        });
        $('#sales_no').attr('disabled', true);
        $('#sales_date').attr('disabled', true);
        $('#customer_id').prop('disabled', true);
        $('#quantity').val('');
        $('#price').val('');
        $('#quantity').focus();
    });
    $(document).on('click', '.sales_item_delete', function (event) {
        if (!confirm("Are you sure you want to delete this item?")) {
            return false;
        }
        var sales_no = $('#sales_no').val();
        var item_id = $(this).prev().val();
        $.ajax({
            type: "POST",
            url: "inventory/sales_item_delete",
            data: {sales_no: sales_no, item_id: item_id},
            success: function (msg) {
                $("#sales_details").children().remove();
                $("#sales_details").html(msg);
                $("#data_table").dataTable();
            }
        });
    });
    $(document).on('keyup', '#discount', function (event) {
        var discount = $('#discount').val();
        var paid_amount = $('#paid_amount').attr('data-org-amount');
        var new_paid_amount = paid_amount;
        if (discount == 0) {
        }
        new_paid_amount = paid_amount - discount;
        $('#paid_amount').val(new_paid_amount);
    });
    $(document).on('click', '#sales_complete', function (event) {
        sales_draft = false;
        var sales_no = $('#sales_no').val();
        var paid_amount = $('#paid_amount').val();
        var customer_id = $('#customer_id').val();
        var emp_id = $('#emp_id').val();
        var sales_date = $('#sales_date').val();
        var notes = $('#notes').val();
        $.ajax({
            type: "POST",
            url: "inventory/sales_complete",
            data: {
                sales_no: sales_no,
                paid_amount: paid_amount,
                sales_date: sales_date,
                customer_id: customer_id,
                emp_id: emp_id,
                notes: notes
            },
            success: function (msg) {
                event.preventDefault();
                window.location.replace(msg);
            }
        });
    });
    $(document).on('click', '#sales_return_add_item', function (event) {
        var sales_return_no = $('#sales_return_no').val();
        var sales_return_date = $('#sales_return_date').val();
        var customer_id = $('#customer_id').val();
        var item_id = $('#item_id').val();
        var quantity = $('#quantity').val();
        var price = $('#price').val();
        var notes = $('#notes').val();
        if (!sales_return_no) {
            alert('Please give a sales return no.');
            return false;
        }
        if (!item_id) {
            alert('Please select an Item.');
            return false;
        }
        if (!customer_id) {
            alert('Please select a Customer.');
            return false;
        }
        if (!quantity) {
            alert('Quantity must be greated than zero.');
            return false;
        }
        $.ajax({
            type: "POST",
            url: "inventory/sales_return_save",
            data: {
                sales_return_no: sales_return_no,
                sales_return_date: sales_return_date,
                customer_id: customer_id,
                item_id: item_id,
                quantity: quantity,
                price: price,
                notes: notes
            },
            success: function (msg) {
                sales_return_draft = true;
                if (msg == "invalid") {
                    alert("Return quantity can't be more than sold quantity!");
                } else {
                    $("#sales_return_details").children().remove();
                    $("#sales_return_details").html(msg);
                    $("#data_table").dataTable();
                }
            }
        });
        $('#sales_return_no').attr('disabled', true);
        $('#sales_return_date').attr('disabled', true);
        $('#quantity').val('');
        $('#price').val('');
        $('#quantity').focus();
    });
    $(document).on('click', '.sales_return_item_delete', function (event) {
        if (!confirm("Are you sure you want to delete this item?")) {
            return false;
        }
        var sales_return_no = $('#sales_return_no').val();
        var item_id = $(this).prev().val();
        $.ajax({
            type: "POST",
            url: "inventory/sales_return_item_delete",
            data: {sales_return_no: sales_return_no, item_id: item_id},
            success: function (msg) {
                $("#sales_return_details").children().remove();
                $("#sales_return_details").html(msg);
                $("#data_table").dataTable();
            }
        });
    });
    $(document).on('click', '#sales_return_complete', function (event) {
        sales_return_draft = false;
        var sales_return_no = $('#sales_return_no').val();
        var paid_amount = $('#paid_amount').val();
        var customer_id = $('#customer_id').val();
        var emp_id = $('#emp_id').val();
        var sales_return_date = $('#sales_return_date').val();
        var notes = $('#notes').val();
        $.ajax({
            type: "POST",
            url: "inventory/sales_return_complete",
            data: {
                sales_return_no: sales_return_no,
                paid_amount: paid_amount,
                sales_return_date: sales_return_date,
                customer_id: customer_id,
                emp_id: emp_id,
                notes: notes
            },
            success: function (msg) {
                window.location.replace(msg);
            }
        });
    });
    $(document).on('click', '#purchase_add_item', function (event) {
        var purchase_no = $('#purchase_no').val();
        var purchase_date = $('#purchase_date').val();
        var supplier_id = $('#supplier_id').val();
        var item_id = $('#item_id').val();
        var quantity = $('#quantity').val();
        var price = $('#price').val();
        var notes = $('#notes').val();
        if (!purchase_no) {
            alert('Please give a purchase no.');
            return false;
        }
        if (!item_id) {
            alert('Please select an Item.');
            return false;
        }
        if (!price) {
            alert('Please give Item price.');
            return false;
        }
        if (!supplier_id) {
            alert('Please select a supplier.');
            return false;
        }
        if (!quantity) {
            alert('Quantity must be greated than zero.');
            return false;
        }
        $.ajax({
            type: "POST",
            url: "inventory/purchase_save",
            data: {
                purchase_no: purchase_no,
                purchase_date: purchase_date,
                supplier_id: supplier_id,
                item_id: item_id,
                quantity: quantity,
                price: price,
                notes: notes
            },
            success: function (msg) {
                purchase_draft = true;
                $("#purchase_details").children().remove();
                $("#purchase_details").html(msg);
                $("#data_table").dataTable();
            }
        });
        $('#purchase_no').attr('disabled', true);
        $('#purchase_date').attr('disabled', true);
        $('#supplier_id').prop('disabled', true);
        $('#quantity').val('');
        $('#price').val('');
        $('#quantity').focus();
    });
    $(document).on('click', '.purchase_item_delete', function (event) {
        if (!confirm("Are you sure you want to delete this item?")) {
            return false;
        }
        var purchase_no = $('#purchase_no').val();
        var item_id = $(this).prev().val();
        $.ajax({
            type: "POST",
            url: "inventory/purchase_item_delete",
            data: {purchase_no: purchase_no, item_id: item_id},
            success: function (msg) {
                $("#purchase_details").children().remove();
                $("#purchase_details").html(msg);
                $("#data_table").dataTable();
            }
        });
    });
    $(document).on('click', '#purchase_complete', function (event) {
        purchase_draft = false;
        var purchase_no = $('#purchase_no').val();
        var paid_amount = $('#paid_amount').val();
        var supplier_id = $('#supplier_id').val();
        var purchase_date = $('#purchase_date').val();
        var notes = $('#notes').val();
        $.ajax({
            type: "POST",
            url: "inventory/purchase_complete",
            data: {
                purchase_no: purchase_no,
                paid_amount: paid_amount,
                purchase_date: purchase_date,
                supplier_id: supplier_id,
                notes: notes
            },
            success: function (msg) {
                window.location.replace(msg);
            }
        });
    });
    $(document).on('click', '#purchase_return_add_item', function (event) {
        var purchase_return_no = $('#purchase_return_no').val();
        var purchase_return_date = $('#purchase_return_date').val();
        var supplier_id = $('#supplier_id').val();
        var item_id = $('#item_id').val();
        var quantity = $('#quantity').val();
        var price = $('#price').val();
        var notes = $('#notes').val();
        if (!purchase_return_no) {
            alert('Please give a purchase return no.');
            return false;
        }
        if (!item_id) {
            alert('Please select an Item.');
            return false;
        }
        if (!supplier_id) {
            alert('Please select a supplier.');
            return false;
        }
        if (!quantity) {
            alert('Quantity can not be empty.');
            return false;
        }
        if (!price) {
            alert('Price can not be empty.');
            return false;
        }
        $.ajax({
            type: "POST",
            url: "inventory/purchase_return_save",
            data: {
                purchase_return_no: purchase_return_no,
                purchase_return_date: purchase_return_date,
                supplier_id: supplier_id,
                item_id: item_id,
                quantity: quantity,
                price: price,
                notes: notes
            },
            success: function (msg) {
                purchase_return_draft = true;
                if (msg == "invalid") {
                    alert("Return quantity can't be more than purchase quantity!");
                } else {
                    $("#purchase_return_details").children().remove();
                    $("#purchase_return_details").html(msg);
                    $("#data_table").dataTable();
                }
            }
        });
        $('#purchase_return_no').attr('disabled', true);
        $('#purchase_return_date').attr('disabled', true);
        $('#quantity').val('');
        $('#price').val('');
        $('#quantity').focus();
    });
    $(document).on('click', '.purchase_return_item_delete', function (event) {
        if (!confirm("Are you sure you want to delete this item?")) {
            return false;
        }
        var purchase_return_no = $('#purchase_return_no').val();
        var item_id = $(this).prev().val();
        $.ajax({
            type: "POST",
            url: "inventory/purchase_return_item_delete",
            data: {purchase_return_no: purchase_return_no, item_id: item_id},
            success: function (msg) {
                $("#purchase_return_details").children().remove();
                $("#purchase_return_details").html(msg);
                $("#data_table").dataTable();
            }
        });
    });
    $(document).on('click', '#purchase_return_complete', function (event) {
        purchase_return_draft = false;
        var purchase_return_no = $('#purchase_return_no').val();
        var paid_amount = $('#paid_amount').val();
        var supplier_id = $('#supplier_id').val();
        var purchase_return_date = $('#purchase_return_date').val();
        var notes = $('#notes').val();
        $.ajax({
            type: "POST",
            url: "inventory/purchase_return_complete",
            data: {
                purchase_return_no: purchase_return_no,
                paid_amount: paid_amount,
                purchase_return_date: purchase_return_date,
                supplier_id: supplier_id,
                notes: notes
            },
            success: function (msg) {
                window.location.replace(msg);
            }
        });
    });
    $(document).on('click', '#debit_add', function (event) {
        var journal_no = $('#journal_no').val();
        var journal_date = $('#journal_date').val();
        var journal_memo = $('#journal_memo').val();
        var debit_chart_id = $('#debit_chart_id').val();
        var debit_amount = $('#debit_amount').val();
        var debit_memo = $('#debit_memo').val();
        $.ajax({
            type: "POST",
            url: "accounts/debit_add",
            data: {
                journal_no: journal_no,
                journal_date: journal_date,
                journal_memo: journal_memo,
                debit_chart_id: debit_chart_id,
                debit_amount: debit_amount,
                debit_memo: debit_memo
            },
            success: function (msg) {
                journal_draft = true;
                $("#debit_details").children().remove();
                $("#debit_details").html(msg);
                var str = $('#debit_total').text();
                var total_debit = str.replace(",", "");
                $('#credit_amount').val(total_debit);
            }
        });
        $('#journal_no').attr('disabled', true);
        $('#journal_date').attr('disabled', true);
        $('#debit_amount').val('');
        $('#debit_memo').val('');
        $('#debit_amount').focus();
    });
    $(document).on('click', '#credit_add', function (event) {
        var journal_no = $('#journal_no').val();
        var journal_date = $('#journal_date').val();
        var journal_memo = $('#journal_memo').val();
        var credit_chart_id = $('#credit_chart_id').val();
        var credit_amount = $('#credit_amount').val();
        var credit_memo = $('#credit_memo').val();
        $.ajax({
            type: "POST",
            url: "accounts/credit_add",
            data: {
                journal_no: journal_no,
                journal_date: journal_date,
                journal_memo: journal_memo,
                credit_chart_id: credit_chart_id,
                credit_amount: credit_amount,
                credit_memo: credit_memo
            },
            success: function (msg) {
                journal_draft = true;
                $("#credit_details").children().remove();
                $("#credit_details").html(msg);
                var debit = $('#debit_total').text();
                var total_debit = debit.replace(",", "");
                var credit = $('#credit_total').text();
                var total_credit = credit.replace(",", "");
                var rest_credit = total_debit - total_credit;
                $('#credit_amount').val(rest_credit);
            }
        });
        $('#journal_no').attr('disabled', true);
        $('#journal_date').attr('disabled', true);
        $('#credit_amount').val('');
        $('#credit_memo').val('');
        $('#credit_amount').focus();
    });
    $(document).on('click', '.debit_voucher_delete', function (event) {
        if (confirm("Are you sure you want to delete this item?")) {
            var journal_no = $('#journal_no').val();
            var voucher_id = $(this).prev().val();
            $.ajax({
                type: "POST",
                url: "accounts/delete_voucher/debit",
                data: {journal_no: journal_no, voucher_id: voucher_id},
                success: function (msg) {
                    journal_draft = true;
                    $("#debit_details").children().remove();
                    $("#debit_details").html(msg);
                }
            });
        }
    });
    $(document).on('click', '.credit_voucher_delete', function (event) {
        if (confirm("Are you sure you want to delete this item?")) {
            var journal_no = $('#journal_no').val();
            var voucher_id = $(this).prev().val();
            $.ajax({
                type: "POST",
                url: "accounts/delete_voucher/credit",
                data: {journal_no: journal_no, voucher_id: voucher_id},
                success: function (msg) {
                    journal_draft = true;
                    $("#credit_details").children().remove();
                    $("#credit_details").html(msg);
                }
            });
        }
    });
    $(document).on('click', '#journal_complete', function (event) {
        journal_draft = false;
        var debit_total = $('#debit_total').text();
        var debit = Number(debit_total.replace(/[^0-9\.]+/g, ""));
        var credit_total = $('#credit_total').text();
        var credit = Number(credit_total.replace(/[^0-9\.]+/g, ""));
        var balance;
        if (debit !== credit) {
            if (debit > credit) {
                balance = debit - credit;
                alert('Credit voucher still need ' + balance + ' amount.');
                $("#credit_amount").focus();
            } else {
                balance = credit - debit;
                alert('Debit voucher still need ' + balance + ' amount.');
                $("#debit_amount").focus();
            }
            return false;
        }
        var journal_no = $('#journal_no').val();
        var journal_date = $('#journal_date').val();
        var journal_memo = $('#journal_memo').val();
        $.ajax({
            type: "POST",
            url: "accounts/journal_complete",
            data: {journal_no: journal_no, journal_date: journal_date, journal_memo: journal_memo},
            success: function (msg) {
                window.location.replace(msg);
            }
        });
    });
    $(document).on('click', '#add_supplier', function (event) {
        var code = $('#code').val();
        var name = $('#name').val();
        var address = $('#address').val();
        var contact_person = $('#contact_person').val();
        var phone_no = $('#phone_no').val();
        var notes = $('#notes').val();
        var status = 'Active';
        if (name == "") {
            var nameField = document.getElementById('name');
            nameField.insertAdjacentHTML('afterend', '<span class="help-block">Supplier name required</span>');
            nameField.closest('.form-group').classList.add('has-error');
            nameField.focus();
            return false;
        }
        $.ajax({
            type: "POST",
            url: "inventory/add_new_supplier",
            data: {
                code: code,
                name: name,
                address: address,
                contact_person: contact_person,
                phone_no: phone_no,
                notes: notes,
                status: status
            },
            success: function (msg) {
                $("#supplier_id").select2("destroy");
                $("#supplier_id option").remove();
                $("#supplier_id").append(msg);
                $("#supplier_id").select2();
            }
        });
        $('#modal-supplier').modal('hide');
    });
    $(document).on('click', '#add_customer', function (event) {
        var code = $('#code').val();
        var name = $('#name').val();
        var address = $('#address').val();
        var mobile = $('#mobile').val();
        var country = $('#country').val();
        var email = $('#email').val();
        var notes = $('#notes').val();
        var status = $('#status').val();
        if (name == "") {
            var nameField = document.getElementById('name');
            nameField.insertAdjacentHTML('afterend', '<span class="help-block">Customer name required</span>');
            nameField.closest('.form-group').classList.add('has-error');
            nameField.focus();
            return false;
        }
        $.ajax({
            type: "POST",
            url: "inventory/add_new_customer",
            data: {
                code: code,
                name: name,
                address: address,
                mobile: mobile,
                country: country,
                email: email,
                notes: notes,
                status: status
            },
            success: function (msg) {
                $("#customer_id").select2("destroy");
                $("#customer_id option").remove();
                $("#customer_id").append(msg);
                $("#customer_id").select2();
            }
        });
        $('#modal-customer').modal('hide');
    });
    $('#data_table').DataTable({responsive: true});
    $('#data_table_desc').DataTable({responsive: true, "order": [[0, "desc"]]});
    $('.select2').select2({theme: "bootstrap", width: 'auto',});
    $('#item_id.change-price').on('select2:select', function (e) {
        var select_data = e.params.data;
        $.ajax({
            type: "POST", url: "inventory/get_item_price", data: {id: select_data.id}, success: function (msg) {
                $("#price").val(msg);
            }
        });
    });
    $('[data-form=datepicker]').datepicker({autoclose: true, format: 'dd/mm/yyyy'});
    $('.datepicker').datepicker({autoclose: true, format: 'dd/mm/yyyy'});
});
$(".del").click(function () {
    if (!confirm("Are you sure you want to delete this item?")) {
        return false;
    }
});
*/