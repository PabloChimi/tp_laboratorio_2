using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }


        public Numero()
        {

        }

        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public string BinarioDecimal(string binario)
        {
            int i;
            double valorTotal = 0;

            for (i = 0; i < binario.Length; i++)
            {
                if (char.Equals(binario[i], '1'))
                {
                    valorTotal += Math.Pow(2, binario.Length - i - 1);
                }
                else
                {
                    if (!char.Equals(binario[i], '0'))
                    {
                        return "Valor invalido";
                    }
                }
            }
            return valorTotal.ToString();

        }

        public string DecimalBinario(double numero)
        {
            string binario = "";
            while (numero != 0)
            {
                if (numero % 2 == 0)
                {
                    numero = numero / 2;
                    binario = "0" + binario;
                }
                else
                {
                    numero = (numero - 1) / 2;
                    binario = "1" + binario;
                }
            }
            return binario;
        }

        public string DecimalBinario(string numero)
        {
            string retorno;
            retorno = DecimalBinario(double.Parse(numero));
            return retorno;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        private double ValidarNumero(string strNumero)
        {
            double n;
            bool isNumeric = double.TryParse(strNumero, out n);
            if (isNumeric)
            {
                return n;
            }
            return 0;
        }

    }


}

