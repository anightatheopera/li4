using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
    public class FeiraModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Data_inicio { get; set; }
        public string Data_fim { get; set; }
        public int N_Barracas { get; set; }
        public int Id_Feira { get; set; }
        public int Id_Organizador { get; set; }
        public virtual UtilizadorModel Organizador { get; set; }
    }
}
