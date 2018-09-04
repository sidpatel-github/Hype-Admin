<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="hoarding.aspx.cs" Inherits="hoarding" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <asp:Label style="margin-left: 40px" ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    function ConfirmationBox(username) {

        var result = confirm('Are you sure you want to delete ' + username + ' banner booked');
        if (result) {

            return true;
        }
        else {
            return false;
        }
    }
</script>
<script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="js/jquery.elevatezoom.js" type="text/javascript"></script>
   

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <div style="margin-left: 40px"><div style="margin-right: 40px"><br/><br/>
        <p style="margin-left: 1px">
            BOOKED HOARDING <br />
        </p>
  
      <table style="width:90%; " >
            <tr>
                <td class="style3">
                    LIST OF 
                    BOOKED HOARDING :</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                   
             
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="2" ><div class="CSSTableGenerator">
                  
                         <asp:GridView ID="GridView2" runat="server"  style="text-align: center"  OnSelectedIndexChanging="GridView2_SelectedIndexChanging"
                        onselectedindexchanged="GridView2_SelectedIndexChanged" OnRowDeleting=GridView2_RowDeleting OnRowCommand="GridView2_RowCommand" onrowdatabound="GridView2_RowDataBound">
                        <Columns>
                        <asp:TemplateField HeaderText="Worker">
                        <ItemTemplate>
                        <asp:DropDownList ID="dduser" runat="server" Width="100px"/>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField Text="payment" CommandName="pay" ButtonType="Button" />
                        <asp:ButtonField Text="remove" CommandName="delete" ButtonType="Button" />
                        <asp:ButtonField  CommandName="worker" Text="send to worker"  ButtonType="Button" />
                        <asp:ButtonField Text="expire" CommandName="expire" ButtonType="Button" />
                        <asp:ImageField  DataImageUrlField="image1" HeaderText="Client_Image" AlternateText="image not found"  ControlStyle-Width="100" ControlStyle-Height = "100" >
                        <ControlStyle Width="100px" Height="100px"></ControlStyle>
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
    
    </div>
    </form>
    <script>
        $(function () {
            $("[id*=GridView2] img").elevateZoom({
                cursor: 'pointer',
                tint:true,
                tintColour:'#F90',
                tintOpacity:0.5,
            });
        });
</script>
        <br />
        <br />
        
        <br />
    
    </div>
</asp:Content>

