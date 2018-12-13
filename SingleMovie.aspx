<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMasterPage.Master" AutoEventWireup="true" CodeBehind="SingleMovie.aspx.cs" Inherits="MovieDB.SingleMovie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<div class="container">
		<div class="wrapper">
			<div class="row">
				<form id="MovieForm">
					<div class="row">
						<asp:Label ID="msg_lb" runat="server"></asp:Label>
						<asp:ListView ID="SingleMovie_lw" runat="server">
							<ItemTemplate>
								<div class="column">
									<div class="col-xs-12">
										<div class="card">
											<td runat="server">
												<div class="row">
													<div class="col-xs-12">
														<p><asp:Label runat="server" ID="MovieName" Text='<%# Eval("SingleMovie") %>' /></p>
													</div>
												</div>
												<div class="row">
													<div class="col-xs-12 col-sm-6">
														<iframe style="border: 1px solid #ff0000;" src='<%# Eval("Trailer") %>'></iframe>
													</div>
													<div class="col-xs-12 col-sm-6">
														<p>Resume:</p>
														<p><asp:Label runat="server" ID="MovieDescription" Text='<%# Eval("Resume") %>' /></p>
													</div>
												</div>
												<div class="row">
													<div class="col-xs-12 col-sm-6">														
														<p>Actors:</p>
														<p><asp:Label runat="server" ID="Actors_lb" Text='<%# Eval("Actors") %>' /></p>
													</div>
													<div class="col-xs-12 col-sm-6">														
														<p>Genre:</p>
														<p><asp:Label runat="server" ID="Genre_lb" Text='<%# Eval("Genre") %>' /></p>
														<p>Rating:</p>
														<p><asp:Label runat="server" ID="Rating_lb" Text='<%# Eval("Rating") %>' /></p>
													</div>
												</div>
												<div class="row">
													<asp:Button runat="server" ID="Like_btn" Text="LIKE" CssClass="btn btn-success" />
													<asp:Button runat="server" ID="Dislike_btn" Text="DISLIKE" CssClass="btn btn-danger" />
												</div>
											</td>
										</div>
									</div>
								</div>
							</ItemTemplate>
							<GroupTemplate>
								<tr id="itemPlaceholderContainer" runat="server">
									<td id="itemPlaceholder" runat="server"></td>
								</tr>
							</GroupTemplate>
						</asp:ListView>
					</div>
				</form>
			</div>
		</div>
	</div>
</asp:Content>
