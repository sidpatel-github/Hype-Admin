<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="area.aspx.cs" Inherits="area" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<asp:Label style="margin-left: 40px" ID="Label5" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style="margin-left: 40px"><div style="margin-right: 40px"><br/><br/>
    
        <asp:HiddenField ID="HiddenField1" runat="server"  Value="insert" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
     <table style="width:1095px; height: 454px;">
            <tr>
                <td dir="ltr" style="height: 26px"  >
        <asp:Label ID="Label1" runat="server" Text="area name"></asp:Label>
    
    &nbsp;:</td>
                <td style="width: 291px; height: 26px;" dir="ltr" >
        <asp:TextBox ID="TextBox1" Width="268px" runat="server"></asp:TextBox>
                </td>
                <td dir="ltr" style="height: 26px; width: 268px" >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox1" ErrorMessage="please enter area name" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
        
                </td>
                <td rowspan="10" style="width: 268px" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" style="width: 273px; height: 26px;" dir="ltr" >
    
        <asp:Label ID="Label2" runat="server" Text="state"></asp:Label>
    
                &nbsp;:</td>
                <td class="modal-lg" style="width: 291px; height: 26px;" dir="ltr" >
        <asp:DropDownList ID="DropDownList1" runat="server" 
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  
                        AutoPostBack ="True" Height="22px" Width="268px">
        </asp:DropDownList>
                </td>
                <td class="style1" dir="ltr" style="height: 26px; width: 268px" >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownList1" ErrorMessage="please select state" Font-Bold="True" Font-Italic="True" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td dir="ltr" style="height: 26px"  >
    
        <asp:Label ID="Label3" runat="server" Text="city"></asp:Label>
    
                &nbsp;:</td>
                <td style="width: 291px; height: 26px;" dir="ltr" >
    
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Height="22px" Width="268px">
        </asp:DropDownList>
                </td>
                <td dir="ltr" style="height: 26px; width: 268px" >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList2" ErrorMessage="please select city" Font-Bold="True" Font-Italic="true" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 273px; height: 27px;" dir="ltr" >
                    banner type :</td>
                <td class="modal-lg" style="width: 291px; height: 27px;" dir="ltr" >
    
        <asp:DropDownList ID="DropDownList3" runat="server" Height="22px" Width="268px">
        </asp:DropDownList>
                </td>
                <td class="style1" dir="ltr" style="height: 27px; width: 274px" >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="please select banner type" Font-Bold="True" Font-Italic="true" ForeColor="Red" ControlToValidate="DropDownList3" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td dir="ltr" style="height: 26px"  >
                    image upload :</td>
                <td style="width: 291px; height: 26px;" dir="ltr" >
        <asp:FileUpload ID="FileUpload1" runat="server"  />
                </td>
                <td dir="ltr" style="height: 26px; width: 268px" >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FileUpload1" ErrorMessage="please upload file" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
        &nbsp;<asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 273px; height: 26px;" dir="ltr" >
                    latitude :</td>
                <td class="modal-lg" style="width: 291px; height: 26px;" dir="ltr" >
        <asp:TextBox ID="TextBox3" Width="268px" runat="server"></asp:TextBox>
                </td>
                <td class="style1" dir="ltr" style="height: 26px; width: 268px" >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox3" ErrorMessage="please enter latitude" Font-Bold="True" Font-Italic="True"  ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td dir="ltr" style="height: 26px"  >
                    longitude :</td>
                <td style="width: 291px; height: 26px;" dir="ltr" >
        <asp:TextBox ID="TextBox2" Width="268px" runat="server"></asp:TextBox>
                </td>
                <td dir="ltr" style="height: 26px; width: 268px" >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox2" ErrorMessage="please enter longitude" Font-Bold="True" Font-Italic="True"  ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 268px; height: 26px;" dir="ltr" >
                    banner
                    size :</td>
                <td class="modal-lg" style="width: 291px; height: 26px;" dir="ltr" >
        <asp:TextBox ID="TextBox4" runat="server" Height="22px" Width="268px"></asp:TextBox>
                </td>
                <td class="style1" dir="ltr" style="height: 26px; width: 268px" >
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox4" ErrorMessage="please enter size" Font-Bold="True" Font-Italic="True"  ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 273px; height: 26px;" dir="ltr" >
                    price:</td>
                <td class="modal-lg" style="width: 291px; height: 26px;" dir="ltr" >
                    <asp:TextBox ID="TextBox5" Width="268px" runat="server"></asp:TextBox>
                </td>
                <td class="style1" dir="ltr" style="height: 26px; width: 274px" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox5" Font-Bold="True" Font-Italic="True"  ErrorMessage="please enter price" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4" style="width: 273px; height: 27px;" dir="ltr" >
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="submit" />
    
                </td>
                <td class="modal-lg" style="width: 291px; height: 27px;" dir="ltr" >
        &nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Cancel" />
    
                </td>
                <td class="style1" dir="ltr" style="height: 27px; width: 274px" >
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
        <asp:GridView ID="GridView1" runat="server"  OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
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

