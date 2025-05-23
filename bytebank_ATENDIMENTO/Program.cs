using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Collections;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

Cliente t1 = new Cliente();
t1.Nome = "André Silva";
t1.Cpf = "123.456.789-00";
t1.Profissao = "Desenvolvedor C#";

Cliente t2 = new Cliente();
t2.Nome = "Ana Maria";
t2.Cpf = "987.654.321-00";
t2.Profissao = "Gerente de Vendas";

Cliente t3 = new Cliente();
t3.Nome = "Carlos Alberto";
t3.Cpf = "456.789.123-00";
t3.Profissao = "Analista de Sistemas";

Cliente t4 = new Cliente();
t4.Nome = "Maria Clara";
t4.Cpf = "321.654.987-00";
t4.Profissao = "Analista de Sistemas";



List<ContaCorrente> _listaDeContas1 = new List<ContaCorrente>()
{
    new ContaCorrente(874, "7781438-C") { Titular = t3, Saldo = 300.0},
    new ContaCorrente(874, "7781438-D") { Titular = t4, Saldo = 400.0},
    new ContaCorrente(874, "5679787-A") { Titular = t1, Saldo = 100.0},
    new ContaCorrente(874, "4456668-B") {Titular = t2, Saldo = 200.0},

};

void AtendimentoCliente()
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
            } catch (Exception ex)
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
                default:
                    Console.WriteLine("Opção não implementada");
                    break;
            }
        }
    } catch (ByteBankException ex)
    {
        Console.WriteLine($"{ex.Message}");
    }

}

void PesquisarContas()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===    PESQUISAR CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.Write("Deseja pesquisar por (1) NUMERO DA CONTA ou (2)CPF TITULAR ? ");

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
        default:
            Console.WriteLine("Opção não implementada.");
            break;
    }
}

ContaCorrente ConsultaPorCPFTitular(string? cpf)
{
    ContaCorrente conta = null;
    for (int i = 0; i < _listaDeContas1.Count; i++)
    {
        if (_listaDeContas1[i].Titular.Cpf.Equals(cpf))
        {
            conta = _listaDeContas1[i];
        }
    }
    return conta;
}

ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
{
    ContaCorrente conta = null;
    for (int i = 0; i < _listaDeContas1.Count; i++)
    {
        if (_listaDeContas1[i].Conta.Equals(numeroConta))
        {
            conta = _listaDeContas1[i];
        }
    }

    return conta;
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

    foreach(var item in _listaDeContas1)
    {
        if (item.Conta.Equals(numeroConta))
        {
            conta = item;
        }
    }

    if(conta != null)
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
        Console.WriteLine("===  Dados da Conta  ===");
        Console.WriteLine("Número da Conta : " + item.Conta);
        Console.WriteLine("Saldo da Conta : " + item.Saldo);
        Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
        Console.WriteLine("CPF do Titular  : " + item.Titular.Cpf);
        Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
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
    Console.Write("Número da conta: ");
    string numeroConta = Console.ReadLine();

    Console.Write("Número da Agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

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

AtendimentoCliente();
#region
//List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
//{
//    new ContaCorrente(874, "5679787-A"),
//    new ContaCorrente(874, "4456668-B"),
//    new ContaCorrente(874, "7781438-C")
//};

//List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
//{
//    new ContaCorrente(951, "5679787-E"),
//    new ContaCorrente(321, "4456668-F"),
//    new ContaCorrente(719, "7781438-G")
//};

//_listaDeContas2.AddRange(_listaDeContas3);
//_listaDeContas2.Reverse();

//for (int i = 0; i < _listaDeContas2.Count; i++)
//{
//    ContaCorrente conta = _listaDeContas2[i];
//    Console.WriteLine($"Indice [{i}] = Conta [{_listaDeContas2[i].Conta}]");
//}

//Console.WriteLine("\n\n");

//var range = _listaDeContas3.GetRange(0, 1);
//for (int i = 0; i < range.Count; i++)
//{
//    ContaCorrente conta = range[i];
//    Console.WriteLine($"Indice [{i}] = Conta [{range[i].Conta}]");
//}

//Console.WriteLine("\n\n");

//_listaDeContas3.Clear();
//for (int i = 0; i < _listaDeContas3.Count; i++)
//{
//    Console.WriteLine($"Indice [{i}] = Conta [{_listaDeContas3[i].Conta}]");
//}
#endregion

#region
////ListaDeContaCorrente listaDeContas = new ListaDeContaCorrente();

//void TestaArrayDeContasCorrentes()
//{
//    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
//    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
//    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
//    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
//    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
//    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
//    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
//    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
//    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
//    var contaDoAndre = new ContaCorrente(963, "123456-X");
//    listaDeContas.Adicionar(contaDoAndre);
//    //listaDeContas.ExibeLista();
//    //Console.WriteLine("============");
//    //listaDeContas.Remover(contaDoAndre);
//    //listaDeContas.ExibeLista();

//    for(int i = 0; i < listaDeContas.Tamanho; i++)
//    {
//        ContaCorrente conta = listaDeContas[i];
//        Console.WriteLine($"Indice[{i}]: {conta.Conta} / {conta.Numero_agencia}");
//    }
//}

////ContaCorrente maiorSaldo = listaDeContas.GetMaiorSaldo();
////Console.WriteLine($"O maior saldo é: {maiorSaldo}");

////TestaArrayDeContasCorrentes();
#endregion