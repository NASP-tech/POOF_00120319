using POOF.Controlador;
using POOF.Modelo;
using System;
using System.Windows.Forms;

namespace POOF.Vista
{
    public partial class NewPassword : Form
    {
        public NewPassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCurrent.Text.Equals(cmbUser.SelectedValue.ToString()))
            {
                var obtenerUsuario = (EmpleadoDAO)cmbUser.SelectedItem;

                ActualizarControles();

                ControladorUsuario.ActualizarUsuario(txtNew.Text, cmbUser.SelectedValue.ToString());
            }
            else
                MessageBox.Show("Contrasena actual incorrecta");
        }

        private void NewPassword_Load(object sender, EventArgs e)
        {
            ActualizarControles();
        }

        private void ActualizarControles()
        {
            cmbUser.ValueMember = "contrasena";
            cmbUser.DataSource = ControladorUsuario.GetUsuarios();
            cmbUser.DisplayMember = "NombreUsuario";
        }
    }
}
