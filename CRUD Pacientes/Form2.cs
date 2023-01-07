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
    public partial class Form2 : Form
    {
        private int? Id;
        public Form2(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
            if(this.Id != null)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            Persona persona = new Persona();
            PersonaDatos Dpersona = persona.GetPersonaDatos((int)Id);
            textBox1.Text = Dpersona.Nombre;
            textBox2.Text = Dpersona.Apellido;
            textBox3.Text = Dpersona.DNI;
            textBox4.Text = Dpersona.Direccion;
           // dateTimePicker1.Value = (DateTime)Dpersona.Fecha_nacimiento;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Persona DPersona = new Persona();

            try
            {
                if (Id == null)
                {
                    DPersona.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Value);
                    MessageBox.Show("Nuevo paciente almacenado.");
                }
                else
                {
                    DPersona.Edit(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Value, (int)Id);
                    MessageBox.Show("Paciente actualizado.");

                }


                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar" + ex.Message);
            }
            
        }
    }
}
