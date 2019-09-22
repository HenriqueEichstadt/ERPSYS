$(document).ready(function () {

    $('#FormAdd').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.data.add) {
                successNotify(resposta.data.message);
                setTimeout(function () {
                    window.history.back();
                }, 3000);
            } else {
                if(resposta.data.message != undefined){
                    warningNotify(resposta.data.message);    
                }
                else{
                    warningNotify(resposta.data.validate);   
                }
            }
        }
    });
});