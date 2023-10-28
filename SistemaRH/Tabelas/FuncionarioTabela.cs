using System.Data.SqlClient;
using SistemaRH.Models;

namespace SistemaRH.Tabelas;

public class FuncionarioTabela
{
    SqlConnection connection = new SqlConnection(ConexaoSQL.ConnectionString);

    public void Deleta(int id) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"delete from tbFuncionarios where id = @id;", connection);
            
            sqlCommand.Parameters.AddWithValue("@id", id);

            sqlCommand.ExecuteScalar();
            sqlCommand.Dispose();    
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally {
            connection.Close();
        }
    }

    public void Atualiza(Funcionario funcionario) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"update tbFuncionarios set nome = @nome, dataAdmissao = @dataAdmissao where id = @id;", connection);
            
            sqlCommand.Parameters.AddWithValue("@nome", funcionario.Nome);
            sqlCommand.Parameters.AddWithValue("@dataAdmissao", funcionario.DataAdmissao.ToString());
            sqlCommand.Parameters.AddWithValue("@id", funcionario.Id);

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

    public Funcionario GetFuncionario(int id) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"select * from tbFuncionarios where id = @id", connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            string nome = string.Empty;
            DateOnly dataAdmissao = default;

            while (reader.Read()){
                dataAdmissao = DateOnly.FromDateTime(Convert.ToDateTime(reader[1]));
                nome = Convert.ToString(reader[2]);
                break;
            }

            sqlCommand.Dispose();
            reader.Close();

            if (nome == string.Empty && dataAdmissao == default)
            {
                return null;
            }

            Funcionario funcionario = new Funcionario(dataAdmissao, nome)
            {
                Id = id
            };

            return funcionario;
        }
        catch (System.Exception err)
        {
            throw new Exception("Erro ao tentar recuperar dados");
        }
        finally {
            connection.Close();
        }
    }

    public List<Funcionario> GetFuncionarios() {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"select * from tbFuncionarios", connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            string nome = string.Empty;
            decimal salario = 0;

            List<Funcionario> funcionarios = new List<Funcionario>();

            while (reader.Read()){
                Funcionario funcionario = new Funcionario{
                    Id = Convert.ToInt32(reader[0]),
                    DataAdmissao =  DateOnly.FromDateTime(Convert.ToDateTime(reader[1])),
                    Nome = reader[2].ToString()
                };

                funcionarios.Add(funcionario);
            }

            sqlCommand.Dispose();
            reader.Close();

            return funcionarios;
        }
        catch (System.Exception err)
        {
            throw new Exception("Erro ao tentar recuperar dados");
        }
        finally {
            connection.Close();
        }
    }

    public int Inserir(Funcionario funcionario) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"insert into tbFuncionarios (nome, dataAdmissao) values (@nome, @dataAdmissao); SELECT SCOPE_IDENTITY();", connection);
            
            sqlCommand.Parameters.AddWithValue("@nome", funcionario.Nome);
            sqlCommand.Parameters.AddWithValue("@dataAdmissao", funcionario.DataAdmissao.ToString());

            int id = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlCommand.Dispose();

            return id;   
        }
        catch (System.Exception err)
        {
            throw new Exception("Erro ao tentar inserir dados");
        }
        finally {
            connection.Close();
        }
    }
}