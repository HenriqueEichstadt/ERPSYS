$(document).ready(function () {

    Page.LoadValidations();
    Page.LoadAjaxForm();
    
});

Page = (function () {

    function loadAjaxForm(){
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
    }
    
    function loadValidations(){
        $("#FormAdd").validate({
            rules: {
                "usuario.Nome": {
                    required: true,
                    minlength: 5,
                    maxlength: 50
                },
                "usuario.Apelido": {
                    required: true,
                    minlength: 5,
                    maxlength: 40
                },
                "usuario.Email": {
                    required: true,
                    minlength: 5,
                    maxlength: 100,
                    email: true
                },
                "usuario.Senha": {
                    required: true,
                    minlength: 5,
                    maxlength: 30
                },
                "senhaRepetida":{
                    required: true,
                    minlength: 5,
                    maxlength: 30,
                    passwordValidate: true
                },
                "usuario.NivelAcesso": {
                    required: true
                },
            },
            messages: {
                "usuario.Nome": {
                    required: "Campo obrigatório",
                    minlength: "Mínimo 5 caracteres",
                    maxlength: "Máximo 50 caracteres"
                },
                "usuario.Apelido": {
                    required: "Campo obrigatório",
                    minlength: "Mínimo 5 caracteres",
                    maxlength: "Máximo 40 caracteres"
                },
                "usuario.Email": {
                    required: "Campo obrigatório",
                    minlength: "Mínimo 5 caracteres",
                    maxlength: "Máximo 100 caracteres",
                    email: "E-mail inválido"
                },
                "usuario.Senha": {
                    required: "Campo obrigatório",
                    minlength: "Mínimo 5 caracteres",
                    maxlength: "Máximo 30 caracteres",
                },
                "senhaRepetida":{
                    required: "Campo obrigatório",
                    minlength: "Mínimo 5 caracteres",
                    maxlength: "Máximo 30 caracteres",
                },
                "usuario.NivelAcesso": {
                    required: "Campo obrigatório",
                },
            },
            errorPlacement: function (label, element){
                label.addClass('alert alert-danger validationErrorMessage');
                label.prop("role", "alert");
                label.insertAfter(element);
            },
            wrapper: 'div',
            errorClass: 'campoInvalido',
            highlight: function (element, errorClass) {
                $(element).addClass(errorClass);
            },
            unhighlight: function (element, errorClass) {
                $(element).removeClass(errorClass);
            },
        });

        jQuery.validator.addMethod("passwordValidate", function (value, element) {
            return this.optional(element) || value === $("#senhaPrincipal").val();
        }, 'As senhas não coincidem');
    }
    return {
        LoadAjaxForm: loadAjaxForm,
        LoadValidations: loadValidations,
    };
})();
