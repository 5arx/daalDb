using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThinkatronicUtils;
using System.Data.SqlClient;
using System.Data;

namespace DaalLib
{
    public class DishType
    {
        public Guid DishTypeId
        {
            get;
            private set;
        }

        public Guid ParentDishTypeId
        {
            get;
            set;
        }
        
        public String Name
        {
            get;
            set;
        }

        public static List<DishType> List()
        {
            List<DishType> lst = new List<DishType>();

            using (SqlConnection conn = DBUtils.GetConnection())
            {
                conn.Open();
                using (SqlDataReader rdr = DBUtils.GetReader("Core.DishType_Select", new SqlParameter[0], conn))
                {
                    while (rdr.Read())
                    {
                        DishType ct = new DishType();
                        ct.DishTypeId = (Guid)rdr["DishTypeId"];
                        ct.Name = rdr["DishTypeName"].ToString();
                        if (rdr["ParentDishTypeId"] != DBNull.Value ){
                            ct.ParentDishTypeId = (Guid)rdr["ParentDishTypeId"];
                        }
                        lst.Add(ct);
                    }
                }
            }

            return lst;
        }
    }
}
