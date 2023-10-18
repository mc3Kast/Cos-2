using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cos_2.Lib
{
    public static class SpectrumMath
    {
        public static double[] SinSpectrum(double[] values, int k, int n) //Im
        {
            int coeff = n / k;
            double[] result = new double[k];
            for (int j = 0; j < k; j++)
            {
                double value = 0;
                for (int i = 0; i < k; i++)
                {
                    value += values[i*coeff] * Math.Sin(2 * Math.PI * i * j / k);
                }

                result[j] = 2 * value / k;
            }

            return result;
        }

        public static double[] CosSpectrum(double[] values, int k, int n) //Re
        {
            int coeff = n / k;
            double[] result = new double[k];
            for (int j = 0; j < k; j++)
            {
                double value = 0;
                for (int i = 0; i < k; i++)
                {
                    value += values[i*coeff] * Math.Cos(2 * Math.PI * i * j / k);
                }

                result[j] = 2 * value / k;
            }

            return result;
        }

        public static double[] AmplitudeSpectrum(int k, double[] sinSpec, double[] cosSpec)
        {
            double[] result = new double[k];
            for (int j = 0; j < k; j++)
            {
                result[j] = Math.Sqrt(Math.Pow(sinSpec[j], 2) + Math.Pow(cosSpec[j], 2));
            }

            return result;
        }

        public static double[] PhaseSpectrum(int k, double[] sinSpec, double[] cosSpec)
        {
            double[] result = new double[k];
            for (int j = 0; j < k; j++)
            {
                result[j] = Math.Atan2(cosSpec[j], sinSpec[j]);
            }

            return result;
        }

        public static double[] RestoredSignal(int k, int N, double[] ampSpec, double[] phaSpec)
        {
            double[] values = new double[N];
            for (int i = 0; i < N; i++)
            {
                double value = ampSpec[0] / 2;
                for (int j = 0; j < k / 2; j++)
                {
                    value += ampSpec[j] * Math.Sin(2 * Math.PI * i * j / N + phaSpec[j]);
                }

                values[i] = value;
            }

            return values;
        }
    }
}
