$(document).ready(function () {

    $('#FormAdd').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.data.add) {
                Notify.SuccessNotify(resposta.data.message);
                setTimeout(function () {
                    window.history.back();
                }, 3000);
            } else {
                if(resposta.data.message != undefined){
                    Notify.WarningNotify(resposta.data.message);    
                }
                else{
                    Notify.WarningNotify(resposta.data.validate);   
                }
            }
        }
    });
});