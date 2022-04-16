using System;
using BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataLayer.Models;

namespace PreventivePlannedMaintenance.Controllers
{
    public class PPMController : Controller
    {
        PPM_BusinessLayer businessLayer = new PPM_BusinessLayer();
        public IActionResult PPM_Index()
        {
            return View();
        }
        public ActionResult _details()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoadData(int col)
        {

            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            var start = HttpContext.Request.Form["start"].FirstOrDefault();
            var length = HttpContext.Request.Form["length"].FirstOrDefault();
            string search = HttpContext.Request.Form["search[value]"].FirstOrDefault();
            //Find Order Column
            var sortColumn = HttpContext.Request.Form["columns[" + HttpContext.Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDir = HttpContext.Request.Form["order[0][dir]"].FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            var eqptDetails = businessLayer.PPM_details(search, sortColumn, sortColumnDir, col);
            recordsTotal = eqptDetails.Count();
            var data = eqptDetails.ToList();
            if (pageSize != -1)
            {
                data = eqptDetails.Skip(skip).Take(pageSize).ToList();
            }
            var json = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(json);

        }


        public ActionResult AddNew()
        {
            try
            {
                Maintenance_masterModel eqptModel = new Maintenance_masterModel();
                return View("_AddNew", eqptModel);
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex;
                return View();

            }
        }

        [HttpPost]
        public ActionResult Update(Maintenance_masterModel ppmModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(ppmModel.MaintenanceMasterId))
                {
                    int update = businessLayer.Update_PPM(ppmModel);
                    if (update == 1)
                    {
                        TempData["msg"] = "Updated Successfully";
                        TempData["no"] = ppmModel.MaintenanceMasterId;
                        return RedirectToAction("PPM_Index");
                    }
                    else
                    {
                        TempData["msg"] = "Update Failed";
                        return RedirectToAction("PPM_Index");
                    }

                }
                TempData["msg"] = "Failed..Try Again";
                return RedirectToAction("PPM_Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex;
                TempData["msg"] = ex;
                return RedirectToAction("PPM_Index");
            }
        }
    }
}