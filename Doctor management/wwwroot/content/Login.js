function Toggle() {

    let temp = document.getElementById("Password");
    if (temp.type === "password") {
        temp.type = "text";
        $("#newpass").html("<i class='fa fa-eye  newpassfa' onclick='Toggle()'></i>")
    }
    else {
        temp.type = "password";
        $("#newpass").html("<i class='fa fa-eye-slash  newpassfa' onclick='Toggle()'></i>")
    }
}