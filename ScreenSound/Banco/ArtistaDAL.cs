using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {
        public IEnumerable<Artista> Listar()
        {
            var lista = new List<Artista>();
            using var connection = new Connection().obterConexao();
            connection.Open();

            string sql = "SELECT* FROM Artistas";
            SqlCommand cmd = new SqlCommand(sql, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string nomeArtista = Convert.ToString(reader["Nome"]);
                string bioArtista = Convert.ToString(reader["Bio"]);
                int idArtista = Convert.ToInt32(reader["Id"]);

                Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };
                lista.Add(artista);
            }
            return lista;
        }

        public void Adicionar(Artista artista)
        {
            var lista = new List<Artista>();
            using var connection = new Connection().obterConexao();
            connection.Open();

            string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@nome", artista.Nome);
            cmd.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
            cmd.Parameters.AddWithValue("@bio", artista.Bio);

            int retorno = cmd.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {retorno}");
        }
    }
}
