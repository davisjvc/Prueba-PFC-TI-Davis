using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Servicios.Models;

namespace Servicios.DataAccess
{
    public class OrdenDataAccess
    {
        public List<Orden> ConsultarOrdenes(int clienteId)
        {
            List<Orden> lstOrdenes = new List<Orden>();

            using (SqlConnection connection = DataBase.GetSqlConnection())
            {
                string sqlQuery = "";
                sqlQuery = sqlQuery + "SELECT [OrdenId] " + "\n";
                sqlQuery = sqlQuery + "      ,[FechaOrden] " + "\n";
                sqlQuery = sqlQuery + "      ,[TipoPago] " + "\n";
                sqlQuery = sqlQuery + "      ,[Total] " + "\n";
                sqlQuery = sqlQuery + "      ,[Entregada] " + "\n";
                sqlQuery = sqlQuery + "      ,[ClienteId] " + "\n";
                sqlQuery = sqlQuery + "  FROM [dbo].[Orden] " + "\n";
                sqlQuery = sqlQuery + "  WHERE ClienteId = @clienteId";


                try
                {
                    SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("clienteId", clienteId);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Orden orden = new Orden();

                        orden.OrdenId = Convert.ToInt32(rdr["OrdenId"]);
                        orden.FechaOrden = Convert.ToDateTime(rdr["FechaOrden"].ToString());
                        orden.TipoPago = rdr["TipoPago"].ToString();
                        orden.Total = Convert.ToDecimal(rdr["Total"]);
                        orden.Entregada = Convert.ToBoolean(rdr["Entregada"]);
                        orden.ClienteId = Convert.ToInt32(rdr["ClienteId"]);

                        lstOrdenes.Add(orden);
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
                
            }
            return lstOrdenes;
        }


        
        public int EliminarOrden(int ordenId)
        {
            int counter = 0;
            using (SqlConnection connection = DataBase.GetSqlConnection())
            {
                String storeProc = "procEliminarOrden";

                using (SqlCommand command = new SqlCommand(storeProc, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("OrdenId", ordenId);

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.DeleteCommand = command;
                        counter = adapter.DeleteCommand.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }
                    
                }
            }
            return counter;
        }
    }
}