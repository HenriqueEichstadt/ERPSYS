$(document).ready(function () {

    Page.ApplyMasks();
    Page.LoadAjaxForm();
    Page.CalculatePoints();
    Page.LoadValidations();
});


Page = (function () {

    function applyMasks() {
        $("#precoVenda").mask('#.##0,00', {reverse: true});
        $("#precoCusto").mask('#.##0,00', {reverse: true});
    }

    function loadAjaxForm() {
        Page.LoadValidations();
        $('#FormAdd').ajaxForm({
            dataType: 'json',
            success: function (response) {
                if (response.data.add) {
                    Notify.SuccessNotify(response.data.message);
                    setTimeout(function () {
                        window.history.back();
                    }, 3000);
                } else {
                    Notify.WarningNotify(response.data.validate);
                }
            }
        });
    }

    function calculatePoints() {
        if($("#precoVenda").val() != ""){
            let precoVendaText = $("#precoVenda").val().replace(',', '.');
            let precoVenda = parseFloat(precoVendaText);
            let pontos = precoVenda * 100;
            $("#trocapontos").val(pontos);        
        }
        else{
            $("#trocapontos").val('');
        }
    }

    function loadValidations() {
        $("#FormAdd").validate({
            rules: {
                Nome: {
                    required: true,
                    maxlength: 50
                },
            },
            messages: {
                Nome: {
                    required: "Campo obrigatório!",
                    maxlength: "Máximo 50 Caracteres!"
                },
            }
        });
    }
    
    return {
        ApplyMasks: applyMasks,
        LoadAjaxForm: loadAjaxForm,
        LoadValidations: loadValidations,
        CalculatePoints: calculatePoints
    };
})();
