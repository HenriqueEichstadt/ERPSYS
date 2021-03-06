$(document).ready(function () {
    
    // Carregar Data Tables
    DataTable.Load();
    
    // ocultar botões
    VisualizationFields.OcultarBotoes();
    
    // Inativar Cliente
    ButtonActions.InatinarCliente();
    
    // Ativar Cliente
    ButtonActions.AtivarCliente();
    
    // Abre o form para editar registro do cliente
    ButtonActions.EditarCliente();

});

DataTable = (function () {
    let table;
    let selectedRow;

    function GetTable(){
        if(table != undefined){
            return table;
        }
    }
    function GetSelectedRow(){
        if(table != undefined)
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
                "url": "/Cliente/ListarClientes",
                "type": "GET",
                "datatype": "json",
            },
            "columns": [
                {"data": "id", "autoWidth": true,},
                {"data": "pessoa.nome", "autoWidth": true},
                {"data": "pessoa.cpfcnpj", "autoWidth": true},
                {"data": "pontos", "autoWidth": true},
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
                {
                    "data": "dataInclusao",
                    "autoWidth": true,
                    render: function (data, type, row) {
                        return moment(row.Validade).format('L');
                    }
                },

            ]
        });
        table.on('select', function (e, dt, type, indexes) {
            selectedRow = table.rows({selected: true}).data()[0];
            VisualizationFields.OcultarBotoes();
            if (selectedRow != undefined) {
                if (selectedRow.ativo == true) {
                    $('#inativar').show();
                }
                if (selectedRow.ativo == false) {
                    $('#ativar').show();
                }
            }
        });
    }
    return {
        Load: Load,
        Table : table,
        GetSelectedRow: GetSelectedRow,
        GetTable: GetTable
    };
})();


ButtonActions = (function (){
    
    function InatinarCliente(){
        $('#inativar').click(function () {
            let clienteId = DataTable.GetSelectedRow().id;
            $.ajax({
                type: "GET",
                url: "/Cliente/InativarCliente/" + clienteId,
                dataType: "json",
                success: function (response) {
                    if (response.data.inativou) {
                        Notify.SuccessNotify("Cliente Inativado");
                        VisualizationFields.OcultarBotao('#inativar');
                        VisualizationFields.ExibirBotao('#ativar');
                        DataTable.GetTable().ajax.reload();
                    }
                }
            });
        });
    }
    
    function AtivarCliente(){
        $('#ativar').click(function () {
            let clienteId = DataTable.GetSelectedRow().id;
            $.ajax({
                type: "GET",
                url: "/Cliente/AtivarCliente/" + clienteId,
                dataType: "json",
                success: function (response) {
                    if (response.data.ativou) {
                        Notify.SuccessNotify("Cliente Ativado");
                        VisualizationFields.ExibirBotao('#inativar');
                        VisualizationFields.OcultarBotao('#ativar');
                        DataTable.GetTable().ajax.reload();
                    }
                }
            });
        });
    }
    
    function EditarCliente(){
        $('#editar').click(function () {
            let clienteId = DataTable.GetSelectedRow().id;
            window.location.href = "/Cliente/Editar/" + clienteId
        });
    }
    
    return {
        InatinarCliente: InatinarCliente,
        AtivarCliente: AtivarCliente,
        EditarCliente: EditarCliente
    };
})();


VisualizationFields = (function (){

    function ocultarBotoes(){
        $('#inativar').hide();
        $('#ativar').hide();
    }

    function exibirBotoes(){
        $('#inativar').show();
        $('#ativar').show();
    }

    function ocultarBotao(id){
        $(id).hide();
    }


    function exibirBotao(id){
        $(id).show();
    }

    return {
        OcultarBotoes: ocultarBotoes,
        ExibirBotoes: exibirBotoes,
        OcultarBotao: ocultarBotao,
        ExibirBotao: exibirBotao
    };    
})();