public static class NumberArraySum
{
    private static Add<sbyte> addSByte = (x, y) => (sbyte)(x + y);

    private static Add<byte> addByte = (x, y) => (byte)(x + y);

    private static Add<short> addShort = (x, y) => (short)(x + y);

    private static Add<ushort> addUShort = (x, y) => (ushort)(x + y);

    private static Add<int> addInt = (x, y) => x + y;

    private static Add<uint> addUInt = (x, y) => x + y;

    private static Add<long> addLong = (x, y) => x + y;

    private static Add<ulong> addULong = (x, y) => x + y;

    private static Add<float> addFloat = (x, y) => x + y;

    private static Add<double> addDouble = (x, y) => x + y;

    private static Add<decimal> addDecimal = (x, y) => x + y;

    private delegate T Add<T>(T x, T y);

    public static sbyte Sum(this sbyte[] a)
    {
        return Sum(a, addSByte);
    }

    public static byte Sum(this byte[] a)
    {
        return Sum(a, addByte);
    }

    public static short Sum(this short[] a)
    {
        return Sum(a, addShort);
    }

    public static ushort Sum(this ushort[] a)
    {
        return Sum(a, addUShort);
    }

    public static int Sum(this int[] a)
    {
        return Sum(a, addInt);
    }

    public static uint Sum(this uint[] a)
    {
        return Sum(a, addUInt);
    }

    public static long Sum(this long[] a)
    {
        return Sum(a, addLong);
    }

    public static ulong Sum(this ulong[] a)
    {
        return Sum(a, addULong);
    }

    public static float Sum(this float[] a)
    {
        return Sum(a, addFloat);
    }

    public static double Sum(this double[] a)
    {
        return Sum(a, addDouble);
    }

    public static decimal Sum(this decimal[] a)
    {
        return Sum(a, addDecimal);
    }

    private static T Sum<T>(T[] a, Add<T> add)
    {
        T s = default(T);

        foreach (T t in a)
        {
            s = add(s, t);
        }

        return s;
    }
}