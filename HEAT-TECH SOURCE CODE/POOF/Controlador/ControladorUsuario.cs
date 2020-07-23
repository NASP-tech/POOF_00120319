using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using POOF.Modelo;

namespace POOF.Controlador
{
    class ControladorUsuario
    {
        public static List<EmpleadoDAO> GetUsuarios()
        {
            string sql = "select * from usuario";

            DataTable tableUsuarios = ConnectionDB.ExecuteQuery(sql);

            List<EmpleadoDAO> list = new List<EmpleadoDAO>();



            foreach (DataRow dr in tableUsuarios.Rows)
            {
                EmpleadoDAO u = new EmpleadoDAO();
                u.idUsuario = Convert.ToInt32(dr[0].ToString());
                u.idDepartamento = Convert.ToInt32(dr[1].ToString());
                u.contrasena = dr[2].ToString();
                u.nombre = dr[3].ToString();
                u.apellido = dr[4].ToString();
                u.DUI = dr[5].ToString();
                u.FechadeNacimiento = Convert.ToDateTime(dr[6].ToString());
                list.Add(u);

            }

            return list;
        }
                     
        public static void CrearUsuario(int idDepartamento, string contrasena, string nombre, string apellido, string dui, DateTime fechaNacimiento)
        {
            try
            {
                string sql = String.Format(
                    "insert into usuario(iddepartamento, contrasena, nombre, apellido, dui, fechanacimiento)" +
                    "values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', );",
                    idDepartamento, contrasena, nombre, apellido, dui, fechaNacimiento);

                //Natalia: Debe llamarse a la conexion de la base de datos:
                ConnectionDB.ExecuteQuery(sql);

                MessageBox.Show("Se ha agregado el nuevo usuario, contrasenia igual al nombre");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        public static void EliminarUsuario(string id)
        {
            try
            {
                ConnectionDB.ExecuteNonQuery($"DELETE FROM USUARIO WHERE idusuario = '{id}'");

                MessageBox.Show("Se ha eliminado el empleado");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }
        
        public static void ActualizarUsuario(string contrasena, string nombre)
        {
            try
            {
                string sql = String.Format(
                    "update usuario set contrasenia = '{0}' where nombre = '{1}';",
                    contrasena, nombre);
                //Natalia: Debe llamarse a la conexion de la base de datos:
                ConnectionDB.ExecuteQuery(sql);


                MessageBox.Show("Se ha actualizado la contrasena");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }
    }
}
