using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataLayer.Models;
using DataLayer.Repository;
using System.Data.Entity;

namespace BusinessLayer
{
    public class PPM_BusinessLayer
    {
        public DataTable List(string section)
            {
            string connectionString = "Data Source=PRIYAIDEA\\PRIYAINSTANCE;Database=ShipPPM;User Id=sa;Password=Sa@123#;";

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;//ConfigurationManager.ConnectionStrings["PPM"].ConnectionString.ToString();
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

        public IEnumerable<EquipmentMasterModel> Eqpt_details(string ssearch, string ssort, string ssortdir)
        {
            using (PPMEntities ppm = new PPMEntities())
            {

                var lists = ppm.EquipmentMaster.Select(m => new EquipmentMasterModel() { tranx_Id=m.Tranx_Id, EquipmentPartId = m.EquipmentPartId, Description = m.Description, ParentEquipmentPartId = m.ParentEquipmentPartId, IsPhysical = m.IsPhysical, Compartment = m.Compartment }).ToList();
                if (!string.IsNullOrEmpty(ssearch))
                {
                    //if (icol != 0)
                    //{
                    //    switch (icol)
                    //    {
                    //        case 1:
                    //            lists = lists.Where(m => m.EquipmentPartId.ToString() == ssearch).ToList();
                    //            break;
                    //        case 2:
                    //            lists = lists.Where(m => m.Description.ToUpper().Contains(ssearch.ToUpper())).ToList();
                    //            break;
                    //        case 3:
                    //            lists = lists.Where(m => m.ParentEquipmentPartId.ToUpper().Contains(ssearch.ToUpper())).ToList();
                    //            break;
                    //        case 4:
                    //            lists = lists.Where(m => m.Compartment.ToUpper().Contains(ssearch.ToUpper())).ToList();
                    //            break;
                    //        case 5:
                    //            if ("Yes".Contains(ssearch))
                    //            {
                    //                lists = lists.Where(m => m.IsPhysical == true).ToList();
                    //                break;
                    //            }
                    //            else if ("No".Contains(ssearch))
                    //            {
                    //                lists = lists.Where(m => m.IsPhysical == false).ToList();
                    //                break;
                    //            }
                    //            else
                    //                break;
                    //    }
                    //}
                    //else
                        lists = lists.Where(m => m.EquipmentPartId.ToUpper().Contains(ssearch.ToUpper()) || (m.Description != null && m.Description.ToUpper().Contains(ssearch.ToUpper())) || (m.ParentEquipmentPartId != null && m.ParentEquipmentPartId.ToUpper().Contains(ssearch.ToUpper()))).ToList();
                }
                
                //sort
                if (!(string.IsNullOrEmpty(ssort) && string.IsNullOrEmpty(ssortdir)))
                {
                    lists = lists.OrderBy(o => ssort + " " + ssortdir).ToList();
                }
                return lists;
            }
        }
    }
}
