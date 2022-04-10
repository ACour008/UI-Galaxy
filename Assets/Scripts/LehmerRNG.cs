/*
 * LehmerRNG courtesy of: https://docs.microsoft.com/en-us/archive/msdn-magazine/2016/august/test-run-lightweight-random-number-generation
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LehmerRNG
{
    private static int a = 16807;
    private static int m = 2147483647;
    private static int q = 127773;
    private static int r = 2836;
    private static int seed;

    private static LehmerRNG instance = null;

    public LehmerRNG(int seed) {

        if (seed < 0 || seed == int.MaxValue)
        {
            LehmerRNG.seed = Mathf.Abs((int)long.Parse(System.DateTime.Now.ToString("yyyyMMddHHmmss")));
        }
        else
        {
            LehmerRNG.seed = seed;
        }

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

    public static int Next(int min, int maxExclusive)
    {
        double x = GetRandomNumber();
        return (int)((maxExclusive - min) * x + min);
    }

    public static double NextDouble(double min, double maxInclusive)
    {
        // make inclusive;

        double x = GetRandomNumber();
        return (maxInclusive - min) * x + min;
    }

    public static float NextFloat(float min, float maxInclusive)
    {
        // make inclusive;
        double x = GetRandomNumber();
        return (float)((maxInclusive - min) * x + min);
    }


}
