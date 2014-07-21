String.prototype.trim = function() { return this.replace(/^\s+|\s+$/, ''); }

function fnMakeHome(obj)
{
        var addHomePage='http://www.easyway2buy.com';
        obj.style.behavior='url(#default#homepage)';
       obj.setHomePage(addHomePage);
}



 function bookmark(url, sitename) {
            ns = "Please use your browser's bookmarking facility to create bookmark.";
            if ((navigator.appName == 'Microsoft Internet Explorer') && (parseInt(navigator.appVersion) >= 4)) {
                window.external.AddFavorite(url, sitename);
            }
            else if (navigator.appName == 'Netscape') {
                alert(ns);
            }
        }

function limitText(limitField, limitCount, limitNum) {
 
	if (limitField.value.length > limitNum) {
		limitField.value = limitField.value.substring(0, limitNum);
	} else {
		document.getElementById(limitCount).innerHTML = limitNum - limitField.value.length;
	}
}

function fnCheck()
    {
       var frndName1 = document.getElementById("txtName1").value;
       var frndName2 = document.getElementById("txtName2").value;
       var frndName3 = document.getElementById("txtName3").value;
       var frndName4 = document.getElementById("txtName4").value;
       var frndName5 = document.getElementById("txtName5").value;
       
       var emailFrnd1 = document.getElementById("txtEmail1").value;
       var emailFrnd2 = document.getElementById("txtEmail2").value;
       var emailFrnd3 = document.getElementById("txtEmail3").value;
       var emailFrnd4 = document.getElementById("txtEmail4").value;
       var emailFrnd5 = document.getElementById("txtEmail5").value;
       
       if(frndName1=="" && emailFrnd1=="")
       {
        alert("Please enter friends name and email");
        return false;
       }
        
        if(frndName1!="" && emailFrnd1=="")
        {
            alert("Please enter email of your friend");
            return false;
        }
        
        if(frndName1=="" && emailFrnd1!="")
        {
            alert("Please enter name of your friend");
            return false;
        }
        if(frndName2!="" && emailFrnd2=="")
        {
            alert("Please enter email of your friend");
            return false;
        }
        
        if(frndName2=="" && emailFrnd2!="")
        {
            alert("Please enter name of your friend");
            return false;
        }
        
        if(frndName3!="" && emailFrnd3=="")
        {
            alert("Please enter email of your friend");
            return false;
        }
        
        if(frndName3=="" && emailFrnd3!="")
        {
            alert("Please enter name of your friend");
            return false;
        }
        if(frndName4!="" && emailFrnd4=="")
        {
            alert("Please enter email of your friend");
            return false;
        }
        
        if(frndName4=="" && emailFrnd4!="")
        {
            alert("Please enter name of your friend");
            return false;
        }
        if(frndName5!="" && emailFrnd5=="")
        {
            alert("Please enter email of your friend");
            return false;
        }
        
        if(frndName5=="" && emailFrnd5!="")
        {
            alert("Please enter name of your friend");
            return false;
        }
        
    }

	function submitReview()
	{
		if (Page_ClientValidate())
		{
		    $("#divLoading").html("<img src='/includes/images/loading.gif'> Loading...Please Wait");
			
				var url = "reviewSubmit.EW2B?TYPE=REVIEWSUBMIT&random="+new Date();
				jqueryAjaxPost('AddItemToCart',url,'action=change',fnReviewResponse)
	
			
		}

	}
	function setRating(objRating)
	{
	    var ratValue = objRating.getAttribute('value');
	    
		if(ratValue=="1")
			$('#liRating').width('20%')
		else if(ratValue=="2")
			$('#liRating').width('40%')
		else if(ratValue=="3")
			$('#liRating').width('60%')
		else if(ratValue=="4")
			$('#liRating').width('80%')
		else
			$('#liRating').width('100%')

		$('#Reviews1_txtRateValidate').val(ratValue);
		$('#hdnRating').val(ratValue);
		
		//alert($('#Reviews1_txtRateValidate').val())
	}
	function fnReviewResponse(responseText)
	{
		if(responseText)
		{
		    $("#divLoading").html("");
		    $("#divMsg").text("Thank you for your review.It will be moderated and reflect in site");
		}
	}

	function readReview()
	{
		
				$("#divLoading").html("<img src='/includes/images/loading.gif'> Loading...Please Wait");
			
				var url = "readReview.EW2B?TYPE=READREVIEW&random="+new Date();
				jqueryAjaxPost('AddItemToCart',url,'action=change',fnReadReviewResponse)
	}

 function fnReadReviewResponse(responseText)
	{
		
			$("#divLoading").html("");
			$("#divReview").html(responseText);
		
	}    
  	function loadCriticalUpdates()
	{
		    var url = "CU.EW2B?TYPE=GETCRITICALUPDATES&random="+new Date(); 
    	    //  var myArguments = new Object();

			    //window.showModalDialog(url, myArguments , '');
			    getAjaxResponsefromURL(url,loadCriticalUpdatesResponse); 
			    
	}
	function loadCriticalUpdatesResponse()
	{
	    try
	    {
	        var content = http.responseText;
	        document.getElementById("divCriticalUpdates").innerHTML = content;
	        //var content=document.getElementById("content").innerHTML; 
            //var myWin=window.open('','myWin','menubar,scrollbars,left=30px,top=40px,height=400px,width=600px'); 
            //myWin.document.write(content);
            setTimeout('loadElement()',delay*1000); 
        }
        catch(e){}    
	}
		
   
