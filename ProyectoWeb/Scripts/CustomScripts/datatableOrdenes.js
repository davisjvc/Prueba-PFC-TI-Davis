$(document).ready(function () {

    var table = $("#tblOrdenes").DataTable({
        "language": {
            "lengthMenu": "Mostrando _MENU_ elementos",
            "zeroRecords": "No existen ordenes para mostrar",
            "emptyTable": "No existen ordenes para mostrar",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ elementos",
            "search": "Búsqueda:",
            "paginate": {
                "first": "Primera",
                "last": "Última",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        ajax: {
            url: "/Ordenes/GetAllJSON/" + location.search.split('id=')[1],
            dataSrc: "",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        },
        columns: [
            {
                data: "OrdenId"
            },
            {
                data: "FechaOrden",
                render: function (data) {
                    var pattern = /Date\(([^)]+)\)/;
                    var results = pattern.exec(data);
                    var dt = new Date(parseFloat(results[1]));
                    return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear()
                }
            },
            {
                data: "TipoPago"
            },
            {
                data: "Total",
                render: function (data) {
                    var formatter = new Intl.NumberFormat('es-CR', {
                        style: 'currency',
                        currency: 'CRC',
                    });
                    return formatter.format(data);
                }
            },
            {
                data: "Entregada",
                render: function (data) {
                    if (data) { return "Si" }
                    else { return "No" }
                }
            },
            {
                data: "OrdenId",
                render: function (data) {
                    return "<button class='btn-link js-eliminar' data-orden-id=" + data + ">Eliminar</button>"
                },
                orderable: false,
                searchable: false
            }
        ]
    });


    $("#tblOrdenes").on("click", ".js-eliminar", function () {
        var button = $(this);

        bootbox.confirm("Esta seguro que desea eliminar esta orden?", function (result) {
            if (result) {
                $.ajax({
                    url: "/Ordenes/Delete/" + button.attr("data-orden-id"),
                    success: function () {
                        table.row(button.parents("tr")).remove();
                        table.draw();
                        console.log("Success");
                    }
                });
            }
        });
    });

});