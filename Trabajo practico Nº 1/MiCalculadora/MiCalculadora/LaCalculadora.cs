using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text.ToString(), txtNumero2.Text.ToString(), cmbOperador.SelectedItem.ToString());
            txtResultado.Text = resultado.ToString();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            txtResultado.Text = numero.DecimalBinario(txtResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            txtResultado.Text = numero.BinarioDecimal(txtResultado.Text);

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo que toma dos numeros (en forma de string), la operación a realizar y devuelve el resultado de la misma
        /// </summary>
        /// <param name="numero1"></param> 1er objeto del tipo Numero
        /// <param name="numero2"></param> 2do objeto del tipo Numero
        /// <param name="operador"></param> string que contiene el operador a aplicar
        /// <returns></returns> retorna en forma de double, el resultado de dicha operacion, en caso de que el operador sea invalido devuelve la suma
        private double Operar(string numero1, string numero2, string operador)
        {
            Calculadora calculadora = new Calculadora();
            Numero double1 = new Numero(numero1);
            Numero double2 = new Numero(numero2);
            return calculadora.Operar(double1, double2, operador);
        }

        /// <summary>
        /// Metodo que limpia el formulario
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = " ";
            txtNumero2.Text = " ";
            txtResultado.Text = " ";
            cmbOperador.SelectedIndex = -1;

        }

    }
}
