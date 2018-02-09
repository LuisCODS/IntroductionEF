using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IntroductionEF.Models
{
    public class Prof
    {
        //ATTRIBUTS
        [Key]
        public int PKProfID { get; set; }

        [MaxLength(30), Required, Index(IsUnique =true)]
        public string  nom { get; set; }

        //1 prof donne plusieurs cours
        public ICollection<Cours> Cours { get; set; }

    }//din class



    //CLASSE QUI CREER LA BD
    public class Cegep: DbContext {
        //CONTRUCTEUR
         public Cegep() : base("CS")
        {
            //get stringConnection from base
        }
        //ATTRIBUTS
        public DbSet<Prof> Profs { get; set; }
        public DbSet<Cours> Cours { get; set; }

    }//fin class



    public class Cours {

        [Key]
        public int PKCoursID { get; set; }

        [Required, MaxLength(20)]
        public string Nom { get; set; }

        [ForeignKey("Prof"), Display(Name = "Prof")]
        public int FKProfID { get; set; }

        //1 cours est relié à un seul prof:clé étrangere
        [ForeignKey("FKProfID")]
        public Prof Prof { get; set; }

    }//fin class

}//FIN namespace