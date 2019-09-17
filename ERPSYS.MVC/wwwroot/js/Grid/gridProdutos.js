$(document).ready(function () {
    var tabela = $('#MyEstoque').DataTable({
        dom: 'Blftip',
        select: { style: 'single' },
        "language":
            {
                "info": "Total: _TOTAL_ registro(s) - Página _PAGE_ de _PAGES_.",
                "zeroRecords": "Nenhum resultado encontrado.",
                "infoEmpty": "Mostrando 0 registros.",
                "infoFiltered": "(Filtrado de _MAX_ itens.)",
                "decimal": ",",
                "thousands": ".",
                "search": "Filtrar",
                "loadingRecords": "Carregando...",
                "processing": "Processando...",
                "paginate": {
                    "first": "Primeira",
                    "last": "Última",
                    "next": "Próxima",
                    "previous": "Anterior"
                },
                "lengthMenu": "Registros por página:  _MENU_",
                select: {
                    rows: {
                        _: "%d registros selecionados.",
                        0: "Clique em um registro para selecioná-lo.",
                        1: "1 registro selecionado."
                    }
                }
            },
        "ajax": {
            "url": "/Produto/ListarProdutos",
            "type": "GET",
            "datatype": "json",
        },
        "columns": [
            { "data": "id", "autoWidth": true },
            { "data": "nome", "autoWidth": true },
            { "data": "marca", "autoWidth": true },
            {
                "data": "categoria",
                "autoWidth": true,
                render: function (data, type, row) {
                    if(row.categoria == 'P'){
                        return "Produto";
                    }
                    else{
                        return "Sem Categoria";
                    }
            },
            { "data": "precoVenda", "autoWidth": true },
            { "data": "precoCusto", "autoWidth": true },
            {
                "data": "ativo",
                "autoWidth": true,
                render: function (data, type, row) {
                    if (row.ativo == true) {
                        return "Ativo";
                    }
                    else {
                        return "Inativo";
                    }
                }
            },
            { "data": "estoqueAtual", "autoWidth": true },
            { "data": "limiteEstoque", "autoWidth": true },
            { "data": "validade", "autoWidth": true },
            { 
                "data": "qtdPontosProgFidelidade",
                "autoWidth": true },
            render: function(data type, row){
            if(row.qtdPontosProgFidelidade == null){
                return "-"
            }
            else{
                return data;
            }
    }
        ]
    });
    tabela.on('select', function(e, dt, type, indexes){
        $('#inativar').hide();
        $('#ativar').hide();
        if(tabela.rows({ selected: true }).data()[0] != undefined) {
            if (tabela.rows({selected: true}).data()[0].ativo == true) {
                $('#inativar').show();
            }
            if (tabela.rows({selected: true}).data()[0].ativo == false) {
                $('#ativar').show();
            }
        }
    });

    // ocultar botões
    $('#inativar').hide();
    $('#ativar').hide();

    // Inativa Cliente
    $('#inativar').click(function () {
        let produtoId = tabela.rows({ selected: true }).data()[0].id;
        $.ajax({
            type: "GET",
            url: "/Produto/InativarProduto/" + produtoId,
            dataType: "json",
            success: function (response) {
                if (response.data.inativou) {
                    successNotify("Produto Inativado");
                    $('#inativar').hide();
                    $('#ativar').show();
                    tabela.ajax.reload();
                }
            }
        });
    });

    // Ativar Cliente
    $('#ativar').click(function () {
        let produtoId = tabela.rows({ selected: true }).data()[0].id;
        $.ajax({
            type: "GET",
            url: "/Produto/AtivarProduto/" + produtoId,
            dataType: "json",
            success: function (response) {
                if (response.data.ativou) {
                    successNotify("Produto Ativado");
                    $('#inativar').show();
                    $('#ativar').hide();
                    tabela.ajax.reload();
                }
            }
        });
    });

    // Abre o form para editar registro do cliente
    $('#editar').click(function () {
        let produtoId = tabela.rows({ selected: true }).data()[0].id;
        window.location.href = "/Produto/Editar/" + produtoId
    });

});