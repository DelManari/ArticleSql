using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleSql
{
    class Article
    {
        public int id;
        public string refi;
        public string designation;
        public float? prix;
        public int? qte ;
        public bool? promo;
        public string dateFinPromo;

      public  Article(int idd,string refii, string desi, float prixx, int qtee, bool promoo, string date)
        {
            id = idd;
            refi = refii;
            designation = desi;
            prix = prixx;
            qte = qtee;
            promo = promoo;
            dateFinPromo = date;
        }
        public Article( string refii, string desi, float prixx, int qtee, bool promoo, string date)
        {
            
            refi = refii;
            designation = desi;
            prix = prixx;
            qte = qtee;
            promo = promoo;
            dateFinPromo = date;
        }
    }
}
