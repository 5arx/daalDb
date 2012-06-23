<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="DaalDb.Search.Search" %>
<div>
<h2>
    Search</h2>
<p>
    <label for="txtSearch">
        Look for:</label>
    <asp:TextBox runat="server" ID="txtSearch" ClientIDMode="Static" />
</p>
<p>
    <asp:Button runat="server" ID="btnSearch" Text="Find Recipes" /></p>
<div>
    <asp:Repeater runat="server" ID="rptResults" OnItemDataBound="rptResults_ItemDataBound">
        <HeaderTemplate>
        </HeaderTemplate>
        <FooterTemplate>
        </FooterTemplate>
        <ItemTemplate>
            <p>
                <a href='/Recipes/View/?Recipe=<%# Eval("RecipeId") %>'>
                    <%# Eval("Name") %></a>
                <br />
                <span class="RecipeIntro">
                    <%# Eval("Description") %></span>
            </p>
        </ItemTemplate>
    </asp:Repeater>
</div>
</div>