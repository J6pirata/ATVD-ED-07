using System;

class Program
{
    static void Main()
    {
    
        Medicamentos medicamentos = new Medicamentos();

        int opcao;
        do
        {
  
            Console.WriteLine("Menu de Operações:");
            Console.WriteLine("0. Finalizar processo");
            Console.WriteLine("1. Cadastrar medicamento");
            Console.WriteLine("2. Consultar medicamento (sintético)");
            Console.WriteLine("3. Consultar medicamento (analítico)");
            Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
            Console.WriteLine("5. Vender medicamento (abater do lote mais antigo)");
            Console.WriteLine("6. Listar medicamentos (informando dados sintéticos)");

           
            Console.Write("Escolha a opção: ");
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                   
                    CadastrarMedicamento(medicamentos);
                    break;

                case 2:
                    
                    ConsultarMedicamentoSintetico(medicamentos);
                    break;

                case 3:
                    
                    ConsultarMedicamentoAnalitico(medicamentos);
                    break;

                case 4:
                 
                    ComprarMedicamento(medicamentos);
                    break;

                case 5:
                   
                    VenderMedicamento(medicamentos);
                    break;

                case 6:
                    
                    ListarMedicamentos(medicamentos);
                    break;

                case 0:
                    
                    Console.WriteLine("Processo finalizado.");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (opcao != 0);
    }

 
    static void CadastrarMedicamento(Medicamentos medicamentos)
    {
        Console.Write("Digite o ID do medicamento: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Digite o nome do medicamento: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o laboratório do medicamento: ");
        string laboratorio = Console.ReadLine();

    
        Medicamento novoMedicamento = new Medicamento(id, nome, laboratorio);

    
        medicamentos.Adicionar(novoMedicamento);

        Console.WriteLine("Medicamento cadastrado com sucesso!");
    }

    
    static void ConsultarMedicamentoSintetico(Medicamentos medicamentos)
    {
        Console.Write("Digite o ID do medicamento a ser consultado: ");
        int idConsulta = int.Parse(Console.ReadLine());

      
        Medicamento medicamentoConsulta = new Medicamento(idConsulta, "", "");

    
        Medicamento resultadoConsulta = medicamentos.Pesquisar(medicamentoConsulta);

       
        if (!resultadoConsulta.Equals(new Medicamento()))
        {
            Console.WriteLine($"Medicamento encontrado: {resultadoConsulta.ToString()}");
        }
        else
        {
            Console.WriteLine("Medicamento não encontrado na lista.");
        }
    }


    static void ConsultarMedicamentoAnalitico(Medicamentos medicamentos)
    {
        Console.Write("Digite o ID do medicamento a ser consultado: ");
        int idConsulta = int.Parse(Console.ReadLine());

   
        Medicamento medicamentoConsulta = new Medicamento(idConsulta, "", "");

      
        Medicamento resultadoConsulta = medicamentos.Pesquisar(medicamentoConsulta);

      
        if (!resultadoConsulta.Equals(new Medicamento()))
        {
            Console.WriteLine($"Medicamento encontrado: {resultadoConsulta.ToString()}");
            Console.WriteLine("Lotes:");
            foreach (Lote lote in resultadoConsulta.ListaLotes)
            {
                Console.WriteLine($"  {lote.ToString()}");
            }
        }
        else
        {
            Console.WriteLine("Medicamento não encontrado na lista.");
        }
    }

    static void ComprarMedicamento(Medicamentos medicamentos)
    {
        Console.Write("Digite o ID do medicamento a ser comprado: ");
        int idCompra = int.Parse(Console.ReadLine());

   
        Medicamento medicamentoCompra = new Medicamento(idCompra, "", "");

     
        Medicamento resultadoCompra = medicamentos.Pesquisar(medicamentoCompra);

        if (!resultadoCompra.Equals(new Medicamento()))
        {
            Console.Write("Digite a quantidade a ser comprada: ");
            int qtdeCompra = int.Parse(Console.ReadLine());

            Console.Write("Digite a data de vencimento do lote (dd/MM/yyyy): ");
            DateTime dataVencimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            
            Lote novoLote = new Lote(resultadoCompra.ProximaIdLote(), qtdeCompra, dataVencimento);

            resultadoCompra.Comprar(novoLote);

            Console.WriteLine("Compra realizada com sucesso!");
        }
        else
        {
            Console.WriteLine("Medicamento não encontrado na lista.");
        }
    }

    static void VenderMedicamento(Medicamentos medicamentos)
    {
        Console.Write("Digite o ID do medicamento a ser vendido: ");
        int idVenda = int.Parse(Console.ReadLine());

        Medicamento medicamentoVenda = new Medicamento(idVenda, "", "");

        Medicamento resultadoVenda = medicamentos.Pesquisar(medicamentoVenda);

     
        if (!resultadoVenda.Equals(new Medicamento()))
        {
            Console.Write("Digite a quantidade a ser vendida: ");
            int qtdeVenda = int.Parse(Console.ReadLine());

            bool vendaSucesso = resultadoVenda.Vender(qtdeVenda);

            
            if (vendaSucesso)
            {
                Console.WriteLine($"Venda de {qtdeVenda} unidades realizada com sucesso.");
            }
            else
            {
                Console.WriteLine($"Não há quantidade disponível para a venda de {qtdeVenda} unidades.");
            }
        }
        else
        {
            Console.WriteLine("Medicamento não encontrado na lista.");
        }
    }

    static void ListarMedicamentos(Medicamentos medicamentos)
    {
        Console.WriteLine("Medicamentos na lista:");
        foreach (Medicamento medicamento in medicamentos.ListaMedicamentos)
        {
            Console.WriteLine($"  {medicamento.ToString()}");
        }
    }
}