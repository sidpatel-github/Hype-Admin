<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="state.aspx.cs" Inherits="state" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"><asp:Label style="margin-left: 40px" ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     <div style="margin-left: 40px"><div style="margin-right: 40px"><br/><br/>
    
        <asp:HiddenField ID="HiddenField1" Value="insert" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />

         <table style="width:1000px; height: 66px;">
            <tr>
                <td style="height: 26px"  >
                    STATE :</td>
                <td style="height: 26px" >
        <asp:TextBox ID="TextBox1" runat="server" Height="19px" Width="130px"></asp:TextBox>
                </td>
                <td style="width: 274px; height: 26px" >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="please enter state" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
        
                </td>
                <td rowspan="2" style="height: 40px; width: 274px" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" style="width: 273px; height: 22px;" >
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ADD STATE" />
                </td>
                <td class="modal-lg" style="width: 274px; height: 22px;" >
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                        Text="Cancel" />
                </td>
                <td class="style1" style="width: 274px; height: 22px" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" style="width: 273px; height: 22px;" >
                    &nbsp;</td>
                <td class="modal-lg" style="width: 274px; height: 22px;" >
                    &nbsp;</td>
                <td class="style1" style="width: 274px; height: 22px" >
                    &nbsp;</td>
                <td class="style1" style="height: 22px; width: 274px" >
                    &nbsp;</td>
            </tr>
            </table>
         <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1"><div class="CSSTableGenerator">
        <asp:GridView ID="GridView1" runat="server" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
            <Columns>
                <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    
                </td>
            </tr>
            </table><br/><br/>
            </div >
 

</asp:Content>

