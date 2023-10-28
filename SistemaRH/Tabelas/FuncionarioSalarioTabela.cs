using System.Data.SqlClient;
using SistemaRH.Models;

namespace SistemaRH.Tabelas;

public class FuncionarioSalarioTabela
{
    SqlConnection connection = new SqlConnection(ConexaoSQL.ConnectionString);

    public void Deleta(int id) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"delete from tbFuncionarioSalario where id = @id;", connection);
            
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

    public void Atualiza(FuncionarioSalario funcionario) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"update tbFuncionarioSalario set salario = @salario, vigenteEm = @vigenteEm where id = @id;", connection);
            
            sqlCommand.Parameters.AddWithValue("@salario", funcionario.Salario);
            sqlCommand.Parameters.AddWithValue("@vigenteEm", funcionario.VigenteEm.ToString());
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

    public FuncionarioSalario GetFuncionarioSalario(int id) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"select FS.*, F.nome from tbFuncionarioSalario FS join tbFuncionarios F on F.id = FS.idFuncionario where FS.id = @id", connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            var funcionarioSalario = new FuncionarioSalario();

            while (reader.Read()){
                funcionarioSalario.Id = Convert.ToInt32(reader[0]);
                funcionarioSalario.IdFuncionario = Convert.ToInt32(reader[1]);
                funcionarioSalario.Salario = Convert.ToDecimal(reader[2]);
                funcionarioSalario.VigenteEm = DateOnly.FromDateTime(Convert.ToDateTime(reader[3]));
                funcionarioSalario.Funcionario = new Funcionario { Nome = reader[4].ToString() };
                break;
            }

            sqlCommand.Dispose();
            reader.Close();

            return funcionarioSalario;
        }
        catch (System.Exception err)
        {
            throw new Exception("Erro ao tentar recuperar dados");
        }
        finally {
            connection.Close();
        }
    }

    public FuncionarioSalario GetFuncionarioSalarioPorFuncionarioId(int id)
    {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"select FS.*, F.nome from tbFuncionarioSalario FS join tbFuncionarios F on F.id = FS.idFuncionario where F.id = @id", connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            FuncionarioSalario funcionarioSalario = null;

            while (reader.Read())
            {
                funcionarioSalario = new FuncionarioSalario();
                funcionarioSalario.Id = Convert.ToInt32(reader[0]);
                funcionarioSalario.IdFuncionario = Convert.ToInt32(reader[1]);
                funcionarioSalario.Salario = Convert.ToDecimal(reader[2]);
                funcionarioSalario.VigenteEm = DateOnly.FromDateTime(Convert.ToDateTime(reader[3]));
                funcionarioSalario.Funcionario = new Funcionario { Nome = reader[4].ToString() };
                break;
            }

            sqlCommand.Dispose();
            reader.Close();

            return funcionarioSalario;
        }
        catch (System.Exception err)
        {
            throw new Exception("Erro ao tentar recuperar dados");
        }
        finally
        {
            connection.Close();
        }
    }

    public List<FuncionarioSalario> GetFuncionarioSalarios(DateOnly vigenteEm) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"select FS.*, F.nome from tbFuncionarioSalario FS join tbFuncionarios F on F.id = FS.idFuncionario where FS.vigenteEm <= @vigenteEm", connection);
            sqlCommand.Parameters.AddWithValue("@vigenteEm", vigenteEm.ToString());
            SqlDataReader reader = sqlCommand.ExecuteReader();

            string nome = string.Empty;
            decimal salario = 0;

            List<FuncionarioSalario> funcionarioSalarios = new List<FuncionarioSalario>();

            while (reader.Read()){
                var funcionarioSalario = new FuncionarioSalario
                {
                    Id = Convert.ToInt32(reader[0]),
                    IdFuncionario = Convert.ToInt32(reader[1]),
                    Salario = Convert.ToDecimal(reader[2]),
                    VigenteEm = DateOnly.FromDateTime(Convert.ToDateTime(reader[3])),
                    Funcionario = new Funcionario { Nome = reader[4].ToString() },
                };
                

                funcionarioSalarios.Add(funcionarioSalario);
            }

            sqlCommand.Dispose();
            reader.Close();

            return funcionarioSalarios;
        }
        catch (System.Exception err)
        {
            throw new Exception("Erro ao tentar recuperar dados");
        }
        finally {
            connection.Close();
        }
    }

    public int Inserir(FuncionarioSalario funcionarioSalario) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"insert into tbFuncionarioSalario (idFuncionario, salario, vigenteEm) values (@idFuncionario, @salario, @vigenteEm); SELECT SCOPE_IDENTITY();", connection);
            
            sqlCommand.Parameters.AddWithValue("@idFuncionario", funcionarioSalario.IdFuncionario);
            sqlCommand.Parameters.AddWithValue("@salario", funcionarioSalario.Salario);
            sqlCommand.Parameters.AddWithValue("@vigenteEm", funcionarioSalario.VigenteEm.ToString());

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