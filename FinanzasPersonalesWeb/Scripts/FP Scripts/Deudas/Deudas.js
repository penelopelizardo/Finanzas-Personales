$(document).ready(function () {

    //$("[name=DeudaMonto]").mask("00,000,000.00", { reverse: true });

    $("#createDeudas").click(function () {
        $("#DeudaForm").trigger("reset");

        $(".modal-title").text("");
        $(".modal-title").text("Crear transacción");

        $("#DeudaModal").attr("actionType", "");
        $("#DeudaModal").attr("actionType", "create");

        $("#btn-crear").show();
        $("#btn-limpiar").show();

        $(".inputState").attr("disabled", false);

        $("#DeudaModal").modal();
    });

    $(".editDeudaacciones").click(function () {
        $(".modal-title").text("");
        $(".modal-title").text("Editar transacción");

        var id = $(this).attr("DeudaId");

        $("#DeudaModal").attr("actionType", "");
        $("#DeudaModal").attr("actionType", "edit");

        $("#btn-crear").show();
        $("#btn-limpiar").show();

        $(".inputState").attr("disabled", false);

        displayDeudaactionsById(id);

    });

    $(".detailsDeudaacciones").click(function () {

        $("#DeudaForm").trigger("reset");

        var id = $(this).attr("DeudaId");


        $(".modal-title").text("");
        $(".modal-title").text("Detalles transacción");

        $("#btn-crear").hide();
        $("#btn-limpiar").hide();

        displayDeudaactionsById(id);

        $(".inputState").attr("disabled", true);

    });

    $("#btn-crear").click(function () {

        var action = $("#DeudaModal").attr("actionType");
        var myData = $("#DeudaForm").serialize();

        switch (action) {
            case "create":
                $.ajax({
                    url: "/Deudas/Create",
                    method: 'POST',
                    type: "json",
                    data: myData,
                    success: function (data) {

                    }
                });
                break;

            case "edit":
                $.ajax({
                    url: "/Deudas/Edit",
                    method: 'POST',
                    type: "json",
                    data: myData,
                    success: function (data) {

                    }
                });

                $("[name=DeudaFh]").hide();
                $("[name=DeudaFecha]").show();
                break;

            default:

        }

    });

    $("#btn-limpiar").click(function () {

        //$("#DeudaForm")[0].reset();

        $("#DeudaForm").trigger("reset");

    });

    function displayDeudaactionsById(id) {

        $.ajax({
            url: "/Deudas/GetDeudaById",
            method: 'GET',
            type: "json",
            data: { id: parseInt(id) },
            success: function (data) {

                $("[name='DeudaId']").val(data.DeudaId);
                $("[name='DeudaFhCreacion']").val(data.DeudaFhCreacion);
                $("[name='DeudaMonto']").val(data.DeudaMonto);
                $("[name='DeudaDescripcion']").val(data.DeudaDescripcion);
                $("[name='DeudaTipoMoneda']").val(data.DeudaTipoMoneda);

                $("#DeudaModal").modal();
            }
        });
    }
});