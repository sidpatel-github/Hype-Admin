<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="payment.aspx.cs" Inherits="payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"><asp:Label style="margin-left: 40px" ID="Label2" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="margin-left: 40px"><div style="margin-right: 40px"><br/><br/>
        <p style="padding-left: 1px">
            &nbsp;</p>
  
        
<title></title>
    
</head>
<body>
    
    <div>
    
      <table style="width:100%;">
            <tr>
                <td class="style4" >
                    &nbsp;</td>
                <td class="style2" >
                    &nbsp;</td>
                <td class="style1" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" colspan="2" ><div class="CSSTableGenerator">
                    <asp:GridView ID="GridView2" runat="server">
                    </asp:GridView>
                </td>
                <td class="style1" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" >
                    &nbsp;</td>
                <td class="style2" >
                    &nbsp;</td>
                <td class="style1" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" >
                    &nbsp;</td>
                <td class="style2" >
                    &nbsp;</td>
                <td class="style1" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" >
                    &nbsp;</td>
                <td class="style2" >
                    &nbsp;</td>
                <td class="style1" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" >
            PAYMENT OF WORKER</td>
                <td class="style2" >
                    &nbsp;</td>
                <td class="style1" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" >
                    &nbsp;</td>
                <td class="style2" >
                    &nbsp;</td>
                <td class="style1" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5" >
                    SELECT WORKER :</td>
                <td class="style6" >
        <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" runat="server" 
                            Height="26px" Width="253px"></asp:DropDownList>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="please select worker" Font-Bold="True" Font-Italic="True" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                        
                   
                    </td>

                      
                </td>
                <td class="style7" >
                    </td>
            </tr>
            <tr>
                <td class="style5" >
                    TOTAL AMOUNT (₹) :</td>
                <td class="style6" >
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style7" >
                    </td>
            </tr>
            <tr>
                <td class="style4" >
                    &nbsp;</td>
                <td class="style2" >
                    &nbsp;</td>
                <td class="style1" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3" >
                    <div class="CSSTableGenerator">
                    <asp:GridView ID="GridView1" runat="server" >
                        <Columns>
                            <asp:BoundField HeaderText="price" />
                        </Columns>
                       
                    </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="3" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3" > 
                    </td>
            </tr>
            <tr>
                <td class="style3" colspan="3" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3" >
                    &nbsp;</td>
            </tr></table>
    </div>
</asp:Content>

