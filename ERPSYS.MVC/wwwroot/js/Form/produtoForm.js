$(document).ready(function () {

    Page.LoadValidations();
    Page.ApplyMasks();
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
                "produto.Nome": {
                    required: true,
                    minlength: 3,
                    maxlength: 50
                },
                "produto.Marca": {
                    required: true,
                    minlength: 3,
                    maxlength: 30
                },
                "produto.Categoria": {
                    required: true
                },
                "produto.PrecoVenda": {
                    required: true
                },
                "produto.PrecoCusto": {
                    required: true
                },
                "produto.Descricao": {
                    maxlength: 200
                },
                "produto.EstoqueAtual": {
                    required: true
                },
            },
            messages: {
                "produto.Nome": {
                    required: "Campo obrigatório",
                    minlength: "Mínimo 3 caracteres",
                    maxlength: "Máximo 50 caracteres"
                },
                "produto.Marca": {
                    required: "Campo obrigatório",
                    minlength: "Mínimo 3 caracteres",
                    maxlength: "Máximo 30 caracteres"
                },
                "produto.Categoria": {
                    required: "Campo obrigatório",
                },
                "produto.PrecoVenda": {
                    required: "Campo obrigatório",
                },
                "produto.PrecoCusto": {
                    required: "Campo obrigatório",
                },
                "produto.Descricao": {
                    maxlength: "Máximo de 200 caracteres"
                },
                "produto.EstoqueAtual": {
                    required: "Campo obrigatório",
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
