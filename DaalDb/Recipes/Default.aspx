<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DaalDb.RecipeBuilder.Default" %>
<%@ Register src="~/Recipes/Search/Search.ascx" tagname="Search" tagprefix="uc1" %>
<%@ Register src="View/Browse.ascx" tagname="Browse" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Recipe Builder</h2>
<p>You can <a href="Create/">create</a> and <a href="/Recipes/Edit/">edit</a> your recipes with this set 
of interactive tools.</p>

<asp:RadioButtonList runat="server" ID="rbMode" >
    <asp:ListItem Text="Search" Value="1" />
    <asp:ListItem Text="Browse" Value="0" />
</asp:RadioButtonList>
    

<asp:Placeholder runat="server" ID="phBrowse" Visible="false">
<uc2:Browse ID="Browse1" runat="server" />
</asp:Placeholder>

<asp:PlaceHolder runat="server" ID="phSearch" Visible="false">
    <uc1:Search ID="Search1" runat="server" />
</asp:PlaceHolder>
    
</asp:Content>
