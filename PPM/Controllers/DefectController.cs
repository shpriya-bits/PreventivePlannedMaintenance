using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace PPM.Controllers
{
    public class DefectController : Controller
    {
        PPM_BusinessLayer businessLayer = new PPM_BusinessLayer();
        public IActionResult Defect_Index()
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
            var defectDetails = businessLayer.Defect_details(search, sortColumn, sortColumnDir, col);
            recordsTotal = defectDetails.Count();
            var data = defectDetails.ToList();
            if (pageSize != -1)
            {
                data = defectDetails.Skip(skip).Take(pageSize).ToList();
            }
            var json = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(json);

        }


    }
}