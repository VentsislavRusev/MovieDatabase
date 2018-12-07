<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieDB.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
	<div class="container">
		<div class="wrapper">
			<div class="row">
			<div class="col-xs-12">
				<table class="table">
					<thead>
						<tr>
						<th scope="col">#</th>
						<th scope="col">Title</th>
						<th scope="col">Year</th>
						<th scope="col">Resumé</th>
						<th scope="col">Rating</th>
						<th scope="col">Displays</th>
						<th scope="col"></th>
						</tr>
					</thead>
					<tbody>
						<tr>
							<td>1</td>
							<td>Batman</td>
							<td>1999</td>
							<td>Some story about batman defeating fellons</td>
							<td>7.8</td>
							<td>@DateTime.Now</td>
							<td><button type="button" class="view-btn">View</button></td>
						</tr>
					</tbody>
				</table>
			</div>
		</div>
		<div class="row">
			<div class="col-xs-12 text-center commercial-box">
				<p><asp:Label ID="Cmc_lb" runat="server"></asp:Label></p>
			</div>
			</div>
		</div>
		</div>
	</div>
</asp:Content>
