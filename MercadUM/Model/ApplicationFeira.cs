

namespace MercadUM.Model
{
    public class ApplicationFeira
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Data_inicio { get; set; }
        public string Data_fim { get; set; }
        public int N_Barracas { get; set; }
        public string Id_Feiras { get; set; }
        public string Id_Organizador { get; set; }
        public virtual ApplicationUser Organizador { get; set; }
        public virtual List<ApplicationBarraca> Barracas { get; set; }

    }
}
