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
    public class DisciplineRepository
    {
        //метод для получения списка дисциплин
        public List<Discipline> GetDisciplineList()
        {

            List<Discipline> result = new List<Discipline>();
            string sql = @"SELECT
                                ID,
                                Name,
                                ClassType,
                                TermNum 
                            FROM
                                Discipline";
            //создаем запрос к БД на выбов всех дисциплин
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(com);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Discipline d = new Discipline();
                d.ID = Convert.ToInt32(row["ID"]);
                d.Name = Convert.ToString(row["Name"]);

                d.ClassType = Convert.ToString(row["ClassType"]);
                d.TermNum = Convert.ToInt32(row["TermNum"]);

                result.Add(d);
            }

            return result;
        }

        //метод для добавления дисциплины
        public void AddDiscipline(Discipline d)
        {
            string sql = @"INSERT INTO Discipline (
                                Name,
                                ClassType,
                                TermNum
                            ) VALUES (
                                :Name,
                                :ClassType,
                                :TermNum
                            )";
            //создаем запрос на добавление записи
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("Name", d.Name);
            com.Parameters.AddWithValue("ClassType", d.ClassType);
            com.Parameters.AddWithValue("TermNum", d.TermNum);

            //выполняем
            com.ExecuteNonQuery();
        }

        //Метод для редактирования дисциплины
        public void EditDiscipline(Discipline d)
        {
            string sql = @"update Discipline set
                                Name = :Name, 
                                ClassType = :ClassType,
                                TermNum = :TermNum
                            where ID = :ID";
            //создаем запрос
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("Name", d.Name);
            com.Parameters.AddWithValue("ClassType", d.ClassType);
            com.Parameters.AddWithValue("TermNum", d.TermNum);
            com.Parameters.AddWithValue("ID", d.ID);

            //выполняем запрос
            com.ExecuteNonQuery();
        }

        //Метод для удаления дисциплин
        public void DeleteDiscipline(Discipline d)
        {
            string sql = @"delete from Discipline 
                            where ID = :ID";
            //создаем запрос
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("ID", d.ID);

            //выполняем запрос
            com.ExecuteNonQuery();
        }
    }
    
}
