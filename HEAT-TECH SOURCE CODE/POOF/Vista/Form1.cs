using POOF.Controlador;
using POOF.Modelo;
using POOF.Vista;
using System;
using System.Windows.Forms;
using MainMenu = POOF.Vista.MainMenu;

namespace POOF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (txtPassword.Text.Equals(cmbUser.SelectedValue.ToString()))
            //{
                EmpleadoDAO u = (EmpleadoDAO)cmbUser.SelectedItem;
            
                MainMenu CheckMain = new MainMenu();
                CheckMain.Show();
                this.Hide();
            //}
            //else
            //    MessageBox.Show("Contrasena incorrecta");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PoblarControles();
        }

        private void PoblarControles()
        {
            cmbUser.DataSource = null;
            cmbUser.ValueMember = "contrasena";
            cmbUser.DisplayMember = "nombre";
            cmbUser.DataSource = ControladorUsuario.GetUsuarios();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            NewPassword frmChange = new NewPassword();
            frmChange.Show();
        }
    }
}