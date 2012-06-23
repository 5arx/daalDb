using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using DaalLib;
using ThinkatronicUtils.Validation;

namespace DaalDb
{

    public class DaalControl : System.Web.UI.UserControl
    {
        public ICollection<String> UrlSegments
        {
            get
            {
                return HttpContext.Current.Request.RawUrl.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public Guid? RecipeId
        {
            get
            {
                if (HttpContext.Current.Request.QueryString["Recipe"] != null
                 &&
                    HttpContext.Current.Request.QueryString["Recipe"].IsValidGuid())
                {
                    return new Guid(HttpContext.Current.Request.QueryString["Recipe"]);
                }
                return null;
            }
        }

    }


}