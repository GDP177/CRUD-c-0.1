using CRUD_Pacientes.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Pacientes
{
    public partial class AgregarMedicamento : Form
    {
        public AgregarMedicamento()
        {
            InitializeComponent();
        }
         
        private void Refresh()
        {
            Medicamentos DMedicamentos = new Medicamentos();
            dataGridView1.DataSource = DMedicamentos.GetMedicamentos();
        }

          



        #region HELPER
        private int? GetID()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }

        }
        #endregion


       
    

        private void AgregarMedicamento_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Medicamentos DMedicamentos = new Medicamentos();
            try
            {
                if (textBox1.Text != "")
                {
                    DMedicamentos.Add(textBox1.Text, richTextBox1.Text);
                    MessageBox.Show("Nuevo medicamento almacenado.");
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Rellenar nombre");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar" + ex.Message);
            }
            Refresh();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int? id = GetID();

            try
            {
                if (id != null)
                {
                    Medicamentos DMedicamentos = new Medicamentos();
                    DMedicamentos.Delete((int)id);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error" + ex.Message);
            }
        }
    }
}
