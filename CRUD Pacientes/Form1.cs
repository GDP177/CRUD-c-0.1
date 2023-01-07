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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();

        }

        private void Refresh()
        {
            Persona oPersonaDB = new Persona();
            dataGridView1.DataSource = oPersonaDB.GetPersonaDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form= new Form2();
            form.ShowDialog();
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

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetID();
            if (id != null)
            {
                Form2 form = new Form2(id);
                form.ShowDialog();
                Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int? id = GetID();

            try
            {
                if (id != null)
                {
                    Persona personaDB = new Persona();
                    personaDB.Delete((int)id);
                    Refresh();
                }
            }
            catch(Exception ex) 
            { 
                MessageBox.Show("Ocurrio un error" + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AgregarEnfermedad form = new AgregarEnfermedad();
            form.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AgregarMedicamento form = new AgregarMedicamento();
            form.ShowDialog();
        }
    }
}
