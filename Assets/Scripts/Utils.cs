using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    private const double KM_TO_LY = 1 / 9.460e12;
    private const double LY_TO_KM = 9.460e12 / 1;
    private const double KM_TO_AU = 1 / 1.496e8;
    private const double AU_TO_KM = 1.496e8/1;
    private const double AU_TO_LY = 1 / 63241.077;
    private const double LY_TO_AU = 6324.007 / 1;

    public const double MO_SUN = 1.989e30;
    public const double RO_SUN = 696340;
    public const double MO_EARTH = 5.972e24;
    public const double RO_EARTH = 6371;
    public const double GRAVITATIONAL_CONSTANT = 6.67e-11;

    public static double ConvertKmToAu(double km) => km * KM_TO_AU;
    public static double ConvertAuToKm(double au) => au * AU_TO_KM;
    public static double ConvertKmToLy(double km) => km * KM_TO_LY;
    public static double ConvertLyToKM(double ly) => ly * LY_TO_KM;
    public static double ConvertAuToLy(double au) => au * AU_TO_LY;
    public static double ConvertLyToAu(double ly) => ly * LY_TO_AU;

    public static string ConvertKm(double km)
    {
        if (km >= 5.88e12) return String.Format("{0:0.#} LY", ConvertKmToLy(km));
        if (km >= 1.496e8) return String.Format("{0:0.#} AU", ConvertKmToAu(km));
        if (km >= 1e6) return String.Format("{0:0.#}M km", km / 1e6);
        if (km >= 10000) return String.Format("{0:0.#}K km", km / 1e5);
        if (km >= 1000) return String.Format("{0:0.##}K km", km / 1000);
        return String.Format("#,0", km);
    }

    public static double DistributeRandomness(double min, double max, int limit)
    {
        double result = 0;
        for (int i = 0; i < limit; i++)
        {
            result += LehmerRNG.NextDouble(min, max);
        }

        return result / limit;
    }
}
