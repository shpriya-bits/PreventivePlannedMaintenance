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
        public IEnumerable<Equipment_masterModel> Eqpt_details(string ssearch, string ssort, string ssortdir, int icol)
        {
            using (PPMEntities ppm = new PPMEntities())
            {

                var lists = ppm.equipment_master.Select(m => new Equipment_masterModel() { Tranx_Id = m.Tranx_Id, EquipmentPartId = m.EquipmentPartId, Description = m.Description, ParentEquipmentPartId = m.ParentEquipmentPartId, IsPhysical = m.IsPhysical??false, Compartment = m.Compartment, EquipmentType=m.EquipmentType }).ToList();
                if (!string.IsNullOrEmpty(ssearch))
                {
                    if (icol != 0)
                    {
                        switch (icol)
                        {
                            case 1:
                                lists = lists.Where(m => m.Tranx_Id.ToString() == ssearch).ToList();
                                break;
                            case 2:
                                lists = lists.Where(m => m.EquipmentPartId.ToUpper().Contains(ssearch.ToUpper())).ToList();
                                break;
                            case 3:
                                lists = lists.Where(m => m.Description.ToUpper().Contains(ssearch.ToUpper())).ToList();
                                break;
                            case 4:
                                lists = lists.Where(m => m.ParentEquipmentPartId.ToUpper().Contains(ssearch.ToUpper())).ToList();
                                break;
                            case 5:
                                lists = lists.Where(m => m.EquipmentType.ToUpper().Contains(ssearch.ToUpper())).ToList();
                                break;
                            case 6:
                                lists = lists.Where(m => m.Compartment.ToUpper().Contains(ssearch.ToUpper())).ToList();
                                break;
                            case 7:
                                if ("Yes".Contains(ssearch))
                                {
                                    lists = lists.Where(m => m.IsPhysical == true).ToList();
                                    break;
                                }
                                else if ("No".Contains(ssearch))
                                {
                                    lists = lists.Where(m => m.IsPhysical == false).ToList();
                                    break;
                                }
                                else
                                    break;
                        }
                    }
                    else
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

        public IEnumerable<Maintenance_masterModel> PPM_details(string ssearch, string ssort, string ssortdir, int icol)
        {
            using (PPMEntities ppm = new PPMEntities())
            {

                var lists = ppm.maintenance_master.Select(m => new Maintenance_masterModel() { Tranx_Id = m.tranx_id, EquipmentPartId = m.EquipmentPartId, MaintenanceMasterId = m.MaintenanceMasterId, Description = m.Description, EmergencyMaintenance = m.EmergencyMaintenance?? false, Periodicity = m.Periodicity }).ToList();
                if (!string.IsNullOrEmpty(ssearch))
                {
                    if (icol != 0)
                    {
                        switch (icol)
                        {
                            case 1:
                                lists = lists.Where(m => m.Tranx_Id.ToString() == ssearch).ToList();
                                break;
                            case 2:
                                lists = lists.Where(m => m.MaintenanceMasterId.ToUpper().Contains(ssearch.ToUpper())).ToList();
                                break;
                            case 3:
                                lists = lists.Where(m => m.EquipmentPartId.ToUpper().Contains(ssearch.ToUpper())).ToList();
                                break;
                            case 4:
                                lists = lists.Where(m => m.Description.ToUpper().Contains(ssearch.ToUpper())).ToList();
                                break;
                            case 5:
                                lists = lists.Where(m => m.Periodicity.ToUpper().Contains(ssearch.ToUpper())).ToList();
                                break;
                            case 6:
                                if ("Yes".Contains(ssearch))
                                {
                                    lists = lists.Where(m => m.EmergencyMaintenance == true).ToList();
                                    break;
                                }
                                else if ("No".Contains(ssearch))
                                {
                                    lists = lists.Where(m => m.EmergencyMaintenance == false).ToList();
                                    break;
                                }
                                else
                                    break;
                        }
                    }
                    else
                        lists = lists.Where(m => m.EquipmentPartId.ToUpper().Contains(ssearch.ToUpper()) || (m.Description != null && m.Description.ToUpper().Contains(ssearch.ToUpper())) || (m.MaintenanceMasterId.ToUpper().Contains(ssearch.ToUpper()))).ToList();
                }

                //sort
                if (!(string.IsNullOrEmpty(ssort) && string.IsNullOrEmpty(ssortdir)))
                {
                    lists = lists.OrderBy(o => ssort + " " + ssortdir).ToList();
                }
                return lists;
            }
        }

        public int AddEqpt(Equipment_masterModel eqptModel)
        {
            try
            {
                using (PPMEntities ppm = new PPMEntities())
                {
                    equipment_master eqpt = new equipment_master()
                    {
                        EquipmentPartId = eqptModel.EquipmentPartId,
                        Description = eqptModel.Description,
                        Compartment = eqptModel.Compartment,
                        IsPhysical = eqptModel.IsPhysical,
                        EquipmentType = eqptModel.EquipmentType,
                        ParentEquipmentPartId = eqptModel.ParentEquipmentPartId,
                        CreatedTs = DateTime.Now
                    };
                    ppm.equipment_master.Add(eqpt);
                    ppm.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Update_Eqpt(Equipment_masterModel model)
        {
            try
            {
                using (PPMEntities ppm = new PPMEntities())
                {
                    var result = (from m in ppm.equipment_master where m.EquipmentPartId == model.EquipmentPartId select m).FirstOrDefault();
                    result.EquipmentType = model.EquipmentType;
                    result.Description = model.Description;
                    result.ParentEquipmentPartId = model.ParentEquipmentPartId;
                    result.IsPhysical = model.IsPhysical;
                    result.ChangedTs = DateTime.Now;
                    result.Compartment = model.Compartment;
                    ppm.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
