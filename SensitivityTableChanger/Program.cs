using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensitivityTableChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SensCalculation calculator = new SensCalculation();
            Console.WriteLine("Example: 0.50\n");
            while (true)
            {
                String text = Console.ReadLine();
                double sens = Convert.ToDouble(text);
                calculator.SensCalc(sens);
            }
     
            
           




        }
    }
}
