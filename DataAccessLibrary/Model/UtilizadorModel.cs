namespace DataAccessLibrary.Model
{
    public class UtilizadorModel
    {
        public string Id_Utilizador { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Morada { get; set; }
        public string Telemovel { get; set; }
        public string DataNascimento { get; set; }
        public string Pagamento { get; set; }
        public string Tipo_de_conta { get; set; }

        public bool isOrganizador(UtilizadorModel u)
        {
            return u.Tipo_de_conta == "Organizador";
        }

        public bool isVendedor(UtilizadorModel u)
        {
            return u.Tipo_de_conta == "Vendedor";
        }

        public bool isCliente(UtilizadorModel u)
        {
            return u.Tipo_de_conta == "Cliente";
        }

    }
}
