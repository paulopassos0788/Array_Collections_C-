using bytebank_ATENDIMENTO.ByteBank.Atendimento;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

ByteBankAtendimento atendimento = new ByteBankAtendimento();
atendimento.AtendimentoCliente();

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