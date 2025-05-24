using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using System.ComponentModel;

namespace bytebank_ATENDIMENTO.ByteBank.Atendimento;

public class ByteBankAtendimento
{
    Cliente t1 = new Cliente()
    {
        Nome = "André Silva",
        Cpf = "123.456.789-00",
        Profissao = "Desenvolvedor C#",
    };

    Cliente t2 = new Cliente()
    {
        Nome = "Ana Maria",
        Cpf = "987.654.321-00",
        Profissao = "Gerente de Vendas",
    };

    Cliente t3 = new Cliente()
    {
        Nome = "Carlos Alberto",
        Cpf = "456.789.123-00",
        Profissao = "Analista de Sistemas",
    };

    private List<ContaCorrente> _listaDeContas1;

    public ByteBankAtendimento()
    {
        _listaDeContas1 = new List<ContaCorrente>()
        {
            new ContaCorrente(874, "7781438-C") { Titular = t3, Saldo = 300.0},
            new ContaCorrente(874, "5679787-A") { Titular = t1, Saldo = 100.0},
            new ContaCorrente(874, "4456668-B") { Titular = t2, Saldo = 200.0},
        };
    }

    public void AtendimentoCliente()
    {
        try
        {
            char opcao = '0';
            while (opcao != '6')
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===       Atendimento       ===");
                Console.WriteLine("===1 - Cadastrar Conta      ===");
                Console.WriteLine("===2 - Listar Contas        ===");
                Console.WriteLine("===3 - Remover Conta        ===");
                Console.WriteLine("===4 - Ordenar Contas       ===");
                Console.WriteLine("===5 - Pesquisar Conta      ===");
                Console.WriteLine("===6 - Sair do Sistema      ===");
                Console.WriteLine("===============================");
                Console.WriteLine("\n\n");
                Console.Write("Digite a opção desejada: ");

                try
                {
                    opcao = Console.ReadLine()[0];
                }
                catch (Exception ex)
                {
                    throw new ByteBankException("Erro ao ler a opção do menu", ex);
                }

                switch (opcao)
                {
                    case '1':
                        CadastrarConta();
                        break;
                    case '2':
                        ListarContas();
                        break;
                    case '3':
                        RemoverContas();
                        break;
                    case '4':
                        OrdenarContas();
                        break;
                    case '5':
                        PesquisarContas();
                        break;
                    case '6':
                        EncerrarAplicacao();
                        break;
                    default:
                        Console.WriteLine("Opção não implementada");
                        break;
                }
            }
        }
        catch (ByteBankException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }

    }

    private void EncerrarAplicacao()
    {
        Console.WriteLine("Encerrando aplicação...");
        Console.ReadKey();
    }

    void PesquisarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===    PESQUISAR CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.Write("Deseja pesquisar por (1) NUMERO DA CONTA ou (2)CPF TITULAR ? (3) Nº AGÊNCIA : ");

        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                Console.Write("Informe o número da Conta: ");
                string _numeroConta = Console.ReadLine();
                ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                Console.WriteLine(consultaConta.ToString());
                Console.ReadKey();
                break;
            case 2:
                Console.Write("Informe o CPF do Titular: ");
                string _cpf = Console.ReadLine();
                ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
                Console.WriteLine(consultaCpf.ToString());
                Console.ReadKey();
                break;
            case 3:
                Console.Write("Informe o Nº da Agência: ");
                int _numeroAgencia = int.Parse(Console.ReadLine());
                var contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);
                ExibirListaDeContas(contasPorAgencia);
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Opção não implementada.");
                break;
        }
    }

    void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
    {
        if (contasPorAgencia == null)
        {
            Console.WriteLine(" ... A consulta não retornou dados ...");
        }
        else
        {
            foreach (var item in contasPorAgencia)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
    {
        var consulta = (
            from conta in _listaDeContas1
            where conta.Numero_agencia == numeroAgencia
            select conta).ToList();
        return consulta;
    }

    ContaCorrente ConsultaPorCPFTitular(string? cpf)
    {
        return _listaDeContas1.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
    }

    ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
    {
        return _listaDeContas1.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
    }

    void OrdenarContas()
    {
        _listaDeContas1.Sort();
        Console.WriteLine("Lista de contas ordenada");
        Console.ReadKey();
    }

    void RemoverContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===      REMOVER CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.Write("Informe o número da Conta: ");
        string numeroConta = Console.ReadLine();

        ContaCorrente conta = null;

        foreach (var item in _listaDeContas1)
        {
            if (item.Conta.Equals(numeroConta))
            {
                conta = item;
            }
        }

        if (conta != null)
        {
            _listaDeContas1.Remove(conta);
            Console.WriteLine("Conta removida com sucesso!");
        }
        else
        {
            Console.WriteLine("Conta não encontrada!");
        }
        Console.ReadKey();
    }

    void ListarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===     LISTA DE CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");

        if (_listaDeContas1.Count <= 0)
        {
            Console.WriteLine("Nenhuma conta cadastrada.");
            Console.ReadKey();
            return;
        }

        foreach (ContaCorrente item in _listaDeContas1)
        {
            Console.WriteLine(item.ToString());
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ReadKey();
        }
    }

    void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===   CADASTRO DE CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("=== Informe dados da conta ===");

        Console.Write("Número da Agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine());

        ContaCorrente conta = new ContaCorrente(numeroAgencia);
        Console.WriteLine($"Numero da conta [nova] : {conta.Conta}");

        Console.Write("Informe o saldo inicial: ");
        conta.Saldo = double.Parse(Console.ReadLine());

        Console.Write("Infome nome do Titular: ");
        conta.Titular.Nome = Console.ReadLine();

        Console.Write("Infome CPF do Titular: ");
        conta.Titular.Cpf = Console.ReadLine();

        Console.Write("Infome Profissão do Titular: ");
        conta.Titular.Profissao = Console.ReadLine();

        _listaDeContas1.Add(conta);

        Console.WriteLine("... Conta cadastrada com sucesso! ...");
        Console.ReadKey();
    }

}
