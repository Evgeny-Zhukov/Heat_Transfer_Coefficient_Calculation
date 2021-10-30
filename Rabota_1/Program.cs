using System;

namespace Rabota_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double tc1, t1h, dt, po, mu, h, r, a1, a2, q1, q2, tst2, w, n, Re, Nu;
            n = 26;
            w = 4.72 / (0.785 * 763 * 0.021 * 0.021 * n);
            Re = w * 0.021 * 763 / (688.5 * Math.Pow(10, -6));
            if (Re > 10000)
            {
                Nu = 0.021 * Math.Pow(Re, 0.8) * Math.Pow(11.4, 0.43);
            }
            else
            {
                Nu = 0.008 * Math.Pow(Re, 0.9) * Math.Pow(11.4, 0.43);
            }
            Console.WriteLine(Math.Pow(11.4, 0.43));
            Console.WriteLine(0.021 * Math.Pow(Re, 0.8) * Math.Pow(11.4, 0.43));
            a2 = Nu * 0.1612 / 0.021;

            t1h = 126.11;
            bool light = true;
            double ddt = 0;
            int i = 0;
            dt = 16.11;
            do
            {
                tc1 = t1h - dt;
                po = 951 - (951 - 943) / 10.0 * ddt;
                mu = 282 - (282 - 256) / 10.0 * ddt;
                h = 68.3 + (68.5 - 68.3) / 10.0 * ddt;
                r = (2234 - (2234 - 2207) / 10.0 * ddt) * 1000;
                a1 = 1.15 * Math.Pow((Math.Pow(h * Math.Pow(10, -2), 3) * po * po * r * 9.81) / (mu * Math.Pow(10, -6) * dt * 2), 0.25);
                q1 = a1 * dt;
                tst2 = t1h - q1 * 0.000449;
                q2 = a2 * (tst2 - 49.65);
                if (q1 / q2 <= 1.2 && q1 / q2 >= 0.8)
                {
                    light = false;

                }
                else
                {
                    ddt++;
                    dt--;
                    i++;
                    if (i == 10)
                    {
                        break;
                    }
                }
            } while (light);

            Console.WriteLine($"Q1:{q1} Q2:{q2},DDT: {ddt}, DT: {dt}");
            Console.WriteLine("END");
        }
    }
}
