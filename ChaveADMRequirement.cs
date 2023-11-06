using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;

public class ChaveADMRequirement
{
    private int chaveADM = 0; // Defina um valor padrão que não seja 0
    public int Chama_ChaveADM()
    {

        using (var connection = new SqlConnection(@"Data Source=DESKTOP-3QU9K7J\SQLEXPRESS; Initial Catalog=Dados;Integrated Security=True;"))
        {
            connection.Open();

            var queryChaveADM = "SELECT Chave_ADM FROM AspNetUsers"; // Selecionar apenas a coluna Chave_ADM
            using (var commandChaveADM = new SqlCommand(queryChaveADM, connection))
            {
                var chaveADMResult = commandChaveADM.ExecuteScalar();
                if (chaveADMResult != DBNull.Value)
                {
                    chaveADM = Convert.ToInt32(chaveADMResult);
                }
            }
        }

        return chaveADM;
    }
}
