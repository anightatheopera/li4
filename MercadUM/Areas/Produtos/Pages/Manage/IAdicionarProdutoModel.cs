﻿using MercadUM.Model;

namespace MercadUM.Areas.Produtos.Pages.Manage
{
    public interface IAdicionarProdutoModel
    {
        Task<List<ApplicationProduto>> GetProdutos();
        Task InsertProduto(ApplicationProduto produto);
        Task<List<ApplicationProduto>> GetProdutosByBarraca(string Id_Barraca);
    }
}