using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Metodo que toma dos numeros, la operación a realizar y devuelve el resultado de la misma
        /// </summary>
        /// <param name="num1"></param> 1er objeto del tipo Numero
        /// <param name="num2"></param> 2do objeto del tipo Numero
        /// <param name="operador"></param> string que contiene el operador a aplicar
        /// <returns></returns> retorna en forma de double, el resultado de dicha operacion, en caso de que el operador sea invalido devuelve la suma
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            operador = ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Metodo que valida que el string ingresado sea un operador valido
        /// </summary>
        /// <param name="operador"></param> el string a validar
        /// <returns></returns> retorna el operador ingresado en caso de ser valido, caso contrario ser retorna el operador + (En forma de string)
        private string ValidarOperador(string operador)
        {

            if (operador == "/" || operador == "*" || operador == "-")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }
    }
}

