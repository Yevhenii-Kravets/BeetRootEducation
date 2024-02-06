function validateEmail(email) {
    var re = /[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/;
    return re.test(String(email).toLowerCase());
}

// REGISTRATION
var buttonSignin = document.getElementById('buttonSignin');
buttonSignin.addEventListener('click', function () {
    var inptPassword = document.getElementById('inputPasswordReg');

    var inptMail = document.getElementById('inputEmailReg');
    if (validateEmail(inptMail.value)) {
        document.getElementById('icon-auth').style.display = "inline";;
        document.getElementById('icon-non-auth').style.display = "none";

        var name = document.getElementById('inputName');
        var surname = document.getElementById('inputSurname');
        document.getElementById('user-name').innerHTML = name.value + " " + surname.value;

        // close modal and clean values
        bootstrap.Modal.getInstance(document.getElementById('signin_modal')).hide();
        inptMail.classList.remove('is-invalid');
        inptMail.value = null;
        name.value = null;
        surname.value = null;
        inptPassword.value = null;
        document.getElementById('error-email-reg').innerHTML = null;
    } else {
        inptMail.classList.add('is-invalid');
        document.getElementById('error-email-reg').innerHTML = "Invalid email!";
    }
    
});

// AUTHORIZATION
var buttonLogin = document.getElementById('buttonLogin');
buttonLogin.addEventListener('click', function () {
    var inptPassword = document.getElementById('inputPasswordReg');

    var inptMail = document.getElementById('inputEmail');
    if (validateEmail(inptMail.value)) {
        document.getElementById('icon-auth').style.display = "inline";;
        document.getElementById('icon-non-auth').style.display = "none";

        document.getElementById('user-name').innerHTML = "name surname";

        // close modal and clean values
        bootstrap.Modal.getInstance(document.getElementById('login_modal')).hide();
        inptMail.classList.remove('is-invalid');
        inptMail.value = null;
        inptPassword.value = null;
        document.getElementById('error-email').innerHTML = null;
    } else {
        inptMail.classList.add('is-invalid');
        document.getElementById('error-email').innerHTML = "Invalid email!";
    }
});
