namespace DataAccessLibrary.Model
{
    public class BarracaModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Id_Barraca { get; set; }
        public string Url_logotipo { get; set; }
        public int Id_Vendedor { get; set; }

        public int Id_Feira { get; set; }
        public virtual UtilizadorModel Vendedor { get; set; }
        public virtual FeiraModel Feira { get; set; }

    }
}
