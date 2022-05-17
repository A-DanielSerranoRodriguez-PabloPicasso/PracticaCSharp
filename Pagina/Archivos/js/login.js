$(document).ready(function(){
    $("#btn-login").click(function(){
        let username = $("#email").val().trim();
        let password = $("#pwd").val().trim();

        console.log(username)

        if( username != "" && password != "" ){
            $.ajax({
                url:'https://localhost:7179/User/login',
                type:'post',
                data:JSON.stringify({UserName:username,Password:password}),
                contentType:"application/json; charset=utf-8",
                success:function(response){
                    if(response){
                        window.location = "views/welcome.html";
                    }else{
                        $("#error").fadeIn();
                    }
                },
                error:$("#error").fadeIn()
            });
        }
    });
});