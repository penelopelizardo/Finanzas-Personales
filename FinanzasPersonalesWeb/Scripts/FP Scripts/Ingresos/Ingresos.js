$(document).ready(function () {

    //$("[name=TranMonto]").mask("00,000,000.00", { reverse: true });

    $("#createIngresos").click(function () {
        $("#IngForm").trigger("reset");

        $(".modal-title").text("");
        $(".modal-title").text("Crear ingreso");

        $("#IngModal").attr("actionType", "");
        $("#IngModal").attr("actionType", "create");

        $("#btn-crear").show();
        $("#btn-limpiar").show();

        $(".inputState").attr("disabled", false);

        $("#IngModal").modal();
    });

    $(".editIngresos").click(function () {
        $(".modal-title").text("");
        $(".modal-title").text("Editar ingreso");

        var id = $(this).attr("IngId");

        $("#IngModal").attr("actionType", "");
        $("#IngModal").attr("actionType", "edit");

        $("#btn-crear").show();
        $("#btn-limpiar").show();

        $(".inputState").attr("disabled", false);

        displayIngresosById(id);

    });

    $(".detailsIngresos").click(function () {

        $("#IngForm").trigger("reset");

        var id = $(this).attr("IngId");

        $(".modal-title").text("");
        $(".modal-title").text("Detalles ingreso");

        $("#btn-crear").hide();
        $("#btn-limpiar").hide();

        displayIngresosById(id);

        $(".inputState").attr("disabled", true);

    });

    $("#btn-crear").click(function () {

        var action = $("#IngModal").attr("actionType");
        var myData = $("#IngForm").serialize();

        switch (action) {
            case "create":
                $.ajax({
                    url: "/Ingresos/Create",
                    method: 'POST',
                    type: "json",
                    data: myData,
                    success: function (data) {

                    }
                });
                break;

            case "edit":
                $.ajax({
                    url: "/Ingresos/Edit",
                    method: 'POST',
                    type: "json",
                    data: myData,
                    success: function (data) {

                    }
                });
                break;

            default:

        }

    });

    $("#btn-limpiar").click(function () {

        //$("#IngForm")[0].reset();

        $("#IngForm").trigger("reset");

    });

    function displayIngresosById(id) {

        console.log(id);

        $.ajax({
            url: "/Ingresos/GetIngresosById",
            method: 'GET',
            type: "json",
            data: { id: parseInt(id) },
            success: function (data) {

                console.log(data);

                $("[name='IngresoId']").val(data.IngresoId);
                $("[name='IngresoTipo']").val(data.IngresoTipo);
                $("[name='IngresoFh']").val(data.IngresoFh);
                $("[name='IngresoMonto']").val(data.IngresoMonto);
                $("[name='IngresoDescripcion']").val(data.IngresoDescripcion);
                $("[name='IngresoCuenta']").val(data.IngresoCuenta);
                //$("[name='IngresoRecurrente']").val(data.IngresoRecurrente);
                //$("[name='IngresoRecurrenteFhLimite']").val(data.IngresoRecurrenteFhLimite);

                $("#IngModal").modal();
            }
        });

        $("#IngModal").modal();
    }
});