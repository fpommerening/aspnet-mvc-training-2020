using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FP.AspNetTraining.PersonsWebApp.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        [Route("demo/{myid:range(1,20)}")]
        public ActionResult RouteByRange_1_20(int myid)
        {
            return Content($"First Range {myid}");
        }

        [Route("demo/{myid:range(21,40)}")]
        public ActionResult RouteByRange_21_40(int myid)
        {
            return Content($"Second Range {myid}");
        }
    }
}