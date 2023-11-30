using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Gestor_de_tareas.Datas;

namespace Gestor_de_tareas
{
    public class Conexion
    {
        
        public string StatusMessage { get; set; }

        private SqliteConnection conn;

        string strConect = "Data source ="+FileSystem.Current.AppDataDirectory + "/BasedDatos.db";
    
        public void CrearTabla()
        {
            using (var conn = new SqliteConnection(strConect))
            {
                conn.Open();

                var command = conn.CreateCommand();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS Tareas(
                                        nombreTarea varchar(100) primary key,
                                        contenidoTarea varchar(500)
                                        )";

                command.ExecuteNonQuery();
            }
        }
        public async void InsertarTarea(string nombreTarea,string contenidoTarea)
        {
            

                using (var conn = new SqliteConnection(strConect))
                {
                    conn.Open();
                    var command = conn.CreateCommand();
                    command.CommandText = "INSERT INTO Tareas VALUES (@nombreTarea,@contenidoTarea)";
                    command.Parameters.Add("@nombreTarea", SqliteType.Text);
                    command.Parameters.Add("@contenidoTarea", SqliteType.Text);
                    //command.Parameters.Add("@dCreacion", SqliteType.Text);


                command.Parameters["@nombreTarea"].Value = nombreTarea;
                    command.Parameters["@contenidoTarea"].Value = contenidoTarea;
                    //command.Parameters["@dCreacion"].Value = dCreacion;
                    //command.Parameters["@mesCreacion"].Value = mesC;
                    //command.Parameters["@anhioCreacion"].Value = anhioC;
                    command.ExecuteNonQuery();
                }         
           
        }

        public List<Tareas> Verdatos()
        {
            var TodasLasTareas = new List<Tareas>();
            using (var conn = new SqliteConnection(strConect))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM Tareas";

                using(var reader= command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime fechahoy = DateTime.Now;
                        string fechaux = fechahoy.ToString();

                        Tareas TareaAgregar = new Tareas();
                        {
                            TareaAgregar.Nombre_Tarea= reader.GetString(0);
                            TareaAgregar.Contenido_Tarea= reader.GetString(1);
                           //TareaAgregar.FechaCreacion.AuxDia = reader.GetString(2);
                           //TareaAgregar.FechaCreacion.Anhio =reader.GetInt32(4);
                            TareaAgregar.Imagen = "icono_tarea.png";
                            TareaAgregar.fechaux= fechaux;
                        };
                        TodasLasTareas.Add(TareaAgregar);
                    }
                }
            }
            return TodasLasTareas;
        }
        public void Eliminador(string nomtarea)
        {
            using (var conn = new SqliteConnection(strConect))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "DELETE FROM TAREAS WHERE nombreTarea = @Primaria";
                command.Parameters.AddWithValue("@Primaria", nomtarea);
                
                command.ExecuteNonQuery();
            }
        }
    }
}
