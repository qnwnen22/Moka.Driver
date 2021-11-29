using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Collections
{
    public class Category
    {
        public string Codes { get; set; }
        public string Names { get; set; }
    }
    public class Site
    {
        public Site() { }
        public Site(string name, string contry)
        {
            Name = name;
            Contry = contry;
        }

        public string Name { get; set; }
        public string Contry { get; set; }
    }
    public class Image
    {
        public string Address { get; set; }
    }
    public class Seller
    {
        public string Compony { get; set; }
    }
    public class Delivery
    {
        public string DeliveryCompony { get; set; }
        public decimal DeliveryFee { get; set; }
    }
    public class Option
    {
        public class Combination
        {
            public string Title { get; set; }

            public class Detail
            {
                public string Code { get; set; }
                public string Name { get; set; }
                public decimal Price { get; set; }
                public Image Image { get; set; }
            }
            public List<Detail> DetailList { get; set; }
        }
        public List<Combination> Combinations { get; set; }

        public class Indepandancy
        {
            public string Names { get; set; }
            public string Codes { get; set; }
            public decimal Price { get; set; }
            public List<Image> ImageList { get; set; }
        }
        public List<Indepandancy> Indepandancies { get; set; }
    }

    public class Detail
    {
        public string Html { get; set; }

        public class Notification
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
        public List<Notification> Notifications { get; set; }
    }
}
