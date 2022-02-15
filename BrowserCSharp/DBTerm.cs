using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Athelas
{
    class DBTerm
    {
        private int _id;
        private string _name;
        private int _textsNumber;
        private int _isRus;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int TextsNumber
        {
            get { return _textsNumber; }
            set { _textsNumber = value; }
        }
        public int isRus
        {
            get { return _isRus; }
            set { _isRus = value; }
        }
        public DBTerm(int id, string name, int textsNumber,int isRus)
        {
            _id = id;
            _name = name;
            _textsNumber = textsNumber;
            _isRus = isRus;
        }
        public static DBTerm FindByName(string name, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("SELECT Id,Term,TextsNumber,isRus FROM Terms WHERE Term='" +
                name + "'", connection);
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            reader.Read();
            int id = reader.GetInt32(0);
            int textsNumber = reader.GetInt32(2);
            int isRus = reader.GetInt32(3);
            reader.Close();
            return new DBTerm(id, name, textsNumber,isRus);
        }
        public static DBTerm Create(string name, int textsNumber, int isRus,SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Terms Values('" +
                name + "'," + textsNumber.ToString() + "," + isRus.ToString() + ")", connection);
            command.ExecuteNonQuery();
            return FindByName(name, connection);
        }
        public void Update(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("UPDATE Terms SET TextsNumber=" +
                _textsNumber.ToString() + " where Id=" + _id.ToString(), connection);
            command.ExecuteNonQuery();
        }
    }
}
