using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Windows.Forms;
using System.Data;

namespace Logica
{
    public class usuario
    {
        private string idUsuario;
        private string nombre;
        private string apellido;
        private string documento;
        private string fechaNacimiento;

        public void setIdUsuario(string id)
        {
            this.idUsuario = id;
        }

        public string getIdUsuario()
        {
            return idUsuario;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setApellido(string apellido)
        {
            this.apellido = apellido;
        }

        public string getApellido()
        {
            return apellido;
        }

        public void setDocumento(string documento)
        {
            this.documento = documento;
        }

        public string getDocumento()
        {
            return documento;
        }

        public void setFechaNacimiento(string fechaNacimiento)
        {
            this.fechaNacimiento = fechaNacimiento;
        }

        public string getFechaNacimiento()
        {
            return fechaNacimiento;
        }

        Datos.Conexion objConexion = new Conexion();

        public void registrarUsuario()
        {
            try
            {
                objConexion.desconectar();
                objConexion.conectar();
                string sentencia;
                sentencia = "insert into usuario (nombre ,apellido, documento, fecha_nacimiento) values ('" +
                    nombre + "','" + apellido + "'," + documento + ",'" + fechaNacimiento + "')";
                objConexion.setSentenciaSql(sentencia);
                objConexion.insertarDatos();
                objConexion.desconectar();
            }
            catch (Exception e)
            {
                objConexion.desconectar();
                throw (e);
            }
        }

        public DataTable consultarTodosUsuarios()
        {
            string sentenciaConsultarclaseUsuario = "";
            try
            {
                objConexion.desconectar();
                objConexion.conectar();
                sentenciaConsultarclaseUsuario = "select * from usuario";
                objConexion.setSentenciaSql(sentenciaConsultarclaseUsuario);
                return objConexion.consultarDatos();
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show("Error al consultar los usuarios");
                MessageBox.Show(ex.Message);
                return objConexion.consultarDatos();
            }
        }

        public void actualizarDatosUsuario()
        {
            objConexion.desconectar();
            objConexion.conectar();
            string sentencia;
            sentencia = "update usuario set nombre = '" + nombre + "', apellido = '" + apellido + "', documento = " + documento +
                ", fecha_nacimiento = '" + fechaNacimiento + "' where id =" + idUsuario;
            objConexion.setSentenciaSql(sentencia);
            objConexion.actualizarDatos();
        }
    }
}
