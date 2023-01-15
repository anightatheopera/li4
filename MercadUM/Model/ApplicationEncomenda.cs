namespace MercadUM.Model
{
    public class ApplicationEncomenda
    {
        public string Id_encomenda { get; set; }
        public string Data { get; set; }
        public double Preco_total { get; set; }
        public string Id_utilizador { get; set; }
        public string Id_barraca { get; set; }
        public virtual ApplicationUser Utilizador { get; set; }
        public virtual ApplicationBarraca Barraca { get; set; }
        public string Id_produto { get; set; }
        public List<ApplicationProduto> Produtos { get; set; }

        public string PK { get; set; }
    }
}
