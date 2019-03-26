$(document).ready(function () {
        $.ajax({
            url: "/Transacciones/GetCuentas",
            method: 'GET',
            type: "json",
            async: true,
            success: function (data) {
                $(".cuenta option:not(:first)").remove();
                $.each(data, function (row) {
                    $(".cuenta").append("<option value='" + data[row].CuentaId + "'>" + data[row].CuentaDescripcion + "</option>")
                });

            }
        })
});
