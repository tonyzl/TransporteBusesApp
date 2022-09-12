function Confirmacion(event) {
    Swal.fire({
        title: 'Esta seguro?',
        text: "El cambio no se puede revertir!",
        icon: 'error',
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