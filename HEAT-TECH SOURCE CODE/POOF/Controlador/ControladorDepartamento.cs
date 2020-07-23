using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using POOF.Modelo;

namespace POOF.Controlador
{
    class ControladorDepartamento
    {
        public static List<DepartamentoDAO> getDepa()
        {
            string sql = "select * from departamento";
            DataTable tableDepartamentos = ConnectionDB.ExecuteQuery(sql);
            List<DepartamentoDAO> list = new List<DepartamentoDAO>();

            foreach (DataRow dr in tableDepartamentos.Rows)
            {
                DepartamentoDAO d = new DepartamentoDAO();
                d.idDepartamento = Convert.ToInt32(dr[0].ToString());
                d.nombre = dr[1].ToString();
                d.ubicacion = dr[2].ToString();
                list.Add(d);
            }

            return list;
        }
    }
}
