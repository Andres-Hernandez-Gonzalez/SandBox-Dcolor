function isNumber(evt) {
    var iKeyCode = (evt.witch) ? evt.witch : evt.keyCode
    if (iKeyCode < 48 || iKeyCode > 57) {
        return false;
    }
    return true;
}

function SoloLetras(e){
       key = e.keyCode || e.which;
       tecla = String.fromCharCode(key);
       letras = " ABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóúabcdefghijklmnñopqrstuvwxyz";
       especiales = "8-37-39-46";

       tecla_especial = false
       for(var i in especiales){
            if(key == especiales[i]){
                tecla_especial = true;
                break;
            }
        }

        if(letras.indexOf(tecla)==-1 && !tecla_especial){
            return false;
        }

      return true;


    }
