$(document).ready(function () {

    //$("[name=GastoMonto]").mask("00,000,000.00", { reverse: true });

    $("#createGastos").click(function () {
        $("#GastosForm").trigger("reset");

        $("[name=GastoFh]").hide();
        $("[name=GastoFecha]").show();

        $(".modal-title").text("");
        $(".modal-title").text("Crear gasto");

        $("#GastosModal").attr("actionType", "");
        $("#GastosModal").attr("actionType", "create");

        $("#btn-crear").show();
        $("#btn-limpiar").show();

        $(".inputState").attr("disabled", false);

        $("#GastosModal").modal();
    });

    $(".editGastos").click(function () {
        $(".modal-title").text("");
        $(".modal-title").text("Editar gasto");

        //$("[name=GastoFh]").show();
        //$("[name=GastoFecha]").hide();

        var id = $(this).attr("GasId");

        $("#GastosModal").attr("actionType", "");
        $("#GastosModal").attr("actionType", "edit");

        $("#btn-crear").show();
        $("#btn-limpiar").show();

        $(".inputState").attr("disabled", false);

        displayGastosById(id);

    });

    $(".detailsGastos").click(function () {

        $("#GastosForm").trigger("reset");

        var id = $(this).attr("GasId");

        $("[name=GastoFh]").show();
        $("[name=GastoFecha]").hide();

        $(".modal-title").text("");
        $(".modal-title").text("Detalles gasto");

        $("#btn-crear").hide();
        $("#btn-limpiar").hide();

        displayGastosById(id);

        $(".inputState").attr("disabled", true);

    });

    $("#btn-crear").click(function () {

        var action = $("#GastosModal").attr("actionType");
        var myData = $("#GastosForm").serialize();

        switch (action) {
            case "create":
                $.ajax({
                    url: "/Gastos/Create",
                    method: 'POST',
                    type: "json",
                    data: myData,
                    success: function (data) {

                    }
                });
                break;

            case "edit":
                $.ajax({
                    url: "/Gastos/Edit",
                    method: 'POST',
                    type: "json",
                    data: myData,
                    success: function (data) {

                    }
                });

                //$("[name=GastoFh]").hide();
                //$("[name=GastoFecha]").show();
                break;

            default:

        }

    });

    $("#btn-limpiar").click(function () {

        //$("#GastosForm")[0].reset();

        $("#GastosForm").trigger("reset");

    });

    function displayGastosById(id) {

        $.ajax({
            url: "/Gastos/GetGastosById",
            method: 'GET',
            type: "json",
            data: { id: parseInt(id) },
            success: function (data) {

                $("[name='GastoId']").val(data.GastoId);
                $("[name='GastoTipo']").val(data.GastoTipo);
                $("[name='GastoFh']").val(data.GastoFh);
                $("[name='GastoMonto']").val(data.GastoMonto);
                $("[name='GastoDescripcion']").val(data.GastoDescripcion);
                $("[name='GastoCuenta']").val(data.GastoCuenta);
                $("[name='GastoRecurrente']").val(data.GastoRecurrente);
                $("[name='GastoFhLimite']").val(data.GastoFhLimite);

                $("#GastosModal").modal();
            }
        });
    }
});