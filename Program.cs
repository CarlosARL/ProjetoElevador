using ProjetoElevador.Model;
using System;

namespace ProjetoElevador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Elevador elevador = new();

            ConsoleKeyInfo Operador;
            Console.WriteLine(" Quantos andares o elevador pode percorrer no prédio ?");

            int newAndares = int.Parse(Console.ReadLine());

            Console.WriteLine("Quantas pessoas o elevador comporta ?");

            int newCapacidade = int.Parse(Console.ReadLine());
            Console.Clear();

            elevador.AndaresAcessiveis = newAndares;
            elevador.Capacidade = newCapacidade;
            do
            {

                ImprimeStatusMenu(elevador);
                //NA LINHA ABAIXO O PROGRAMA IRÁ CAPTURAR A TECLA PARA REALIZAR UM COMANDO 
                Operador = Console.ReadKey();
                Console.Clear();
                Console.WriteLine("");
                //NO SWITCH A BAIXO O PROGRAMA IRÁ IDENTIFICAR A TECLA PRESSIONADA E DIRECIONAR A SUA DEVIDA FUNÇÃO
                switch (Operador.Key)
                {
                    //NESTA CASE SE ENCONTRA A FUNÇÃO ONDE O ELEVADOR IRÁ SIMULAR A SUBIDA DE ANDARES DO ELEVADOR, SENDO ATIVADA QUANDO É PRESSIONADA A SETA PARA CIMA NO TECLADO
                    case ConsoleKey.UpArrow:

                        if (elevador.OndeEsta() < elevador.AndaresAcessiveis)
                        {


                            Console.WriteLine("ESTAMOS NO "+elevador.AndarAtual+"º ANDAR");
                            elevador.Subir();
                        }
                        else
                        {
                            //SE NAO HOUVER MAIS ANDARES PARA PERCORRER O PROGRAMA ACUSA QUE ESTÁ NO ULTIMO ANDAR 
                            Console.WriteLine("ESTAMOS NO ULTIMO ANDAR ");

                        }

                        break;


                    //NESTA CASE SE ENCONTRA A FUNÇÃO ONDE O ELEVADOR IRÁ SIMULAR A DESCIDA DE ANDARES DO ELEVADOR, SENDO ATIVADA QUANDO É PRESSIONADA A SETA PARA BAIXO NO TECLADO
                    case ConsoleKey.DownArrow:


                        if (elevador.OndeEsta() > 1)
                        {

                            Console.WriteLine("DESCENDO UM ANDAR");

                            elevador.Descer();
                        }
                        else
                        {
                            //SE NAO HOUVER MAIS ANDARES PARA PERCORRER O PROGRAMA ACUSA QUE ESTÁ NO ANDAR MAIS BAIXO   
                            Console.WriteLine("ESTAMOS NO ANDAR MAIS BAIXO");
                        }
                        break;

                    //NESTA CASE SE ENCONTRA A FUNÇÃO ONDE O ELEVADOR IRÁ SIMULAR A ENTRADA DE PESSOAS NO ELEVADOR, SENDO ATIVADA QUANDO É PRESSIONADA A SETA PARA DIREITA NO TECLADO
                    case ConsoleKey.RightArrow:

                        //SO PODERÁ ENTRAR PESSOAS SE A QUANTIDADE DE VAGAS FOR MAIOR QUE 0
                        if (elevador.QuantasVagas() > 0)
                        {

                            Console.WriteLine("ENTRANDO O "+elevador.Vagas()+"º PASSAGEIRO");

                            elevador.Entrar("passageiro", 1);
                        }
                        else
                        {
                            //QUANDO A CAPACIDADE MAXIMA FOR ALCANÇADA O PROGRAMA NAO ACEITARA MAIS ENTRADA E INFORMARÁ QUE ESTÁ NA CAPACIDADE MÁXIMA 
                            Console.WriteLine(("O "+elevador.Capacidade)+"º PASSAGEIRO ENTROU, O ELEVADOR ESTÁ EM SUA CAPACIDADE MÁXIMA");
                        }

                        break;



                    case ConsoleKey.LeftArrow:

                        if (elevador.Vagas() > 0)
                        {
                            //NESTA CASE SE ENCONTRA A FUNÇÃO ONDE O ELEVADOR IRÁ SIMULAR A SAIDA DE PESSOAS NO ELEVADOR, SENDO ATIVADA QUANDO É PRESSIONADA A SETA PARA ESQUERDA NO TECLADO

                            Console.WriteLine("SAINDO UM PASSAGEIRO");
                            elevador.Sair();
                        }
                        else 
                        {
                            //QUANDO NÃO HOUVER MAIS PESSOAS NO ELEVADOR ELE INDICARÁ QUE NÃO HÁ MAIS PESSOAS E IRÁ INTERROMPER A SUBTRAÇÃO DE PASSAGEIROS NO PROGRAMA
                            Console.WriteLine("O ELEVADOR ESTÁ VAZIO");
                        } 
                       break;

                }
            } while (Operador.Key != ConsoleKey.Escape);


        }

        //NESTA CLASSE FICARÁ UMA PEQUENA PARTE VISUAL DO PROGRAMA ELEVADOR ONDE ELE MOSTRARÁ O STATUS ATUAL E OS COMANDOS ACEITOS
        static void ImprimeStatusMenu(Elevador elevador)
        {
            Console.WriteLine("");
            Console.WriteLine("STATUS ATUAL DO ELEVADOR: ");
            Console.WriteLine("                         Quantos Andares = " + elevador.AndaresAcessiveis);
            Console.WriteLine("                         Qual Andar Atual = " + elevador.AndarAtual);
            Console.WriteLine("                         Quantas Vagas = " + elevador.Capacidade);
            Console.WriteLine("                         Quantas Pessoas = " + elevador.Vagas());
            
            
            Console.WriteLine();

            Console.WriteLine("COMANDOS:                                                       ");
            Console.WriteLine("         Para Colocar pessoas dentro do Elevador Aperte Seta para Direita");
            Console.WriteLine("         Para Retirar Pessoas do Elevador Aperte Seta para Esquerda");
            Console.WriteLine("         Para Subir um Andar Aperte a Seta para Cima");
            Console.WriteLine("         Para Descer um Andar Aperte a Seta para baixo");
            Console.WriteLine("         Para Desligar o Elevador Aperte ESC");
            Console.WriteLine("Digite uma opção:");
        }
    }
}
