using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroClienteCRUD
{
    public partial class Favorecidos : Form
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost;userid=suporte;port=4569;password=suporte;database=cadastroclientecrud");
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSql;
        
        public void limpar()
        {
            txtId.Text = "";
            txtNome.Text = "";
        }



        public Favorecidos()
        {
            InitializeComponent();

            
        }

        private void Favorecidos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {               
                strSql = "insert into cliente (nome) values (@nome)";

                comando = new MySqlCommand(strSql, conexao);

                comando.Parameters.AddWithValue("@nome", txtNome.Text);                               

                conexao.Open();

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                MessageBox.Show("Cadastro realizado com Sucesso");
                limpar();
                comando = null;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                strSql = "update cliente set nome = @nome where idcliente = @idcliente";

                comando = new MySqlCommand(strSql, conexao);

                comando.Parameters.AddWithValue("@idcliente", txtId.Text);
                comando.Parameters.AddWithValue("@nome", txtNome.Text);

                conexao.Open();

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                MessageBox.Show("Cadastro atualizado com Sucesso");
                limpar();
                comando = null;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                strSql = "delete from cliente where idcliente = @idcliente";

                comando = new MySqlCommand(strSql, conexao);

                comando.Parameters.AddWithValue("@idcliente", txtId.Text);                

                conexao.Open();

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                MessageBox.Show("Cadastro excluído com Sucesso");
                limpar();
                comando = null;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                strSql = "select * from cliente where idcliente = @idcliente";

                comando = new MySqlCommand(strSql, conexao);

                comando.Parameters.AddWithValue("@idcliente", txtId.Text);

                conexao.Open();

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    txtNome.Text = Convert.ToString(dr["nome"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();              
                
                comando = null;
            }
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                strSql = "select * from cliente";

                da = new MySqlDataAdapter(strSql, conexao);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvDados.DataSource = dt;
                 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();

                comando = null;
            }
        }
    
    }
}
