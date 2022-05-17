$(document).ready(function(){
    $("#btn-login").click(function(){
        let username = $("#email").val().trim();
        let password = $("#pwd").val().trim();

        console.log(username)

        if( username != "" && password != "" ){
            $.ajax({
                url:'https://127.0.0.1:7179/User/login',
                // url:'https://127.0.0.1:44359/User/register',
                type:'post',
                data:JSON.stringify({UserName:username,Password:password}),
                contentType:"application/json; charset=utf-8",
                success:function(response){
                    if(response){
                        window.location = "welcome.html";
                    }else{
                        $("#error").fadeIn();
                    }
                }
            });
        }
    });
});