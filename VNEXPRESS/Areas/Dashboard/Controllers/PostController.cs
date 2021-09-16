using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using DAL.Models;
using Newtonsoft.Json;
using RestSharp;


namespace VNEXPRESS.Areas.Dashboard.Controllers
{
    public class PostController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ScanCategory()
        {
            var doc = new XmlDocument();
            doc.Load("https://vnexpress.net/rss/the-gioi.rss");

            var json = JsonConvert.SerializeXmlNode(doc);
            var myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);

            var lst = myDeserializedClass.Rss.Channel.Item.Select(item => item.Link).ToList();

            return Json(lst, JsonRequestBehavior.AllowGet);

            // return Json(new
            // {
            //     statusCode = 200,
            //     message = "Success",
            //     data = json
            // }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ScanPost()
        {
            var client = new RestClient("https://vnexpress.net/anh-harry-va-meghan-gay-tranh-cai-4357606.html");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute(request);
            
            var rx = Regex.Match(response.Content, "<article class=\"fck_detail \">(.*)<\\/article>", RegexOptions.Singleline);
            
            var result = Regex.Replace(rx.Value, "<[^>]*>", "",
                RegexOptions.IgnorePatternWhitespace,
                TimeSpan.FromSeconds(.25));
            
            result = Regex.Replace(result, @"^\s+$[\r\n]*", @"", RegexOptions.Multiline);

            return Json(result, JsonRequestBehavior.AllowGet);

            // return Json(new
            // {
            //     statusCode = 200,
            //     message = "Success",
            //     data = json
            // }, JsonRequestBehavior.AllowGet);
        }
    }
}