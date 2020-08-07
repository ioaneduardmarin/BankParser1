using System;
using System.Collections.Generic;
using System.IO;

namespace BankParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Tranzactii p = new Tranzactii();
            string[] linii = File.ReadAllLines(@"C:\Users\User1\source\repos\BankParser\STA\1.STA");
            string texttotal = File.ReadAllText(@"C:\Users\User1\source\repos\BankParser\STA\1.STA");
            List<string> tags = new List<string>();
            
            List<string> Final2 = new List<string>();

            int consec = 0;
            List<int> nr20 = IndexFinder.AllIndexesOf(texttotal, ":20:");
            List<int> nr25 = IndexFinder.AllIndexesOf(texttotal, ":25:");
            List<int> nr28 = IndexFinder.AllIndexesOf(texttotal, ":28C:");
            List<int> nr60 = IndexFinder.AllIndexesOf(texttotal, ":60F:");
            List<int> nr61 = IndexFinder.AllIndexesOf(texttotal, ":61:");
            List<int> nr62 = IndexFinder.AllIndexesOf(texttotal, ":62F:");
            List<int> nr64 = IndexFinder.AllIndexesOf(texttotal, ":64:");
            List<int> nr65 = IndexFinder.AllIndexesOf(texttotal, ":65:");
            List<int> nr86 = IndexFinder.AllIndexesOf(texttotal, ":86:");
            List<int> nrparant = IndexFinder.AllIndexesOf(texttotal, "-}");
            List<int> tagtr = new List<int>();
            tagtr.AddRange(nr20);
            tagtr.AddRange(nr25);
            tagtr.AddRange(nr28);
            tagtr.AddRange(nr60);
            tagtr.AddRange(nr61);
            tagtr.AddRange(nr62);
            tagtr.AddRange(nr64);
            tagtr.AddRange(nr65);
            tagtr.AddRange(nr86);
            tagtr.AddRange(nrparant);
            tagtr.Sort();





            foreach (string linie in linii)
            {
                if (linie.Length > 2)
                {
                    if (linie.Substring(1, 2) == "20" || linie.Substring(1, 2) == "25" || linie.Substring(1, 2) == "28" || linie.Substring(1, 2) == "60" || linie.Substring(1, 2) == "61" || linie.Substring(1, 2) == "62" || linie.Substring(1, 2) == "64" || linie.Substring(1, 2) == "86")
                    {
                        tags.Add(linie.Substring(1, 2));
                    }
                }
            }




            for (int i = 0; i < tags.Count - 1; i++)
            {

                if ((tags[i] == "86") && tags[i] == tags[i + 1])
                {
                    consec++;
                }
            }



            if (consec == 0)
            {
               
                for (int idx = 0; idx < tagtr.Count; idx++)
                {
                    if (texttotal[tagtr[idx] + 1] == '2' && texttotal[tagtr[idx] + 2] == '0')
                    {
                        string instr20 = texttotal.Substring(tagtr[idx] + 4, tagtr[idx + 1] - tagtr[idx] - 4);
                        Final2.Add(p.Tranzactia20(instr20));

                    }
                    if (texttotal[tagtr[idx] + 1] == '2' && texttotal[tagtr[idx] + 2] == '5')
                    {
                        string instr25 = texttotal.Substring(tagtr[idx] + 4, tagtr[idx + 1] - tagtr[idx] - 4);
                        Final2.Add(p.Tranzactia25(instr25));

                    }
                    if (texttotal[tagtr[idx] + 1] == '2' && texttotal[tagtr[idx] + 2] == '8')
                    {
                        string instr28 = texttotal.Substring(tagtr[idx] + 5, tagtr[idx + 1] - tagtr[idx] - 5);
                        Final2.Add(p.Tranzactia28(instr28));

                    }
                    if (texttotal[tagtr[idx] + 1] == '6' && texttotal[tagtr[idx] + 2] == '0')
                    {
                        string instr60 = texttotal.Substring(tagtr[idx] + 5, tagtr[idx + 1] - tagtr[idx] - 5);
                        Final2.Add(p.Tranzactia60(instr60));

                    }
                    if (texttotal[tagtr[idx] +1] == '6' && texttotal[tagtr[idx] + 2] == '1')
                    {
                        string instr61 = texttotal.Substring(tagtr[idx] + 4, tagtr[idx + 1] - tagtr[idx] - 4);
                        Final2.Add(p.Tranzactia61(instr61));

                    }
                    if (texttotal[tagtr[idx] + 1] == '6' && texttotal[tagtr[idx] + 2] == '2')
                    {
                        string instr62 = texttotal.Substring(tagtr[idx] + 5, tagtr[idx + 1] - tagtr[idx] - 5);
                        Final2.Add(p.Tranzactia62(instr62));
                    }
                    if (texttotal[tagtr[idx] + 1] == '6' && texttotal[tagtr[idx] + 2] == '4')
                    {
                        string instr64 = texttotal.Substring(tagtr[idx] + 4, tagtr[idx + 1] - tagtr[idx] - 4);
                        Final2.Add(p.Tranzactia64(instr64));
                    }
                    if (texttotal[tagtr[idx] + 1] == '6' && texttotal[tagtr[idx] + 2] == '5')
                    {
                        string instr65 = texttotal.Substring(tagtr[idx] + 4, tagtr[idx + 1] - tagtr[idx] - 4);
                        Final2.Add(p.Tranzactia65(instr65));
                    }
                    if (texttotal[tagtr[idx] + 1] == '8' && texttotal[tagtr[idx] + 2] == '6')
                    {
                        string instr86 = texttotal.Substring(tagtr[idx] + 4, tagtr[idx + 1] - tagtr[idx] - 4);
                        Final2.Add(p.Tranzactia86(instr86));
                    }

                 }
                File.WriteAllLines(@"C:\Users\User1\source\repos\BankParser\STA\OutputFinal.txt", Final2);

            }
            else
            {
                Final2.Add("0");
                File.WriteAllLines(@"C:\Users\User1\source\repos\BankParser\STA\Output.txt", Final2);
            }
        }
        public bool VerificareNumere(string numar)
        {
            bool isNumeric = decimal.TryParse(numar, out decimal result);
            return isNumeric;
        }

        




    }








}

