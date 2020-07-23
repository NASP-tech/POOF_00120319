using POOF.Controlador;
using POOF.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POOF.Vista
{
    public partial class MainMenu : Form
    {
        //CProxy.IComponente myProxy = new CProxy.ProxySencillo();
        public MainMenu()
        {
            InitializeComponent();
            EmpleadoDAO emp = new EmpleadoDAO();
            //myProxy.entrar(emp.idDepartamento);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //ActualizarControles();
        }

        private void btnEntrance_Click(object sender, EventArgs e)
        {
            if (txtDUI.Text.Equals("") &&
                txtTemperature.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                int idUsuario;
                try
                {
                    string sql = String.Format($"select idusuario from usuario where dui = '{txtDUI.Text}' ");
                    idUsuario = ConnectionDB.EjecutaEscalar(sql);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                    idUsuario = 0;
                }

                bool entrada = true;
                if (Convert.ToDouble(txtTemperature.Text) >= 37.5)
                    entrada = false;

                double temperatura = Convert.ToDouble(txtTemperature.Text);

                ControladorRegistro.CrearRegistro(idUsuario, entrada, DateTime.Now, temperatura);                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (txtDUI.Text.Equals("") &&
                txtTemperature.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                int idUsuario;
                try
                {
                    string sql = String.Format($"select idusuario from usuario where dui = '{txtDUI.Text}' ");
                    idUsuario = ConnectionDB.EjecutaEscalar(sql);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                    idUsuario = 0;
                }

                bool entrada = false;

                double temperatura = Convert.ToDouble(txtTemperature.Text);

                ControladorRegistro.CrearRegistro(idUsuario, entrada, DateTime.Now, temperatura);
            }
        }

        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            ActualizarControles();
        }

        private void ActualizarControles()
        {
            List<RegistroDAO> lista = ControladorRegistro.GetRegList(txtDUIREG.Text);
            dgvUserHistory.DataSource = null;
            dgvUserHistory.DataSource = lista;

            int idUsuario;
            try
            {
                string sql = String.Format($"select idusuario from usuario where dui = '{txtDUIREG.Text}' ");
                idUsuario = ConnectionDB.EjecutaEscalar(sql);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
                idUsuario = 0;
            }

            List<RegistroDAO> list = ControladorRegistro.GetRegListTop(idUsuario);
            dgvMaximunTemperature.DataSource = null;
            dgvMaximunTemperature.DataSource = list;
        }
    }
}
