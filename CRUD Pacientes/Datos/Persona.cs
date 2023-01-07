using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Windows.Forms;

namespace CRUD_Pacientes.Datos
{
    public class Persona
    {
        //string para realizar la conexion con la DB
        private string ConnectionString = "Data Source=localhost; Initial Catalog=Proyecto; Integrated Security=true";
        //Metodo para verificar conexion con la base de datos
        public bool Ok()
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString); 
                connection.Open();
            }
            catch
            {
                return false;
            }
            return true;
           
        }

        //Lista de datos
        public List<PersonaDatos> GetPersonaDatos()
        {
            List<PersonaDatos> personaDatos= new List<PersonaDatos>();
            string query = "select * from Table_Pacientes";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    //este codigo lee los datos de la DB a la que nos conectamos
                    SqlDataReader reader= command.ExecuteReader();
                    //Este while lo que hace es leer todos los datos almacenados en la DB
                    while (reader.Read())
                    {
                        //Aca almacenamos los datos de la DB en la lista que vamos a mostrar
                        PersonaDatos Dpersona = new PersonaDatos();
                        Dpersona.Id = reader.GetInt32(0);
                        Dpersona.Nombre = reader.GetString(1);
                        Dpersona.Apellido= reader.GetString(2);
                        Dpersona.DNI= reader.GetString(3);
                        Dpersona.Direccion = reader.GetString(4);
                        Dpersona.Fecha_nacimiento = reader.GetDateTime(5);

                        //Agregamos el objeto a la lista
                        personaDatos.Add( Dpersona );

                    }
                    reader.Close(); 
                    connection.Close(); 
                }
                catch(SqlException ex)
                {
                    throw new Exception("Hay un error en la db" + ex.Message);
                }
            }
            return personaDatos;
        }
        public PersonaDatos GetPersonaDatos(int Id)
        {
            string query = "select id,nombre,apellido,dni,direccion,fecha_nacimiento from Table_Pacientes" +
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
                    PersonaDatos Dpersona = new PersonaDatos();
                    Dpersona.Id = reader.GetInt32(0);
                    Dpersona.Nombre = reader.GetString(1);
                    Dpersona.Apellido = reader.GetString(2);
                    Dpersona.DNI = reader.GetString(3);
                    Dpersona.Direccion = reader.GetString(4);
                    Dpersona.Fecha_nacimiento = reader.GetDateTime(5);
                    reader.Close();
                    connection.Close();
                    
                    return Dpersona;
                    
                }
                catch (SqlException ex)
                {
                    throw new Exception("Hay un error en la db" + ex.Message);
                }
            }
        }

        //Metodo para agregar elementos a la DB
        public void Add(string nombre, string apellido, string dni, string direccion, DateTime fecha_nacimiento)
        {

            string query = "insert into Table_Pacientes(nombre,apellido,dni,direccion,fecha_nacimiento) values" +
                "(@nombre, @apellido, @dni, @direccion, @fecha_nacimiento)";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@dni", dni);
                command.Parameters.AddWithValue("@direccion", direccion);
                command.Parameters.AddWithValue("@fecha_nacimiento", fecha_nacimiento);

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

        //Metodo para editar elementos en la DB

        public void Edit(string nombre, string apellido, string dni, string direccion, DateTime fecha_nacimiento, int id)
        {

            string query = "update Table_Pacientes set nombre=@nombre, apellido=@apellido, dni=@dni, direccion=@direccion, fecha_nacimiento=@fecha_nacimiento" +
                " where id=@id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@dni", dni);
                command.Parameters.AddWithValue("@direccion", direccion);
                command.Parameters.AddWithValue("@fecha_nacimiento", fecha_nacimiento);
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

        //Metodo para eliminar elementos
        public void Delete(int id)
        {

            string query = "delete from Table_Pacientes" +
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


    }

    //Clase persona
    public class PersonaDatos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Direccion { get; set; }

        public DateTime Fecha_nacimiento { get; set; }  
    }
}
