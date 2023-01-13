﻿namespace DataAccessLibrary.Model
{
    public class ProdutoModel
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double? Preco { get; set; }
        public byte[]? Foto { get; set; }
        public string? UrlImagem { get; set; }
        public int? Stock { get; set; }
        public string? Id_Produto { get; set; }
        public string? Id_Barraca { get; set; }
        public virtual BarracaModel? Barraca { get; set; }
    }
}
