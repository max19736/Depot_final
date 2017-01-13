using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Service
{
    public class DatabaseService
    {

        public List<Models.Album> LoadAllAlbum()
        {
            List<Models.Album> result = new List<Models.Album>();

            var connection = new System.Data.SqlClient.SqlConnection(@"
Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dan\Desktop\課業\軟體工程\Depot_final\KUAS-Depot\Depot\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = @"
Select * from Album";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.Album item = new Models.Album();

                item.ID = reader["ID"].ToString();
                item.Kind = reader["Kind"].ToString();
                item.Value = (decimal)reader["Value"];
                item.Title = reader["Title"].ToString();
                item.ImageUrl = reader["ImageUrl"].ToString();
                result.Add(item);
            }
            connection.Close();
            return result;
        }
        public Models.Album GetAlbumByID(string id)
        {
           Models.Album result = new Models.Album();

            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dan\Desktop\課業\軟體工程\Depot_final\KUAS-Depot\Depot\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
Select * from Album
Where ID='{0}'", id);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.Album item = new Models.Album();

                item.ID = reader["ID"].ToString();
                item.Kind = reader["Kind"].ToString();
                item.Value = (decimal)reader["Value"];
                item.Title = reader["Title"].ToString();
                item.ImageUrl = reader["ImageUrl"].ToString();
                result = item;
            }
            connection.Close();
            return result;
        }
        public void CreateAlbum(Models.Album newAlbum)
        {
            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dan\Desktop\課業\軟體工程\Depot_final\KUAS-Depot\Depot\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    Album(ID, Kind, Title, Value, ImageUrl)
VALUES          ('{0}','{1}','{2}',{3},'{4}')
", newAlbum.ID, newAlbum.Kind, newAlbum.Title, newAlbum.Value, newAlbum.ImageUrl);

            command.ExecuteNonQuery();
            

            connection.Close();
        }


        public void DeleteAlbum(string id)
        {
            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dan\Desktop\課業\軟體工程\Depot_final\KUAS-Depot\Depot\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
DELETE FROM Album
Where ID='{0}'
", id);

            command.ExecuteNonQuery();
            connection.Close();

        }
        public void UpdateAlbum(Models.Album updateAlbum)
        {
            var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dan\Desktop\課業\軟體工程\Depot_final\KUAS-Depot\Depot\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True");
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
UPDATE          Album
SET             Kind='{1}',Title='{2}',Value={3},ImageUrl='{4}'
Where           ID='{0}'
", updateAlbum.ID, updateAlbum.Kind, updateAlbum.Title, updateAlbum.Value, updateAlbum.ImageUrl);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}