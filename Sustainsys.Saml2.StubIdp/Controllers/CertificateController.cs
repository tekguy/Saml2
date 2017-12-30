﻿using System.IO;
using System.Net.Mime;
using System.Web.Mvc;

namespace Sustainsys.Saml2.StubIdp.Controllers
{
    public class CertificateController : Controller
    {
        public ActionResult Index()
        {
            var path = Request.Url.Host == "stubidp.Sustainsys.se"
                ? HttpContext.Server.MapPath("~\\App_Data\\Sustainsys.Saml2.StubIdp.cer")
                : HttpContext.Server.MapPath("~\\App_Data\\stubidp.sustainsys.com.cer");

            var disposition = new ContentDisposition { Inline = false, FileName = Path.GetFileName(path) };
            Response.AppendHeader("Content-Disposition", disposition.ToString());
            return File(path, MediaTypeNames.Text.Plain);
        }
    }
}