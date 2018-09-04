<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="worker.aspx.cs" Inherits="worker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"><asp:Label style="margin-left: 40px" ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">


</style>
    <script>
        function doConfirm() {
            var r = confirm("do you want to delete?");
            alert(r);
        }


	</script>

<script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="js/jquery.elevatezoom.js" type="text/javascript"></script>
  
      <div style="margin-left: 40px"><div style="margin-right: 40px"><br/><br/>
        <p style="margin-left: 1px">
            WORKER DISTRIBUTION<br />
        </p>
  
       <table style="width:100%;">
            
            <tr>
                <td class="style3" colspan="2">
                    LIST OF WORK TO EACH WORKER:</td>
            </tr>
            
            <tr>
                <td class="style3" colspan="2"><div class="CSSTableGenerator">
                    <asp:GridView ID="GridView7" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    LIST OF 
                    WORK DISTRIBUTION:</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                   
             
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="2"><div class="CSSTableGenerator">
                  
                         <asp:GridView ID="GridView6" runat="server" OnRowDeleting="GridView6_RowDeleting"
                     OnSelectedIndexChanging="GridView6_SelectedIndexChanging" OnRowCommand="GridView6_RowCommand"
                        onselectedindexchanged="GridView6_SelectedIndexChanged">
                             <Columns>
                                 <asp:CommandField DeleteText="REJECT" ShowDeleteButton="True" ButtonType="Button"/>
                                 <asp:CommandField SelectText="ORDER DONE" ShowSelectButton="True" ButtonType="Button" />
                                 
                                 <asp:ImageField DataImageUrlField="client image" HeaderText="finalimage"  AlternateText="image not found" ControlStyle-Width="100" ControlStyle-Height = "100" >
<ControlStyle Height="100px" Width="100px"></ControlStyle>
                                 </asp:ImageField>
                                 <asp:ImageField DataImageUrlField="worker image" HeaderText="locfinalimage" AlternateText="image not found"  ControlStyle-Width="100" ControlStyle-Height = "100"  >
<ControlStyle Height="100px" Width="100px"></ControlStyle>
                                 </asp:ImageField>
                             </Columns>
                         </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
        <br />
        
        <br />
    
    </div>
    </form>
     <script>
        $(function () {
            $("[id*=GridView6] img").elevateZoom({
                cursor: 'pointer',
                tint:true,
                tintColour:'#F90',
                tintOpacity:0.5,
            });
        });
</script>
    
</asp:Content>

