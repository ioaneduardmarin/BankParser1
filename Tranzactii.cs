using System;
using System.Collections.Generic;
using System.Text;

namespace BankParser
{
    class Tranzactii
    {





        public string Tranzactia20(string sir)
        {
            sir = sir.Replace("\n", "").Replace("\r", "");
            return ($"\n\n\nNumarul de referinta este urmatorul: {sir}");
        }
        public string Tranzactia25(string sir)
        {
            string iban = sir.Replace("\n", "").Replace("\r", "");
            return ($"Contul Iban al clientului este urmatorul: {sir}");
        }
        public string Tranzactia28(string sir)
        {
            string nrextras = sir.Substring(0, 5);
            string nrsecventa = sir.Substring(6);
            string fin = ($"Numarul de extras este: {nrextras}. Numarul de secventa este: {nrsecventa}.");
            fin = fin.Replace("\n", "").Replace("\r", "");
            return fin;
        }


        public string Tranzactia60(string sir)
        {

            string tipsoldinitial = sir.Substring(0, 1);
            DateTime data = (DateTime.ParseExact("20" + sir.Substring(1, 6), "yyyyMMdd", null)).Date;
            string valutasoldinitial = sir.Substring(7, 3);
            string soldinitial = sir.Substring(10);
            soldinitial = soldinitial.Replace("\n", "").Replace("\r", "");

            if (tipsoldinitial == "C")
            {
                return ($"In contul de credit, la initierea tranzactiei din data de {data}, se afla {soldinitial} {valutasoldinitial} ");
            }
            if (tipsoldinitial == "D")
            {
                return ($"In contul de debit, la initierea tranzactiei din data de {data}, se afla {soldinitial} {valutasoldinitial} ");
            }
            return "";
        }

        public string Tranzactia61(string sir)
        {
            DateTime data = (DateTime.ParseExact("20" + sir.Substring(4, 6), "yyyyMMdd", null)).Date;
            string codtr = sir.Substring(10, 1);
            string sumatranzactionata = sir.Substring(11, sir.IndexOf(',') - 11) + sir.Substring(sir.IndexOf(','), 3);
            string tiptranzactie = sir.Substring(sir.IndexOf(',') + 3, 4);
            string referintaclient = sir.Substring(sir.IndexOf(',') + 7, 16);
            string detalii = sir.Substring(sir.IndexOf(',') + 23);

            if (detalii == "\r\n")
            {
                if (codtr == "C")
                {
                    if (tiptranzactie == "NTRF")
                    {
                        return ($"Tranzactia efectuata in data de {data} de tip transfer credit in valoare de {sumatranzactionata} unitati monetare a fost realizata de clientul posesor al referintei {referintaclient}.");
                    }
                    if (tiptranzactie == "NCOM")
                    {
                        return ($"Tranzactia efectuata in data de {data} de tip comision credit in valoare de {sumatranzactionata} unitati monetare a fost realizata de clientul posesor al referintei {referintaclient}.");
                    }
                    if (tiptranzactie == "NMSC")
                    {
                        return ($"Tranzactia efectuata in data de {data} de tip dobanda credit in valoare de {sumatranzactionata} unitati monetare a fost realizata de clientul posesor al referintei {referintaclient}.");
                    }
                }
                if (codtr == "D")
                {
                    if (tiptranzactie == "NTRF")
                    {
                        return ($"Tranzactia efectuata in data de {data} de tip transfer debit in valoare de {sumatranzactionata} unitati monetare a fost realizata de clientul posesor al referintei {referintaclient}.");
                    }
                    if (tiptranzactie == "NCOM")
                    {
                        return ($"Tranzactia efectuata in data de {data} de tip comision debit in valoare de {sumatranzactionata} unitati monetare a fost realizata de clientul posesor al referintei {referintaclient}.");
                    }
                    if (tiptranzactie == "NMSC")
                    {
                        return ($"Tranzactia efectuata in data de {data} de tip dobanda debit in valoare de {sumatranzactionata} unitati monetare a fost realizata de clientul posesor al referintei {referintaclient}.");
                    }
                }
            }
            else
            {
                if (codtr == "C")
                {
                    if (tiptranzactie == "NTRF")
                    {
                        return ($"Tranzactia efectuata in data de {data} de tip transfer credit in valoare de {sumatranzactionata} unitati monetare a fost realizata de clientul posesor al referintei {referintaclient}.\nDetaliile tranzactiei sunt urmatoarele {detalii}.");
                    }
                    if (tiptranzactie == "NCOM")
                    {
                        return ($"Tranzactia efectuata in data de {data} de tip comision credit in valoare de {sumatranzactionata} unitati monetare a fost realizata de clientul posesor al referintei {referintaclient}.\nDetaliile tranzactiei sunt urmatoarele {detalii}.");
                    }
                    if (tiptranzactie == "NINT")
                    {
                        return ($"Tranzactia efectuata in data de {data} de tip dobanda credit in valoare de {sumatranzactionata} unitati monetare a fost realizata de clientul posesor al referintei {referintaclient}.\nDetaliile tranzactiei sunt urmatoarele {detalii}.");
                    }
                }
                if (codtr == "D")
                {
                    if (tiptranzactie == "NTRF")
                    {
                        return ($"Tranzactia efectuata in data de {data} de tip transfer debit in valoare de {sumatranzactionata} unitati monetare a fost realizata de clientul posesor al referintei {referintaclient}.\nDetaliile tranzactiei sunt urmatoarele {detalii}.");
                    }
                    if (tiptranzactie == "NCOM")
                    {
                        return ($"Tranzactia efectuata in data de {data} de tip comision debit in valoare de {sumatranzactionata} unitati monetare a fost realizata de clientul posesor al referintei {referintaclient}.\nDetaliile tranzactiei sunt urmatoarele {detalii}.");
                    }
                    if (tiptranzactie == "NINT")
                    {
                        return ($"Tranzactia efectuata in data de {data} de tip dobanda debit in valoare de {sumatranzactionata} unitati monetare a fost realizata de clientul posesor al referintei {referintaclient}.\nDetaliile tranzactiei sunt urmatoarele {detalii}.");
                    }
                }
            }
            return "";

        }

