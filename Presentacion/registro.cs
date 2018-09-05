using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Presentacion
{
    public partial class registro : Form
    {
        usuario objUsuario = new usuario();
        public registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                txtnombre.Focus();
                MessageBox.Show("Este campo esta vacio");
            }
            else if (txtapellido.Text == "")
            {
                txtapellido.Focus();
                MessageBox.Show("Este campo esta vacio");
            }
            else if (txtdocumento.Text == "")
            {
                txtdocumento.Focus();
                MessageBox.Show("Este campo esta vacio");
            }
            else if (txtFnacimiento.Text == "")
            {
                txtFnacimiento.Focus();
                MessageBox.Show("Este campo esta vacio");
            }
            else
            {
                objUsuario.setNombre(txtnombre.Text);
                objUsuario.setApellido(txtapellido.Text);
                objUsuario.setDocumento(txtdocumento.Text);
                objUsuario.setFechaNacimiento(txtFnacimiento.Text);
                objUsuario.registrarUsuario();
                MessageBox.Show("Usuario Registrado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu regresa = new menu();
            regresa.Show();
        }
    }
}
