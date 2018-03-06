using System;
using System.Data;
using System.Data.SqlClient;
namespace xadrez
{
    class AddHistorico
    {
        public static void Vencedor(PartidaDeXadrez partida)
        {            
            try
            {
                DBConnect.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("INSERT INTO PARTIDAS (PLAYER, DATA, TURNOS) VALUES(@PLAYER, @DATA, @TURNOS)", DBConnect.myConnection);
                myCommand.Parameters.AddWithValue("PLAYER", partida.jogadorAtual.ToString());
                myCommand.Parameters.AddWithValue("DATA", System.DateTime.Now);
                myCommand.Parameters.AddWithValue("TURNOS", partida.turno);
                myCommand.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DBConnect.myConnection.Close();
            }
        }

        public static void historicoDePartidas()
        {
            try
            {
                DBConnect.myConnection.Open();
                SqlCommand myCommand = new SqlCommand("select ID_Partida, Player, DATA, TURNOS FROM PARTIDAS", DBConnect.myConnection);
                var dataAdapter = new SqlDataAdapter(myCommand.CommandText, DBConnect.myConnection);
                var ds = new DataSet();
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    // write the data on to the screen
                    Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",
                        // call the objects from their index
                    reader[0], reader[1], reader[2], reader[3]));
                }

            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());
            }
            finally
            {
                DBConnect.myConnection.Close();
            }
        }
    }
}
