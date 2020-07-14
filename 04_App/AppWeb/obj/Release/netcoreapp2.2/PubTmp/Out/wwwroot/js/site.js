// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function SetItem(llave, valor) {
    if (localStorage.getItem(llave) === null) {
        localStorage.setItem(llave, valor);
    }
}

function GetItem(llave) {
    if (localStorage.getItem(llave) != null) {
        return localStorage.getItem(llave);
    }
    if (llave == 'IdUsuario') {
        return 1;
    }
    return '';
}

function RemoveItem(llave) {
    if (localStorage.getItem(llave) != null) {
        return localStorage.removeItem(llave);
    }
}

