<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="mapforall.aspx.cs" Inherits="mapforall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Show/Add multiple markers to Google Maps from database in asp.net website</title>
<style type="text/css">
html { height: 100% }
body { height: 100%; margin: 0; padding: 0 }
#map_canvas { height: 100% }
</style>
<script type="text/javascript" src = "https://maps.googleapis.com/maps/api/js?key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk&sensor=false">
</script>
<script type="text/javascript">
    function initialize() {
        var markers = JSON.parse('<%=ConvertDataTabletoString() %>');
        var mapOptions = {
            center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
            zoom: 15,
            mapTypeId: google.maps.MapTypeId.ROADMAP
            //  marker:true
        };
        var infoWindow = new google.maps.InfoWindow();
        var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
        for (i = 0; i < markers.length; i++) {
            var data = markers[i]
            var myLatlng = new google.maps.LatLng(data.lat, data.lng);
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: data.title
            });
            (function (marker, data) {

                // Attaching a click event to the current marker
                google.maps.event.addListener(marker, "click", function (e) {
                    infoWindow.setContent(data.desc1);
                    infoWindow.open(map, marker);
                });
            })(marker, data);
        }
    }
</script>
</head>
<body onload="initialize()">
<form id="form1" >
<div>

      <table style="width:1348px; height: 11px; text-align:center">
            <tr>
                <td>STATE :</td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" Width="224px" ></asp:DropDownList></td>
                <td>CITY :</td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True" Width="224px"  ></asp:DropDownList></td>
                <td>AREA :</td>
                <td><asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Width="228px"  ></asp:DropDownList></td>
             <!--<asp:Button ID="Button1" runat="server" Text="show feedback" onClick="initialize_click" OnClientClick="initialize()"/>
                <input type="button" name="btn1" value="show feedback" onclick="initialize();" /> -->
                <td>RATING:</td>
                <td>
                <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" Width="168px"  >
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
      </table>
<div  id="map_canvas" style="width: 1348px; height: 580px; text-align:center  ">

</form>
</body>
</html>

</asp:Content>

