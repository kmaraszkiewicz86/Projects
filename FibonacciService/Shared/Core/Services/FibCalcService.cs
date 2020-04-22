namespace Core.Services
{
    public class FibCalcService: IFibCalcService
    {
        public long Calculate(long x)
        {
            long first = 0;
            long second = 1;
            long result = 0;

            for (long index = 1; index < x; index++)
            {
                result = first + second;
                first = second;
                second = result;
            }

            return result;
        }
    }
}
