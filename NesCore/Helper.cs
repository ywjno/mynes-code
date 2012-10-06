namespace MyNes.Core
{
    public static class Helper
    {
        public static int GreatestCommonFactor(int a, int b)
        {
            int remainder;

            while (b != 0)
            {
                remainder = (a % b);
                a = b;
                b = remainder;
            }

            return a;
        }

        public static void Reduce(ref int a, ref int b)
        {
            var gcf = GreatestCommonFactor(a, b);

            a /= gcf;
            b /= gcf;
        }

        public static T[][] CreateArray<T>(int length1, int length2)
        {
            T[][] result = new T[length1][];

            for (int i = 0; i < length1; i++)
            {
                result[i] = new T[length2];
            }

            return result;
        }
    }
}