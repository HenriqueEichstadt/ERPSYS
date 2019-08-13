$(document).ready(function () {

    $('#FormAdd').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.data.add) {
                successNotify(resposta.data.message, resposta.data.type);
                //$('#FormAdd').resetForm();
                //$("#messageContainer").remove();
                /*$("#messageContainer").append(
                    '<div class="col-sm-12" id="messageContainer">'
                    + '<div class="alert  alert-success alert-dismissible fade show" role="alert">'
                    + '<span class="badge badge-pill badge-success">sucesso</span> Cliente adicionado.'
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>');
                    */
            } else {
                $.notify("Erro no Cadastro");
                //$("#messageContainer").remove();
                /*
                $("#messageContainer").append(
                    '<div class="col-sm-12" id="msgErroInternoCliente">'
                    + '<div class="sufee-alert alert with-close alert-danger alert-dismissible fade show">'
                    + '<span class="badge badge-pill badge-danger">erro interno</span> ' + resposta.message
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>');
                    */
            }
        }
    });
});