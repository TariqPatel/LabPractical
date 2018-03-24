using Lab.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(HttpPostedFileBase file)
		{
			if (file != null && file.ContentLength > 0)
			{
				try
				{
					if (Path.GetExtension(file.FileName)?.Substring(1) != "csv")
					{
						ViewBag.Message = "Please upload a file of type CSV.";
						return View();
					}
					
					string inputContent;
					using (var inputStreamReader = new StreamReader(file.InputStream))
					{
						inputContent = inputStreamReader.ReadToEnd();
					}
					ViewBag.Message = LabFunctions.GetLeader(inputContent);
				}
				catch (Exception ex)
				{
					ViewBag.Message = "ERROR:" + ex.Message;
				}
			}
			else
			{
				ViewBag.Message = "You have not specified a file.";
			}
			return View();
		}
		
	}
}