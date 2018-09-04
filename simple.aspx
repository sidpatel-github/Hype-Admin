<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="simple.aspx.cs" Inherits="simple" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"><asp:Label style="margin-left: 40px" ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<link href="css/style2.css" rel="stylesheet" type="text/css" media="all"/>
<link href="css/slider.css" rel="stylesheet" type="text/css" media="all"/>
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/jquery.easing.1.3.js"></script> 
<script type="text/javascript" src="js/camera.min.js"></script> 
<link href='http://fonts.googleapis.com/css?family=Baumans' rel='stylesheet' type='text/css'>
   <script>
       jQuery(function () {

           jQuery('#camera_wrap_1').camera({
               thumbnails: true
           });
       });
	</script>
					    <div class="slider">						    								     
								 <div class="fluid_container">
									        <div class="camera_wrap camera_azure_skin" id="camera_wrap_1" style="margin-bottom:0px">
									            <div data-thumb="img/thumbnails/a.jpg" data-src="img/a.jpg">   </div>
									            <div data-thumb="img/thumbnails/aa.jpg" data-src="img/aa.jpg">  </div>
									            <div data-thumb="img/thumbnails/aaa.jpg" data-src="img/aaa.jpg">   </div>
									            <div data-thumb="img/thumbnails/aaaa.jpg" data-src="img/aaaa.jpg">  </div>
                                                <div data-thumb="img/thumbnails/aaaaa.jpg" data-src="img/aaaaa.jpg">   </div>
									            <div data-thumb="img/thumbnails/aaaaaa.jpg" data-src="img/aaaaaa.jpg">  </div>
									            <div data-thumb="img/thumbnails/aaaaaaa.jpg" data-src="img/aaaaaaa.jpg">   </div>
									            <div data-thumb="img/thumbnails/aaaaaaaa.jpg" data-src="img/aaaaaaaa.jpg">  </div>
                                                <div data-thumb="img/thumbnails/aaaaaaaaa.jpg" data-src="img/aaaaaaaaa.jpg">   </div>
									            <div data-thumb="img/thumbnails/aaaaaaaaaa.jpg" data-src="img/aaaaaaaaaa.jpg">  </div>
									        </div>
					    	   			</div>
					    	    <div class="clear"></div><br />
                                <br />					       
					    	</div>
  								
 

</asp:Content>

