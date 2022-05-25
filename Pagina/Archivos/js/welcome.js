$(document).ready(function () {
    function populate() {
        $.ajax({
            url: 'https://localhost:7179/User/get_users',
            type: 'get',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                var users = response
                users.forEach(user => {
                    // console.log(user)
                    $("#users").append("<li value=" + user.userName + " class='expendable'>" + user.userName + "&emsp;&emsp;&emsp;<button type='button' onClick='modify(this)' class='btn btn-dark modifier'>Modificar</button><button type='button' onClick='erase(this)' class='btn btn-danger deleter'>Borrar</button></li>")
                });
            },
        });
    };
    populate();
})

function insertUser() {
    var name = $("#insertName").val();
    var pwd = $("#insertPwd").val();
    var email = $("#insertEmail").val();
    var bDate = $("#insertBdate").val();

    if (!name || !pwd || !email || !bDate) {

    } else {
        $.ajax({
            url: 'https://localhost:7179/User/register',
            type: 'post',
            data: JSON.stringify({ UserName: name, Password: pwd, Email: email, BirthDate: bDate }),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                cancelInsert()
                clearUsers()
                $.ajax({
                    url: 'https://localhost:7179/User/get_users',
                    type: 'get',
                    contentType: "application/json; charset=utf-8",
                    success: function (response) {
                        var users = response
                        users.forEach(user => {
                            // console.log(user)
                            $("#users").append("<li value=" + user.userName + " class='expendable'>" + user.userName + "&emsp;&emsp;&emsp;<button type='button' onClick='modify(this)' class='btn btn-dark modifier'>Modificar</button><button type='button' onClick='erase(this)' class='btn btn-danger deleter'>Borrar</button></li>")
                        });
                    },
                });
            },
        });
    }
}

function toggleInsert() {
    if ($("#primero").css("display") === "none") {
        $("#primero").css("display", "block");
    } else {
        $("#primero").css("display", "none");
    }

    if ($("#segundo").css("display") === "none") {
        $("#segundo").css("display", "block");

    } else {
        $("#segundo").css("display", "none");
    }
}

function cancelInsert() {
    toggleInsert();
    $("#insertName").val("");
    $("#insertPwd").val("");
    $("#insertEmail").val("");
    $("#insertBdate").val("");
}

function erase(element) {
    var parent = $(element).parent("li")
    var user = parent.attr("value")
    console.log(user)
    $.ajax({
        url: 'https://localhost:7179/User/remove?username=' + user,
        type: 'delete',
        // data: JSON.stringify({ UserName: username, Password: password }),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response) {
                parent.remove();
            }
        }
    })
}

function searchUser() {
    clearUsers();
    var user = $("#suInput").val();
    $.ajax({
        url: 'https://localhost:7179/User/get_user?username=' + user,
        type: 'get',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response !== undefined) {
                var users = response
                $("#users").append("<li value=" + users.userName + " class='expendable'>" + users.userName + "&emsp;&emsp;&emsp;<button type='button' onClick='modify(this)' class='btn btn-dark modifier'>Modificar</button><button type='button' onClick='erase(this)' class='btn btn-danger deleter'>Borrar</button></li>")
            }
        },
    });
}

function clearUsers() {
    $(".expendable").remove();
}

function modify(element) {
    var user = $(element).parent("li").attr("value");
    var uName, uMail, uBd;
    $.ajax({
        url: 'https://localhost:7179/User/get_user?username=' + user,
        type: 'get',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response !== undefined) {
                $("#email").attr("placeholder", response.email);
            }
        },
    });
    $("#modify-user").css("display", "block");
    $("#modify-user").attr("value", user);
    $("#users-div").css("display", "none");

}

function cancelModify() {
    $("#modify-user").css("display", "none");
    $("#users-div").css("display", "block");
    $("#pwd").val("");
    $("#email").val("");
    $("#birthDate").val("");
}

function updateUser() {
    var uName = $("#modify-user").attr("value"), uPass = $("#pwd").val(), uMail = $("#email").val(), uBd = $("#birthDate").val();
    var oldPass, oldBd;
    if (!uPass && !uMail && !uBd)
        cancelModify()
    else {
        $.ajax({
            url: 'https://localhost:7179/User/get_user?username=' + uName,
            type: 'get',
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response !== undefined) {
                    oldPass = response.password;
                    oldBd = response.birthDate;
                    if (!uPass) {
                        uPass = oldPass;
                    }

                    if (!uMail) {
                        uMail = $("#email").attr("placeholder");
                    }

                    if (!uBd) {
                        uBd = oldBd;
                    }
                    $.ajax({
                        url: 'https://localhost:7179/User/update_user?username=' + uName,
                        type: 'post',
                        data: JSON.stringify({ UserName: uName, Password: uPass, Email: uMail, BirthDate: uBd }),
                        contentType: "application/json; charset=utf-8",
                        success: function () {
                            cancelModify()
                        },
                    });
                }
            },
        });
    }
}