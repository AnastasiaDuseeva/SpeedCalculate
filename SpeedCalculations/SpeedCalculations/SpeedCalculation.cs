using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;

namespace SpeedCalculations
{
    public class SpeedCalculation
    {
        public static double Speed(double distance, double time)
        {
            if (time <= 0)
                throw new ArgumentException("Время должно быть больше нуля!");
            return distance / time;
        }

        public static double Distance(double speed, double time)
        {
            if (speed < 0 || time < 0)
                throw new ArgumentException("Скорость и время должны быть больше нуля!");
            return speed * time;
        }

        public static double Time(double distance, double speed)
        {
            if (speed <= 0)
                throw new ArgumentException("Скорость должна быть больше нуля!");
            return distance / speed;
        }

        //корректно ли ввели числа
        public static bool TryParseInput(string input, out double value)
        {
            return double.TryParse(input, out value) && value >= 0;
        }
    }
}