<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<link href="css/style2.css" rel="stylesheet" type="text/css" media="all"/>
<link href="css/slider.css" rel="stylesheet" type="text/css" media="all"/>
<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="js/jquery.easing.1.3.js"></script> 
<script type="text/javascript" src="js/camera.min.js"></script> 

	<section class="page_title">		
			<h1 class="title">About HYPE</h1>
	</section>
	<!--  end page title  -->
    
    <script>
        jQuery(function () {

            jQuery('#camera_wrap_1').camera({
                thumbnails: true
            });
        });
	</script>
	<script>
	    jQuery(function () {

	        jQuery('#camera_wrap_2').camera({
	            thumbnails: true
	        });
	    });
	</script>
	
    <!--  start about section  -->
	<section class="about clearfix">
		<div class="wrapper">
			<p class="intro">The Goal of Hype is to provide results-oriented advertising, public relations, and marketing designed to meet our clients objectives by providing strong marketing concepts and excelling at customer service.We seek to become a marketing partner with our clients.We desire to measure success for our clients through awareness, increased sales, or other criteria mutually agreed upon between the agency and the clients.We are committed to maintaining a rewarding environment in which we can accomplish our Goal.</p>

			<div class="columns clearfix">
				<div class="col_1 col_left">
					<h2>OUR CUSTOMER.</h2>
                    
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
					    	    <br />
                                <br />					       
					    	</div>
					<p>Our valuable client are client1, client2, client3, client4, client5, client6, client7, client8 </p>
				</div>
                
				<div class="columns clearfix">
				<div class="col_1 col_right">
					<h2>OUR BANNER.</h2>
                    <div class="slider">						    								     
								 <div class="fluid_container">
									        <div class="camera_wrap camera_azure_skin" id="camera_wrap_2" style="margin-bottom:0px">
									            <div data-thumb="img/thumbnails/hoarding.jpg" data-src="img/hoarding.jpg">  </div>
                                                <div data-thumb="img/thumbnails/kioskchowpaty.jpg" data-src="img/kioskchowpaty.jpg">  </div>
                                                <div data-thumb="img/thumbnails/footoverbridge.jpg" data-src="img/footoverbridge.jpg">  </div>
                                                <div data-thumb="img/thumbnails/gantry.jpg" data-src="img/gantry.jpg">   </div>
                                                <div data-thumb="img/thumbnails/bqschowpaty.jpg" data-src="img/bqschowpaty.jpg">   </div>
                                                <div data-thumb="img/thumbnails/bus.jpg" data-src="img/bus.jpg">   </div>
                                                <div data-thumb="img/thumbnails/mobilevan.jpg" data-src="img/mobilevan.jpg">  </div>
                                                <div data-thumb="img/thumbnails/lediscon.jpg" data-src="img/lediscon.jpg">   </div>
									            
                                        </div>
					    	   			</div>
									 
					    	    <br />
                                <br />					       
					    	
					<p> We provide different type of banner such as hoarding, kiosh, fob, gantry, Bus Queue Shelters, Bus Branding, Mobile Vans, LED Screen .</p>
				</div>
			</div>
		</div>
       
	</section>
	<!--  end about section  -->


    	<!--  start team section  -->
	<section class="team">
		<div class="wrapper clearfix">			
			<h2 class="title">Our Team</h2>
			<ul>
				
				<li>
					<div class="team_pic">
						<img src="img/user.png" alt="" title=""/>
					</div>
					<h3 class="team_name">Harekrushna Goyani</h3>
					<h4 class="team_job">Developer</h4>
				</li>
				<li>
					<div class="team_pic">
						<img src="img/user.png" alt="" title=""/>
					</div>
					<h3 class="team_name">Siddharth Patel</h3>
					<h4 class="team_job">Developer</h4>
				</li>
                <li>
					<div class="team_pic">
						<img src="img/user.png" alt="" title=""/>
					</div>
					<h3 class="team_name">Shubham Patel</h3>
					<h4 class="team_job">Developer</h4>
				</li>
				<li>
					<div class="team_pic">
						<img src="img/user.png" alt="" title=""/>
					</div>
					<h3 class="team_name">Arpit Modi</h3>
					<h4 class="team_job">Developer</h4>
				</li>



			</ul>
		</div>
	</section>
	<!--  end team section  -->

    	<section class="cta">
		<h4>Geady to talk business!</h4>
		<a href="https://play.google.com/store/apps/details?id=com.hype" class="cta_btn">Get In Touch download app <img src="img/cta_arrow.png" alt="" title="" class="cta_arrow"/></a>
	</section>
	<!--  end call to action section  -->


</asp:Content>

