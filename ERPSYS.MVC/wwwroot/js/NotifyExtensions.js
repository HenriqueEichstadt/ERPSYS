
Notify = (function (){

    function successNotify(message) {
        $.notify({
            message: message
        }, {
            type: 'success'
        });
    }

    function errorNotify(message) {
        $.notify({
            message: message
        }, {
            type: 'danger'
        });
    }

    function warningNotify(message) {
        $.notify({
            message: message
        }, {
            type: 'warning'
        });
    }
    
    return {
        SuccessNotify: successNotify,
        ErrorNotify: errorNotify,
        WarningNotify: warningNotify
    };
})();

AlertBox = (function () {

    function show(mensagem){
        if(mensagem != undefined){
            $("#alertMessage").html('<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>' +
                '<h4><i class="icon fa fa-warning"></i> Atenção</h4>' + mensagem);
            $("#alertMessage").removeClass('hide');
        }
    }
    
    function hide(){
        $("#alertMessage").addClass('hide');
    }
    
    return {
        Show: show,
        Hide: hide
    };
})();