$(document).ready(function () {
    $('.table').DataTable({
        "language": {
            "processing": "...Procesando...",
            "lengthMenu": "Mostrar _MENU_ registros",
            "zeroRecords": "No se encontraron registros disponibles",
            "emptyTable": "No hay registros disponibles en esta tabla",
            "info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
            "infoPostFix": "",
            "search": "Buscar:",
            "url": "",
            "infoThousands": ",",
            "loadingRecords": "...Cargando...",
            "paginate": {
                "first": " Primero ",
                "last": " Ultimo ",
                "next": " Siguiente ",
                "previous": " Anterior "
            },
            "aria": {
                "sortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        },
        responsive: true,
        initComplete: function () {
            $(".dataTables_wrapper input[type='search']").focus().select();
        }
    });

    //$('#TransT').DataTable({
    //    "language": {
    //        "processing": "...Procesando...",
    //        "lengthMenu": "Mostrar _MENU_ registros",
    //        "zeroRecords": "No se encontraron registros disponibles",
    //        "emptyTable": "No hay registros disponibles en esta tabla",
    //        "info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
    //        "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
    //        "infoFiltered": "(filtrado de un total de _MAX_ registros)",
    //        "infoPostFix": "",
    //        "search": "Buscar:",
    //        "url": "",
    //        "infoThousands": ",",
    //        "loadingRecords": "...Cargando...",
    //        "paginate": {
    //            "first": " Primero ",
    //            "last": " Ultimo ",
    //            "next": " Siguiente ",
    //            "previous": " Anterior "
    //        },
    //        "aria": {
    //            "sortAscending": ": Activar para ordenar la columna de manera ascendente",
    //            "sortDescending": ": Activar para ordenar la columna de manera descendente"
    //        }
    //    },
    //    responsive: true,
    //    initComplete: function () {
    //        $(".dataTables_wrapper input[type='search']").focus().select();
    //    }
    //});
});

