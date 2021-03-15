using SQLProgrammability.Models;
using SQLProgrammability.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLProgrammability.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //SQLPro db = new SQLPro();
            //db.ProFunction.Count();

            return View();
        }
		[HttpPost]
		public ActionResult Index(ProStoredProcedure proSP)
		{
			ViewBag.Title = "Home Page";

			ViewBag.Name = "";
			if (!string.IsNullOrWhiteSpace(proSP.Name))
			{
				ViewBag.Name = proSP.Name;
			}
			ViewBag.EXECUTE = "";
			if (!string.IsNullOrWhiteSpace(proSP.Execute))
			{
				ViewBag.EXECUTE = proSP.Execute;
			}
			ViewBag.content = "";
			if (!string.IsNullOrWhiteSpace(proSP.Content))
			{
				ViewBag.content = proSP.Content;
			}
			ViewBag.remark = "";
			if (!string.IsNullOrWhiteSpace(proSP.Remark))
			{
				ViewBag.remark = proSP.Remark;
			}
			ViewBag.tags = "";
			if (!string.IsNullOrWhiteSpace(proSP.Tags))
			{
				ViewBag.tags = proSP.Tags;
			}

			ViewBag.AJAXparams = getAJAXparams(proSP);

			return View();
		}

		private string getAJAXparams(ProStoredProcedure proSP)
		{
			List<string> aJAX_Params = new List<string>();

			if (!string.IsNullOrWhiteSpace(proSP.Name))
			{
				aJAX_Params.Add("Name=" + proSP.Name);
			}
			if (!string.IsNullOrWhiteSpace(proSP.Execute))
			{
				if (string.IsNullOrWhiteSpace(proSP.Name))
				{
					aJAX_Params.Add("Name=");
				}
				aJAX_Params.Add("Execute=" + proSP.Execute);
			}
			if (!string.IsNullOrWhiteSpace(proSP.Content))
			{
				if (string.IsNullOrWhiteSpace(proSP.Name))
				{
					aJAX_Params.Add("Name=");
				}
				if (string.IsNullOrWhiteSpace(proSP.Execute))
				{
					aJAX_Params.Add("Execute=");
				}
				aJAX_Params.Add("Content=" + proSP.Content);
			}
			if (!string.IsNullOrWhiteSpace(proSP.Remark))
			{
				if (string.IsNullOrWhiteSpace(proSP.Name))
				{
					aJAX_Params.Add("Name=");
				}
				if (string.IsNullOrWhiteSpace(proSP.Execute))
				{
					aJAX_Params.Add("Execute=");
				}
				if (string.IsNullOrWhiteSpace(proSP.Content))
				{
					aJAX_Params.Add("Content=");
				}
				aJAX_Params.Add("Remark=" + proSP.Remark);
			}
			if (!string.IsNullOrWhiteSpace(proSP.Tags))
			{
				if (string.IsNullOrWhiteSpace(proSP.Name))
				{
					aJAX_Params.Add("Name=");
				}
				if (string.IsNullOrWhiteSpace(proSP.Execute))
				{
					aJAX_Params.Add("Execute=");
				}
				if (string.IsNullOrWhiteSpace(proSP.Content))
				{
					aJAX_Params.Add("Content=");
				}
				if (string.IsNullOrWhiteSpace(proSP.Remark))
				{
					aJAX_Params.Add("Remark=");
				}
				aJAX_Params.Add("Tags=" + proSP.Tags);
			}

			if (aJAX_Params.Count > 0)
			{
				return "?" + string.Join("&", aJAX_Params);
			}
			else
			{
				return "";
			}
		}
	}
}
