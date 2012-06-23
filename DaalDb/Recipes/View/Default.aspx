<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DaalDb.View.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <p>
            <strong><asp:Literal runat="server" ID="litName" /></strong>
        </p>
        <p>
            Cuisine:
            <asp:Literal runat="server" ID="litCuisine" /></p>
        <p>
            Description:
            <asp:Literal runat="server" ID="litDesc" /></p>
        <p>
            Dish Type:
            <asp:Literal runat="server" ID="litDishType" /></p>
        <p>
            Preparation Time:
            <asp:Literal runat="server" ID="litPrepTime" /></p>
        <p>
            Cook Time:
            <asp:Literal runat="server" ID="litCookTime" /></p>
        <p>
            Number of Servings:
            <asp:Literal runat="server" ID="litNumServs" /></p>
        <p>
            Notes:
            <asp:Literal runat="server" ID="litNotes" /></p>
    </div>
    <div>
        <asp:Button runat="server" ID="btnEdit" Text="Edit" />
    </div>

</asp:Content>
