<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Browse.ascx.cs" Inherits="DaalDb.Recipes.View.Browse" %>

<h2>Browse</h2>
    <fieldset>
        <div class="Toolstrip">
            <p>
                <label>
                    Cuisine Type</label>
                <asp:DropDownList runat="server" ID="ddlCuisineType" />
            </p>
            <p>
                <label>
                    Food Type</label>
                <asp:DropDownList runat="server" ID="ddlDishType" />
            </p>
            <p>
                <label>
                    /ddl3</label>
                <asp:DropDownList runat="server" ID="ddl3" />
            </p>
            <p>
                <label>
                    /ddl4</label>
                <asp:DropDownList runat="server" ID="ddl4" />
            </p>
        </div>
    </fieldset>