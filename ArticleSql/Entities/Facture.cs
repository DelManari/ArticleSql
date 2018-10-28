using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleSql.Entities
{
    class Facture
    {
       public int id;
       public string reference;
       public string date;
        public LigneFacture[] Articles;

        public Facture(int id, string refe, string date)
        {
            this.id = id;
            this.reference = refe;
            this.date = date;
        }
        public Facture( string refe, string date)
        {
            
            this.reference = refe;
            this.date = date;
        }
        public Facture(int id, string refe,string date,LigneFacture[] articles)
        {
            this.id = id;
            this.reference = refe;
            this.date = date;
            this.Articles = articles;
        }
        public Facture() { }
    }
}
