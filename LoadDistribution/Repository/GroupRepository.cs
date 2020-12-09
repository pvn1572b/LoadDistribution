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
    public class GroupRepository
    {
        //метод для получения списка групп
        public List<Group> GetGroupList()
        {

            List<Group> result = new List<Group>();
            string sql = @"SELECT
                                ID,
                                GroupNum,
                                StudentCount,
                                EducationForm 
                            FROM
                                Groups";
            //создаем запрос к БД на выбов всех групп
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(com);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Group group = new Group();
                group.GroupID = Convert.ToInt32(row["ID"]);
                group.GroupNum = Convert.ToString(row["GroupNum"]);

                group.StudentCount = Convert.ToInt32(row["StudentCount"]);
                group.EducationForm = Convert.ToString(row["EducationForm"]);

                result.Add(group);
            }

            return result;
        }

        //метод для добавления группы
        public void AddGroup(Group group)
        {
            string sql = @"INSERT INTO Groups (
                                GroupNum,
                                StudentCount,
                                EducationForm
                            ) VALUES (
                                :GroupNum,
                                :StudentCount,
                                :EducationForm
                            )";
            //создаем запрос на добавление записи
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("GroupNum", group.GroupNum);
            com.Parameters.AddWithValue("StudentCount", group.StudentCount);
            com.Parameters.AddWithValue("EducationForm", group.EducationForm);

            //выполняем
            com.ExecuteNonQuery();
        }

        //Метод для редактирования групп
        public void EditGroup(Group group)
        {
            string sql = @"update Groups set
                                GroupNum = :GroupNum, 
                                StudentCount = :StudentCount,
                                EducationForm = :EducationForm
                            where ID = :ID";
            //создаем запрос
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("GroupNum", group.GroupNum);
            com.Parameters.AddWithValue("StudentCount", group.StudentCount);
            com.Parameters.AddWithValue("EducationForm", group.EducationForm);
            com.Parameters.AddWithValue("ID", group.GroupID);

            //выполняем запрос
            com.ExecuteNonQuery();
        }

        //Метод для удаления групп
        public void DeleteGroup(Group group)
        {
            string sql = @"delete from Groups 
                            where ID = :GroupID";
            //создаем запрос
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("GroupID", group.GroupID);

            //выполняем запрос
            com.ExecuteNonQuery();
        }
    }
}
