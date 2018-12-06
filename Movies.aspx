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
                <asp:ListView ID="MovieList_lw" runat="server" GroupItemCount="4" DataSourceID="DS_MoviesAndPoster">
                    <ItemTemplate>
		   <div class="column">
				<div class="col-xs-6 col-md-4">
					<td runat="server">
						<asp:Image ID="PosterUrlLabel" runat="server" ImageUrl='<%# Bind("PosterUrl") %>' AlternateText="Movieposter" Height="25em" Width="100%"/>
						<p><asp:Label ID="MovieNameLabel" runat="server" Text='<%# Eval("MovieName") %>' /></p>
					</td>
				</div>
			</div>
				</ItemTemplate>
				<GroupTemplate>
					<tr id="itemPlaceholderContainer" runat="server">
						<td id="itemPlaceholder" runat="server"></td>
					</tr>
				</GroupTemplate>
               </asp:ListView>
           	<asp:SqlDataSource ID="DS_MoviesAndPoster" runat="server" ConnectionString="<%$ ConnectionStrings:MovieDBConnectionString %>" SelectCommand="SELECT TOP 15 [PosterUrl], [MovieName] FROM [Movies]"></asp:SqlDataSource>
			</div>
	   </div>
	   </div>
</asp:Content>
