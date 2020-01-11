using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SampleMVCApp.Controllers
{
    public class HelloController : Controller
    {
        public List<string> list;

        public HelloController() {
            list = new List<string>();
            list.Add("Japan");
            list.Add("USA");
            list.Add("UK");
        }

        [HttpGet("Hello/{id?}/{name?}")]
        public IActionResult Index()
        {
            ViewData["message"] = "※テーブルの表示";
            ViewData["header"] = new string[] {"id", "name", "mail"};
            ViewData["data"] = new string[][] {
                new string[] {"1", "Taro", "taro@yamada"},
                new string[] {"2", "Hanako", "hanako@flower"},
                new string[] {"3", "Sachiko", "sachiko@happy"}
            };
            return View();
        }


        [HttpPost]
        public IActionResult Form() {
            string[] res = (string[])Request.Form["list"];
            string msg = "※";
            foreach(var item in res) {
                msg += "「" + item + "」";
            }
            ViewData["message"] = msg + " selected.";
            ViewData["list"] = Request.Form["list"];
            ViewData["listdata"] = list;
            return View("Index");
        }

        private byte[] ObjectToBytes(MyData ob)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, ob);
            return ms.ToArray();
        }

        private object BytesToObject(byte[] arr)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            ms.Write(arr, 0, arr.Length);
            ms.Seek(0, SeekOrigin.Begin);
            return (Object)bf.Deserialize(ms);
        }

    }

    [Serializable]
    class MyData {
        public int Id = 0;
        public string Name = "";

        public MyData(int id, string name) {
            this.Id = id;
            this.Name = name;
        }

        override public string ToString() {
            return "<" + Id + ": " + Name + ">";
        }
    }
}