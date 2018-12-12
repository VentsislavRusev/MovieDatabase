<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieDB.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
	<div class="container">
		<div class="wrapper">
			<h1 class="text-center display-header"><asp:Label runat="server" ID="display_lb" ForeColor="#FF5252">Top 10</asp:Label></h1>
			<div class="row">
				<div class="col-xs-12 col-sm-offset-3 col-sm-4">
					<asp:dropdownlist cssclass="form-control" id="TimeSpanList" runat="server" forecolor="#212121">
						<asp:ListItem Enabled="true" Text="Select Timespan" Value="Select Timespan"></asp:ListItem>
						<asp:ListItem Text="Day" Value="Day"></asp:ListItem>
						<asp:ListItem Text="Week" Value="Week"></asp:ListItem>
						<asp:ListItem Text="Month" Value="Month"></asp:ListItem>
					</asp:dropdownlist>
				</div>
				<div class="col-xs-12 col-sm-2 text-center">
					<asp:button id="Filter_btn" runat="server" forecolor="#ffffff" text="FILTER" cssclass="btn btn-danger" onclick="Filter_btn_Click" />
				</div>
			</div>
			<div class="row">	
				<table class="table">
					<thead>
						<th>Title</th>
						<th>Release Year</th>
						<th>Rating</th>
					</thead>
					<tbody>
				<asp:ListView ID="TopTenMovies_lw" runat="server">
					<ItemTemplate>
        				<td CssClass="display-table" runat="server">
							<p class="card-text"><asp:Label ID="MovieNameLabel" runat="server" Text='<%# Eval("MovieName") %>' /></p>
						</td>
        				<td CssClass="display-table" runat="server">
							<p class="card-text"><asp:Label ID="ReleaseYearLabel" runat="server" Text='<%# Eval("ReleaseYear") %>' /></p>
						</td>
        				<td CssClass="display-table" runat="server">
							<p class="card-text"><asp:Label ID="RatingLabel" runat="server" Text='<%# Eval("Rating") %>' /></p>
						</td>
					</ItemTemplate>
					<GroupTemplate>
						<tr id="itemPlaceholderContainer" runat="server">
							<td id="itemPlaceholder" runat="server"></td>
						</tr>
					</GroupTemplate>	
				</asp:ListView>
				</tbody>
				</table>
			</div>
			<div class="row">
				<div class="col-xs-12 text-center commercial-box">
					<p><asp:Label ID="Cmc_lb" runat="server"></asp:Label></p>
				</div>
			</div>
		</div>
	</div>
</asp:Content>
