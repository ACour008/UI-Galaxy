using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Conversions
    {
        private const double KM_TO_LY = 1 / 1.057e-13;
        private const double LY_TO_KM = 9.460e12 / 1;
        private const double KM_TO_AU = 1 / 1.496e8;
        private const double AU_TO_KM = 1.496e8/1;
        private const double AU_TO_LY = 1 / 63241.077;
        private const double LY_TO_AU = 6324.007 / 1;

        public static readonly double MO_SUN = 1.989e30;
        public static readonly double RO_SUN = 696340;
        public static readonly double MO_EARTH = 5.972e24;
        public static readonly double RO_EARTH = 6371;
        public static readonly double GRAVITATIONAL_CONSTANT = 6.67e-11;

        public static double ConvertKmToAu(double km) => km * KM_TO_AU;
        public static double ConvertAuToKm(double au) => au * AU_TO_KM;
        public static double ConvertKmToLY(double km) => km * KM_TO_LY;
        public static double ConvertLyToKM(double ly) => ly * LY_TO_KM;
        public static double ConvertAuToLy(double au) => au * AU_TO_LY;
        public static double ConvertLyToAu(double ly) => ly * LY_TO_AU;

        public static string ConvertNumber(double number, double factor)
        {
            return string.Format("{0:0.##}", number / factor);
        }

        public static string ConvertNumber(float number, float factor) {
            return string.Format("{0:0.##}", number / factor);
        }

        public static string ConvertNumber(int number, int factor)
        {
            return string.Format("{0:0.##}", number / factor);
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
}

