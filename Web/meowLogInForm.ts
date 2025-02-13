<h3>meowLogInForm</h3>

@code {
    const form = getElementById("LogInForm");
    const username = getElementById("Username");
    const password = getElementById("Password");
    const formData = new FormData();
    formData.uppend("Username", username);
    formData.uppend("Password", password);
    const responce = await fetch("/Users/LogIn",{
        method: "post",
        body: formData
    });
    const data = awair responce.json();
    if(data.Success){
        RedirectToAction(nameof(Index));
    }else if(data.Fail){

    }
}
