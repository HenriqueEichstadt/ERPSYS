$(document).ready(function () {

    //  $('#validade-message').hide();
    //$('#validade-message').html("ahskjdhakdjsa");
    
    $('#FormAdd').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.data.add) {
                successNotify(resposta.data.message);
                setTimeout(function () {
                    window.history.back();
                }, 3000);
            } else {
                warningNotify(resposta.data.validate);
            }
        }
    });
});