function fnDelBannerAd(adId,imgName)
    {
    
       var url = "delBannerAd.EW2B?TYPE=DELETEBANNER&adId="+adId+"&imgName="+imgName+"&random="+new Date();
        document.getElementById("divLoading").innerHTML = "<img src='../admin/includes/images/loading.gif'> Loading...Please Wait";
        getAjaxResponsefromURL(url,delBannerResponse);
    }

function delBannerResponse()
{
     document.getElementById("divLoading").innerHTML = "";
    alert(http.responseText);
    window.location.reload();
}

function fnRemoveImg()
{
    document.getElementById("divImgView").innerHTML = "";
    document.getElementById("hdnImg").innerText = "Y";
}

 var arrPids= new Array();
function fnArrayPush(checkVal,pid)
{
  
   if(checkVal)
   {
    arrPids.push(pid);
   }
   else
   {
    arrPids.pop(pid);
   } 
   
 }
function fnSelectAll(checkVal)
{

    var table = document.getElementById("data_sortable")
               
         for (var i=1;i<table.rows.length;i++) 
         {
             var obj = table.rows[i].getElementsByTagName("input");
              objCntrl = obj(0);
              if(objCntrl.name.indexOf('chkProd') > -1)
                objCntrl.checked = checkVal;
              
         }
        
}

function checkSelected(obj)
{
    if(!obj.checked)
    {
        if(document.getElementById('chkAll').checked)
            document.getElementById('chkAll').checked = false;
    }
}

function fnDelProduct(pid)
{
   var url = "delProduct.EW2B?TYPE=DELETEPRODUCT&pid="+pid+"&random="+new Date();
   document.getElementById("divLoading").innerHTML = "<img src='../admin/includes/images/loading.gif'> Loading...Please Wait";
    getAjaxResponsefromURL(url,delProductResponse);
}



function delProductResponse()
{
     document.getElementById("divLoading").innerHTML = "";
    alert(http.responseText);
    window.location.reload();
}

function fnChangestatus(obj)
{
   if(arrPids!='')
  { 
    var url = "changestatus.EW2B?TYPE=CHANGESTATUS&statusId="+obj.value+"&pIds="+arrPids+"&random="+new Date();
     document.getElementById("divLoading").innerHTML = "<img src='../admin/includes/images/loading.gif'> Loading...Please Wait";
    getAjaxResponsefromURL(url,changeStatusResponse);
  }
  else
    {
        alert('Please select product to change the status');
        return false;
    }  
}
function changeStatusResponse()
{
    arrPids = new Array();
    document.getElementById("divLoading").innerHTML = "";
    alert(http.responseText);
    window.location.reload()
}

function fnBrowse(objCat)
{
	var catId=objCat.getAttribute("data_id");
	$('#hdnCatId').val(catId)
		document.getElementById("home").method = "post";
		document.getElementById("home").action="/control/browse";
		document.getElementById("home").submit();


}




