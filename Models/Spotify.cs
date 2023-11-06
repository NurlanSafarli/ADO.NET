using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET.Models
{
    public class Spotify
    {
        string connectionString = "server=DESKTOP-222NTH0; DATABASE=Spotify; trusted_connection=true; integrated security;";

     

        public int CreateMusic(string name, int durationInSeconds, int categoryID, int artistID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Musics (Name, DurationInSeconds, CategoryID, ArtistID) " +
                               "VALUES (@Name, @DurationInSeconds, @CategoryID, @ArtistID); " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@DurationInSeconds", durationInSeconds);
                    command.Parameters.AddWithValue("@CategoryID", categoryID);
                    command.Parameters.AddWithValue("@ArtistID", artistID);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public DataTable GetAllMusic()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Musics";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public DataRow GetMusicById(int musicID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Musics WHERE MusicID = @MusicID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusicID", musicID);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        return dataTable.Rows[0];
                    }

                    return null;
                }
            }
        }

        public void DeleteMusic(int musicID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Musics WHERE MusicID = @MusicID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusicID", musicID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public class ArtistRepository
    {
        private string connectionString;

        public ArtistRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int CreateArtist(string name, string surname, DateTime birthday, string gender)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Artists (Name, Surname, Birthday, Gender) " +
                               "VALUES (@Name, @Surname, @Birthday, @Gender); ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Surname", surname);
                    command.Parameters.AddWithValue("@Birthday", birthday);
                    command.Parameters.AddWithValue("@Gender", gender);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public DataTable GetAllArtists()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Artists";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public DataRow GetArtistById(int artistID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Artists WHERE ArtistID = @ArtistID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArtistID", artistID);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        return dataTable.Rows[0];
                    }

                    return null;
                }
            }
        }

        public void DeleteArtist(int artistID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Artists WHERE ArtistID = @ArtistID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArtistID", artistID);
                    command.ExecuteNonQuery();
                }




            }
        }
    }
}
