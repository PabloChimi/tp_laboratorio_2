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

        /// <summary>
        /// Hace un seteo de una variable del tipo string, hace una validación y en el caso de pasar la misma, convierte la variable a double y la asigna al atributo numero
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Constructor por defecto, no se inicializa con ningun valor
        /// </summary>
        public Numero()
        {

        }

        /// <summary>
        /// Constructor que recibe un parametro
        /// </summary>
        /// <param name="numero"></param> variable del tipo string que se asignará al atributo numero (Con su correspondiente parseo)
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        /// <summary>
        /// Constructor que recibe un parametro
        /// </summary>
        /// <param name="numero"></param> variable del tipo double que se asignará al atributo numero
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Metodo que convierte un binario a un numero decimal
        /// </summary>
        /// <param name="binario"></param> el numero binario a ser convertido
        /// <returns></returns> Retorna el valor convertido a decimal en forma de string, en caso de que el parametro ingresado sea invalido retorna "valor invalido"
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

        /// <summary>
        /// Metodo que convierte un numero decimal a un numero binario
        /// </summary>
        /// <param name="numero"></param> el valor que será convertido a binario
        /// <returns></returns> retorna un string que representa el numero decimal pasado como parametro convertido a binario
        public string DecimalBinario(double numero)
        {
            string binario = "";
            if (numero == 0)
            {
                binario = "0";
            }
            else
            {

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
            }
            return binario;
        }
        /// <summary>
        /// Metodo que convierte un numero decimal a un numero binario
        /// </summary>
        /// <param name="numero"></param> Valor que será convertido a binario
        /// <returns></returns> retorna un string que representa el numero decimal pasado como parametro convertido a binario
        public string DecimalBinario(string numero)
        {
            string retorno;
            retorno = DecimalBinario(double.Parse(numero));
            return retorno;
        }

        /// <summary>
        /// Sobrecarga de operador que resta el atributo numero de ambos parametros
        /// </summary>
        /// <param name="n1"></param> 1er objeto del tipo Numero
        /// <param name="n2"></param> 2do objeto del tipo Numero
        /// <returns></returns> retorna la resta, en forma de double, de n1 por n2 ( n1 - n2 )
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador que suma el atributo numero de ambos parametros
        /// </summary>
        /// <param name="n1"></param> 1er objeto del tipo Numero
        /// <param name="n2"></param> 2do objeto del tipo Numero
        /// <returns></returns> retorna la suma, en forma de double, de n1 por n2
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador que multiplica el atributo numero de ambos parametros
        /// </summary>
        /// <param name="n1"></param> 1er objeto del tipo Numero
        /// <param name="n2"></param> 2do objeto del tipo Numero
        /// <returns></returns> retorna el cociente, en forma de double, de n1 por n2
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga de operador que divide el atributonumero de ambos parametros
        /// </summary>
        /// <param name="n1"></param> 1er objeto del tipo Numero
        /// <param name="n2"></param> 2do objeto del tipo Numero
        /// <returns></returns> retorna la división, en forma de double, de n1 por n2 ( n1 / n2 )
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }
        /// <summary>
        /// Valida que el string ingresado haya sido solo númerico
        /// </summary>
        /// <param name="strNumero"></param> el valor a ser validado
        /// <returns></returns> retorna el numero ingresado en forma de double, en caso de que el mismo tenga algun termino no-numerico se retornará 0
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

