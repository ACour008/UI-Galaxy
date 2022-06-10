/*
 * LehmerRNG courtesy of: https://docs.microsoft.com/en-us/archive/msdn-magazine/2016/august/test-run-lightweight-random-number-generation
 */

using UnityEngine;

public class LehmerRNG
{
    private static int a = 16807;
    private static int m = 2147483647;
    private static int q = 127773;
    private static int r = 2836;
    private static int seed;

    private static LehmerRNG instance = null;

    public LehmerRNG(int seed)
    {
        LehmerRNG.seed = seed;
    }

    public static void Initialize(int seed)
    {
        if (instance == null) instance = new LehmerRNG(seed);
    }

    private static double GetRandomNumber()
    {
        if (instance == null)
        {
            instance = new LehmerRNG(-1);
        }

        int hi = seed / q;
        int lo = seed % q;
        seed = (a * lo) - (r * hi);
        if (seed <= 0) seed = seed + m;

        return (seed * 1.0) / m;
    }

    public static int Next(int min, int max)
    {
        float x = (float)GetRandomNumber();
        return Mathf.FloorToInt((max - min) * x + min);
    }

    public static double NextDouble(double min, double max)
    {
        return (max - min) * GetRandomNumber() + min;
    }

    public static float NextFloat(float min, float max)
    {
        return (max - min) * (float)GetRandomNumber() + min;
    }


}
