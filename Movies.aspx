<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMasterPage.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="MovieDB.Movies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
	<div class="container">
		<div class="wrapper">
			<div class="row">
				<div class="col-xs-12 col-sm-offset-2 col-sm-2">
					<asp:DropDownList CssClass="form-control" ID="Genrelist" runat="server" ForeColor="#212121">
						<asp:ListItem Enabled="true" Text="Select Genre" Value="Select Genre"></asp:ListItem>
						<asp:ListItem Text="Action" Value="Action"></asp:ListItem>
						<asp:ListItem Text="Animation" Value="Animation"></asp:ListItem>
						<asp:ListItem Text="Thriller" Value="Thriller"></asp:ListItem>
						<asp:ListItem Text="Science Fiction" Value="Science Fiction"></asp:ListItem>
					</asp:DropDownList>
				</div>
				<div class="col-xs-12 col-sm-4">
					<asp:TextBox CssClass="form-control" runat="server" ID="Moviename_tb" ForeColor="#212121"></asp:TextBox>
				</div>
				<div class="col-xs-12 col-sm-2">
					<asp:Button ID="Search_btn" runat="server" ForeColor="#ffffff" Text="SEARCH" CssClass="btn btn-danger" OnClick="Search_btn_Click" />
				</div>
			</div>
			<div class="row text-center">
				<asp:ListView ID="MovieList_lw" runat="server">
					<ItemTemplate>
						<div class="column">
							<div class="col-xs-6 col-sm-3">
								<a class="modal-link">
									<div class="card">
										<td runat="server">
											<asp:Image CssClass="card-img-top" ID="PosterUrlLabel" runat="server" ImageUrl='<%# Bind("Poster") %>' AlternateText="Movieposter" Height="15em" Width="100%"/>
											<p class="card-text"><asp:Label ID="MovieNameLabel" runat="server" Text='<%# Eval("MovieName") %>' /></p>
										</td>
									</div>
								</a>
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
	   </div>
	   </div>
</asp:Content>
