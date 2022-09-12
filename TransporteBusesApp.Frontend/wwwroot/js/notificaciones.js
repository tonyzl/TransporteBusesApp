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