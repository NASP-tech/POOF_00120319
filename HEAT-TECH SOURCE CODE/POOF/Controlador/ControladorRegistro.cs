using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using POOF.Modelo;

namespace POOF.Controlador
{
    class ControladorRegistro
    {
       public static List<RegistroDAO> GetReg()
        {
            string sql = "select * from registro";

            DataTable tableRegistros = ConnectionDB.ExecuteQuery(sql);

            List<RegistroDAO> list = new List<RegistroDAO>();

            foreach (DataRow dr in tableRegistros.Rows)
            {
                RegistroDAO r = new RegistroDAO();
                r.idRegistro = Convert.ToInt32(dr[0].ToString());
                r.idUsuario = Convert.ToInt32(dr[1].ToString());
                r.entrada = Convert.ToBoolean(dr[2].ToString());
                r.fechaYhora = Convert.ToDateTime(dr[3].ToString());
                r.temperatura = Convert.ToDouble(dr[4].ToString());
                list.Add(r);
            }

            return list;
            
        }

        public static List<RegistroDAO> GetRegList(string dui)
        {
            int idUsuario;
            try
            {
                string sql1 = String.Format($"select idusuario from usuario where dui = '{dui}' ");
                idUsuario = ConnectionDB.EjecutaEscalar(sql1);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
                idUsuario = 0;
            }
            string sql = $"select * from registro where idusuario = {idUsuario}";

            DataTable tableRegistros = ConnectionDB.ExecuteQuery(sql);

            List<RegistroDAO> list = new List<RegistroDAO>();

            foreach (DataRow dr in tableRegistros.Rows)
            {
                RegistroDAO r = new RegistroDAO();
                r.idRegistro = Convert.ToInt32(dr[0].ToString());
                r.idUsuario = Convert.ToInt32(dr[1].ToString());
                r.entrada = Convert.ToBoolean(dr[2].ToString());
                r.fechaYhora = Convert.ToDateTime(dr[3].ToString());
                r.temperatura = Convert.ToDouble(dr[4].ToString());
                list.Add(r);
            }

            return list;

        }

        public static List<RegistroDAO> GetRegListTop(int idusuario)
        {
            string sql = $"select * from registro where idusuario = {idusuario} order by temperatura desc limit 1";

            DataTable tableRegistros = ConnectionDB.ExecuteQuery(sql);

            List<RegistroDAO> list = new List<RegistroDAO>();

            foreach (DataRow dr in tableRegistros.Rows)
            {
                RegistroDAO r = new RegistroDAO();
                r.idRegistro = Convert.ToInt32(dr[0].ToString());
                r.idUsuario = Convert.ToInt32(dr[1].ToString());
                r.entrada = Convert.ToBoolean(dr[2].ToString());
                r.fechaYhora = Convert.ToDateTime(dr[3].ToString());
                r.temperatura = Convert.ToDouble(dr[4].ToString());
                list.Add(r);
            }

            return list;

        }

        public static void CrearRegistro(int idUsuario, bool entrada, DateTime fechaYhora, double temperatura)
        {
            try
            {
                string sql = String.Format(
                    "insert into registro(idusuario, entrada, fechayhora, temperatura)" +
                    "values({0}, '{1}', '{2}', {3});",
                    idUsuario, entrada, fechaYhora, temperatura);
                ConnectionDB.ExecuteNonQuery(sql);

                MessageBox.Show("Se ha agregado el nuevo registro.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        public static void EliminarRegistro(string id)
        {
            try
            {
                ConnectionDB.ExecuteNonQuery($"DELETE FROM REGISTRO WHERE idUsuario = '{id}'");

                MessageBox.Show("Se ha eliminado el registro");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }
        
        public static void ActualizarRegistro(double temperatura, string id)
        {
            try
            {
                ConnectionDB.ExecuteNonQuery($"UPDATE REGISTRO SET temperatura = '{temperatura}' " +
                                             $"WHERE idUsuario = '{id}'");                         

                MessageBox.Show("Se ha agregado el nuevo empleado");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }
    }
}
