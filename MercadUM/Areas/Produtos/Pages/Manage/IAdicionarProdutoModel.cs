﻿using MercadUM.Model;

namespace MercadUM.Areas.Produtos.Pages.Manage
{
    public interface IAdicionarProdutoModel
    {
        Task<List<ApplicationProduto>> GetProdutos();
        Task InsertFeira(ApplicationProduto produto);
    }
}