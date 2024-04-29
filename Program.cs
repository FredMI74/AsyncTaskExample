namespace AsyncTaskExample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            static async Task<string> funcF6Async()
            {
                Console.WriteLine("Start f6");
                await Task.Delay(6000);
                Console.WriteLine("End f6");
                return "Result f6";
            }

            static async Task<string> funcF2Async()
            {
                Console.WriteLine("Start f2");
                await Task.Delay(2000);
                Console.WriteLine("End f2");
                return "Result f2";
            }
            static async Task<string> funcF4Async()
            {
                Console.WriteLine("Start f4");
                await Task.Delay(4000);
                Console.WriteLine("End f4");
                return "Result f4";
            }

            List<Task<string>> functionList = [];

            Task<string> f6 = funcF6Async();
            functionList.Add(f6);

            Task<string> f2 = funcF2Async();
            functionList.Add(f2);

            Task<string> f4 = funcF4Async();
            functionList.Add(f4);

            await Task.WhenAll(functionList);

            Console.WriteLine("Functions results");
            foreach (Task<string> funcResult in functionList)
            {
                Console.WriteLine(funcResult.Result);
            }

        }
    }
}
