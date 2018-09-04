<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"><asp:Label style="margin-left: 40px" ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    
   <div style="margin-left: 40px"><div style="margin-right: 40px"><br/><br/>
        <p style="margin-left: 1px">
            WORKER REGISTRATION<br />
        </p>
        <asp:HiddenField ID="HiddenField1" Value="insert" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <table style="width:100%;">
            <tr>
                <td class="style1" style="width: 253px; height: 25px;">
                    NAME :</td>
                <td class="style2" style="height: 25px">
                    <asp:TextBox ID="TextBox1" runat="server" Width="268px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="please enter name" Font-Bold="True" Font-Italic="False" ForeColor="Red" ControlToValidate="TextBox1" ></asp:RequiredFieldValidator>
                   
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 253px; height: 25px;">
                    USERNAME :</td>
                <td class="style2">
                    <asp:TextBox ID="TextBox2" runat="server" Width="268px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="please enter username" Font-Bold="True" Font-Italic="False" ForeColor="Red" ControlToValidate="TextBox2" ></asp:RequiredFieldValidator>
 
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 253px; height: 25px;">
                    PASSWORD :</td>
                <td class="style2">
                    <asp:TextBox ID="TextBox3" runat="server" Width="268px" TextMode="Password" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="please enter password" Font-Bold="True" Font-Italic="False" ForeColor="Red" ControlToValidate="TextBox3" ></asp:RequiredFieldValidator>
                    &nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TextBox3" runat="server" ErrorMessage="length min 6" ValidationExpression="\w{6,20}" Font-Bold="True" Font-Italic="False" ForeColor="Red" ></asp:RegularExpressionValidator>
 
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 253px; height: 25px;">
                    CONFIRM PASSWORD :</td>
                <td class="style2">
                    <asp:TextBox ID="TextBox4" runat="server" Width="268px" TextMode="Password" 
                        ></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" ControlToValidate="Textbox4" runat="server" ErrorMessage="confirm password do not match" ControlToCompare="TextBox3" Font-Bold="True" Font-Italic="False" ForeColor="Red" ></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 253px; height: 25px;">
                    EMAIL :</td>
                <td class="style2">
                    <asp:TextBox ID="TextBox7" runat="server" Width="268px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox7"  ErrorMessage="enter the email" Font-Bold="True" Font-Italic="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    &nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox7"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email in proper" Font-Bold="True" Font-Italic="False" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 253px ; height: 25px;">
                    ADDRESS :</td>
                <td class="style2">
                    <asp:TextBox ID="TextBox5" runat="server" Width="268px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="please enter address" Font-Bold="True" Font-Italic="False" ForeColor="Red" ControlToValidate="TextBox5" ></asp:RequiredFieldValidator>
 
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 253px; height: 25px;" >
                    PHONE NO :</td>
                <td class="style2">
                    <asp:TextBox ID="TextBox6" runat="server" Width="268px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="please enter phone no" Font-Bold="True" Font-Italic="False" ForeColor="Red" ControlToValidate="TextBox6" ></asp:RequiredFieldValidator>
                    &nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox6"  ValidationExpression="\w{10}" ErrorMessage="please enter 10 number" Font-Bold="True" Font-Italic="False" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 253px">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Button ID="Button1" runat="server" Text="REGISTER" 
                        onclick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="CANCEL" Width="98px"  onclick="Button2_Click"  />
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 253px">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 253px">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 253px">
                    LIST OF WORKER :</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="2">   <div class="CSSTableGenerator" >
                    <asp:GridView ID="GridView3" runat="server"  OnRowDeleting="GridView3_RowDeleting"
                     OnSelectedIndexChanging="GridView3_SelectedIndexChanging"
                        onselectedindexchanged="GridView3_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <br />
        
        <br />
    
    </div>
    
</asp:Content>

