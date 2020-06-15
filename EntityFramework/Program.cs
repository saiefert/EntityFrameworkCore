using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            //RecuperarProdutos();
            ExcluirProdutos();
            //RecuperarProdutos();
            AualizarProduto();
        }

        private static void AualizarProduto()
        {
            // incluir um poduto
            GravarUsandoEntity();
            RecuperarProdutos();

            // aualizar o produto

            using (var repo = new ProdutoDAOEntity())
            {
                Produto primeiro = repo.Produtos().First();
                primeiro.Nome = "Senhor dos anéis - Editado";
                repo.Atualizar(primeiro);
            }

            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();

                foreach (var item in produtos)
                {
                    repo.Remover(item);
                }
            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                Console.WriteLine("foram encontrados {0} produto(s).", produtos.Count);

                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "O Senhor Dos Anéis";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var contexto = new ProdutoDAOEntity())
            {
                contexto.Adicionar(p);
            }
        }      
    }
}
