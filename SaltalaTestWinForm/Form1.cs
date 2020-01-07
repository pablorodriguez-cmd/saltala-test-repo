using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assembly.Entity;
using Assembly.Data;

namespace SaltalaTestWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var list = Assembly.Core.ListBoxOptions.GetListBoxOptions();

            //carga las opciones en el ListBox
            list.ForEach(i => listBoxRegisterReason.Items.Add(i));
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Length == 0 ||
                    txtLastName.Text.Length == 0 ||
                    listBoxRegisterReason.SelectedItem == null
                    )
                {
                    MessageBox.Show("Por favor complete todos los campos antes de continuar.");
                }
                else
                {
                    FormData data = new FormData();
                    data.Name = txtName.Text;
                    data.LastName = txtLastName.Text;
                    data.RegisterReason = listBoxRegisterReason.SelectedItem.ToString();
                    data.Apply = chkApply.Checked;

                    using (Connection con = new Connection())
                    {
                        if (con.InsertFormData(data))
                        {
                            MessageBox.Show("Registro ingresado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo ingresar el registro.");
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                var exresult = ex;
                MessageBox.Show("Se produjo un error al procesar la solicitud.");
            }
        }
    }
}
