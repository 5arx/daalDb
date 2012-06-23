<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DaalDb.RecipeBuilder.Create.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        RecipeBuilder&trade;</h2>
    <p>
        Use this interactive tool to save your own recipes.</p>
    <asp:ValidationSummary runat="server" EnableClientScript="true" DisplayMode="BulletList"
        HeaderText="Please correct the errors below and try again" />
    <div id="rb01">
        <p>
            Name:
            <asp:TextBox runat="server" ID="txtName" MaxLength="50" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" Text="*" ErrorMessage="Please enter the name of the recipe"
                EnableClientScript="true" />
        </p>
        <p>
            Cuisine:
            <asp:DropDownList runat="server" ID="ddlCuisine" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCuisine" InitialValue="-1"
                ErrorMessage="Please clarify Cuisine Type" EnableClientScript="true" Text="*" />
        </p>
        <p>
            Description:
            <asp:TextBox runat="server" ID="txtDesc" TextMode="MultiLine" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDesc" Text="*" ErrorMessage="Please enter the recipe description"
                EnableClientScript="true" />
        </p>
        <p>
            Type:
            <asp:DropDownList runat="server" ID="ddlDishType" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlDishType" EnableClientScript="true"
                ErrorMessage="Please clarify dish type" Text="*" InitialValue="-1" />
        </p>
        <p>
            Preparation Time:
            <asp:TextBox runat="server" ID="txtPrepTime" CssClass="numeric" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrepTime" ErrorMessage="Please clarify Cuisine Type"
                EnableClientScript="true" Text="*" />
            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPrepTime" Text="*"
                EnableClientScript="true" ErrorMessage="Please enter the approximate Preparation Time (whole number)"
                ValidationExpression="\d+" />
            <asp:DropDownList runat="server" ID="ddlTimeUnit" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCTimeUnit" EnableClientScript="true"
                InitialValue="-1" ErrorMessage="Please clarify cooking time (units)" Text="*" />
        </p>
        <p>
            Cooking Time:
            <asp:TextBox runat="server" ID="txtCookTime" CssClass="numeric" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCookTime" ErrorMessage="Please enter the approximate Cooking time"
                EnableClientScript="true" Text="*" />
            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCookTime" Text="*"
                EnableClientScript="true" ErrorMessage="Please enter the approximate Cooking time (whole number)"
                ValidationExpression="\d+" />
            <asp:DropDownList runat="server" ID="ddlCTimeUnit" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCTimeUnit" EnableClientScript="true"
                InitialValue="-1" ErrorMessage="Please clarify approximate Cooking time (units)"
                Text="*" />
        </p>
        <p>
            Number of Servings:
            <asp:TextBox runat="server" ID="txtNumServings" CssClass="numeric" />
            <asp:RequiredFieldValidator runat="server" ID="valnumservs" ControlToValidate="txtNumServings"
                Text="*" ErrorMessage="Please enter the number of servings" EnableClireentScript="true" />
            <asp:RegularExpressionValidator runat="server" ID="valrgxservings" ControlToValidate="txtNumServings"
                Text="*" ErrorMessage="Please enter the number of servings (whole number)" ValidationExpression="\d+" />
        </p>
        <p>
            Notes:
            <asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" />
        </p>
        <div>
            <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Add Recipe" />
        </div>
    </div>
    <input type="hidden" runat="server" id="hRecipeId" />
</asp:Content>
