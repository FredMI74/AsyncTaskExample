using System.Diagnostics;

namespace AsyncTaskExample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Função com tempo de execução simulado de 6 segundos
            // Function with simulated execution time of 6 seconds
            static async Task<string> funcF6Async()
            {
                Console.WriteLine("Início/Start f6");
                await Task.Delay(6000);
                Console.WriteLine("Fim/End f6");
                return "Resultado/Result f6";
            }

            // Função com tempo de execução simulado de 2 segundos
            // Function with simulated execution time of 2 seconds
            static async Task<string> funcF2Async()
            {
                Console.WriteLine("Início/Start f2");
                await Task.Delay(2000);
                Console.WriteLine("Fim/End f2");
                return "Resultado/Result f2";
            }

            // Função com tempo de execução simulado de 4 segundos
            // Function with simulated execution time of 4 seconds
            static async Task<string> funcF4Async()
            {
                Console.WriteLine("Início/Start f4");
                await Task.Delay(4000);
                Console.WriteLine("Fim/End f4");
                return "Resultado/Result f4";
            }

            // Executando de forma simultânea as 3 funçoes
            // Executing the 3 functions simultaneously
            Console.WriteLine("Execução simultânea/Concurrent execution\n");

            // Criar uma instância da classe Stopwatch
            // Create an instance of the Stopwatch class
            Stopwatch asyncStopwatch = new();

            // Iniciar a contagem de tempo
            // Start counting time
            asyncStopwatch.Start();

            // Criar uma lista das funções
            // Create a list of functions
            List<Task<string>> functionList = [];

            // Incluir funcF6Async
            // Add funcF6Async
            Task<string> f6 = funcF6Async();
            functionList.Add(f6);

            // Incluir funcF2Async
            // Add funcF2Async
            Task<string> f2 = funcF2Async();
            functionList.Add(f2);

            // Incluir funcF4Async
            // Add funcF4Async
            Task<string> f4 = funcF4Async();
            functionList.Add(f4);

            Console.WriteLine("");

            // Agauardar a execução de todas as funções
            // Wait for all functions to execute
            await Task.WhenAll(functionList);

            // Parar a contagem de tempo
            // Stop counting time
            asyncStopwatch.Stop();

            Console.WriteLine("");

            // Pegar o tempo decorrido
            // Get the elapsed time
            TimeSpan asyncTimeElapsed = asyncStopwatch.Elapsed;

            // Formatar o texto para exibição
            // Format text for display
            string mytTimeElapsedFormated = string.Format("{0:00}:{1:00}:{2:00}",
                                            asyncTimeElapsed.Hours, asyncTimeElapsed.Minutes, asyncTimeElapsed.Seconds);

            // Mostrar tempo decorrido
            // Show elapsed time
            Console.WriteLine("Tempo decorrido/Elapsed time: " + mytTimeElapsedFormated);

            Console.WriteLine("");

            // Mostar resultadosa das funções
            // Show function results
            Console.WriteLine("Resultados das Funções/Functions results");
            foreach (Task<string> funcResult in functionList)
            {
                Console.WriteLine(funcResult.Result);
            }
        }
    }
}
