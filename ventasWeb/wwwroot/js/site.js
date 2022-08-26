// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#globales").hide();
$("#vendidos").hide();
$("#comprar").hide();
$("#existencias").hide();
$("#tablaPro").hide();

var ventas=[];
var productos=[];

function buscar() {
    var id = document.getElementById("selectVP").value;
    ventapp(id);
    
    $("#tablaPro").show();
}

function cambia_visibles() {
    var cod = document.getElementById("selectV").value;
    if (cod == 1) {
        ventasm();
        $("#vendidos").show();
        $("#globales").hide();
    }
    else if (cod == 2) {
        tablavendidos();
        $("#vendidos").hide();
        $("#globales").show();
    }
}
    function visiblesProd() {
        var cod = document.getElementById("selectP").value;
        if (cod == 1) {
            tablapc();
            $("#comprar").show();
            $("#existencias").hide();
        }
        else if (cod == 2) {
            tablaex();
            $("#comprar").hide();
            $("#existencias").show();
        }
   
}

function tablapc() {
    jQuery.post("ConsultaVenta").done(function (datosv) {

        jQuery.post("ConsultaProducto").done(function (datosp) {

            console.log(datosv);
            console.log(datosp);
            var a = 0;
            var n = datosv['length'];

            for (var i = 0; i <= n - 1; i++) {
                p = datosv[i].idProductos;
                
                if (datosp[p - 1].existencias <= 100) {                  
                   
                    contenido = '<tr id="datos">';
                    contenido += '<td>' + (a + 1) + '</td>';
                    contenido += '<td>' + datosp[p - 1].titulo + '</td>';
                    contenido += '<td>' + datosp[p - 1].descripcion + '</td>';
                    contenido += '<td>' + datosp[p - 1].existencias + '</td>';
                    contenido += '</tr>';
                    jQuery("#tablapc").append(contenido);
                    a++;
                }
                
            }
        })

    })
}

function tablaex() {
    jQuery.post("ConsultaMasV").done(function (datosv) {

        jQuery.post("ConsultaProducto").done(function (datosp) {

            console.log(datosv);
            console.log(datosp);
           
            var n = datosv['length'];

            for (var i = 0; i <= n - 1; i++) {
                p = datosv[i].idProductos;

               

                    contenido = '<tr id="datos">';
                    contenido += '<td>' + (i + 1) + '</td>';
                    contenido += '<td>' + datosp[p - 1].titulo + '</td>';
                    contenido += '<td>' + datosp[p - 1].existencias + '</td>';
                    contenido += '<td>' + datosv[i].cantidadVendida + '</td>';
                    contenido += '</tr>';
                    jQuery("#tablaex").append(contenido);
                   
               

            }
        })

    })
}

function ventasm() {

    jQuery.post("ConsultaMasV").done(function (datosv) {

        jQuery.post("ConsultaProducto").done(function (datosp) {

            console.log(datosv);
            console.log(datosp);
            
            var n = datosv['length'];
            for (var i = 0; i <= n - 1; i++) {
                
                p = datosv[i].idProductos;
                tot = datosv[i].cantidadVendida * datosp[p - 1].precioUnitario;
                contenido = '<tr id="datos">';
                contenido += '<td>' + (i + 1) + '</td>';
                contenido += '<td>' + datosp[p - 1].titulo + '</td>';
                contenido += '<td>' + datosv[i].cantidadVendida + '</td>';
                contenido += '<td>$' + tot + '</td>';
                contenido += '</tr>';
                jQuery("#ventasm").append(contenido);
            }
        })

    })
}



function ventapp(id) {
    jQuery("#ventapp").empty();
    console.log(id);
    jQuery.post("ConsultaVentaP", { id: id }).done(function (datosv) {

        jQuery.post("ConsultaPro", { id: id }).done(function (datosp) {

            console.log(datosv);
            console.log(datosp);
            var n = datosv['length'];
            for (var i = 0; i <= n - 1; i++) {
                p = datosv[i].idProductos;
                contenido = '<tr id="datos">';
                contenido += '<td>' + (i + 1) + '</td>';
                contenido += '<td>' + datosp[0].titulo + '</td>';
                contenido += '<td>' + datosv[i].cantidadVendida + '</td>';
                contenido += '<td>' + datosv[i].fecha + '</td>';
                contenido += '</tr>';
                jQuery("#ventapp").append(contenido);
            }
        })


    })

}


function tablavendidos() {  
   
    jQuery.post("ConsultaVenta").done(function (datosv) {

        jQuery.post("ConsultaProducto").done(function (datosp) { 

            console.log(datosv);
            console.log(datosp);
            var n = datosv['length'];
            for (var i = 0; i <= n - 1; i++) {
                p = datosv[i].idProductos;
                contenido = '<tr id="datos">';
                contenido += '<td>' + (i+1) + '</td>';
                contenido += '<td>' + datosp[p - 1].titulo + '</td>';
                contenido += '<td>' + datosv[i].cantidadVendida + '</td>';
                contenido += '<td>' + datosv[i].fecha + '</td>';
                contenido += '</tr>';
                jQuery("#ventasg").append(contenido);
            }
        })
             
        
    })
     
    
}
function tablaventaprod() {
    var url = '@Url.Action("ConsultaVentaP", "Home")';
    jQuery.post("/ConsultaVentaP", params).done(function (datosV) {
        alert("algo");
    })
}       