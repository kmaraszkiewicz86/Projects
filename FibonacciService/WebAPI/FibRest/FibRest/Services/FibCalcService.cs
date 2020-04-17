namespace FibRest.Services
{
    public class FibCalcService: IFibCalcService
    {
        public long Calculate(int x)
        {
            if (x < 2)
                return x;

            return Calculate(x - 2) + Calculate(x - 1);
        }
    }
}
