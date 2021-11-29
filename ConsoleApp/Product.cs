using ConsoleApp.Collections;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Product
    {
        public Product()
        {
            _id = Bson.GenerateNewId();
            Status = "Available";
            RegistrationDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss").ToString();
        }
        public string _id { get; set; }
        public string Status { get; set; }
        public Site Site { get; set; }
        public string Address { get; set; }
        public Category Category { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public List<Image> ImageList { get; set; }
        public Seller Seller { get; set; }
        public Delivery Delivery { get; set; }
        public Option Option { get; set; }
        public Detail Detail { get; set; }
        public string RegistrationDate { get; set; }
        public string ModificationDate { get; set; }
    }


}