        public string Tranzactia62(string sir)
        {

            string tipsoldfinal = sir.Substring(0, 1);
            DateTime data = (DateTime.ParseExact("20" + sir.Substring(1, 6), "yyyyMMdd", null)).Date;
            string valutasoldfinal = sir.Substring(7, 3);
            string soldfinal = sir.Substring(10);
            soldfinal = soldfinal.Replace("\n", "").Replace("\r", "");

            if (tipsoldfinal == "C")
            {
                return ($"In contul de credit, la finalizarea tranzactiei din data de {data}, se afla {soldfinal} {valutasoldfinal} ");
            }
            if (tipsoldfinal == "D")
            {
                return ($"In contul de debit, la finalizarea tranzactiei din data de {data}, se afla {soldfinal} {valutasoldfinal} ");
            }
            return "";
        }

        public string Tranzactia64(string sir)
        {
            string tipsoldfinal = sir.Substring(0, 1);
            DateTime data = (DateTime.ParseExact("20" + sir.Substring(1, 6), "yyyyMMdd", null)).Date;
            string valutasoldfinal = sir.Substring(7, 3);
            string soldfinal = sir.Substring(10);
            soldfinal = soldfinal.Replace("\n", "").Replace("\r", "");

            if (tipsoldfinal == "C")
            {
                return ($"In contul de credit, in data de {data}, soldul final este urmatorul: {soldfinal} {valutasoldfinal} ");
            }
            if (tipsoldfinal == "D")
            {
                return ($"In contul de credit, in data de {data}, soldul final este urmatorul: {soldfinal} {valutasoldfinal} ");
            }
            return "";
        }


        public string Tranzactia65(string sir)
        {
            string tipsoldfinal = sir.Substring(0, 1);
            DateTime data = (DateTime.ParseExact("20" + sir.Substring(1, 6), "yyyyMMdd", null)).Date;
            string valutasoldfinal = sir.Substring(7, 3);
            string soldfinal = sir.Substring(10);
            soldfinal = soldfinal.Replace("\n", "").Replace("\r", "");

            if (tipsoldfinal == "C")
            {
                return ($"In contul de credit, in data de {data}, soldul final ajustat este urmatorul: {soldfinal} {valutasoldfinal} ");
            }
            if (tipsoldfinal == "D")
            {
                return ($"In contul de credit, in data de {data}, soldul final ajustat este urmatorul: {soldfinal} {valutasoldfinal} ");
            }
            return "";
        }


        public string Tranzactia86(string sir)
        {
            string detalii = sir.Replace("\n", "\\").Replace("\r", "\\");
            return ($"Detaliile tranzactiei sunt urmatoarele: {detalii}");
        }
    }
}
