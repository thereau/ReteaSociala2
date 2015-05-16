using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.Results;

namespace ReteaSocialaMDS.Models.Teste
{
    public class TesteIndexMVVM
    {
        [StringLength(30),Required(ErrorMessage = "Trebuie sa furnizezi un nume")]
        public string Nume { get; set; }
        [StringLength(30),Required(ErrorMessage = "Trebuie sa furnizezi un prenume")]
        public string Prenume { get; set; }
        [Range(14, 120, ErrorMessage = "Trebuie sa ai cel putin 14 ani pentru a te putea inregistra pe acest site")]
        public int Varsta { get; set; }
        public bool? Admin { get; set; }
        public bool EmailConfirmat { get; set; }
        
        public int? VechimeForum { get; set; }
    }
}