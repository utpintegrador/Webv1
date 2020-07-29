//Al inicio de cada clase se debe de llamar a este evento
function ValidacionInicial() {
    resultOk = true;
    if (GetItem('Nombre') == '' && resultOk) {
        resultOk = false;
    }
    if (GetItem('Apellido') == '' && resultOk) {
        resultOk = false;
    }
    if (GetItem('CorreoElectronico') == '' && resultOk) {
        resultOk = false;
    }
    if (GetItem('IdUsuario') == '' && resultOk) {
        resultOk = false;
    }
    if (GetItem('UrlImagen') == '' && resultOk) {
        resultOk = false;
    }
    if (GetItem('Token') == '' && resultOk) {
        resultOk = false;
    }

    if (!resultOk) {
        window.location.href = '/Home/Login';
    }
}