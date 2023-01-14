using Microsoft.AspNetCore.Identity;

namespace MercadUM.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Pagamento { get; set; }
        public string DataNascimento { get; set; }
        public string TipoDeConta { get; set; }

    }
}
