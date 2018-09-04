<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
 <%@ OutputCache Location="None" NoStore="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                   <center>
        <!-- Bootstrap -->
       
        <link rel="stylesheet" media="screen" href="css/bootstrap.min.css">
        <link rel="stylesheet" media="screen" href="css/bootstrap-theme.min.css">

        <!-- Bootstrap Admin Theme -->
        <link rel="stylesheet" media="screen" href="css/bootstrap-admin-theme.css">

        <!-- Custom styles -->
        <style type="text/css">
            .alert{
                margin: 0 auto 20px;
                             
                             
            }
        </style>

        <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!--[if lt IE 9]>
           <script type="text/javascript" src="js/html5shiv.js"></script>
           <script type="text/javascript" src="js/respond.min.js"></script>
        <![endif]-->
    </head>
   
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <form method="post" action="about.aspx" class="bootstrap-admin-login-form">
                        <h1>Login</h1>
                        <div class="form-group">
                            <asp:TextBox ID="TextBox1" runat="server" class="form-control" style="width:250px" type="text" name="email" placeholder="Username"></asp:TextBox>
                         <div>   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="enter username" ControlToValidate="TextBox1" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                       </div> </div>
                        <div class="form-group">
                            <asp:TextBox ID="TextBox2" runat="server" class="form-control"  style="width:250px" type="password" name="password" placeholder="Password"></asp:TextBox>
                        <div>   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="enter password" ControlToValidate="TextBox2" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                       </div>
                        </div>
                    <asp:Button class="btn btn-lg btn-primary" ID="Button1" 
                            runat="server" Text="SUBMIT" onclick="Button1_Click" />
                        <label class="checkbox">
		                <span class="pull-right" ><br />
		                    <a data-toggle="modal" href="ForgotPassword.aspx#myModal" style="margin-right:510px"> Forgot Password?</a>
		                </span>
		            </label>
                        <br />
                       <!-- Modal -->
		          <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                      <div class="modal-header">
		                          <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
		                          <h4 class="modal-title">Forgot Password ?</h4>
		                      </div>
		                      <div class="modal-body">
		                          <p>Enter your e-mail address below to reset your password.</p>

                                   <asp:TextBox class="form-control" ID="TextBox3" runat="server" 
                      placeholder="Enter Your Email" Width="300px"></asp:TextBox>
                      
                      <!--<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Your Email" ControlToValidate="TextBox3"></asp:RequiredFieldValidator> <br>-->
		         
		                       <!--   <input type="text" name="email" placeholder="Email" autocomplete="off" class="form-control placeholder-no-fix">-->
		
		                      </div>
		                      <div class="modal-footer">
                              <asp:Button class="btn btn-theme btn-block" 
                        ID="Button3" runat="server" Text="Submit" style="margin-left:180px" Width="200" onclick="Button3_Click" />
		                          <asp:Button class="btn btn-theme btn-block" 
                        ID="Button2" runat="server" Text="Cancel" style="margin-left:180px" Width="200"  onclick="Button2_Click" />
                          
		                         
                    
		                      </div>
		                  </div>
		              </div>
		          </div>
		          <!-- modal -->
                    </form>
                </div>
            </div>
        </div>

        <script type="text/javascript" src="http://code.jquery.com/jquery-2.0.3.min.js"></script>
        <script type="text/javascript" src="js/bootstrap.min.js"></script>
        <script type="text/javascript">
            $(function () {
                // Setting focus
                $('input[name="email"]').focus();

                // Setting width of the alert box
                var alert = $('.alert');
                var formWidth = $('.bootstrap-admin-login-form').innerWidth();
                var alertPadding = parseInt($('.alert').css('padding'));

                if (isNaN(alertPadding)) {
                    alertPadding = parseInt($(alert).css('padding-left'));
                }

                $('.alert').width(formWidth - 2 * alertPadding);
            });
        </script>

        </center>
</asp:Content>

