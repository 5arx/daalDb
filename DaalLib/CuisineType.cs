using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThinkatronicUtils;
using System.Data.SqlClient;
using System.Data;

namespace DaalLib
{
    public class CuisineType
    {
        public Guid CuisineTypeId{
            get;
            private set;
        }

        public String Name{
            get;
            set;
        }

        public static List<CuisineType> List(){
            List<CuisineType> lst = new List<CuisineType>();

            using (SqlConnection conn = DBUtils.GetConnection()){
                conn.Open();
                using (SqlDataReader rdr = DBUtils.GetReader("Core.Cuisinetype_Select",new SqlParameter[0],conn)){
                    while (rdr.Read()){
                        CuisineType ct = new CuisineType();
                        ct.CuisineTypeId = (Guid)rdr["CuisineTypeId"];
                        ct.Name = rdr["CuisineName"].ToString();
                        
                        lst.Add(ct);
                    }
                }
            }

            return lst;
        }
    }
}
