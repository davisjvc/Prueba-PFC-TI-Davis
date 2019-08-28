$(document).ready(function () {
    $("#tblClientes").hide();
    $("#btnBusqueda").click(function (e) {
        e.preventDefault();
        $("#tblClientes").show();
        $("#btnBusqueda").hide();
        return cargarClientes();
    });

    function cargarClientes() {
        var table = $("#tblClientes").DataTable({
            "language": {
                "lengthMenu": "Mostrando _MENU_ elementos",
                "zeroRecords": "Sin datos para mostrar",
                "emptyTable": "Sin datos para mostrar",
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
                url: "/Clientes/GetAllJSON",
                dataSrc: "",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            },
            columns: [
                {
                    data: "ClienteId"
                },
                {
                    data: "Nombre"
                },
                {
                    data: "Direccion"
                },
                {
                    data: "Telefono"
                },
                {
                    data: "FechaNac",
                    render: function (data) {
                        var pattern = /Date\(([^)]+)\)/;
                        var results = pattern.exec(data);
                        var dt = new Date(parseFloat(results[1]));
                        return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear()
                    }
                },
                {
                    data: "Email"
                },
                {
                    render: function (data, type, cliente) {
                        return "<a class='btn btn-link' href='/Ordenes/?id=" + cliente.ClienteId + "'>Ver Ordenes de Compra</a>";
                    },
                    orderable: false,
                    searchable: false
                },
                {
                    render: function (data, type, cliente) {
                        return "<a class='btn btn-link' href='/Clientes/Edit/" + cliente.ClienteId + "'>Modificar</a>";
                    },
                    orderable: false,
                    searchable: false
                }
            ]
        });
    }

});