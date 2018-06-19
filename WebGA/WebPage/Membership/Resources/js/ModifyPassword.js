  
  var modifyPwd = document.getElementById("nodifyNewPassword");
  var modifyPwd1 = document.getElementById("reNodifyNewPassword");
  var address = document.getElementById("address");
  var mail = document.getElementById("mail");
  var phone = document.getElementById("phone");
  
  
  
  modifyPwd.onkeyup = function(){
    
    var pwd = modifyPwd.value;
    var pwd1 = modifyPwd1.value;
    
    if(pwd.length >= 6 && pwd.length <= 20){
        document.getElementById("reNodifyNewPassword").disabled = false;
        if(pwd1.length > 0){
            pd();
        }
    }else{
        //modifyPwd1.value = "";
        modifyPwd1.setAttribute("disabled","disabled");
        document.getElementById("spanRe").innerHTML="<font color='red'>请输入新密码!</font>";  
    }
  }
  
  modifyPwd1.onkeyup = function(){
    pd();
}

function pd(){
    var pwd = modifyPwd.value;
    var pwd1 = modifyPwd1.value;
    
    if(pwd == pwd1){
      document.getElementById("spanRe").innerHTML="<font color='green'>验证成功</font>";
      document.getElementById("btnSavePwd").disabled = false;
    }else{
        document.getElementById("spanRe").innerHTML="<font color='red'>密码不同</font>";
        document.getElementById("btnSavePwd").disabled = true;
    }  
}
  
 