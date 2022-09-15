function Alerta_Confirmacion(id, nombre,tipo) {
    let _id = id;
    let _nombre = nombre;
    let _tipo = tipo
    var _title = ""
    switch (_tipo) {
        case "bus":
            _title = `Esta seguro de eliminar el auto ${_nombre} `;
            break;
        case "estacion":
            _title = `Esta seguro de eliminar la estacion ${_nombre} `;
            break;
        case "ruta":
            _title = `Esta seguro de eliminar la ruta ${_id} `;
            break;
    }
    Swal.fire({
        title: _title,
        text: "El cambio no se puede revertir!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#00C2F8',
        confirmButtonText: 'Si, Eliminar!',
        cancelButtonText: "Cancelar"
    }).then((result) => {
        if (result.isConfirmed) {

            Swal.fire({
                title: 'Eliminado!',
                text: 'El registro ha sido eliminado',
                icon: 'success'
            }
            ).then((isok) => {
                $("form").submit();
                return true;
            }
            );


        } else {
            return false;
        }
    });
    return false;
}

//******Funcion Toastr de confirmacion */

function notificacion_guardado(mensaje){
    toastr.success(mensaje);
    toastr.options.closeButton = true;
    toastr.options.closeMethod = 'fadeOut';
    toastr.options.closeDuration = 3;
    toastr.options.closeEasing = 'swing';
    toastr.options.progressBar = true;
    
}
    
function notificacion_error(mensaje){
    toastr.error(mensaje);
    toastr.options.closeButton = true;
    toastr.options.closeMethod = 'fadeOut';
    toastr.options.closeDuration = 3;
    toastr.options.closeEasing = 'swing';
    toastr.options.progressBar = true;
    toastr.options.positionClass = "toast-bottom-left";
    return true;
/*
    toastr.options = {
    "closeButton": true,
    "debug": false,
    "newestOnTop": false,
    "progressBar": true,
    "positionClass": "toast-bottom-left",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
    }*/
    
    }