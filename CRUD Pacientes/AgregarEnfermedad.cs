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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD_Pacientes
{
    public partial class AgregarEnfermedad : Form
    {
        public AgregarEnfermedad()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            Enfermedades DEnfermedad = new Enfermedades();
            dataGridView1.DataSource = DEnfermedad.GetEnfermedades();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Enfermedades DEnfermedades = new Enfermedades();
            try
            {
                if (textBox1.Text != "")
                {
                    DEnfermedades.Add(textBox1.Text);
                    MessageBox.Show("Nueva enfermedad almacenada.");
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



        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetID();

            try
            {
                if (id != null)
                {
                    Enfermedades DEnfermedad = new Enfermedades();
                    DEnfermedad.Delete((int)id);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarEnfermedad_Load(object sender, EventArgs e)
        {
            Refresh();
        }

      
    }
}
