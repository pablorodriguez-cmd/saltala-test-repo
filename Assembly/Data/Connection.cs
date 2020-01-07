using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Assembly.Entity;

namespace Assembly.Data
{
    public class Connection : IDisposable
    {
        private OracleConnection _con;
        public Connection()
        {
            /*
             * Nunca dejar connection strings en duro, se debe dejar en archivo de configuración idealmente.
             * Dado el proyecto pequeño se deja así para una rápida funcionalidad.
             * */
            string connString = "Data Source=localhost:1521/xe;User Id=SALTALA;Password=saltala;";
            _con = new OracleConnection(connString);
            _con.Open();
        }

        public void Dispose()
        {
            _con.Close();
        }

        //En condiciones normales se crearía una clase conexión base, de la cual heredarían las demás clases que interactuarían con la BD en el caso de un API, por ejemplo.
        public int ExecuteNonQuery(string query)
        {
            OracleCommand command = new OracleCommand(query, _con);
            return command.ExecuteNonQuery();
        }

        public bool InsertFormData(FormData data)
        {
            string query = string.Format("INSERT INTO FORM_DATA VALUES(SEQ_FORM_DATA.NEXTVAL, '{0}', '{1}', '{2}', {3})",
                                            data.Name,
                                            data.LastName,
                                            data.RegisterReason,
                                            data.Apply ? 1 : 0);


            OracleCommand command = new OracleCommand(query, _con);
            return command.ExecuteNonQuery() > 0;
        }

        public List<Entity.FormData> GetAllFormData()
        {
            string query = "SELECT id, name, last_name, register_reason, apply FROM FORM_DATA";

            OracleCommand command = new OracleCommand(query, _con);

            command.CommandType = System.Data.CommandType.Text;

            List<FormData> model = new List<FormData>();

            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    FormData data = new FormData();
                    data.Id = reader.IsDBNull(0) ? -1 : reader.GetInt32(0);
                    data.Name = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    data.LastName = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    data.RegisterReason = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    data.Apply = reader.GetString(4) == "1";

                    model.Add(data);
                }
            }

            return model;
        }
    }
}
