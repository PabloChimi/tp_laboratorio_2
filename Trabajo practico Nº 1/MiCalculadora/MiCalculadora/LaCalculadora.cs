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

        private double Operar(string numero1, string numero2, string operador)
        {
            Calculadora calculadora = new Calculadora();
            Numero double1 = new Numero(numero1);
            Numero double2 = new Numero(numero2);
            return calculadora.Operar(double1, double2, operador);
        }

        private void Limpiar()
        {
            txtNumero1.Text = " ";
            txtNumero2.Text = " ";
            txtResultado.Text = " ";
            cmbOperador.SelectedIndex = -1;

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
    }
}
