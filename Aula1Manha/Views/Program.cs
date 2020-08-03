using Aula1Manha.Models;
using Aula1Manha.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Aula1Manha
{
    //Bruno Henrique Martinez
    class Program
    {
        static void Main(string[] args)
        {

            PedidoDAO dao = new PedidoDAO();

            dao.Menu();
         }
        
    }
}
