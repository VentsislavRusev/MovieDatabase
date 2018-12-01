<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMasterPage.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="MovieDB.Movies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
	<div class="container">
		<div class="row">
			<div class="col-xs-12 col-sm-offset-2 col-sm-2">
				<select class="form-control">
					<option>Select Genre</option>
					<option>Action</option>
					<option>Animation</option>
					<option>Thriller</option>
					<option>Genre</option>
				</select>
			</div>
			<div class="col-xs-12 col-sm-2">
				<input type="number" class="form-control" placeholder="2008" aria-label="Year">
			</div>
			<div class="col-xs-12 col-sm-4">
				<input class="form-control" type="text" placeholder="Search" aria-label="Search">
			</div>
		</div>
		<div class="row text-center">
			<div class="col-xs-6 col-sm-3">
				<p>Poster</p>
				<p>Title</p>
			</div>
			<div class="col-xs-6 col-sm-3">
				<p>Poster</p>
				<p>Title</p>
			</div>
			<div class="col-xs-6 col-sm-3">
				<p>Poster</p>
				<p>Title</p>
			</div>
			<div class="col-xs-6 col-sm-3">
				<p>Poster</p>
				<p>Title</p>
			</div>
		</div>
	</div>
</asp:Content>
