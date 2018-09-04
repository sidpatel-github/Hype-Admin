<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="status.aspx.cs" Inherits="status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"><asp:Label style="margin-left: 40px" ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div style="margin-left: 40px"><div style="margin-right: 40px"><br/><br/>
        <p style="margin-left: 1px">
            STATUS OF HOARDING <br />
        </p>
  
        <table style="width:100%;">
            <tr>
                <td class="style3">
                    LIST OF 
                    STATUS HOARDING :</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                   
                    
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                  
                    <div class="CSSTableGenerator" >
                    <asp:GridView ID="GridView4" runat="server"  OnRowDeleting="GridView4_RowDeleting"
                     OnSelectedIndexChanging="GridView4_SelectedIndexChanging"
                        onselectedindexchanged="GridView4_SelectedIndexChanged">
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

