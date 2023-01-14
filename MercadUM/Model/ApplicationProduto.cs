namespace MercadUM.Model
{
    public class ApplicationProduto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string Imagem { get; set; }
        public int Stock { get; set; }
        public string Id_Produtos { get; set; }
        public string Id_Barraca { get; set; }
        public virtual ApplicationBarraca Barraca { get; set; }
    }
}
