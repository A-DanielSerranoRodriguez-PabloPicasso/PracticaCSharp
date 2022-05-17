$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:7179/User/get_all',
        type: 'get',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var users = response
            users.forEach(user => {
                $("#users").append("<li>" + user.UserName + "</li>")
            });
        },
        // error: function () { $("#error").fadeIn() }
    });
})