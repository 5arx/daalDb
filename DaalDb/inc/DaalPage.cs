using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ThinkatronicUtils.Validation;

namespace DaalDb
{
    public class DaalPage : System.Web.UI.Page
    {
        public ICollection<String> UrlSegments{
            get{
                return HttpContext.Current.Request.RawUrl.Split(new char[]{'/'}, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public Guid? RecipeId{
            get{
            if (Request.QueryString["Recipe"] != null
             && 
                Request.QueryString["Recipe"].IsValidGuid()){
                    return new Guid(HttpContext.Current.Request.QueryString["Recipe"]);
                }
            return null;    
            } 
        }

    }
}