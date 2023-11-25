using System.Text.RegularExpressions;

namespace console
{
    public class Program
    {
        static void Main(string[] args)
        {
            // normal method
            SymbolAmountsByTypeDelegate SymbolAmountsByType = SymbolAmountsByTypeMethod;
            double[] NormalMethodResp = SymbolAmountsByType("123 abc @#$");
            Console.WriteLine(NormalMethodResp[0] + " - letters, " + NormalMethodResp[1] + " - numbers, " + NormalMethodResp[2] + " - symbols");

            // anonymous
            SymbolAmountsByType = delegate (string input)
            {
                double[] counts =
                [
                    Regex.Matches(input, @"[a-zA-Z]").Count,
                    Regex.Matches(input, @"\d").Count,
                    Regex.Matches(input, @"[^\w\s]").Count + Regex.Matches(input, @"\s").Count,
                ]; // [0] -> Letters, [1] -> Numbers, [2] -> Symbols

                return counts;
            };
            double[] AnonymousMethodResp = SymbolAmountsByType("123 abc @#$");
            Console.WriteLine(AnonymousMethodResp[0] + " - letters, " + AnonymousMethodResp[1] + " - numbers, " + AnonymousMethodResp[2] + " - symbols");

            // lambda
            SymbolAmountsByType = (input) =>
            {
                double[] counts =
                [
                    Regex.Matches(input, @"[a-zA-Z]").Count,
                    Regex.Matches(input, @"\d").Count,
                    Regex.Matches(input, @"[^\w\s]").Count + Regex.Matches(input, @"\s").Count,
                ]; // [0] -> Letters, [1] -> Numbers, [2] -> Symbols

                return counts;
            };
            double[] LambdaMethodResp = SymbolAmountsByType("123 abc @#$");
            Console.WriteLine(LambdaMethodResp[0] + " - letters, " + LambdaMethodResp[1] + " - numbers, " + LambdaMethodResp[2] + " - symbols");


            SwimmingPool SwimmingPool = new(100, 10, 10);
            SwimmingPool.Overflowing += PoolOverflowHandler;
            Console.WriteLine(SwimmingPool.Length + " - Length, " + SwimmingPool.Width + " - Width, " + SwimmingPool.Depth + " - Depth, " + SwimmingPool.Volume + " - Volume, " + SwimmingPool.Amount + " - Amount");
            SwimmingPool.Amount = SwimmingPool.Volume+1;
            Console.WriteLine(SwimmingPool.Length + " - Length, " + SwimmingPool.Width + " - Width, " + SwimmingPool.Depth + " - Depth, " + SwimmingPool.Volume + " - Volume, " + SwimmingPool.Amount + " - Amount");
        }

        public delegate double[] SymbolAmountsByTypeDelegate(string input);
        public static double[] SymbolAmountsByTypeMethod(string input)
        {
            double[] counts =
            [
                Regex.Matches(input, @"[a-zA-Z]").Count,
                Regex.Matches(input, @"\d").Count,
                Regex.Matches(input, @"[^\w\s]").Count + Regex.Matches(input, @"\s").Count,
            ]; // [0] -> Letters, [1] -> Numbers, [2] -> Symbols

            return counts;
        }

        public static void PoolOverflowHandler(SwimmingPool? sender, EventArgs eventArgs)
        {
            Console.WriteLine(sender?.Amount + " is too much!");
        }
    }
}