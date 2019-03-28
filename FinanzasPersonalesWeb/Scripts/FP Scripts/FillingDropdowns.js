$(document).ready(function () {
    $.ajax({
        url: "/Generic/GetCuentas",
        method: 'GET',
        type: "json",
        success: function (data) {
            $(".cuenta option:not(:first)").remove();
            $.each(data, function (row) {
                $(".cuenta").append("<option value='" + data[row].CuentaId + "'>" + data[row].CuentaDescripcion + "</option>")
            });

        }
    });

    $.ajax({
        url: "/Generic/GetTipoIngresos",
        method: 'GET',
        type: "json",
        success: function (data) {
            $(".tipoIngresos option:not(:first)").remove();
            $.each(data, function (row) {
                $(".tipoIngresos").append("<option value='" + data[row].TipoIngresoId + "'>" + data[row].TipoIngresoDescripcion + "</option>")
            });

        }
    });

    $.ajax({
        url: "/Generic/GetTipoGastos",
        method: 'GET',
        type: "json",
        success: function (data) {
            $(".tipoGastos option:not(:first)").remove();
            $.each(data, function (row) {
                $(".tipoGastos").append("<option value='" + data[row].TiposGastosId + "'>" + data[row].TiposGastosDescripcion + "</option>")
            });

        }
    })
});
