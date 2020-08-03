using Aula1Manha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Aula1Manha.DAL
{
    class PedidoDAO
    {

        Pedido p = new Pedido();
        Context ctx = new Context();


        public void Menu()
        {
            int menu = 1;
            while (menu != 0)
            {
                Console.WriteLine("\t -- MENU --");
                Console.WriteLine("\t (1) Cadastrar um pedido");
                Console.WriteLine("\t (2) Listar pedidos cadastrados");
                Console.WriteLine("\t (3) Buscar pedidos cadastrados ");
                Console.WriteLine("\t (4) Editar pedidos cadastrados ");
                Console.WriteLine("\t (5) Excluir pedidos cadastrados");
                Console.WriteLine("\t (0) Sair\n\n");
                int opcao = Convert.ToInt32(Console.ReadLine());


                switch (opcao)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        Listar();
                        break;
                    case 3:
                        Buscar();
                        break;
                    case 4:
                         Alterar();
                        break;
                    case 5:
                        Excluir();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void Cadastrar()
        {

            Console.WriteLine("\t-- CADASTRO DE PEDIDOS --");
            Console.WriteLine("Digite o numero de produtos que deseja cadastrar: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Digite o nome do Produto: ");
                p.Produto = Console.ReadLine();
                Console.WriteLine("Digite a quantidade do Produto: ");
                p.Quantidade = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite o valor do Produto: ");
                p.Valor = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Digite o nome do Fornecedor: ");
                p.Fornecedor = Console.ReadLine();
                Console.WriteLine("Digite a data do cadastro: ");
                p.Data = Convert.ToDateTime(Console.ReadLine());
                ctx.Pedidos.Add(p);
                ctx.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nProduto Cadastrado com sucesso! \n\n");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        public void Listar()
        {
            List<Pedido> pedidos = ctx.Pedidos.ToList();
            Console.WriteLine("\t LISTA DE PEDIDOS\n");
            foreach (Pedido p in pedidos)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Produto: " + p.Produto);
                Console.WriteLine("Quantidade: " + p.Quantidade);
                Console.WriteLine("Valor: " + p.Valor);
                Console.WriteLine("Fornecedor: " + p.Fornecedor);
                Console.WriteLine("Data: " + p.Data);
                Console.WriteLine("------------------------------------\n");

            }
        }

        public void Buscar()
        {
            List<Pedido> pedidos = ctx.Pedidos.ToList();
            Console.WriteLine("Digite o nome do produto que deseja buscar: ");
            string busca = Console.ReadLine();
            foreach (Pedido p in pedidos)
            {
                if (busca == p.Produto )
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Produto: " + p.Produto);
                    Console.WriteLine("Quantidade: " + p.Quantidade);
                    Console.WriteLine("Valor: " + p.Valor);
                    Console.WriteLine("Fornecedor: " + p.Fornecedor);
                    Console.WriteLine("Data: " + p.Data);
                    Console.WriteLine("------------------------------------\n");
                }
                else
                {

                    Console.WriteLine("\nESSE PRODUTO NÃO EXISTE!");
                    Console.WriteLine("------------------------------------\n\n");

                }
            }
        }



        public void Excluir()
        {
            List<Pedido> pedidos = ctx.Pedidos.ToList();
            Console.WriteLine("Digite o nome do produto que deseja excluir: ");
            string exclui = Console.ReadLine();
            foreach (Pedido p in pedidos)
            {

                if (exclui == p.Produto)
                {
                    ctx.Remove(p);
                    ctx.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPRODUTO REMOVIDO!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("------------------------------------\n\n");

                }
                else
                {

                    Console.WriteLine("\nESSE PRODUTO NÃO EXISTE!");
                    Console.WriteLine("------------------------------------\n\n");


                }
            }
        }

         public List<Pedido> Alterar()
        {
            List<Pedido> pedidos = ctx.Pedidos.ToList();
            Console.WriteLine("Digite o nome do produto que deseja editar: ");
            string altera = Console.ReadLine();
            foreach (Pedido p in pedidos.ToList())
            {
                if (altera == p.Produto)
                {
                    Console.WriteLine("\n\n------------------------------------");
                    Console.WriteLine("Produto: " + p.Produto);
                    Console.WriteLine("Quantidade: " + p.Quantidade);
                    Console.WriteLine("Valor: " + p.Valor);
                    Console.WriteLine("Fornecedor: " + p.Fornecedor);
                    Console.WriteLine("Data: " + p.Data);
                    Console.WriteLine("------------------------------------\n");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Digite as novas informações do pedido:\n ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Digite o nome do Produto: ");
                    p.Produto = Console.ReadLine();
                    Console.WriteLine("Digite a quantidade do Produto: ");
                    p.Quantidade = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o valor do Produto: ");
                    p.Valor = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Digite o nome do Fornecedor: ");
                    p.Fornecedor = Console.ReadLine();
                    Console.WriteLine("Digite a data da edição: ");
                    p.Data = Convert.ToDateTime(Console.ReadLine());
                    ctx.Pedidos.Update(p);
                    ctx.SaveChanges();
                    Console.WriteLine("\nProduto alterado com sucesso!\n\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return pedidos;        } 
    }
}
        