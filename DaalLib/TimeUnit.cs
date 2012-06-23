using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ThinkatronicUtils;

namespace DaalLib
{
    public class TimeUnit
    {
        public Guid TimeUnitId{
            get;
            private set;
        }

        public string TimeUnitName{
            get;
            set;
        }

        public static List<TimeUnit> List(){
            List<TimeUnit> lst = new List<TimeUnit>();

             using (SqlConnection conn = DBUtils.GetConnection()){
                conn.Open();
                using (SqlDataReader rdr = DBUtils.GetReader("Core.TimeUnit_Select",new SqlParameter[0],conn)){
                    while (rdr.Read()){
                        TimeUnit t = new TimeUnit();
                        t.TimeUnitId = (Guid)rdr["TimeUnitId"];
                        t.TimeUnitName = rdr["TimeUnitName"].ToString();
                        
                        lst.Add(t);
                    }
                }
            }
            return lst;
        }

    }
}
