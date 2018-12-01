<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMasterPage.Master" AutoEventWireup="true" CodeBehind="SaveDataToDB.aspx.cs" Inherits="MovieDB.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
	<asp:Label ID="poster_lb" runat="server"></asp:Label>
	<br />
	<asp:Label ID="actors_lb" runat="server"></asp:Label>
	<br />
	<asp:Label ID="rating_lb" runat="server"></asp:Label>
	<br />
	<asp:Label ID="plot_lb" runat="server"></asp:Label>
	<br />
	<asp:Label ID="msg_lb" runat="server"></asp:Label>
</asp:Content>
