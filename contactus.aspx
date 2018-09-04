<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="contactus.aspx.cs" Inherits="contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"><asp:Label style="margin-left: 40px" ID="Label5" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 846px;
        }
        .style3
        {
        }
        .style4
        {
            width: 280px;
        }
        .style6
     {
         width: 280px;
         height: 27px;
     }
     .style7
     {
         width: 645px;
         height: 27px;
     }
     .style8
     {
         width: 645px
     }
    </style>
<div style="margin-left: 40px"><div style="margin-right: 40px"><br/><br/>
        <p style="margin-left: 1px">
            CONTACT OF HOARDING <br />
        </p>
        <asp:HiddenField ID="HiddenField1" Value="insert" runat="server" onvaluechanged="HiddenField1_ValueChanged" />
        <table style="width:100%;">
            <tr>
                <td class="style3" colspan="2">
                    LIST OF 
                    CONTACT CUSTOMER FOR HOARDING :</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    <asp:Label ID="Label1" runat="server" Text="SENT TO :"></asp:Label>
                </td>
                <td class="style7">
                    <asp:TextBox ID="TextBox1" Width="268px" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="please enter reciver" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="style2" rowspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    <asp:Label ID="Label2" runat="server" Text="FROM :"></asp:Label>

                </td>
                <td class="style7">
                    <asp:TextBox ID="TextBox2" Width="268px" runat="server" Text="hypescet@gmail.com" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    <asp:Label ID="Label3" runat="server" Text="SUBJECT :"></asp:Label>
                     </td>
                <td class="style7">
                    <asp:TextBox ID="TextBox3" Width="268px" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="please enter subject" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
               
                </td>
            </tr>
            <tr>
                <td class="style6">
                    <asp:Label ID="Label4" runat="server" Text="BODY :"></asp:Label>
                </td>
                <td class="style7">
                    <asp:TextBox ID="TextBox4" Width="268px" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="please enter body" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
               
                </td>
            </tr>
            <tr>
                <td class="style6">
                    <asp:Button ID="SEND" runat="server" onclick="Button1_Click" Text="send" />
                </td>
                <td class="style7">
                    <asp:Button ID="CANCEL" runat="server" Text="cancel" onclick="Button2_Click" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="3">
                   
                        <div class="CSSTableGenerator">
                    
                        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                        onselectedindexchanged="GridView1_SelectedIndexChanged" 
                                OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand" 
                                onrowdatabound="GridView1_RowDataBound">
                        
                         <Columns>
                            <asp:CommandField SelectText="TALK" ShowSelectButton="True" />
                             <asp:CommandField ShowDeleteButton="True" ButtonType="button"/>
                            </Columns></asp:GridView></div>
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                  
                    
                    &nbsp;</td>
                <td class="style1">
                  
                    
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                  
                    
                    &nbsp;</td>
                <td class="style1">
                  
                    
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        
        <br />
    
    </div>
</asp:Content>

