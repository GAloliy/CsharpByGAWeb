/*
 * 
 * Date : 2018-6-3
 * LastModified:6-3 0:21
 * AuthorName : @GAloliy
 * 
 * */

$(function(){

        function postId(source){
        
            var sources = source.split(",");
            var id = sources[0];
            var postURL = sources[1];

           $.ajax({
                                    
                url:postURL,
                type:"POST",
                dataType:"json",
                async:false,
                contentType:"application/json;charset=utf-8",
                data:"{'id':'" + id + "'}",
                success:function(data){

                    if(postURL == "../UploadFile/MembershipManagement.aspx/GetMemberId") {
                         setData(data.d,postURL);
                    }else{
                        setData1(data.d,postURL);
                    }
                },
                error:function(XMLHttpRequest,textStatus,errorThrown){
                    alert("请求出错状态信息:" + XMLHttpRequest.status + "ReadState:" + XMLHttpRequest.readState + "TextStatue:" + textStatus + "Thrown:" + errorThrown);
                },
                complete:function(XMLHttpRequest,textStatus){
                    this;
                }               
                             
            });  
            
        }
        
        function setData(data,postURL){//MembershipManagement
        
            
            var rw = data.split(",");
            
            var userId = rw[0];
            var loginId = rw[1];
            var name = rw[2];
            var address = rw[3];
            var phone = rw[4];
            var mail = rw[5];
            var role = rw[6];
            var personalSynopsis = rw[7];
            postURL = postURL.replace("GetMemberId","");
            

            $("#displayLogId").html(loginId);
            $("#signature").attr("placeholder",personalSynopsis);
            $("#txtName").attr("placeholder",name);
            $("#txtAddress").attr("placeholder",address);
            $("#txtPhone").attr("placeholder",phone);
            $("#txtMail").attr("placeholder",mail);
            $("#role").find("option[value='" + role + "']").attr("selected","selected");            
            
            $("#delInfo").click(function(){
            
                var isConFirm = confirm("是否要删除该成员【" + loginId + "】");
                if(isConFirm){
                    postDel(userId + "，" + postURL);                    
                }else
                    return;
            });
            
            $("#btnModifyInfo").click(function(){
                
                var m_userId = userId;
                var mSignature = $("#signature");
                var mTxtName = $("#txtName");
                var mRole = $("#role");
                var mTxtAddress = $("#txtAddress");
                var mTxtPhone = $("#txtPhone");
                var mTxtMail = $("#txtMail");
                
                
                var m_Signature = $.trim(mSignature.val()) == "" ? (mSignature.attr("placeholder") == undefined ? "": mSignature.attr("placeholder")) : mSignature.val();
                var m_TxtName = $.trim(mTxtName.val()) == "" ? (mTxtName.attr("placeholder") == undefined ? "": mTxtName.attr("placeholder")) : mTxtName.val();
                var m_Role = $.trim(mRole.val()) == "" ? (mRole.attr("placeholder") == undefined ? "" : mRole.attr("placeholder")) : mRole.val();
                var m_TxtAddress = $.trim(mTxtAddress.val()) == "" ? (mTxtAddress.attr("placeholder") == undefined ? "":mTxtAddress.attr("placeholder")): mTxtAddress.val();
                var m_TxtPhone = $.trim(mTxtPhone.val()) == "" ? (mTxtPhone.attr("placeholder") == undefined ? "":mTxtPhone.attr("placeholder")): mTxtPhone.val();
                var m_TxtMail = $.trim(mTxtMail.val()) == "" ? (mTxtMail.attr("placeholder") == undefined ? "":mTxtMail.attr("placeholder")): mTxtMail.val();
                
                var i = "；";
                
                var sources = m_userId + i + m_TxtName + i + m_Signature + i + m_TxtMail + i+ m_TxtPhone + i + m_TxtAddress + i + m_Role;
                var mPostURL = postURL;   
                           
                mPostURL += "ModifyInfo";
                jsonData = "{'sources':'"+ sources +"'}";
                
                ajaxFactory(
                    
                    mPostURL,
                    jsonData,
                    function(data){
                        
                        if(data.d > 0)
                            alert('编辑成功');
                        else 
                            alert('编辑失败,请过一会尝试');
                            
                        window.location.replace("MembershipManagement.aspx");                        
                    }
                
                );
            
            });
        }
        
        function setData1(data,postURL){
        
            var rw = data.split(",");
            
            var MBId = rw[0];
            var author = rw[1];
            var title = rw[2];
            var content = rw[3];
            var linkURL = rw[4];
            var categroies = rw[5];
            postURL = postURL.replace("GetMemberId","");
            
            $("#displayAuthor").html(author);
            $("#title").html(title);
            $("#mTitle").attr("placeholder",title);            
            $("#content").attr("placeholder",content);
            $("#linkURL").attr("placeholder",linkURL);
            $("#categroies").attr("placeholder",categroies);
            
            $("#delInfo").click(function(){
            
                var isConFirm = confirm("是否要删除该文章");
                if(isConFirm){
                    postDel(MBId + "，" + postURL);
                }else
                    return;
                
            });
            
            $("#btnModifyInfo").click(function(){
                
                var m_MBId = MBId;
                var mTitle = $("#mTitle");
                var mContent = $("#content");
                var mLinkURL = $("#linkURL");
                var mCategroies = $("#categroies");
                
                var m_title = $.trim(mTitle.val()) == "" ? (mTitle.attr("placeholder") == undefined ? "": mTitle.attr("placeholder")) : mTitle.val();
                var m_content = $.trim(mContent.val()) == "" ? (mContent.attr("placeholder") == undefined ? "": mContent.attr("placeholder")) : mContent.val();
                var m_linkURL = $.trim(mLinkURL.val()) == "" ? (mLinkURL.attr("placeholder") == undefined ? "" : mLinkURL.attr("placeholder")) : mLinkURL.val();
                var m_categroies = $.trim(mCategroies.val()) == "" ? (mCategroies.attr("placeholder") == undefined ? "":mCategroies.attr("placeholder")): mCategroies.val();
                var i = "；";
                
                var sources = m_MBId + i + m_title + i + m_content + i + m_linkURL + i+ m_categroies;
                var mPostURL = postURL;   
                           
                mPostURL += "ModifyInfo";
                jsonData = "{'sources':'"+ sources +"'}";
                
                ajaxFactory(
                    
                    mPostURL,
                    jsonData,
                    function(data){
                        
                        if(data.d > 0)
                            alert('编辑成功');
                        else 
                            alert('编辑失败,请过一会尝试');
                        window.location.replace("CommentManagement.aspx");
                    }
                
                );
                
            });
        }
    
        function postDel(source){
        
            var sources = source.split("，");
            var id = sources[0];
            var postURL = sources[1];
            postURL += "DelElement";
            
            var jsonData = "{'id':'" + id + "'}";
            
            ajaxFactory(
            
                postURL,
                jsonData,
                function(data){

                    if(postURL == "../UploadFile/MembershipManagement.aspx/DelElement") {
                        if(data.d > 0)
                            alert('成员成功删除!');
                         else
                            alert('成员删除失败,请过一会尝试');
                            
                    window.location.replace("MembershipManagement.aspx");                            
                    }else{
                        if(data.d > 0)
                            alert('留言成功删除!');
                        else
                            alert('留言删除失败,请过一会尝试');
                            
                    window.location.replace("CommentManagement.aspx");                                                        
                    }
                }        
            );
        }
        
        function ajaxFactory(postURL,data,successFn){
        
            $.ajax({
                                    
                url:postURL,
                type:"POST",
                dataType:"json",
                async:false,
                contentType:"application/json;charset=utf-8",
                data:data,
                success:successFn,
                error:function(XMLHttpRequest,textStatus,errorThrown){
                    alert("请求出错状态信息:" + XMLHttpRequest.status + "ReadState:" + XMLHttpRequest.readState + "TextStatue:" + textStatus + "Thrown:" + errorThrown);
                },
                complete:function(XMLHttpRequest,textStatus){
                    this;
                }               
                             
            });  
        }
        
    window.postId = postId;
    window.setData = setData;
    window.setData1 = setData1;
    window.ajaxFactory = ajaxFactory;
});