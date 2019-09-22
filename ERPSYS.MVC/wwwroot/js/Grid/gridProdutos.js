$(document).ready(function () {

    // Carregar Data Tables
    DataTable.Load();

    // ocultar botões
    VisualizationFields.OcultarBotoes();

    // Inativar Produto
    ButtonActions.InatinarProduto();

    // Ativar Produto
    ButtonActions.AtivarProduto();

    // Abre o form para editar registro do produto
    ButtonActions.EditarProduto();

});

DataTable = (function () {
    let table;
    let selectedRow;

    function GetTable() {
        if (table != undefined) {
            return table;
        }
    }

    function GetSelectedRow() {
        if (table != undefined)
            return table.rows({selected: true}).data()[0];
    }

    function Load() {
        table = $('#MyEstoque').DataTable({
            dom: 'Blftip',
            select: {style: 'single'},
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
                {"data": "id", "autoWidth": true},
                {"data": "nome", "autoWidth": true},
                {"data": "marca", "autoWidth": true},
                {
                    "data": "categoria",
                    "autoWidth": true,
                    render: function (data, type, row) {
                        if (row.categoria == 'P') {
                            return "Produto";
                        } else {
                            return "Sem Categoria";
                        }
                    }
                },
                {"data": "precoVenda", "autoWidth": true},
                {"data": "precoCusto", "autoWidth": true},
                {
                    "data": "ativo",
                    "autoWidth": true,
                    render: function (data, type, row, meta) {
                        if (row.ativo == true) {
                            return '<button type="button" class="btn btn-success mb-1 rounded" onclick="InativarProduto(' + meta.row + ')"><i class="fa fa-thumbs-up"></i></button>';
                        } else {
                            return '<button type="button" class="btn btn-danger rounded" onclick="AtivarProduto(' + meta.row + ')"><i class="fa fa-thumbs-down"></i></button>';
                        }
                    }
                },
                {"data": "estoqueAtual", "autoWidth": true},
                {"data": "limiteEstoque", "autoWidth": true},
                {
                    "data": "validade",
                    "autoWidth": true,
                    render: function (data, type, row) {
                        return moment(row.validade).format('L');
                    }
                },
                {
                    "data": "qtdPontosProgFidelidade",
                    "autoWidth": true,
                    render: function (data, type, row) {
                        if (row.qtdPontosProgFidelidade == null) {
                            return "-"
                        } else {
                            return data;
                        }
                    }
                }
            ]
        });
        table.on('select', function (e, dt, type, indexes) {
            VisualizationFields.OcultarBotoes();
            selectedRow = table.rows({selected: true}).data()[0];
            if (selectedRow != undefined) {
                if (selectedRow.ativo == true) {
                    VisualizationFields.ExibirBotao('#inativar');
                }
                if (selectedRow.ativo == false) {
                    VisualizationFields.ExibirBotao('#ativar');
                }
            }
        });
    }

    return {
        Load: Load,
        Table: table,
        GetSelectedRow: GetSelectedRow,
        GetTable: GetTable
    };
})();


ButtonActions = (function () {

    function InatinarProduto() {
        $('#inativar').click(function () {
            let produtoId = DataTable.GetSelectedRow().id;
            $.ajax({
                type: "GET",
                url: "/Produto/InativarProduto/" + produtoId,
                dataType: "json",
                success: function (response) {
                    if (response.data.inativou) {
                        successNotify("Produto Inativado");
                        VisualizationFields.OcultarBotao('#inativar');
                        VisualizationFields.ExibirBotao('#ativar');
                        DataTable.GetTable().ajax.reload();
                    }
                }
            });
        });
    }

    function AtivarProduto() {
        $('#ativar').click(function () {
            let produtoId = DataTable.GetSelectedRow().id;
            $.ajax({
                type: "GET",
                url: "/Produto/AtivarProduto/" + produtoId,
                dataType: "json",
                success: function (response) {
                    if (response.data.ativou) {
                        successNotify("Produto Ativado");
                        VisualizationFields.ExibirBotao('#inativar');
                        VisualizationFields.OcultarBotao('#ativar');
                        DataTable.GetTable().ajax.reload();
                    }
                }
            });
        });
    }

    function EditarProduto() {
        $('#editar').click(function () {
            let produtoId = DataTable.GetSelectedRow().id;
            window.location.href = "/Produto/Editar/" + produtoId
        });
    }

    return {
        InatinarProduto: InatinarProduto,
        AtivarProduto: AtivarProduto,
        EditarProduto: EditarProduto
    };
})();

VisualizationFields = (function () {

    function ocultarBotoes() {
        $('#inativar').hide();
        $('#ativar').hide();
    }

    function exibirBotoes() {
        $('#inativar').show();
        $('#ativar').show();
    }

    function ocultarBotao(id) {
        $(id).hide();
    }


    function exibirBotao(id) {
        $(id).show();
    }

    return {
        OcultarBotoes: ocultarBotoes,
        ExibirBotoes: exibirBotoes,
        OcultarBotao: ocultarBotao,
        ExibirBotao: exibirBotao
    };
})();
