
namespace MercadUM.Model
{
    public class ApplicationBarraca
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string Id_Barraca { get; set; }
        public string? Url_logotipo { get; set; }
        public string Id_Vendedor { get; set; }
        public string? Id_Feira { get; set; }
        public virtual ApplicationUser Vendedor { get; set; }
        public virtual ApplicationFeira? Feira { get; set; }
    }

    
    
}
