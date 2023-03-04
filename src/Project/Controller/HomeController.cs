using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webhooktest.Models;
using System.Diagnostics;
using System.Text;

namespace webhooktest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
       
        public ActionResult TestWebhook1(string type)
        {
            var readJsonData = new StreamReader(HttpContext.Request.InputStream);

            readJsonData.BaseStream.Seek(0, SeekOrigin.Begin);
            var webHookResponse = readJsonData.ReadToEnd();

            RootJson myDeserializedClass = JsonConvert.DeserializeObject<RootJson>(webHookResponse);
            myDeserializedClass.Type = type;
            myDeserializedClass.dateTime = DateTime.Now;
            string ItemName = myDeserializedClass.Item.Name;
            string ItemID = myDeserializedClass.Item.Id;
            string EventName = myDeserializedClass.EventName;
            string Date = myDeserializedClass.dateTime.ToString();
           string Type = myDeserializedClass.Type;
            string root = @"C:\Temp\";
            string fileName = @"C:\Temp\webhookdetail.txt";

            try
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                if (!System.IO.File.Exists(fileName))
                {
                    System.IO.File.Create(fileName);
                    using(StreamWriter sw = System.IO.File.AppendText(fileName))
                    {
                        sw.WriteLine("\n" + "NEW ITEM HAS BEEN CREATED" + "\n" + "Item Name: " + ItemName + "\n" + "Item ID: " + ItemID + "\n" + "Event Name: " + EventName + "\n" + "Type: " + Type + "\n" + "Date: " + Date);
                        sw.Close();
                    }
                 
                }
                else
                {
                    using (StreamWriter sw = System.IO.File.AppendText(fileName))
                    {
                        sw.WriteLine("\n" + "NEW ITEM HAS BEEN CREATED" + "\n" + "Item Name: " + ItemName + "\n" + "Item ID: " + ItemID + "\n" + "Event Name: " + EventName + "\n" + "Type: " + Type + "\n" + "Date: " + Date);
                        sw.Close();
                    }
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            System.IO.File.AppendAllText("C:\\New folder\\temp1.txt", "\n" + "NEW ITEM HAS BEEN CREATED" + "\n" + "Item Name: " + ItemName + "\n" + "Item ID: " + ItemID + "\n" + "Event Name: " + EventName + "\n" + "Type: " + Type + "\n" + "Date: " + Date);

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "success" };
        }
        public ActionResult webhookTeams(string type)
        {
            var readJsonData = new StreamReader(HttpContext.Request.InputStream);

            readJsonData.BaseStream.Seek(0, SeekOrigin.Begin);
            var webHookResponse = readJsonData.ReadToEnd();

            RootJson myDeserializedClass = JsonConvert.DeserializeObject<RootJson>(webHookResponse);
            myDeserializedClass.Type = type;
            myDeserializedClass.dateTime = DateTime.Now;
            string ItemName = myDeserializedClass.Item.Name;
            string ItemID = myDeserializedClass.Item.Id;
            string EventName = myDeserializedClass.EventName;
            string Date = myDeserializedClass.dateTime.ToString();
            string Type = myDeserializedClass.Type;
            string root = @"C:\Temp\";
            string fileName = @"C:\Temp\webhookdetail.txt";

            try
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                if(!System.IO.File.Exists(fileName))
                {
                    System.IO.File.Create(fileName);
                    System.IO.File.AppendAllText(fileName, "\n" + "NEW ITEM HAS BEEN CREATED" + "\n" + "Item Name: " + ItemName + "\n" + "Item ID: " + ItemID + "\n" + "Event Name: " + EventName + "\n" + "Type: " + Type + "\n" + "Date: " + Date);
                }
                else {
                    System.IO.File.AppendAllText(fileName, "\n" + "NEW ITEM HAS BEEN CREATED" + "\n" + "Item Name: " + ItemName + "\n" + "Item ID: " + ItemID + "\n" + "Event Name: " + EventName + "\n" + "Type: " + Type + "\n" + "Date: " + Date);
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            System.IO.File.AppendAllText("C:\\New folder\\temp1.txt", "\n" + "NEW ITEM HAS BEEN CREATED" + "\n" + "Item Name: " + ItemName + "\n" + "Item ID: " + ItemID + "\n" + "Event Name: " + EventName + "\n" + "Type: " + Type + "\n" + "Date: " + Date);

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "success" };
        }

    }
}
