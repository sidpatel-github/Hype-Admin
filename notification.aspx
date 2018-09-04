<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="notification.aspx.cs" Inherits="notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"><asp:Label style="margin-left: 40px" ID="Label2" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
      <title></title>
    <style type="text/css">
        .style1
        {
            width: 1152px;
        }
        .style2
        {
            width: 985px;
        }
        .style3
        {
            width: 265px;
        }
        .style4
        {
            width: 265px;
            height: 26px;
        }
        .style5
        {
            width: 985px;
            height: 26px;
        }
        .style8
        {
            width: 265px;
            height: 24px;
        }
        .style9
        {
            width: 985px;
            height: 24px;
        }
        .style10
        {
            width: 265px;
            height: 25px;
        }
        .style11
        {
            width: 985px;
            height: 25px;
        }
        .style12
        {
            width: 265px;
            height: 29px;
        }
        .style13
        {
            width: 985px;
            height: 29px;
        }
    </style>

    
   <div style="margin-left: 40px"><div style="margin-right: 40px"><br/><br/>
    <asp:HiddenField ID="HiddenField1" runat="server" onvaluechanged="HiddenField1_ValueChanged" />
        <table style="width:100%;">
            <tr>
                <td class="style8">
                    MESSAGE :</td>
                <td class="style9">
                    <textarea id="TextArea1" runat="server"  cols="35" name="S2" rows="1" placeholder="max 100 char..." ></textarea><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="please enter message" Font-Bold="True" Font-Italic="False" ForeColor="Red" ControlToValidate="TextArea1"></asp:RequiredFieldValidator>
                       
                </td>
            </tr>
            <tr>
                <td class="style4">
                    SEND TO :</td>
                <td class="style5">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="268px">
                                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    FROM :</td>
                <td class="style5">
                    ADMIN</td>
            </tr>
            <tr>
                <td class="style4">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="SEND" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Text="CANCEL" />
                </td>
                <td class="style5">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style12">
                    SHOW CLIENT :</td>
                <td class="style13">
                    <asp:DropDownList ID="DropDownList2" Height="22px" Width="268px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"    >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    SHOW MESSAGE :</td>
                <td class="style11">
                    <textarea id="TextArea2" runat="server" Height="22px" Width="268px" cols="35" name="S1" rows="1"></textarea></td>
            </tr>
            <tr>
                <td class="style4">
                    READ UNREAD:</td>
                <td class="style5">
                    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true" Height="22px" Width="268px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" >
                        <asp:ListItem Value="0">all</asp:ListItem>
                        <asp:ListItem Value="1">unread</asp:ListItem>
                        <asp:ListItem Value="2">read</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Button ID="Button5" runat="server" onclick="Button5_Click" Text="REFRESH" />
                    &nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td class="style5">
                    </td>
            </tr>
            <tr>
                <td class="style1" colspan="2"><div class="CSSTableGenerator">
                    <asp:GridView ID="GridView1" runat="server" OnRowDeleting="GridView1_RowDeleting"
                     OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                        onselectedindexchanged="GridView1_SelectedIndexChanged">
                    <Columns>
                             <asp:CommandField SelectText="View" ShowSelectButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView></div>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            </table>
    
    </div>
</asp:Content>

