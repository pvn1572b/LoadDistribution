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
    public class AssignmentRepository
    {
        //получаем список  
        public List<Assignment> GetAssignmentList()
        {
            GroupRepository groupRepo = new GroupRepository();
            DisciplineRepository disciplineRepo = new DisciplineRepository();
            TeacherRepository teacherRepo = new TeacherRepository();
            ScheduleRepository scheduleRepo = new ScheduleRepository();

            List<Schedule> scheduleList = scheduleRepo.GetScheduleList();
            List<Teacher> teacherList= teacherRepo.GetTeacherList();
            List<Discipline> disciplineList = disciplineRepo.GetDisciplineList();
            List<Group> groupList = groupRepo.GetGroupList();


            List<Assignment> result = new List<Assignment>();
            string sql = @"SELECT
                                ID,
                                TeacherID,
                                NormHours,
                                PersonalData,
                                GUID
                            FROM
                                Assignment";

            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(com);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Assignment a = new Assignment();
                a.ID = Convert.ToInt32(row["ID"]);

                int TeacherID = Convert.ToInt32(row["TeacherID"]);

                int normHours = Convert.ToInt32(row["NormHours"]);
                string personalData = Convert.ToString(row["PersonalData"]);
                string guid = Convert.ToString(row["GUID"]);
                a.NormHours = normHours;
                a.PersonalData = personalData;
                Teacher t = teacherList.Where(x => x.ID == TeacherID).FirstOrDefault();
                a.Teacher = t;
                a.Guid = Guid.Parse(guid);

                sql = @"SELECT
                                SubItemID,
                                GroupID,
                                DisciplineID,
                                ScheduleID,
                                AssignmentGUID
                            FROM
                                SubItem
                            WHERE AssignmentGUID = :AssignmentGUID";

                com = new SQLiteCommand(sql, DBConnection.con);
                com.Parameters.AddWithValue("AssignmentGUID", a.Guid.ToString());
                SQLiteDataAdapter dataAdapterSub = new SQLiteDataAdapter(com);
                DataTable dataTableSub = new DataTable();
                dataAdapterSub.Fill(dataTableSub);

                foreach (DataRow rowSub in dataTableSub.Rows)
                {
                    SubItem sub = new SubItem();

                    int SubItemID = Convert.ToInt32(rowSub["SubItemID"]);
                    int scheduleID = Convert.ToInt32(rowSub["ScheduleID"]);
                    //int groupID = Convert.ToInt32(rowSub["GroupID"]); 
                    //int disciplineID = Convert.ToInt32(rowSub["DisciplineID"]);

                    Schedule s = scheduleList.Where(x => x.ID == scheduleID).FirstOrDefault();
                    //Group g = groupList.Where(x => x.GroupID == groupID).FirstOrDefault();
                    //Discipline d = disciplineList.Where(x => x.ID == disciplineID).FirstOrDefault();

                    sub.Schedule = s;
                    //sub.Group = g;
                    //sub.Discipline = d;
                    sub.SubItemID = SubItemID;
                    sub.AssignmentGUID = Guid.Parse(guid);

                    a.SubItems.Add(sub);
                }

                result.Add(a);
            }

            return result;
        }

        public void AddAssignment(Assignment a)
        {
            string sql = @"INSERT INTO Assignment (
                                TeacherID,
                                NormHours,
                                PersonalData,
                                GUID
                            ) VALUES (
                                :TeacherID,
                                :NormHours,
                                :PersonalData,
                                :GUID
                            )";
            //создаем запрос на добавление записи
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("TeacherID", a.Teacher.ID);
            com.Parameters.AddWithValue("NormHours", a.NormHours);
            com.Parameters.AddWithValue("PersonalData", a.PersonalData);
            com.Parameters.AddWithValue("GUID", a.Guid.ToString());

            //выполняем
            com.ExecuteNonQuery();

            foreach (SubItem item in a.SubItems)
            {
                sql = @"INSERT INTO SubItem (
                                ScheduleID,
                                AssignmentGUID
                            ) VALUES (
                                :ScheduleID,
                                :AssignmentGUID
                            )";
                //создаем запрос на добавление записи
                com = new SQLiteCommand(sql, DBConnection.con);

                //заполняем параметрами
                //com.Parameters.AddWithValue("ScheduleID", item.Schedule.ID);
                //com.Parameters.AddWithValue("GroupID", item.Group.GroupID); 
                //com.Parameters.AddWithValue("DisciplineID", item.Discipline.ID);
                com.Parameters.AddWithValue("ScheduleID", item.Schedule.ID);
                com.Parameters.AddWithValue("AssignmentGUID", a.Guid.ToString());

                //выполняем
                com.ExecuteNonQuery();
            }
        }


        //Метод для редактирования 
        public void EditAssignment(Assignment a)
        {
            string sql = @"update Assignment set
                                TeacherID = :TeacherID,
                                NormHours = :NormHours,
                                PersonalData = :PersonalData
                            where ID = :ID";
            //создаем запрос
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("TeacherID", a.Teacher.ID);
            com.Parameters.AddWithValue("NormHours", a.NormHours);
            com.Parameters.AddWithValue("PersonalData", a.PersonalData);
            com.Parameters.AddWithValue("ID", a.ID);
            //выполняем запрос
            com.ExecuteNonQuery();

            sql = @"delete from SubItem 
                            where ReportGUID = :ReportGUID";
            //создаем запрос
            com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("AssignmentGUID", a.Guid.ToString());
            com.ExecuteNonQuery();

            foreach (SubItem item in a.SubItems)
            {
                sql = @"INSERT INTO SubItem (
                                ScheduleID,
                                AssignmentGUID
                            ) VALUES (
                                :ScheduleID
                                :AssignmentGUID
                            )";
                //создаем запрос на добавление записи
                com = new SQLiteCommand(sql, DBConnection.con);

                //заполняем параметрами
                //com.Parameters.AddWithValue("ScheduleID", item.Schedule.ID);
                //com.Parameters.AddWithValue("GroupID", item.Group.GroupID);
                //com.Parameters.AddWithValue("DisciplineID", item.Discipline.ID);
                com.Parameters.AddWithValue("ScheduleID", item.Schedule.ID);
                com.Parameters.AddWithValue("AssignmentGUID", a.Guid.ToString());

                //выполняем
                com.ExecuteNonQuery();
            }
        }


        //Метод для удаления  
        public void DeleteAssignment(Assignment a)
        {
            string sql = @"delete from Assignment 
                            where ID = :ID";
            //создаем запрос
            SQLiteCommand com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("ID", a.ID);

            //выполняем запрос
            com.ExecuteNonQuery();

            sql = @"delete from SubItem 
                            where ReportGUID = :ReportGUID";
            //создаем запрос
            com = new SQLiteCommand(sql, DBConnection.con);

            //заполняем параметрами
            com.Parameters.AddWithValue("AssignmentGUID", a.Guid.ToString());
            com.ExecuteNonQuery();

        }
    }
}

