using System.Data.SqlClient;
using SistemaRH.Models;

namespace SistemaRH.Tabelas;

public class AliquotaTabela
{
    SqlConnection connection = new SqlConnection(ConexaoSQL.ConnectionString);

    public void Deleta(int id) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"delete from tbAliquotas where id = @id;", connection);
            
            sqlCommand.Parameters.AddWithValue("@id", id);

            sqlCommand.ExecuteScalar();
            sqlCommand.Dispose();    
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally {
            connection.Close();
        }
    }

    public void Atualiza(Aliquota aliquota) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"update tbAliquotas set anoVigencia = @anoVigencia, descricao = @descricao, desconta = @desconta where id = @id;", connection);
            
            sqlCommand.Parameters.AddWithValue("@anoVigencia", aliquota.AnoVigencia);
            sqlCommand.Parameters.AddWithValue("@descricao", aliquota.Descricao);
            sqlCommand.Parameters.AddWithValue("@desconta", aliquota.Desconta);
            sqlCommand.Parameters.AddWithValue("@id", aliquota.Id);

            sqlCommand.ExecuteScalar();
            sqlCommand.Dispose();    
        }
        catch (Exception)
        {
            throw new Exception("Erro ao atualizar dados");
        }
        finally {
            connection.Close();
        }
    }

    public Aliquota GetAliquota(int id) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"select * from tbAliquotas where id = @id", connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            int anoVigencia = 0;
            string descricao = string.Empty;
            bool? desconta = null;

            while (reader.Read()){
                anoVigencia = Convert.ToInt32(reader[1]);
                descricao =  reader[2].ToString();
                desconta =  Convert.ToBoolean(reader[3]);
                break;
            }

            sqlCommand.Dispose();
            reader.Close();

            if (descricao == string.Empty && anoVigencia == 0 && desconta == null)
            {
                return null;
            }

            Aliquota Aliquota = new Aliquota()
            {
                Id = id,
                Descricao = descricao,
                AnoVigencia = anoVigencia,
                Desconta = (bool)desconta
            };

            return Aliquota;
        }
        catch (System.Exception)
        {
            throw new Exception("Erro ao tentar recuperar dados");
        }
        finally {
            connection.Close();
        }
    }

    public int Inserir(string descricao, int anoVigencia, bool desconta) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"insert into tbAliquotas (anoVigencia, descricao, desconta) values (@anoVigencia, @descricao, @desconta); SELECT SCOPE_IDENTITY();", connection);
            
            sqlCommand.Parameters.AddWithValue("@descricao", descricao);
            sqlCommand.Parameters.AddWithValue("@anoVigencia", anoVigencia);
            sqlCommand.Parameters.AddWithValue("@desconta", desconta);

            int id = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlCommand.Dispose();

            return id;   
        }
        catch (System.Exception)
        {
            throw new Exception("Erro ao tentar inserir dados");
        }
        finally {
            connection.Close();
        }
    }

    public List<Aliquota> GetAliquotas()
    {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"select * from tbAliquotas", connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Aliquota> aliquotas = new List<Aliquota>();

            while (reader.Read()){
                Aliquota aliquota = new Aliquota
                {
                    Id = Convert.ToInt32(reader[0]),
                    AnoVigencia = Convert.ToInt32(reader[1]),
                    Descricao = reader[2].ToString(),
                    Desconta = Convert.ToBoolean(reader[3])
                };

                aliquotas.Add(aliquota);
            }

            sqlCommand.Dispose();
            reader.Close();


            return aliquotas;
        }
        catch (System.Exception)
        {
            throw new Exception("Erro ao tentar recuperar dados");
        }
        finally {
            connection.Close();
        }
    }
}