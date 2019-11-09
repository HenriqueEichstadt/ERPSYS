
$(document).ready(function () {
    LoginPage.LoadFormValidations();
    LoginPage.LoadAjaxForm();
});


LoginPage = (function () {

    function loadAjaxForm(){
        $('#loginForm').ajaxForm({
            dataType: 'json',
            success: function (resposta) {
                if (resposta.logIn) {
                    $(location).attr('href', "/Home/Index");
                } else {
                    Notify.WarningNotify(resposta.message);
                }
            }
        });    
    }
    
    function loadFormValidations(){
        bootstrapValidate('#apelido', 'required:Informe o usuário');
    }
    
    return {
        LoadAjaxForm: loadAjaxForm,
        LoadFormValidations: loadFormValidations
    }
})();