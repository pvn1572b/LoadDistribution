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
    public class ScheduleRepository
    {
        //получаем список  
        public List<Schedule> GetScheduleList()
        {
            GroupRepository groupRepo = new GroupRepository();
            DisciplineRepository disciplineRepo= new DisciplineRepository();

            List<Group> groupList = groupRepo.GetGroupList();
            List<Discipline> disciplineList = disciplineRepo.GetDisciplineList();
 

            List<Schedule> result = new List<Schedule>();
            string sql = @"SELECT
                                ID,
                                GroupID,
                                DisciplineID,
                                Hours
                            FROM
                                Schedule";

            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(com);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Schedule sc = new Schedule();
                sc.ID  = Convert.ToInt32(row["ID"]);

                int groupID = Convert.ToInt32(row["GroupID"]);
                int disciplineID = Convert.ToInt32(row["DisciplineID"]);

                int hours = Convert.ToInt32(row["Hours"]);
 
                Group gr = groupList.Where(x => x.GroupID == groupID).FirstOrDefault();
                Discipline d = disciplineList.Where(x => x.ID == disciplineID).FirstOrDefault();
                sc.Group = gr;
                sc.Discipline = d;
                sc.Hours = hours;

                result.Add(sc);
            }

            return result;
        }

        public void AddSchedule(Schedule sc)
        {
            string sql = @"INSERT INTO Schedule (
                                GroupID,
                                DisciplineID,
                                Hours
                            ) VALUES (
                                :GroupID,
                                :DisciplineID,
                                :Hours
                            )";
            //создаем запрос на добавление записи
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("GroupID", sc.Group.GroupID);
            com.Parameters.AddWithValue("DisciplineID", sc.Discipline.ID);
            com.Parameters.AddWithValue("Hours", sc.Hours);


            //выполняем
            com.ExecuteNonQuery();
       }


        //Метод для редактирования 
        public void EditSchedule(Schedule sc)
        {
            string sql = @"update Schedule set
                                GroupID = :GroupID,
                                DisciplineID = :ProfID,
                                Hours = :Hours
                            where ReportID = :ReportID";
            //создаем запрос
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("GroupID", sc.Group.GroupID);
            com.Parameters.AddWithValue("DisciplineID", sc.Discipline.ID);
            com.Parameters.AddWithValue("Hours", sc.Hours);

            //выполняем запрос
            com.ExecuteNonQuery();
        }


        //Метод для удаления  
        public void DeleteReport(Schedule sc)
        {
            string sql = @"delete from Schedule 
                            where ID = :ID";
            //создаем запрос
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("ID", sc.ID);

            //выполняем запрос
            com.ExecuteNonQuery();

        }
    }
}
