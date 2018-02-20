using System;
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
    }
}
