$(document).ready(function () {

    Page.LoadValidations();
    Page.ApplyMasks();
    Page.LoadAjaxForm();

});

Page = (function () {

    function loadAjaxForm() {
        $('#FormAdd').ajaxForm({
            dataType: 'json',
            success: function (resposta) {
                if (resposta.data.add) {
                    Notify.SuccessNotify(resposta.data.message);
                    setTimeout(function () {
                        window.history.back();
                    }, 3000);
                } else {
                    Notify.WarningNotify(resposta.data.validate);
                }
            }
        });
    }

    function applyMasks() {
        $("#CpfeCnpj").mask("00.000.000/0000-00");
        $("#telefoneUm").mask("(00)00000-0000");
        $("#telefoneDois").mask("(00)00000-0000");
        $("#Cep").mask("00000-000");
    }

    function loadValidations() {
        $("#FormAdd").validate({
            rules: {
                "pessoa.TipoPessoa": {
                    required: true
                },
                "pessoa.Nome": {
                    minlength: 5,
                    maxlength: 100
                },
                "pessoa.CPFCNPJ": {
                    required: true,
                    minlength: 14,
                    maxlength: 18
                },
                "pessoa.Email": {
                    required: true,
                    minlength: 10,
                    maxlength: 100
                },
                "pessoa.TelefoneUm": {
                    required: true,
                    minlength: 10,
                    maxlength: 14
                },
                "pessoa.TelefoneDois": {
                    minlength: 10,
                    maxlength: 14
                },
                "pessoa.NomeFantasia": {
                    required: true,
                    minlength: 5,
                    maxlength: 50
                },
                "pessoa.NomeRazaoSocial": {
                    required: true,
                    minlength: 5,
                    maxlength: 50
                },
                "pessoa.InscricaoEstadual": {
                    required: true,
                    minlength: 5,
                    maxlength: 50
                },
                "pessoa.Observacoes": {
                    maxlength: 200,
                },
            },
            messages: {
                "pessoa.TipoPessoa": {
                    required: "Campo obrigatório"
                },
                "pessoa.Nome": {
                    minlength: "Mínimo 5 caracteres",
                    maxlength: "Máximo 100 caracteres"
                },
                "pessoa.CPFCNPJ": {
                    required: "Campo obrigatório",
                    minlength: "Mínimo 14 caracteres",
                    maxlength: "Máximo 18 caracteres"
                },
                "pessoa.Email": {
                    required: "Campo obrigatório",
                    minlength: "Mínimo 10 caracteres",
                    maxlength: "Máximo 100 caracteres"
                },
                "pessoa.TelefoneUm": {
                    required: "Campo obrigatório",
                    minlength: "Mínimo 10 caracteres",
                    maxlength: "Máximo 14 caracteres"
                },
                "pessoa.TelefoneDois": {
                    minlength: "Mínimo 10 caracteres",
                    maxlength: "Máximo 14 caracteres"
                },
                "pessoa.NomeFantasia": {
                    required: "Campo obrigatório",
                    minlength: "Mínimo 5 caracteres",
                    maxlength: "Máximo 50 caracteres"
                },
                "pessoa.NomeRazaoSocial": {
                    required: "Campo obrigatório",
                    minlength: "Mínimo 5 caracteres",
                    maxlength: "Máximo 50 caracteres"
                },
                "pessoa.InscricaoEstadual": {
                    required: "Campo obrigatório",
                    minlength: "Mínimo 5 caracteres",
                    maxlength: "Máximo 50 caracteres"
                },
                "pessoa.Observacoes": {
                    maxlength: "Máximo 200 caracteres"
                },
            },
            errorPlacement: function (label, element) {
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
    }

    return {
        ApplyMasks: applyMasks,
        LoadAjaxForm: loadAjaxForm,
        LoadValidations: loadValidations,
    };
})();