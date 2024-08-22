function Toggle12() {

    let temp = document.getElementById("pass");
    if (temp.type === "password") {
        temp.type = "text";
        $("#olpass").html("<i class='fa fa-eye  pass' onclick='Toggle12()'></i>")
    }
    else {
        temp.type = "password";
        $("#olpass").html("<i class='fa fa-eye-slash  pass' onclick='Toggle12()'></i>")
    }
}   