$(document).ready(function(){
    $("#btn-login").click(function(){
        let username = $("#email").val().trim();
        let password = $("#pwd").val().trim();

        console.log(username)

        if( username != "" && password != "" ){
            $.ajax({
                url:'https://localhost:44308/api/Login',
                type:'post',
                data:JSON.stringify({username:username,password:password}),
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