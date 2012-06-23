using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaalLib;

namespace DaalDb.Search
{
    public partial class Search : DaalControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnSearch.Click += new EventHandler(btnSearch_Click);
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                showResults();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void rptResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
            }
        }

        private void showResults()
        {
            rptResults.DataSource = Recipe.Create(txtSearch.Text.Trim()).OrderBy(x => x.Name);
            rptResults.DataBind();
        }
    }
}