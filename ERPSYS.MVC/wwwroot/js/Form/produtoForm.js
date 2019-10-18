$(document).ready(function () {

    Page.ApplyMasks();
    Page.LoadValidations();
    Page.LoadAjaxForm();
    Page.CalculatePoints();

});


Page = (function () {

    function applyMasks() {
        $("#precoVenda").mask('#.##0,00', {reverse: true});
        $("#precoCusto").mask('#.##0,00', {reverse: true});
    }

    function loadAjaxForm() {
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

    function loadValidations() {
        $('#FormAdd').validate({
            debug: true,
            rules: {
                'nomeproduto': {
                    required: true,
                    minLength: 3,
                    maxLength: 1500
                }
            },
            messages: {
                'nomeproduto': {
                    accept: "Campo obrigatório"
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


    return {
        ApplyMasks: applyMasks,
        LoadAjaxForm: loadAjaxForm,
        LoadValidations: loadValidations,
        CalculatePoints: calculatePoints
    };
})();
