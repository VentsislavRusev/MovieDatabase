<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMasterPage.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="MovieDB.Movies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container">
        <div class="wrapper">
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
                <div class="col-xs-6 col-md-3 movie-box">
                    <img class="movies-img" src="https://m.media-amazon.com/images/M/MV5BMjgxNjg1Mjg1Ml5BMl5BanBnXkFtZTgwODgyODA1MjE@._V1_SX300.jpg" alt="Movie Poster" />
                    <p class="movies-title">Title</p>
                </div>
                <div class="col-xs-6 col-md-3 movie-box">
                    <img class="movies-img" src="https://m.media-amazon.com/images/M/MV5BMjgxNjg1Mjg1Ml5BMl5BanBnXkFtZTgwODgyODA1MjE@._V1_SX300.jpg" alt="Movie Poster" />
                    <p class="movies-title">Title</p>
                </div>
                <div class="col-xs-6 col-md-3 movie-box">
                    <img class="movies-img" src="https://m.media-amazon.com/images/M/MV5BMjgxNjg1Mjg1Ml5BMl5BanBnXkFtZTgwODgyODA1MjE@._V1_SX300.jpg" alt="Movie Poster" />
                    <p class="movies-title">Title</p>
                </div>
                <div class="col-xs-6 col-md-3 movie-box">
                    <img class="movies-img" src="https://m.media-amazon.com/images/M/MV5BMjgxNjg1Mjg1Ml5BMl5BanBnXkFtZTgwODgyODA1MjE@._V1_SX300.jpg" alt="Movie Poster" />
                    <p class="movies-title">Title</p>
                </div>
            </div>
            <p><asp:Label runat="server" ID="msg_lb"></asp:Label></p>
            <div class="row">
                <asp:ListView ID="MovieList_lw" runat="server">
                    <ItemTemplate>
                        <div class="col-xs-6 col-md-3">
                            <img src="<%# Eval("PosterUrl") %>" alt="<%# Eval("MovieName") %> + Poster" />
                            <p><%# Eval("MovieName") %></p>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
