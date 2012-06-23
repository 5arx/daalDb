using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ThinkatronicUtils;
using ThinkatronicUtils.DBAccess;

namespace DaalLib
{
    public class Recipe
    {
        #region Properties
        public Guid RecipeId { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid DishTypeId { get; set; }

        public Guid CuisineTypeId { get; set; }

        public int PreparationTime { get; set; }

        public int CookingTime { get; set; }

        public int NumberOfServings { get; set; }

        public string Notes { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<MethodStep> Method { get; set; }

        #endregion Properties
        #region Constructors
        public Recipe()
        {
        }

        public static Recipe Create(){
            return new Recipe();
        }

        public static List<Recipe> Create(string q){
            return Create(new List<Recipe>()).FindAll(r=>   r.Name.ToUpper().Contains(q.ToUpper()) 
                                                            || r.Description.ToUpper().Contains(q.ToUpper())
                                                            || r.Notes.ToUpper().Contains(q.ToUpper())
                                                     );
        }

        public static List<Recipe> Create(List<Recipe> lst){
            Recipe r;
            using (SqlConnection con = DBUtils.GetConnection()){
                con.Open();
                using (SqlDataReader rdr = DBUtils.GetReader("Core.Recipe_Select",
                    new SqlParameter[0],
                    con)
                )
                {
                    if (rdr.HasRows){
                        while(rdr.Read()){
                            r= new Recipe();
                            populate(r, rdr);
                            lst.Add(r);
                        }
                    }
                }
            }
            return lst;
        }

        public static Recipe Create (Guid rId){
            Recipe r;

            using (SqlConnection conn = DBUtils.GetConnection())
            {
                conn.Open();
                using (SqlDataReader rdr = DBUtils.GetReader("Core.Recipe_Select", new SqlParameter[]{
                    new SqlParameter("@RecipeId", rId)}, conn))
                {
                    if (rdr.HasRows)
                    {    
                        r = new Recipe();
                        while (rdr.Read())
                        {
                            populate(r, rdr);
                        }
                    
                        return r;
                    }
                    else{
                        throw new ApplicationException(string.Format("Recipe with ID:{0} was not found.", rId));
                    }
                }
            }
        }

        private static void populate(Recipe r, SqlDataReader rdr){
            r.RecipeId = (Guid)rdr["RecipeId"];
            r.Name = rdr["Name"].ToString();
            r.Description = rdr["Description"].ToString();
            r.DishTypeId = (Guid)rdr["DishTypeId"];
            r.CuisineTypeId = (Guid)rdr["CuisineTypeId"];
            r.PreparationTime = Int32.Parse(rdr["PreparationTime"].ToString());
            r.CookingTime = Int32.Parse(rdr["CookingTime"].ToString());
            r.Notes = rdr["Notes"].ToString();
            r.NumberOfServings = Int32.Parse(rdr["Numberofservings"].ToString());
             
        }

        #endregion Constructors


        #region Persistence
        public void Save()
        {
            if (this.RecipeId == new Guid())
            {
                insert();
            }
            else
            {
                update();
            }
        }

        private void insert()
        {
            SqlParameter[] prams = getParams();
            using (SqlConnection conn = DBUtils.GetConnection())
            {
                conn.Open();
                DBUtils.ExecuteProc("Core.Recipe_Insert", prams);
                this.RecipeId = (Guid)prams[0].Value;
            }
        }

        private void update()
        {
            using(SqlConnection con = DBUtils.GetConnection()){
                con.Open();
                using (SqlCommand cmnd = DBUtils.GetCommand("Core.Recipe_Update", con)
                ){
                    SqlParameter[] prams = getParams();
                    for(int i=0; i< prams.Length; i++){
                        cmnd.Parameters.Add(prams[i]);
                    }

                    cmnd.ExecuteNonQuery();
                }
            }
        }

        private SqlParameter[] getParams()
        {
            SqlParameter[] p = new SqlParameter[9];
            SqlParameter pr;

            pr = new SqlParameter("@RecipeId", this.RecipeId);
            pr.Direction = System.Data.ParameterDirection.InputOutput;
            p[0] = pr;

            pr = new SqlParameter("@Name", this.Name);
            pr.Direction = System.Data.ParameterDirection.Input;
            p[1] = pr;

            pr = new SqlParameter("@Description", this.Description);
            pr.Direction = System.Data.ParameterDirection.Input;
            p[2] = pr;

            pr = new SqlParameter("@DishtypeId", this.DishTypeId);
            pr.Direction = System.Data.ParameterDirection.Input;
            p[3] = pr;

            pr = new SqlParameter("@CuisineTypeId", this.CuisineTypeId);
            pr.Direction = System.Data.ParameterDirection.Input;
            p[4] = pr;

            pr = new SqlParameter("@PreparationTime", this.PreparationTime);
            pr.Direction = System.Data.ParameterDirection.Input;
            p[5] = pr;

            pr = new SqlParameter("@CookingTime", this.CookingTime);
            pr.Direction = System.Data.ParameterDirection.Input;
            p[6] = pr;

            pr = new SqlParameter("@NumberOfServings", this.NumberOfServings);
            pr.Direction = System.Data.ParameterDirection.Input;
            p[7] = pr;

            pr = new SqlParameter("@Notes", this.Notes);
            pr.Direction = System.Data.ParameterDirection.Input;
            p[8] = pr;


            return p;

        }
        #endregion Persistence

        public static List<Recipe> List()
        {
            return List(string.Empty);
        }

        public static List<Recipe> List(string p)
        {
            return Recipe.Create(new List<Recipe>());
        }
    }
}
