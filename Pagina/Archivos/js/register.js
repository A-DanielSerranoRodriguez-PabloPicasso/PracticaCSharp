$(document).ready(function () {
    $("#btn-register").click(function () {
        let username = $("#userName").val().trim();
        let password = $("#pwd").val().trim();
        let email = $("#email").val().trim();
        let birthDate = $("#birthDate").val().trim();

        console.log(username)

        if (username != "" && password != "") {
            $.ajax({
                url: 'https://localhost:7179/User/register',
                type: 'post',
                data: JSON.stringify({ UserName: username, Password: password, Email: email, BirthDate: birthDate }),
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    if (response) {
                        window.location = "../index.html";
                    }
                },
                error: function () { $("#error").fadeIn() }
            });
        }
    });
});