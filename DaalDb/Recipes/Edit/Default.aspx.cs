using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaalLib;

namespace DaalDb.RecipeBuilder
{
    public partial class Edit: DaalDb.DaalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (RecipeId.HasValue)
                {
                    buildGui();
                    populateForEdit();
                }
                else {
                    displayLibrary();
                }
            }
        }

        private void populateForEdit()
        {
            phEdit.Visible = true;
            phLibrary.Visible = false;

            Recipe r = Recipe.Create(this.RecipeId.Value);

            txtName.Text = r.Name;
            litName.Text = r.Name;
            txtDesc.Text = r.Description;
            txtNotes.Text = r.Notes;
            txtCookTime.Text = r.CookingTime.ToString();
            txtNumServings.Text = r.NumberOfServings.ToString();
            txtPrepTime.Text = r.PreparationTime.ToString();
            ddlCuisine.SelectedValue = r.CuisineTypeId.ToString();
            ddlDishType.SelectedValue = r.DishTypeId.ToString();
            ////TODO: set all dropdowns
            //ddlCTimeUnit.SelectedValue = r.CookingTimeUnitId.ToString();
            //ddlTimeUnit.SelectedValue = r.TimeUnitId.ToString();
        }

        private void buildGui()
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

        private void displayLibrary(){
            phEdit.Visible = false;
            phLibrary.Visible = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                update();
                populateForEdit();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Recipes/View/?Recipe=" + RecipeId.Value);
        }

        private void update()
        {
            Recipe r = Recipe.Create(RecipeId.Value);
            r.Name = txtName.Text.Trim();
            r.Description = txtDesc.Text.Trim();
            r.DishTypeId = new Guid(ddlDishType.SelectedValue);
            r.CuisineTypeId = new Guid(ddlCuisine.SelectedValue);
            r.PreparationTime = Int32.Parse(txtPrepTime.Text);
            r.CookingTime = int.Parse(txtCookTime.Text);
            r.NumberOfServings = Int32.Parse(txtNumServings.Text);
            r.Notes = txtNotes.Text.Trim();

            r.Save();

            Response.Write("Recipe Updated");

            Response.Redirect(Request.RawUrl);
        }
    }
}