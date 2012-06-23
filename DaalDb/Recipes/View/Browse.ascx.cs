using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaalLib;

namespace DaalDb.Recipes.View
{
    public partial class Browse : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                buildGui();
            }
        }

        private void buildGui()
        {
            ddlCuisineType.DataSource = CuisineType.List();
            ddlCuisineType.DataTextField = "Name";
            ddlCuisineType.DataValueField = "CuisineTypeId";
            ddlCuisineType.DataBind();

            ddlDishType.DataSource = DishType.List();
            ddlDishType.DataValueField = "DishTypeId";
            ddlDishType.DataTextField = "Name";
            ddlDishType.DataBind();
        }
    }
}