using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Util;

public class ListaDeContaCorrente
{
    private ContaCorrente[] _itens = null;
    private int _proximaPosicao = 0;
    public int Tamanho { get => _proximaPosicao; }

    public ListaDeContaCorrente(int tamanhoInicial = 5)
    {
        _itens = new ContaCorrente[tamanhoInicial];
    }

    public ContaCorrente[] Itens { get => _itens; set => _itens = value; }

    public void Adicionar(ContaCorrente item)
    {
        Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
        VericarCapacidade(_proximaPosicao + 1);
        _itens[_proximaPosicao] = item;
        _proximaPosicao++;
    }

    private void VericarCapacidade(int tamanhoNecessario)
    {
        if(_proximaPosicao >= _itens.Length)
        {
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];
            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
            }
            _itens = novoArray;
        }
    }

    public void Remover(ContaCorrente conta)
    {
        int indiceItem = -1;
        for (int i = 0; i < _proximaPosicao; i++)
        {
            ContaCorrente contaAtual = _itens[i];
            if (contaAtual == conta)
            {
                indiceItem = i;
                break;
            }
        }

        for (int i = indiceItem; i < _proximaPosicao - 1; i++)
        {
            _itens[i] = _itens[i + 1];
        }
        _proximaPosicao--;
        _itens[_proximaPosicao] = null;
    }

    public void ExibeLista()
    {
        for (int i = 0; i < _itens.Length; i++)
        {
            if (_itens[i] != null)
            {
                var conta = _itens[i];
                Console.WriteLine($" Indice[{i}] = " +
                    $"Conta:{conta.Conta} - " +
                    $"N° da Agência: {conta.Numero_agencia}");
            }
        }
    }

    public ContaCorrente GetMaiorSaldo() { 
        ContaCorrente maiorConta = null;
        double maiorSaldo = 0.0;

        for (int i = 0; i < _itens.Length; i++)
        {
            if (_itens[i] != null && _itens[i].Saldo > maiorSaldo)
            {
                maiorSaldo = _itens[i].Saldo;
                maiorConta = _itens[i];
            }
        }
        return maiorConta;
    }

    public ContaCorrente RecuperarContaNoIndice(int indice)
    {
        if (indice < 0 || indice >= _proximaPosicao)
        {
            throw new ArgumentOutOfRangeException(nameof(indice), "O índice não pode ser menor que zero ou maior que o número de itens na lista.");
        }
        return _itens[indice];
    }

    public ContaCorrente this[int indice]
    {
        get
        {
            return RecuperarContaNoIndice(indice);
        }
    }

}
