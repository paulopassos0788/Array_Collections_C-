Console.WriteLine("Ex01 - Encontra um nome na lista");

List<string> nomesDosEscolhidos = new List<string>()
{
    "Bruce Wayne",
    "Carlos Vilagran",
    "Richard Grayson",
    "Bob Kane",
    "Will Farrel",
    "Lois Lane",
    "General Welling",
    "Perla Letícia",
    "Uxas",
    "Diana Prince",
    "Elisabeth Romanova",
    "Anakin Wayne"
};

void NomeEstaNaLista(List<string> lista, string nome)
{
    if (lista.Contains(nome))
    {
        Console.WriteLine($"O nome {nome} está na lista.");
    }
    else
    {
        Console.WriteLine($"O nome {nome} não está na lista.");
    }
}

NomeEstaNaLista(nomesDosEscolhidos, "Anakin Wayne");