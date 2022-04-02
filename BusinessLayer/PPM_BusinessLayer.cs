using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BusinessLayer
{
    public class PPM_BusinessLayer
    {
        public DataTable List(string section)
        {
            using(SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["PPM"].ConnectionString;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                if (section == "Eqpt")
                    cmd.CommandText = "sp_eqpt_list";
                else if (section == "PPM")
                    cmd.CommandText = "sp_ppm_list";
                else if (section == "Defect")
                    cmd.CommandText = "sp_def_list";
                else if (section == "PPMS")
                    cmd.CommandText = "sp_ppms_list";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }
    }
}
