<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication2.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

     <asp:Button ID="Button1" runat="server" Enabled="true" CssClass="btn btn-primary" Text="TestMe" OnClick="Button1_Click"/>
    <asp:Button ID="Button2" runat="server" Enabled="true" CssClass="btn btn-primary" Text="TestMe Disable" OnClick="Button2_Click"/>
</asp:Content>
