using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensitivityTableChanger
{
    class SensCalculation
    {
        List<string> dataList = new List<string>();
        StringBuilder sb = new StringBuilder();
        int[][] RecoilTableUpdated;
        double originalSens = 0.15;
        double difference;

        public int[][] SensCalc(double yourSens)
        {
            /*
             * Program that loops through a Dictionary of int lists. 
             * Loops through each list and replaces the values based on the difference between your sensitivity and the original sensitivity.
             * Checks the settings.ini file for Recoiltables and updates them with new tables generated for your sensitivity.
            */
            TableList wepList = new TableList();
            difference = yourSens / originalSens;



           
            String path = $@"C:\Users\{Environment.UserName}\Desktop\SensFiles\settings.ini";
            foreach (var weapon in wepList.weaponList)
            {
                RecoilTableUpdated = weapon.Value;
                foreach (int[] recoilTable in RecoilTableUpdated)
                {

                    int nr1 = Convert.ToInt32((double)recoilTable[0] / (double)difference);
                    int nr2 = Convert.ToInt32((double)recoilTable[1] / (double)difference);

                    sb.Append("{" + nr1 + ", " + nr2 + "}");
                    Console.Write("{" + nr1 + ", " + nr2 + "}");
                }
               

                dataList.Add(sb.ToString());
                sb.Clear();
                Console.WriteLine("\n");

            }
            var lines = File.ReadAllLines(path);
            var lineBuffer = lines;

            var dicIndex = 0;

            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {

                if (lines[lineIndex].Contains("RecoilTable"))
                {
                    lineBuffer[lineIndex] = "RecoilTable={" + dataList.ElementAt(dicIndex) + "}";
                    dicIndex++;
                }
            }


            File.WriteAllLines(path, lineBuffer);
            yourSens = 0;
            dataList.Clear();
            return RecoilTableUpdated;
        }
    }
}
