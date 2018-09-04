<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="feedback.aspx.cs" Inherits="feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"><asp:Label style="margin-left: 40px" ID="Label6" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div style="margin-left: 40px"><div style="margin-right: 40px"><br/><br/>
        <p style="margin-left: 1px">
            FEEDBACK OF HOARDING <br />
        </p>
  
          <div>
          
            <table style="width: 415px; height: 194px; margin-right: 123px; ">
                <tr>
                    <td dir="ltr" style="height: 27px; width: 526px;">
                        <asp:Label ID="Label1" runat="server" Text="SELECT STATE"></asp:Label>
                        &nbsp;:</td>
                    <td style="width: 281px; height: 27px;" dir="ltr">
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" 
                            Height="26px" Width="253px"></asp:DropDownList>
                    </td>

                    <td style="width: 281px; height: 27px;" dir="ltr">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="please select state" Font-Bold="True" Font-Italic="True" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td dir="ltr" style="height: 27px; width: 526px;">
                        <asp:Label ID="Label2" runat="server" Text="SELECT CITY"></asp:Label>
                        &nbsp;:</td>
                    <td style="width: 281px; height: 27px;" dir="ltr">
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                            OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Height="26px" 
                            Width="253px"></asp:DropDownList>
                    </td>
                    <td style="width: 281px; height: 27px;" dir="ltr">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList2" ErrorMessage="please select city" Font-Bold="True" Font-Italic="False" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td style="text-align: center; height: 27px;" colspan="2">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                            RepeatDirection="Horizontal" Width="389px" 
                            OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" 
                            AutoPostBack="True" Height="19px">
                            <asp:ListItem Selected="True">BY AREA</asp:ListItem>
                            <asp:ListItem>BY BANNERTYPE</asp:ListItem>
                            <asp:ListItem>BY RATING</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td style="text-align: center; height: 27px;">
                        </td>
                </tr>

                <tr>
                    <td dir="ltr" style="height: 27px; width: 526px;">
                        <asp:Label ID="Label4" runat="server" Text="SELECT AREA"></asp:Label>
                        &nbsp;:</td>
                    <td style="width: 281px; height: 27px;" dir="ltr">
                        <asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" AutoPostBack="True" Height="26px" Width="253px"></asp:DropDownList>
                    </td>

                    <td style="width: 281px; height: 27px;" dir="ltr">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="please select area" Font-Bold="True" Font-Italic="False" ForeColor="Red" ControlToValidate="DropDownList4" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td dir="ltr" style="height: 27px; width: 526px;">
                        <asp:Label ID="Label3" runat="server" Text="SELECT BANNER"></asp:Label>
                        :</td>
                    <td style="width: 281px; height: 27px;" dir="ltr">
                        <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True" 
                            Enabled="False" Height="27px" Width="253px"></asp:DropDownList>
                    </td>
                    <td style="width: 281px; height: 27px;" dir="ltr">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="please select banner type" Font-Bold="True" Font-Italic="False" 
                            ForeColor="Red" ControlToValidate="DropDownList3" InitialValue="-1" 
                            Enabled="False" Width="253px"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td dir="ltr" style="height: 27px; width: 526px;">
                        <asp:Label ID="Label5" runat="server" Text="SELECT RATING"></asp:Label>
                        &nbsp;:</td>
                    <td style="width: 281px; height: 27px; margin-left: 80px;" dir="ltr">
                        <asp:DropDownList ID="DropDownList5" Height="26px" Width="253px" runat="server" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" AutoPostBack="True" Enabled="False">
                            <asp:ListItem Value="0">0.0</asp:ListItem>
                            <asp:ListItem Value="1">1.0</asp:ListItem>
                            <asp:ListItem Value="1">1.5</asp:ListItem>
                            <asp:ListItem Value="2">2.0</asp:ListItem>
                            <asp:ListItem Value="2">2.5</asp:ListItem>
                            <asp:ListItem Value="3">3.0</asp:ListItem>
                            <asp:ListItem Value="3">3.5</asp:ListItem>
                            <asp:ListItem Value="4">4.0</asp:ListItem>
                            <asp:ListItem Value="4">4.5</asp:ListItem>
                            <asp:ListItem Value="5">5.0</asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td style="width: 281px; height: 27px; margin-left: 80px;" dir="ltr">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="please select rating" Font-Bold="True" Font-Italic="False" ForeColor="Red" ControlToValidate="DropDownList5" InitialValue="-1" Enabled="False"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td style="height: 23px; width: 526px;">
                        &nbsp;</td>
                    <td style="width: 281px; height: 23px; margin-left: 80px;">
                        &nbsp;</td>
                    <td style="width: 281px; height: 23px; margin-left: 80px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 526px;">
                        &nbsp;</td>
                    <td style="width: 281px; height: 23px; margin-left: 80px;">
                        &nbsp;</td>
                    <td style="width: 281px; height: 23px; margin-left: 80px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 23px; " colspan="3"><div class="CSSTableGenerator">
                                        <asp:GridView ID="GridView1" runat="server">
                                        </asp:GridView>

                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 526px;">
                        &nbsp;</td>
                    <td style="width: 281px; height: 23px; margin-left: 80px;">
                        &nbsp;</td>
                    <td style="width: 281px; height: 23px; margin-left: 80px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 526px;">
                        &nbsp;</td>
                    <td style="width: 281px; height: 23px; margin-left: 80px;">
                        &nbsp;</td>
                    <td style="width: 281px; height: 23px; margin-left: 80px;">
                        &nbsp;</td>
                </tr>
            </table>
            </center>
    </div>

</asp:Content>

