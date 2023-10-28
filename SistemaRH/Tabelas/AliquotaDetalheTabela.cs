using System.Data.SqlClient;


namespace SistemaRH.Tabelas;

public class AliquotaDetalheTabela
{
    SqlConnection connection = new SqlConnection(ConexaoSQL.ConnectionString);

    public void Deleta(int id) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new(@$"delete from tbAliquotaDetalhes where id = @id;", connection);
            
            sqlCommand.Parameters.AddWithValue("@id", id);

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

    public void Atualiza(AliquotaDetalhe AliquotaDetalhe) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"update tbAliquotaDetalhes set baseCalculo = @baseCalculo, porcentagem = @porcentagem where id = @id;", connection);
            
            sqlCommand.Parameters.AddWithValue("@baseCalculo", AliquotaDetalhe.BaseCalculo);
            sqlCommand.Parameters.AddWithValue("@porcentagem", AliquotaDetalhe.Porcentagem);
            sqlCommand.Parameters.AddWithValue("@id", AliquotaDetalhe.Id);

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

    public AliquotaDetalhe GetAliquotaDetalhe(int id) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"select AD.id, AD.idAliquota, AD.baseCalculo, AD.porcentagem, A.descricao from tbAliquotaDetalhes AD join tbAliquotas A on A.id = AD.idAliquota where AD.id = @id", connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            int idAliquota = 0;
            decimal baseCalculo = 0;
            float porcentagem = 0;
            string aliquotaDescricao = string.Empty;

            while (reader.Read()){
                idAliquota = Convert.ToInt32(reader[1]);
                baseCalculo =  Convert.ToDecimal(reader[2]);
                porcentagem =  Convert.ToSingle(reader[3]);
                aliquotaDescricao = Convert.ToString(reader[4]);
                break;
            }

            sqlCommand.Dispose();
            reader.Close();

            if (idAliquota == 0 && baseCalculo == 0 && porcentagem == 0)
            {
                return null;
            }

            AliquotaDetalhe aliquotaDetalhe = new AliquotaDetalhe()
            {
                Id = id,
                IdAliquota = idAliquota,
                BaseCalculo = baseCalculo,
                Porcentagem = porcentagem,
                Aliquota = new Models.Aliquota
                {
                    Descricao = aliquotaDescricao
                }
                
            };

            return aliquotaDetalhe;
        }
        catch (System.Exception)
        {
            throw new Exception("Erro ao tentar recuperar dados");
        }
        finally {
            connection.Close();
        }
    }

    public List<AliquotaDetalhe> GetAliquotaDetalhes(int anoVigencia)
    {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"select ad.id, ad.idAliquota, ad.baseCalculo, ad.porcentagem, a.descricao, a.desconta, a.anoVigencia from tbAliquotaDetalhes ad join tbAliquotas a on a.id = ad.idAliquota where a.anoVigencia = @anoVigencia", connection);
            sqlCommand.Parameters.AddWithValue("@anoVigencia", anoVigencia);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            var aliquotaDetalhes = new List<AliquotaDetalhe>();

            while (reader.Read())
            {
                var aliquotaDetalhe = new AliquotaDetalhe()
                {
                    Id = Convert.ToInt32(reader[0]),
                    IdAliquota = Convert.ToInt32(reader[1]),
                    BaseCalculo = Convert.ToDecimal(reader[2]),
                    Porcentagem = Convert.ToSingle(reader[3]),
                    Aliquota = new Models.Aliquota
                    {
                        Id = Convert.ToInt32(reader[1]),
                        Descricao = reader[4].ToString(),
                        Desconta = Convert.ToBoolean(reader[5]),
                        AnoVigencia = Convert.ToInt32(reader[6]),
                    }
                };

                aliquotaDetalhes.Add(aliquotaDetalhe);
            }

            sqlCommand.Dispose();
            reader.Close();

            return aliquotaDetalhes;
        }
        catch (System.Exception)
        {
            throw new Exception("Erro ao tentar recuperar dados");
        }
        finally
        {
            connection.Close();
        }
    }

    public List<AliquotaDetalhe> GetAliquotaDetalhesPorIdAliquota(int idAliquota) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"select * from tbAliquotaDetalhes where idAliquota = @idAliquota", connection);
            sqlCommand.Parameters.AddWithValue("@idAliquota", idAliquota);
            SqlDataReader reader = sqlCommand.ExecuteReader();


            List<AliquotaDetalhe> aliquotaDetalhes = new List<AliquotaDetalhe>();

            while (reader.Read()){
                AliquotaDetalhe aliquotaDetalhe  = new AliquotaDetalhe
                {
                    IdAliquota = Convert.ToInt32(reader[1]),
                    BaseCalculo = Convert.ToDecimal(reader[2]),
                    Porcentagem = Convert.ToSingle(reader[3])
                };

                aliquotaDetalhes.Add(aliquotaDetalhe);
            }

            sqlCommand.Dispose();
            reader.Close();


            return aliquotaDetalhes;
        }
        catch (System.Exception)
        {
            throw new Exception("Erro ao tentar recuperar dados");
        }
        finally {
            connection.Close();
        }
    }

    public int Inserir(AliquotaDetalhe aliquotaDetalhe) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"insert into tbAliquotaDetalhes (idAliquota, baseCalculo, porcentagem) values (@idAliquota, @baseCalculo, @porcentagem); SELECT SCOPE_IDENTITY();", connection);
            
            sqlCommand.Parameters.AddWithValue("@idAliquota", aliquotaDetalhe.IdAliquota);
            sqlCommand.Parameters.AddWithValue("@baseCalculo", aliquotaDetalhe.BaseCalculo);
            sqlCommand.Parameters.AddWithValue("@porcentagem", aliquotaDetalhe.Porcentagem);

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
}