$(document).ready(function () {

    $("#createTransacciones").click(function () {
        $(".modal-title").text("");
        $(".modal-title").text("Crear transacción");

        $("#TransModal").attr("actionType", "");
        $("#TransModal").attr("actionType", "create");

        $("#btn-crear").show();
        $("#TransModal").modal();
    });
    
    $(".editTransacciones").click(function () {
        $(".modal-title").text("");
        $(".modal-title").text("Editar transacción");

        $("#btn-crear").show();
        $("#btn-limpiar").show();

        var id = $(this).attr("TransId");

        $.ajax({
            url: "/Transacciones/Edit",
            method: 'GET',
            type: "json",
            data: { id: parseInt(id) },
            success: function (data) {

                console.log(data);
                console.log(data.TranTipo);

                $("[name='TranTipo']").val(data.TranTipo);
                $("[name='TranMonto']").val(data.TranMonto);
                $("[name='TranDescripcion']").val(data.TranDescripcion);
                $("[name='TranCuenta']").val(data.TranCuenta);
                $("[name='TranRecurrente']").val(data.TranRecurrente);
                $("[name='TranRecurrenteFhLimite']").val(data.TranRecurrenteFhLimite);

                $("#TransModal").modal();
            }
        });

    });

    $(".detailsTransacciones").click(function () {

        $(".modal-title").text("");
        $(".modal-title").text("Detalles transacción");

        $("#btn-crear").hide();
        $("#btn-limpiar").hide();

        $.ajax({
            url: "/Transacciones/GetCuentas",
            method: 'GET',
            type: "json",
            data: $("#TransId").val(),
            success: function (data) {

            }
        });
        $("#TransModal").modal();
    });

    $("#btn-crear").click(function () {

        var action = $("#TransModal").attr("actionType");
        var myData = $("#TransForm").serialize();

        switch (action) {
            case "create":
                $.ajax({
                    url: "/Transacciones/Create",
                    method: 'POST',
                    type: "json",
                    data: myData,
                    success: function (data) {
                        console.log("Wiiiiiii" + data);
                    }
                });
                break;

            case "edit":
                $.ajax({
                    url: "/Transacciones/Edit",
                    method: 'POST',
                    type: "json",
                    data: myData,
                    success: function (data) {
                        console.log("Wiiiiiii" + data);
                    }
                });
                break;

            default:

        }

    });
});