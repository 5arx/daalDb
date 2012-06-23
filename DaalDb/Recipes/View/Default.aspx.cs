using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaalLib;
using ThinkatronicUtils.Validation;

namespace DaalDb.View
{
    public partial class Default: DaalDb.DaalPage
    {

        protected void Page_Init(object sender, EventArgs e){
            btnEdit.Click += new EventHandler(btnEdit_Click);    
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Recipes/Edit/?Recipe=" + this.RecipeId);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (RecipeId.HasValue)
            {
                Recipe r = null;
                try{
                    r = Recipe.Create(RecipeId.Value);
                }catch(RecordNotFoundException){
                    Response.Redirect("/");
                }
                
                if (r != null)
                {
                    populate(r);
                }
                else
                {
                    Response.Redirect("/Search");
                }
            }
            else{
                //Response.Redirect("/");
                }
        }

        private void populate(Recipe r)
        {
            litName.Text = r.Name;
            litDesc.Text = r.Description;
            litDishType.Text = r.DishTypeId.ToString();
            litCuisine.Text = r.CuisineTypeId.ToString();
            litPrepTime.Text = r.PreparationTime.ToString();
            litCookTime.Text = r.CookingTime.ToString();
            litNumServs.Text = r.NumberOfServings.ToString();
            litNotes.Text = r.Notes;
        }

    }
}