using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleSql.Entities
{
    class LigneFacture
    {
        public int id;
        public int f;
        public int a;
        public int Quantite;
        public float prixUnit;


        public LigneFacture()
        {

        }
        public LigneFacture(int id ,int f,int a ,int quantit,float prix)
        {
            this.id = id;
            this.f = f;
            this.a = a;
            this.Quantite = quantit;
            this.prixUnit = prix;
        }
    }
}