function fnLogout() {
    var url = "addToCart.EW2B?TYPE=LOGOUT&random=" + new Date();
    jqueryAjaxPost('form[0]', url, 'action=cart', logoutResponse)
}
    function logoutResponse(responseText) {
        var chk = responseText;

        if (chk) {
            window.parent.location.href = "/control/home";
        }
    }

    function fnChngeCustomerStatus(objCustomer) {
        var id = objCustomer.getAttribute("datalist_id");
        
        var statusVal = objCustomer.innerText;
        var toggleHtml = "";
        var val = "";
        if (statusVal == "Active") {
            toggleHtml = "<a href='javascript:void(0)' datalist_id='" + id + "' onclick='javascript:fnChngeCustomerStatus(this)'>Inactive </a>"
            val = 0;
        }
        else {
            toggleHtml = "<a href='javascript:void(0)' datalist_id='" + id + "' onclick='javascript:fnChngeCustomerStatus(this)'>Active</a>"
            val = 1;
        }

        $("#divCust"+id).html(toggleHtml);
        var url = "addToCart.EW2B?TYPE=CUSTSTATUS&id=" + id + "&val=" + val + "&random=" + new Date();
        
        jqueryAjaxPost('form[0]', url, 'action=cart', chngeCustomerStatusResp)

    }

    function chngeCustomerStatusResp(respText, objCustomer) {
        if (!respText) {

            alert("Error occured when changing customer status!!!");
        }

    }

    function fnContinue()
    {
        window.parent.location.href="/control/home";
        //$.fancybox.close();
    }

    function toggleUser()
    {
        var radValues = document.getElementById("radUser").getElementsByTagName("input");
        var radValue="";
	
        for(var i=0;i<radValues.length;i++)
        {
            if(radValues[i].checked)
            {
                radValue=radValues[i].value;
                break;
            }
        }
        if(radValue=="E")
        {
            document.getElementById("divEUser").style.display='block';
            document.getElementById("divNUser").style.display='none';
        }
        else
        {
            document.getElementById("divEUser").style.display='none';
            document.getElementById("divNUser").style.display='block';

        }	
	

    }

    function jqueryAjaxPost(formId,url,data,loadHandler)
    {
        var dataString = data+"&"+$('#'+formId).serialize();

        $.ajax({

            url:url,
            type:"POST",
            data:dataString,
            cache:false,
            success:function(html)
            {
                loadHandler(html);
            }
        });
		
	
    }

    function fnViewDetails(pid)
    {
        var url = "../ViewProducts.aspx?pid="+pid
        window.open(url,"ViewProduct","height=500;width=500;toolbars=no,controlbox=no,status=yes,scrollbars=yes,resizable=yes");
    }

    var http;
    var isWorking = false;

    function getHTTPObject()
    {
        var xmlhttp;
    
        if(window.XMLHttpRequest)
        {
            xmlhttp = new XMLHttpRequest()
        }
        try
        {
            xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch(e){
            
            try{
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch(ee){
                xmlhttp = null;
            }
                
        }
        
        if(!xmlhttp && typeof XMLHttpRequest != 'undefined'){
            xmlhttp = new XMLHttpRequest();
        }
        
        return xmlhttp;
    }

    function getAjaxResponsefromURL(url , loadHandler)
    {
        http = getHTTPObject();
        if(! isWorking && http){
        
            http.open("GET",url,true);
            http.onreadystatechange = function(){
                if(http.readystate == 4 && http.status == 200 ){
                    loadHandler(http.responseText);
                }
                isWorking = false;
            };
            isWorking = true;
            http.send(null);
        }
    }


    var delay = "2";  //############# How long before window appears (seconds)
    var winw = "400"; //############# How wide should your window be (pixels)
    var winh = "300"; //############# How tall should the window be (pixels)
    var repeat = "1"; //Do you want visitor to be able to re-open window after closing?


    //############# published at: scripts.tropicalpcsolutions.com


    var ie=(document.all);
    var ns=(document.layers);
    var ns6=(document.getElementById && !ie);
    var calculate=ns? "" : "px"

    function loadElement(){
        if(!ns && !ie && !ns6) return;
        if(ie) popup=eval('document.all.elementDiv.style');
        else if(ns) popup=eval('document.layers["elementDiv"]');
        else if(ns6) popup=eval('document.getElementById("elementDiv").style');
        if (ie||ns6) popup.visibility="visible";
        else popup.visibility ="show";
        displayElement()
    }

    function displayElement(){
        var agent=navigator.userAgent.toLowerCase();
        if (ie){
            documentWidth = (centerElement().offsetWidth)/2+centerElement().scrollLeft-(winw/2);
            documentHeight = (centerElement().offsetHeight)/2+centerElement().scrollTop-(winh/2);
        }
        else if (ns){
            documentWidth=window.innerWidth/2+window.pageXOffset-(winw/2);
            documentHeight=window.innerHeight/2+window.pageYOffset-(winh/2);
        }
        else if (ns6){
            documentWidth=self.innerWidth/2+window.pageXOffset-(winw/2);
            documentHeight=self.innerHeight/2+window.pageYOffset-(winh/2);
        }
        popup.left = documentWidth+calculate;
        popup.top = documentHeight+calculate;
        setTimeout("displayElement()",100);
    }

    function centerElement(){
        return (document.compatMode && document.compatMode!="BackCompat")? document.documentElement : document.body
    }

    function closeElement(){
        if (ie||ns6) { popup.display="none"; } 
        else { popup.visibility ="hide"; }
        if (repeat == 1) { location.replace; }
    }
    

