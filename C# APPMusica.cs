// Luffy Songs 
using System.Security.Cryptography.X509Certificates;

// Variavel para dar mensgaem de boas vindas
string mensagemDeBoasVindas = "Boas vindas ao LuffySongs";

// lista aonde vamos guarda nossas bandas
//List<string> listaDeBandas = new List<string> {"Enygma", "7minutoz", "Mhrap" };

Dictionary<string, List<int>> bandasresgistradas = new Dictionary<string, List<int>>();

bandasresgistradas.Add("The beatles", new List<int>()); // Ja deixar uma banda registrada mas sem nota
bandasresgistradas.Add("U2", new List<int> { 10, 5, 2 }); // ja deixar uma banda registrada mas com notas
bandasresgistradas.Add("Elvis", new List<int> { 4, 2, 5 });


// Função aonde vamos codificar a mensagem de boas vindas
void ExibirMensagemDeBoasVindas()
{
    Console.WriteLine(@"
██╗░░░░░██╗░░░██╗███████╗███████╗██╗░░░██╗  ░██████╗░█████╗░███╗░░██╗░██████╗░░██████╗
██║░░░░░██║░░░██║██╔════╝██╔════╝╚██╗░██╔╝  ██╔════╝██╔══██╗████╗░██║██╔════╝░██╔════╝
██║░░░░░██║░░░██║█████╗░░█████╗░░░╚████╔╝░  ╚█████╗░██║░░██║██╔██╗██║██║░░██╗░╚█████╗░
██║░░░░░██║░░░██║██╔══╝░░██╔══╝░░░░╚██╔╝░░  ░╚═══██╗██║░░██║██║╚████║██║░░╚██╗░╚═══██╗
███████╗╚██████╔╝██║░░░░░██║░░░░░░░░██║░░░  ██████╔╝╚█████╔╝██║░╚███║╚██████╔╝██████╔╝
╚══════╝░╚═════╝░╚═╝░░░░░╚═╝░░░░░░░░╚═╝░░░  ╚═════╝░░╚════╝░╚═╝░░╚══╝░╚═════╝░╚═════╝░");
    Console.WriteLine(mensagemDeBoasVindas);
}

// Função aonde vamos codificar o menu
void ExibirMenu()
{
    Console.WriteLine("\ndigite 1 para registar uma banda");
    Console.WriteLine("digite 2 para mostar todas as bandas");
    Console.WriteLine("digite 3 para avaliar uma banda");
    Console.WriteLine("digite 4 para exibir a media de uma banda");
    Console.WriteLine("digite 0 para sair");

    Console.Write("\n escolha uma função: ");
    string opçãoEscolhida = Console.ReadLine()!;
    int opçãoEscolhidaNumero = int.Parse(opçãoEscolhida); 
   
    // Escolher qual função você quer fazer 
    switch(opçãoEscolhidaNumero)
    {
        case 1: Registrabanda();
            break;
        case 2: Mostarbandasregistradas();
            break;
        case 3: RegistarUmaBanda();
            break;
        case 4: Media();
            break; 
         case -1: Adeus();
            break;
        default: Console.WriteLine("opção invalida");
            break;
            
              
    }

}

// Função para registar qualquer banda 
void Registrabanda()
{
    Console.Clear(); // Limpar codigo
    ExibirTituloDasOpçoes("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    String nomedabanda = Console.ReadLine()!; // para usuario digitar
    bandasresgistradas.Add(nomedabanda, new List<int>()); // Registar a banda sem nota
    Console.WriteLine("\n"); // Pular linha
    Console.WriteLine($"A banda {nomedabanda} foi resgitrada com sucesso"); // registro da banda
    Thread.Sleep(3000); // Função para esperar 
    Console.Clear();
    ExibirMensagemDeBoasVindas(); // exibir mensagem de boas vindas e o menu
    ExibirMenu();


}
// Mostrar a banda registrada
void Mostarbandasregistradas()
{
Console.Clear();
    ExibirTituloDasOpçoes("Exibindo todas as bandas registradas");
   // for (int i = 0; i < listaDeBandas.Count; i++)
    //{
      //  Console.WriteLine($"Bandas: {listaDeBandas[i]}\n"); 

    //}
    foreach(string banda in bandasresgistradas.Keys) // Pegar so as "chaves" "nome das bandas" no for
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("Digite uma tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
}

// Exibir os asteristicos em cima das opçores
void ExibirTituloDasOpçoes(string titulo)
{
    int Quantidadedeletras = titulo.Length;
    string asteristicos = string.Empty.PadLeft(Quantidadedeletras, '*');
    Console.WriteLine(asteristicos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteristicos );
    Console.WriteLine();
}

 void RegistarUmaBanda()
{
  Console.Clear();
    ExibirTituloDasOpçoes("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine();
    if (bandasresgistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que você dara a {nomeDaBanda}"); 
        int nota = int.Parse(Console.ReadLine()!);
        bandasresgistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} para a banda {nomeDaBanda} foi registrada com sucesso");
        Thread.Sleep(5000);
        Console.Clear() ;
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrado");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMensagemDeBoasVindas();
        ExibirMenu();
    }
    
}

void Adeus()
{
    Console.WriteLine("tchau tchau");
}

void Media() {
    Console.Clear();
    ExibirTituloDasOpçoes("exibir a media da banda");
    Console.Write("Digite o nome da banda que deseja ver a media: "); 
    string media = Console.ReadLine()!;
    if(bandasresgistradas.Keys.Contains(media))
    {
        List<int> nota = bandasresgistradas[media];
        Console.WriteLine($"A media da banda {media} é {nota.Average()}."); // "Avarage" serve para fazer uma media, Divisão
        Console.WriteLine("Digite uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
 
    }
    else
    {
        Console.WriteLine($"\nA banda {media} não foi encontrado");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMensagemDeBoasVindas();
        ExibirMenu();
    }
}

ExibirMensagemDeBoasVindas();
ExibirMenu();
Mostarbandasregistradas();
