<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<section class="page_title">		
			<h1 class="title">Contact Us</h1>
	</section>
	<!--  end page title  -->


	<!--  start contact info section  -->
	<section class="contact_info clearfix">
		<div class="wrapper">
			<h2 class="email">hypescet@gmail.com</h2>
			<h2 class="adress">HYPE SCET<br/>SURAT GUJARAT -395001</h2>
			<h2 class="phone">(+0261) 259854</h2>
		</div>
	</section>
	<!--  end contact info section  -->


	<!--  start form section  -->
	<section class="contact_form">
		<div class="wrapper">			
			<h2 class="title">Send Us a Message</h2>
			  <!-- Bootstrap -->
        <link rel="stylesheet" media="screen" href="css/bootstrap.min.css">
        <link rel="stylesheet" media="screen" href="css/bootstrap-theme.min.css">

        <!-- Bootstrap Admin Theme -->
        <link rel="stylesheet" media="screen" href="css/bootstrap-admin-theme.css">

        <!-- Custom styles -->
        <style type="text/css">
            .alert{
                margin: 0 auto 00px;
                             
            }
        </style>
    
        <div class="container" >
            <div class="row">
                <div class="col-lg-12" style="padding-left:420px">
                    <form method="post" action="contact.aspx" class="bootstrap-admin-login-form">
                        
                        <div class="form-group">
                            <asp:TextBox ID="TextBox1" runat="server" class="form-control" style="width:250px" type="text" name="name" placeholder="Name"></asp:TextBox>
                        <div>   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="enter name" ControlToValidate="TextBox1" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                       </div> 
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="TextBox2" runat="server" class="form-control"  style="width:250px" type="text" name="email" placeholder="Email"></asp:TextBox>
                        <div>   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="enter email" ControlToValidate="TextBox2" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>&nbsp;
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email not proper" Font-Bold="True" Font-Italic="False" ForeColor="Red"></asp:RegularExpressionValidator>

                       </div> 
                        </div>
                   <div class="form-group">
                            <asp:TextBox ID="TextBox3" runat="server" class="form-control" style="width:250px" type="text" name="summary" placeholder="Summary"></asp:TextBox>
                        <div>   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="enter summary" ControlToValidate="TextBox3" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                       </div> 
                        </div>
                        <div class="form-group">
                            <Textarea id="TextArea1" rows="2" cols="20" runat="server" class="form-control"  style="width:250px" type="text" name="description" placeholder="Description"></Textarea>
                        <div>   <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  runat="server" ErrorMessage="enter discription" ControlToValidate="TextArea1" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                       </div> 
                        </div>
                        <asp:Button class="btn btn-lg btn-primary" ID="Button1" runat="server" Text="submit" onclick="Button1_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        <asp:Button class="btn btn-lg btn-primary" ID="Button2" runat="server" Text="cancel" onclick="Button2_Click" />

                        <br /><br />
                    </form>
                </div>
            </div>
        </div>

        
        

	</section>
	<!--  end form section  -->

</asp:Content>

