$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:7179/User/get_users',
        type: 'get',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var users = response
            users.forEach(user => {
                // console.log(user)
                $("#users").append("<li value=" + user.userName + ">" + user.userName + "&emsp;&emsp;&emsp;<button type='button' onClick='erase(this)' class='btn btn-danger deleter'>Borrar</button></li>")
            });
        },
        // error: function () { $("#error").fadeIn() }
    });
})

function erase(element){
    var parent = $(element).parent("li")
    var user = parent.attr("value")
    console.log(user)
    $.ajax({
        url: 'https://localhost:7179/User/remove?username='+user,
        type: 'delete',
        // data: JSON.stringify({ UserName: username, Password: password }),
        contentType: "application/json; charset=utf-8",
        success: function(response){
            if(response){
                parent.remove();
            }
        }
    })
    // console.log(parent)
}