function Validate() {
    var name = document.getElementById("txtName").value;
    if (name == "") {
        alert('Please Enter Name')
        return false;
    }
    var email = document.getElementById("email").value;
    var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

    if (!email.match(validRegex)) {

        alert("Envalid email address!");
        return false;

    }
    var phonenumber = document.getElementById("phn").value;
    var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
    if ((!phonenumber.match(phoneno) || phonenumber.length > 10)) {
        alert("invalid number ");
        return false;
    }


    var password = document.getElementById("pass").value;
    var regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@.#$!%*?&])[A-Za-z\d@.#$!%*?&]{8,15}$/;
    if (password == "" || password < 10 || !password.match(regex)) {
        alert("invalid password");
        return false;
    }


    return true;

}
