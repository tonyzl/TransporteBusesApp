function Confirmacion(id, marca) {
    let _id = id;
    let _marca = marca;
    Swal.fire({
        title: `Esta seguro de eliminar el auto ${_marca} `,
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