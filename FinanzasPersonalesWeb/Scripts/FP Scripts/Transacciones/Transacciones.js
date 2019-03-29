$(document).ready(function () {
      
    //$("[name=TranMonto]").mask("00,000,000.00", { reverse: true });
   
    $("#createTransacciones").click(function () {
        $("#TransForm").trigger("reset");

        $("[name=TranFh]").hide();
        $("[name=TranFecha]").show();

        $(".modal-title").text("");
        $(".modal-title").text("Crear transacción");

        $("#TransModal").attr("actionType", "");
        $("#TransModal").attr("actionType", "create");

        $("#btn-crear").show();
        $("#btn-limpiar").show();

        $(".inputState").attr("disabled", false);

        $("#TransModal").modal();
    });

    $(".editTransacciones").click(function () {
        $(".modal-title").text("");
        $(".modal-title").text("Editar transacción");

        $("[name=TranFh]").show();
        $("[name=TranFecha]").hide();

        var id = $(this).attr("TransId");

        $("#TransModal").attr("actionType", "");
        $("#TransModal").attr("actionType", "edit");

        $("#btn-crear").show();
        $("#btn-limpiar").show();

        $(".inputState").attr("disabled", false);

        displayTransactionsById(id);

    });

    $(".detailsTransacciones").click(function () {

        $("#TransForm").trigger("reset");

        var id = $(this).attr("TransId");

        $("[name=TranFh]").show();
        $("[name=TranFecha]").hide();

        $(".modal-title").text("");
        $(".modal-title").text("Detalles transacción");

        $("#btn-crear").hide();
        $("#btn-limpiar").hide();

        displayTransactionsById(id);

        $(".inputState").attr("disabled", true);

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
                     
                    }
                });

                $("[name=TranFh]").hide();
                $("[name=TranFecha]").show();
                break;

            default:

        }

    });

    $("#btn-limpiar").click(function () {

        //$("#TransForm")[0].reset();

        $("#TransForm").trigger("reset");

    });

    function displayTransactionsById(id) {

        $.ajax({
            url: "/Transacciones/GetTransactionsById",
            method: 'GET',
            type: "json",
            data: { id: parseInt(id) },
            success: function (data) {
               
                $("[name='TranId']").val(data.TranId);
                $("[name='TranTipo']").val(data.TranTipo);
                $("[name='TranFh']").val(data.TranFh);
                $("[name='TranMonto']").val(data.TranMonto);
                $("[name='TranDescripcion']").val(data.TranDescripcion);
                $("[name='TranCuenta']").val(data.TranCuenta);
                $("[name='TranRecurrente']").val(data.TranRecurrente);
                $("[name='TranFhLimite']").val(data.TranFhLimite);

                $("#TransModal").modal();
            }
        });
    }
});