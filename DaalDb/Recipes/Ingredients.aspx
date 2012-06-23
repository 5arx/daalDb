<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingredients.aspx.cs" Inherits="DaalDb.RecipeBuilder.Ingredients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Ingredients</h2>
<p><strong><asp:Literal runat="server" ID="litName" /></strong></p>
<asp:Repeater runat="server" ID="rptIngred" onitemcommand="rptIngred_ItemCommand">
<ItemTemplate>
<div>
<%# Eval("IngredientName") %>
</div>
</ItemTemplate>
</asp:Repeater>
</asp:Content>
