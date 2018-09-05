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
    public partial class consulta : Form
    {
        DataTable tablaUsuario = new DataTable();
        usuario objUsuario = new usuario();
        public consulta()
        {
            InitializeComponent();
            tablaUsuario = objUsuario.consultarTodosUsuarios();
            dataGridView1.DataSource = tablaUsuario;
        }

        private void consulta_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Point punto = dataGridView1.CurrentCellAddress;
            int n_fila = punto.Y;
            int n_columna = punto.X;
            modificarDatos(tablaUsuario, n_fila);
        }

        private void modificarDatos(DataTable tabla, int varIndex)
        {
            int index;
            index = varIndex;

            txtNombre.Text = tabla.Rows[index]["nombre"].ToString();
            txtApellido.Text = tabla.Rows[index]["apellido"].ToString();
            txtDocumento.Text = tabla.Rows[index]["documento"].ToString();
            txtFechaNacimiento.Text = tabla.Rows[index]["fecha_nacimiento"].ToString();
            txtID.Text = tabla.Rows[index]["id"].ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            menu formulario = new menu();
            formulario.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Focus();
                MessageBox.Show("Este campo esta vacio");
            }
            else if (txtApellido.Text == "")
            {
                txtApellido.Focus();
                MessageBox.Show("Este campo esta vacio");
            }
            else if (txtDocumento.Text == "")
            {
                txtDocumento.Focus();
                MessageBox.Show("Este campo esta vacio");
            }
            else if (txtFechaNacimiento.Text == "")
            {
                txtFechaNacimiento.Focus();
                MessageBox.Show("Este campo esta vacio");
            }
            else
            {
                objUsuario.setNombre(txtNombre.Text);
                objUsuario.setApellido(txtApellido.Text);
                objUsuario.setDocumento(txtDocumento.Text);
                objUsuario.setFechaNacimiento(txtFechaNacimiento.Text);
                objUsuario.setIdUsuario(txtID.Text);
                objUsuario.actualizarDatosUsuario();
                MessageBox.Show("Usuario Actualizado");
            }
        }
    }
}
