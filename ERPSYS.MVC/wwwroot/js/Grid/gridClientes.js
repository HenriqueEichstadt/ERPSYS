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
            "url": "/Cliente/ListarClientes",
            "type": "GET",
            "datatype": "json",
        },
        "columns": [
            { "data": "id", "autoWidth": true, },
            { "data": "pessoa.nome", "autoWidth": true },
            { "data": "pessoa.cpfcnpj", "autoWidth": true },
            { "data": "pontos", "autoWidth": true },
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
            {
                "data": "dataInclusao",
                "autoWidth": true,
                render: function (data, type, row) {
                    return moment(row.Validade).format('L');
                }
            },

        ]
    });
    
    // ocultar botões
    $('#inativar').hide();
    $('#ativar').hide();
    
    if(tabela.rows({ selected: true }).data()[0].ativo){
        $('#inativar').show();
    }
    if(tabela.rows({ selected: true }).data()[0].ativo){
        $('#ativar').show();
    }
    
    // Inativa Cliente
    $('#inativar').click(function () {
        let clienteId = tabela.rows({ selected: true }).data()[0].id;
        $.ajax({
            type: "GET",
            url: "/Cliente/InativarCliente/" + clienteId,
            dataType: "json",
            success: function (response) {
                if (response.data.inativou) {
                    $.notify("Cliente Inativado");
                    tabela.ajax.reload();
                }
            }
        });
    });

    // Ativar Cliente
    $('#ativar').click(function () {
        let clienteId = tabela.rows({ selected: true }).data()[0].id;
        $.ajax({
            type: "GET",
            url: "/Cliente/AtivarCliente/" + clienteId,
            dataType: "json",
            success: function (response) {
                if (response.data.ativou) {
                    $.notify("Cliente Ativado");
                    tabela.ajax.reload();
                }
            }
        });
    });
    
    // Abre o form para editar registro do cliente
    $('#editar').click(function () {
        let clienteId = tabela.rows({ selected: true }).data()[0].id;
        window.location.href = "/Cliente/Editar/" + clienteId
    });

});