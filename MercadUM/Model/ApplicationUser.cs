using Microsoft.AspNetCore.Identity;
using System.Drawing;

namespace MercadUM.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Pagamento { get; set; }
        public string DataNascimento { get; set; }
        public string TipoDeConta { get; set; }

    }
}
