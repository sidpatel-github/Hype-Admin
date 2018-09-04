<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="city.aspx.cs" Inherits="city" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"><asp:Label style="margin-left: 40px" ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
td img
{
    width:50px;
    height:50px;
}
    .style3
    {
        width: 1095px;
        height: 302px;
    }
    .style6
    {
        height: 64px;
    }
    .style12
    {
        width: 316px;
        height: 190px;
    }
    .style13
    {
        height: 25px;
    }
    .style20
    {
        width: 274px;
        height: 22px;
    }
    .style21
    {
        height: 25px;
        width: 273px;
    }
    .style22
    {
        width: 291px;
        height: 22px;
    }
    .style23
    {
        width: 274px;
        height: 25px;
    }
    .style24
    {
        height: 26px;
        width: 273px;
    }
    .style25
    {
        width: 274px;
        height: 26px;
    }
</style>
   <div style="margin-left: 40px"><div style="margin-right: 40px"><br/><br/>
    
        <asp:HiddenField ID="HiddenField1" runat="server" Value="insert" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
         <table class="style3">
            <tr>
                <td class="style13"  >
                    CITY :</td>
                <td class="style13" >
                    <asp:TextBox ID="TextBox1" runat="server" Width="175px" ></asp:TextBox>
                </td>
                <td class="style23" >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="please enter city" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
        
                </td>
                <td class="style6" rowspan="3" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style24" >
                    STATE :</td>
                <td class="style25" >
        <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="175px">
        </asp:DropDownList>
                </td>
                <td class="style25" >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList1" ErrorMessage="please select state" Font-Bold="True" Font-Italic="True" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style21" >
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="INSERT" />
                </td>
                <td class="style23" >
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Cancel" />
                </td>
                <td class="style23" >
                    </td>
            </tr>
            <tr>
                <td class="style22" colspan="3" >
                    &nbsp;</td>
                <td class="style20" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style22" colspan="3" >
                    &nbsp;</td>
                <td class="style20" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style12" colspan="4" ><div class="CSSTableGenerator">
        <asp:GridView ID="GridView1" runat="server" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
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


</asp:Content>

