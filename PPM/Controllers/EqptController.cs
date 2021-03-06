using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using System.Data;
using System.Collections;
using DataLayer.Models;

namespace PreventivePlannedMaintenance.Controllers
{
    public class EqptController : Controller
    {
        PPM_BusinessLayer businessLayer = new PPM_BusinessLayer();
        public IActionResult Eqpt_Index()
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
            var eqptDetails = businessLayer.Eqpt_details(search, sortColumn, sortColumnDir, col);
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
                Equipment_masterModel eqptModel = new Equipment_masterModel();
                return View("_AddNew", eqptModel);
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex;
                return View();

            }
        }

        [HttpPost]
        public ActionResult AddEqpt(Equipment_masterModel eqptModel)
        {
            if (ModelState.IsValid)
            {
                int iCreated = 0;
                try
                {
                    iCreated = businessLayer.AddEqpt(eqptModel);
                    if (iCreated == 1)
                        return Json(new { success = true, title = "New Equipment Status", message = "New Equipment Added" });
                    else
                    {
                        return Json(new { success = false, title = "New equipment status", message = "Error while inserting the record" });
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message += ex;
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json(new { success = false, title = "Validation", message = "Validation Error" });

            }

        }
        [HttpPost]
        public ActionResult Update(Equipment_masterModel eqptModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(eqptModel.EquipmentPartId))
                {
                    int update = businessLayer.Update_Eqpt(eqptModel);
                    if (update == 1)
                    {
                        TempData["msg"] = "Updated Successfully";
                        TempData["no"] = eqptModel.EquipmentPartId;
                        return RedirectToAction("Eqpt_Index");
                    }
                    else
                    {
                        TempData["msg"] = "Update Failed";
                        return RedirectToAction("Eqpt_Index");
                    }

                }
                TempData["msg"] = "Failed..Try Again";
                return RedirectToAction("Dean_Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message += ex;
                TempData["msg"] = ex;
                return RedirectToAction("Eqpt_Index");
            }
        }

    }
}