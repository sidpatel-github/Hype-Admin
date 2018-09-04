<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="registerclient.aspx.cs" Inherits="registerclient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style="margin-left: 40px"><br/><br/>
        <p style="margin-left: 1px">
            REGISTERED CLIENT<br />
        </p>
  
        <table style="width:90%; " >
            <tr>
                <td class="style3">
                    LIST OF CLIENT :</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                   
             
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="2" ><div class="CSSTableGenerator">
                  
                         <asp:GridView ID="GridView2" runat="server"  style="text-align: center"  OnRowDeleting="GridView2_RowDeleting ">
                        <Columns>
                        <asp:ButtonField Text="delete" CommandName="delete" ButtonType="Button" />
                        </Columns>
                        </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
        <br />
        
        <br />
    
    </div>
</asp:Content>

