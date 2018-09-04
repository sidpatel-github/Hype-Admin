<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="banner.aspx.cs" Inherits="banner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"><asp:Label style="margin-left: 40px" ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div>
    
        <div style="margin-left: 40px"><br/><br/>
    
        <asp:HiddenField ID="HiddenField1" runat="server"  Value="insert" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
     <table style="width:1095px; height: 454px;">
            <tr>
                
                <td class="style4" style="width: 273px; height: 23px;" dir="ltr" >
                    banner type :</td>
                <td class="modal-lg" style="width: 274px; height: 23px;" dir="ltr" >
    
        
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    
        
                </td>
                <td class="style1" dir="ltr" style="height: 23px; width: 274px" >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="please enter banner type" Font-Bold="True" Font-Italic="False" ForeColor="Red" ControlToValidate="TextBox4" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td dir="ltr" style="height: 23px"  >
                    image upload :</td>
                <td style="width: 274px; height: 23px;" dir="ltr" >
        <asp:FileUpload ID="FileUpload1" runat="server"  />
                </td>
                <td dir="ltr" style="height: 23px; width: 274px" >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FileUpload1" ErrorMessage="please upload file" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
        &nbsp;<asp:Label ID="Label4" Font-Bold="True" Font-Italic="True" ForeColor="Red" runat="server"></asp:Label>
                </td>
            </tr>
           
            
            <tr>
                <td class="style4" style="width: 273px; height: 24px;" dir="ltr" >
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="submit" />
    
                </td>
                <td class="modal-lg" style="width: 274px; height: 24px;" dir="ltr" >
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Cancel" />
    
                </td>
                <td class="style1" dir="ltr" style="height: 24px; width: 274px" >
                    </td>
            </tr>
            <tr>
                <td class="style3" colspan="3" style="height: 24px" >
                    &nbsp;</td>
                <td class="style3" style="height: 24px; width: 274px" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3" style="height: 24px" >
    
                </td>
                <td class="style3" style="width: 274px; height: 24px" >
    
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="3" style="height: 24px" >
                    &nbsp;</td>
                <td class="style3" style="height: 24px; width: 274px" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="4" style="height: 190px" ><div class="CSSTableGenerator">
        <asp:GridView ID="GridView1" runat="server"  OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
                </td>
            </tr></table>
    
        <br />
    
    </div>
        <br />
</asp:Content>

