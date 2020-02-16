using DAL.DataSource;
using DAL.Entity;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Persistence
{
    public class PacienteDAL
    {
        public IList<Paciente> ListaPacientes()
        {
            FbConnection _conexao = ConexaoFirebird.getInstancia().getConexao();
            try
            {
                _conexao.Open();
                return _conexao.Query<Paciente>("SELECT id_paciente as IdPaciente, nome, idade, peso, altura FROM tb_paciente").ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexao.Close();
            }
        }

        public Paciente getPaciente(int idPaciente)
        {
            FbConnection _conexao = ConexaoFirebird.getInstancia().getConexao();
            try
            {
                _conexao.Open();
                return _conexao.Query<Paciente>($@"SELECT ID_PACIENTE as IdPaciente, nome, idade, peso, altura FROM tb_paciente
                                                  WHERE id_paciente = {idPaciente}").SingleOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexao.Close();
            }
        }

        public bool InserirPaciente(Paciente paciente)
        {
            FbConnection _conexao = ConexaoFirebird.getInstancia().getConexao();
            try
            {
                _conexao.Open();
                return _conexao.Execute($@"INSERT INTO TB_PACIENTE (NOME, IDADE, PESO, ALTURA)
                                                   VALUES ('{paciente.Nome}', {paciente.Idade}, {paciente.Peso}, {paciente.Altura}) ") > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexao.Close();
            }
        }

        public bool EditarPaciente(Paciente paciente)
        {
            FbConnection _conexao = ConexaoFirebird.getInstancia().getConexao();
            try
            {
                _conexao.Open();
                return _conexao.Execute($@"UPDATE TB_PACIENTE
                                            SET NOME = '{paciente.Nome}',
                                                IDADE = {paciente.Idade},
                                                PESO = {paciente.Peso},
                                                ALTURA = {paciente.Altura}
                                            WHERE (ID_PACIENTE = {paciente.IdPaciente})") > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexao.Close();
            }
        }

        public bool DeletarPaciente(int idPaciente)
        {
            FbConnection _conexao = ConexaoFirebird.getInstancia().getConexao();
            try
            {
                _conexao.Open();
                return _conexao.Execute($@"DELETE FROM TB_PACIENTE
                                            WHERE (ID_PACIENTE = {idPaciente})") > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conexao.Close();
            }
        }

    }
}
