using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using System.Data;
using System.Data.SqlClient;

namespace MvcMovie.Data
{
    public class MvcMovieData : List<Models.Movie>
    {
        private string connectionstring = "Server=mssql.fhict.local;Database=dbi400058;User Id=dbi400058;Password=Welkom01;";
        public void init()
        {
            this.Clear();
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string query = "SELECT * FROM Movie";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            
            while (reader.Read())
            {
                Movie _movie = new Movie();
                _movie.Id = reader.GetInt32(0);
                _movie.Title = reader.GetString(1);
                _movie.ReleaseDate = reader.GetDateTime(2);
                _movie.Genre = reader.GetString(3);
                _movie.Price = reader.GetDecimal(4);
                this.Add(_movie);
            }
            conn.Close();

        }

        public void insert(Movie _movie)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string query = "INSERT INTO Movie VALUES (@Id, @Title, @ReleaseDate, @Genre, @Price)";
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.Parameters.AddWithValue("@Id", _movie.Id);
            cmd.Parameters.AddWithValue("@Title", _movie.Title);
            cmd.Parameters.AddWithValue("@ReleaseDate", _movie.ReleaseDate);
            cmd.Parameters.AddWithValue("@Genre", _movie.Genre);
            cmd.Parameters.AddWithValue("@Price", _movie.Price);
            cmd.ExecuteNonQuery();
            this.Add(_movie);
            conn.Close();
        }

        public Movie getMovie(int id)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string query = "SELECT * FROM Movie WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Movie _movie = new Movie();
                _movie.Id = reader.GetInt32(0);
                _movie.Title = reader.GetString(1);
                _movie.ReleaseDate = reader.GetDateTime(2);
                _movie.Genre = reader.GetString(3);
                _movie.Price = reader.GetDecimal(4);
                conn.Close();
                return _movie;
            }
            else
            {
                conn.Close();
                return null;
            }
        }

        public void updateMovie(int id, Movie _movie)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string query = $"UPDATE Movie SET Id = @Id, Title = @Title, ReleaseDate = @ReleaseDate, Genre = @Genre, Price = @Price WHERE Id = {id}";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", _movie.Id);
            cmd.Parameters.AddWithValue("@Title", _movie.Title);
            cmd.Parameters.AddWithValue("@ReleaseDate", _movie.ReleaseDate);
            cmd.Parameters.AddWithValue("@Genre", _movie.Genre);
            cmd.Parameters.AddWithValue("@Price", _movie.Price);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
