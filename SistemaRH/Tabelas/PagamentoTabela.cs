using SistemaRH.Models;
using System.Data;
using System.Data.SqlClient;

namespace SistemaRH.Tabelas;

public class PagamentoTabela
{
    SqlConnection connection = new SqlConnection(ConexaoSQL.ConnectionString);

    public int Inserir(Pagamento pagamento) {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"insert into tbPagamentos (dataPagamento, dataReferencia, idFuncionarioSalario, salarioLiquido) values (@dataPagamento, @dataReferencia, @idFuncionarioSalario, @salarioLiquido); SELECT SCOPE_IDENTITY();", connection);
            
            sqlCommand.Parameters.AddWithValue("@dataPagamento", pagamento.DataPagamento.ToString());
            sqlCommand.Parameters.AddWithValue("@dataReferencia", pagamento.DataReferencia.ToString());
            sqlCommand.Parameters.AddWithValue("@idFuncionarioSalario", pagamento.IdFuncionarioSalario);
            sqlCommand.Parameters.AddWithValue("@salarioLiquido", pagamento.SalarioLiquido);

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

    internal bool FuncionarioTemPagamento(int idFuncionario)
    {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"select P.id from tbPagamentos P join tbFuncionarioSalario FS on P.idFuncionarioSalario = FS.id where FS.idFuncionario = @idFuncionario", connection);
            sqlCommand.Parameters.AddWithValue("@idFuncionario", idFuncionario);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            return reader.HasRows;
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

    internal bool FuncionarioTemPagamentoComEsteSalario(int idFuncionarioSalario)
    {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"select P.id from tbPagamentos P join tbFuncionarioSalario FS on P.idFuncionarioSalario = FS.id where FS.id = @id", connection);
            sqlCommand.Parameters.AddWithValue("@id", idFuncionarioSalario);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            return reader.HasRows;
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

    internal List<Pagamento> GetPagamentos()
    {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(@$"select P.*, F.nome from tbPagamentos P join tbFuncionarioSalario FS on P.idFuncionarioSalario = FS.id join tbFuncionarios F on F.id = FS.idFuncionario", connection);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Pagamento> pagamentos = new();

            while (reader.Read())
            {
                var pagamento = new Pagamento
                {
                    Id = Convert.ToInt32(reader[0]),
                    DataPagamento = DateOnly.FromDateTime(Convert.ToDateTime(reader[1])),
                    DataReferencia = DateOnly.FromDateTime(Convert.ToDateTime(reader[2])),
                    IdFuncionarioSalario = Convert.ToInt32(reader[3]),
                    SalarioLiquido = Convert.ToDecimal(reader[4]),
                    FuncionarioSalario = new FuncionarioSalario
                    {
                        Funcionario = new Funcionario
                        {
                            Nome = reader[5].ToString()
                        }
                    }
                };

                pagamentos.Add(pagamento);
            }

            return pagamentos;
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

    internal List<Pagamento> GetPagamentos(DateTime referencia)
    {
        try
        {
            connection.Open();

            SqlCommand sqlCommand = new (@$"select P.*, F.nome, FS.salario from tbPagamentos P join tbFuncionarioSalario FS on P.idFuncionarioSalario = FS.id join tbFuncionarios F on F.id = FS.idFuncionario where MONTH(P.dataReferencia) = @mes and YEAR(P.dataReferencia) = @ano", connection);
            
            sqlCommand.Parameters.AddWithValue("@mes", referencia.Month);
            sqlCommand.Parameters.AddWithValue("@ano", referencia.Year);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Pagamento> pagamentos = new();

            while (reader.Read())
            {
                var pagamento = new Pagamento
                {
                    Id = Convert.ToInt32(reader[0]),
                    DataPagamento = DateOnly.FromDateTime(Convert.ToDateTime(reader[1])),
                    DataReferencia = DateOnly.FromDateTime(Convert.ToDateTime(reader[2])),
                    IdFuncionarioSalario = Convert.ToInt32(reader[3]),
                    SalarioLiquido = Convert.ToDecimal(reader[4]),
                    FuncionarioSalario = new FuncionarioSalario
                    {
                        Funcionario = new Funcionario
                        {
                            Nome = reader[5].ToString()
                        },
                        Salario = Convert.ToDecimal(reader[6]),
                    }
                };

                pagamentos.Add(pagamento);
            }

            return pagamentos;
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

    internal DataTable GetPagamentosDT(DateTime referencia)
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("Funcionário", typeof(string));
        dt.Columns.Add("Salário bruto", typeof(decimal));
        dt.Columns.Add("Salário líquido", typeof(decimal));
        dt.Columns.Add("Data de referência", typeof(DateOnly));
        dt.Columns.Add("Data de pagamento", typeof(DateOnly));

        try
        {
            connection.Open();

            SqlCommand sqlCommand = new(@$"select P.*, F.nome, FS.salario from tbPagamentos P join tbFuncionarioSalario FS on P.idFuncionarioSalario = FS.id join tbFuncionarios F on F.id = FS.idFuncionario where MONTH(P.dataReferencia) = @mes and YEAR(P.dataReferencia) = @ano", connection);

            sqlCommand.Parameters.AddWithValue("@mes", referencia.Month);
            sqlCommand.Parameters.AddWithValue("@ano", referencia.Year);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Pagamento> pagamentos = new();

            while (reader.Read())
            {

                
                var pagamento = new Pagamento
                {
                    Id = Convert.ToInt32(reader[0]),
                    DataPagamento = DateOnly.FromDateTime(Convert.ToDateTime(reader[1])),
                    DataReferencia = DateOnly.FromDateTime(Convert.ToDateTime(reader[2])),
                    IdFuncionarioSalario = Convert.ToInt32(reader[3]),
                    SalarioLiquido = Convert.ToDecimal(reader[4]),
                    FuncionarioSalario = new FuncionarioSalario
                    {
                        Funcionario = new Funcionario
                        {
                            Nome = reader[5].ToString()
                        },
                        Salario = Convert.ToDecimal(reader[6]),
                    }
                };

                // Add rows to the table
                dt.Rows.Add(pagamento.FuncionarioSalario.Funcionario.Nome, pagamento.FuncionarioSalario.Salario, pagamento.SalarioLiquido, pagamento.DataReferencia, pagamento.DataPagamento);
            }

            return dt;
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
}