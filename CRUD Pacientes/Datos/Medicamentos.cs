using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Pacientes.Datos
{
    public class Medicamentos
    {

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; } 
        private string ConnectionString = "Data Source=localhost; Initial Catalog=Proyecto; Integrated Security=true";


        public void Add(string nombre,string descripcion)
        {

            string query = "insert into Table_Medicamentos(nombre,descripcion) values" +
                "(@nombre,@descripcion)";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@descripcion", descripcion);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Hay un error en la db" + ex.Message);
                }
            }

        }

        //Metodo para eliminar elementos
        public void Delete(int id)
        {

            string query = "delete from Table_Medicamentos" +
                " where id=@id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Hay un error en la db" + ex.Message);
                }
            }

        }


        //Lista de datos
        public List<Medicamentos> GetMedicamentos()
        {
            List<Medicamentos> ListaMedicamentos = new List<Medicamentos>();
            string query = "select * from Table_Medicamentos";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    //este codigo lee los datos de la DB a la que nos conectamos
                    SqlDataReader reader = command.ExecuteReader();
                    //Este while lo que hace es leer todos los datos almacenados en la DB
                    while (reader.Read())
                    {
                        //Aca almacenamos los datos de la DB en la lista que vamos a mostrar
                        Medicamentos DMedicamentos = new Medicamentos();
                        DMedicamentos.ID = reader.GetInt32(0);
                        DMedicamentos.Nombre = reader.GetString(1);
                        DMedicamentos.Descripcion = reader.GetString(2);
                        //Agregamos el objeto a la lista
                        ListaMedicamentos.Add(DMedicamentos);

                    }
                    reader.Close();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Hay un error en la db" + ex.Message);
                }
            }
            return ListaMedicamentos;
        }



        public Medicamentos GetMedicamentos(int Id)
        {
            string query = "select id,nombre,descripcion from Table_Medicamentos" +
                " where id=@Id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    //este codigo lee los datos de la DB a la que nos conectamos
                    SqlDataReader reader = command.ExecuteReader();
                    //Este while lo que hace es leer todos los datos almacenados en la DB
                    reader.Read();
                    //PersonaDatos Dpersona = new PersonaDatos();
                    Medicamentos DMedicamentos = new Medicamentos();
                    DMedicamentos.ID = reader.GetInt32(0);
                    DMedicamentos.Nombre = reader.GetString(1);
                    DMedicamentos.Descripcion = reader.GetString(2);
                    reader.Close();
                    connection.Close();

                    return DMedicamentos;

                }
                catch (SqlException ex)
                {
                    throw new Exception("Hay un error en la db" + ex.Message);
                }
            }
        }

    }
}

