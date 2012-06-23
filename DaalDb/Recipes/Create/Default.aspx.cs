using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaalLib;
using ThinkatronicUtils.Validation;

namespace DaalDb.RecipeBuilder.Create
{
    public enum FormMode
    {
        Create,
        View,
        Edit
    }

    public partial class Default: DaalDb.DaalPage
    {
        //public Guid? RecipeId
        //{
        //    get
        //    {
        //        if (Request.Form["hRecipeId"] != null)
        //        {
        //            return new Guid(Request.Form["hRecipeId"]);
        //        }
        //        return new Guid();
        //    }
        //    set
        //    {
        //        this.hRecipeId.Value = value.ToString();
        //    }
        //}

        public FormMode PageMode
        {
            get
            {
                if (Session["RecipeBuilderMode"] == null)
                {
                    Session["RecipeBuilderMode"] = FormMode.Create;
                }
                return (FormMode)Session["RecipeBuilderMode"];
            }
            set
            {
                Session["RecipeBuilderMode"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                buildAddGui();
            }

        }


        private void buildAddGui()
        {
            ddlCuisine.DataSource = CuisineType.List().OrderBy(x => x.Name);
            ddlCuisine.DataTextField = "Name";
            ddlCuisine.DataValueField = "CuisineTypeId";
            ddlCuisine.DataBind();
            ddlCuisine.Items.Insert(0, new ListItem("Select ...", "-1"));

            ddlDishType.DataSource = DishType.List().OrderBy(x => x.Name);
            ddlDishType.DataValueField = "DishTypeId";
            ddlDishType.DataTextField = "Name";
            ddlDishType.DataBind();
            ddlDishType.Items.Insert(0, new ListItem("Select ...", "-1"));

            ddlTimeUnit.DataSource = TimeUnit.List().OrderBy(x => x.TimeUnitName);
            ddlTimeUnit.DataTextField = "TimeUnitName";
            ddlTimeUnit.DataValueField = "TimeUnitId";
            ddlTimeUnit.DataBind();
            ddlTimeUnit.Items.Insert(0, new ListItem("Select ...", "-1"));

            ddlCTimeUnit.DataSource = ddlTimeUnit.DataSource;// TimeUnit.List().OrderBy(x => x.TimeUnitName);
            ddlCTimeUnit.DataTextField = "TimeUnitName";
            ddlCTimeUnit.DataValueField = "TimeUnitId";
            ddlCTimeUnit.DataBind();
            ddlCTimeUnit.Items.Insert(0, new ListItem("Select ...", "-1"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Recipe r = new Recipe();
                r.Name = txtName.Text.Trim();
                r.Description = txtDesc.Text.Trim();
                r.DishTypeId = new Guid(ddlDishType.SelectedValue);
                r.CuisineTypeId = new Guid(ddlCuisine.SelectedValue);
                r.PreparationTime = Int32.Parse(txtPrepTime.Text);
                r.CookingTime = int.Parse(txtCookTime.Text);
                r.NumberOfServings = Int32.Parse(txtNumServings.Text);
                r.Notes = txtNotes.Text.Trim();

                r.Save();

                Response.Write("Recipe saved: ID: " + r.RecipeId);

                Response.Redirect("/RecipeBuilder/Edit/?Recipe=" + r.RecipeId);
            }
        }
    }
}