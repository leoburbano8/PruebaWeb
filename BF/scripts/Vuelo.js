listar();
function listar() {
    $.get("Vuelo/listarVuelo", function (data) {


    }
     );
}

var btnBuscar = document.getElementById("btnBuscar");
btnBuscar.onclick = function () {
    //Aqui
    var corn = document.getElementById("cboOrigen").value;
    var cdst = document.getElementById("cboDestino").value;
    var fc = document.getElementById("dateida").value;
    $.get("Vuelo/bVuelo/?corigen=" + corn+"&cdestino="+cdst+"&fech"+fc, function (data) {
        crearListado(["Origen", "Destino", "Fecha", "Hora", "N° Vuelo", "Precio", "Moneda"], data);

    });
}

function crearListado(arrayColumnas, data) {
    var contenido = "";
    contenido += "<table id='tablas'  class='table' >";
    contenido += "<thead>";
    contenido += "<tr>";
    for (var i = 0; i < arrayColumnas.length; i++) {
        contenido += "<td>";
        contenido += arrayColumnas[i];
        contenido += "</td>";

    }
    contenido += "<td>Operaciones</td>";
    contenido += "</tr>";
    contenido += "</thead>";
    var llaves = Object.keys(data[0]);
    contenido += "<tbody>";
    for (var i = 0; i < data.length; i++) {
        contenido += "<tr>";
        for (var j = 0; j < llaves.length; j++) {
            var valorLLaves = llaves[j];
            contenido += "<td>";
            contenido += data[i][valorLLaves];
            contenido += "</td>";

        }
        var llaveId = llaves[0];
        contenido += "<td>";
        contenido += "<button class='btn btn-primary' onclick='abrirModal(" + data[i][llaveId] + ")' data-toggle='modal' data-target='#myModal'><p>Seleccionar</p></button> "
        contenido += "</td>"

        contenido += "</tr>";
    }
    contenido += "</tbody>";
    contenido += "</table>";
    document.getElementById("tabla").innerHTML = contenido;
    $("#tablas").dataTable(
        {
            searching: false
        }

        );
}





