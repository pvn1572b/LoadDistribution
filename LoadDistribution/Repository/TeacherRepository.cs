using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDistribution.Entity; 

namespace LoadDistribution.Repository
{
    public class TeacherRepository
    {
        //метод для получения спсика учителей
        public List<Teacher> GetTeacherList()
        {

            List<Teacher> result = new List<Teacher>();
            string sql = @"SELECT
                                ID,
                                FirstName,
                                LastName,
                                Patronymic,
                                Chair,
                                Post
                            FROM
                                Teacher";
            //создаем запрос к БД на выбов всех профессоров
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(com);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Teacher t = new Teacher();
                t.ID = Convert.ToInt32(row["ID"]);
                t.FirstName = Convert.ToString(row["FirstName"]);
                t.LastName = Convert.ToString(row["LastName"]);
                t.Patronimyc = Convert.ToString(row["Patronymic"]);
                t.Chair = Convert.ToString(row["Chair"]);
                t.Post = Convert.ToString(row["Post"]);
                result.Add(t);
            }

            return result;
        }

        //метод для добавления учителя
        public void AddTeacher(Teacher t)
        {
            string sql = @"INSERT INTO Teacher (
                                FirstName,
                                LastName,
                                Patronymic,
                                Chair,
                                Post
                            ) VALUES (
                                :FirstName,
                                :LastName,
                                :Patronymic,
                                :Chair,
                                :Post
                            )";
            //создаем запрос на добавление записи
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("FirstName", t.FirstName);
            com.Parameters.AddWithValue("LastName", t.LastName);
            com.Parameters.AddWithValue("Patronymic", t.Patronimyc);
            com.Parameters.AddWithValue("Chair", t.Chair);
            com.Parameters.AddWithValue("Post", t.Post);

            //выполняем
            com.ExecuteNonQuery();
        }

        //Метод для редактирования профессора
        public void EditTeacher(Teacher t)
        {
            string sql = @"update Teacher set
                                FirstName = :FirstName,
                                LastName = :LastName,
                                Patronymic = :Patronymic,
                                Chair = :Chair,
                                Post = :Post 
                            where ID = :ID";
            //создаем запрос
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("FirstName", t.FirstName);
            com.Parameters.AddWithValue("LastName", t.LastName);
            com.Parameters.AddWithValue("Patronymic", t.Patronimyc);
            com.Parameters.AddWithValue("Chair", t.Chair);
            com.Parameters.AddWithValue("Post", t.Post);
            com.Parameters.AddWithValue("ProfID", t.ID);

            //выполняем запрос
            com.ExecuteNonQuery();
        }

        //метод для удаления учителей
        public void DeleteTeacher(Teacher t)
        {
            string sql = @"delete from Teacher
                            where ID = :ID";
            //создаем запрос
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("ID", t.ID);

            //выполняем запрос
            com.ExecuteNonQuery();

            ////удаляем так же из Loadings
            //sql = @"delete from Loadings
            //                where ProfID = :ProfID";
            ////создаем запрос
            //com = new SQLiteCommand(sql, DBConnection.con);

            ////заполняем параметрами
            //com.Parameters.AddWithValue("ProfID", prof.ProfID);

            ////выполняем запрос
            //com.ExecuteNonQuery();
        }
    }
}
