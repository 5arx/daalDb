using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DaalDb.RecipeBuilder
{
    public partial class Default : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e){
            this.rbMode.SelectedIndexChanged += new EventHandler(rbMode_SelectedIndexChanged);
            this.rbMode.AutoPostBack = true;
        }

        void rbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbMode.SelectedValue.Equals("1")){
                populateForSearch();
            }
            else{
                browse();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (! IsPostBack){
                populateForSearch();
            }
        }

        private void populateForSearch(){
            phBrowse.Visible = false;
            phSearch.Visible = true;
        }

        private void browse(){
            phBrowse.Visible = true;
            phSearch.Visible = false;
        }

    }
}