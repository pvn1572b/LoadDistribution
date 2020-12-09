using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoadDistribution.Entity;
using LoadDistribution.Repository;


namespace LoadDistribution
{
    public partial class frmAssignmentEdit : Form
    {

        Assignment assignment;                
        AssignmentRepository assignmentRepo; 
        TeacherRepository teacherRepo ;  
        GroupRepository groupRepo;     
        DisciplineRepository disciplineRepo ;      
        public frmAssignmentEdit()
        {
            InitializeComponent();
        }
        public frmAssignmentEdit(AssignmentRepository _assignmentRepo)
        {
            InitializeComponent();
            assignment = new Assignment();
            assignment.SubItems = new List<SubItem>();

            assignmentRepo = _assignmentRepo;
            teacherRepo = new TeacherRepository();
            groupRepo = new  GroupRepository();
            disciplineRepo = new DisciplineRepository();

            //заполняем выподающие списки данными
            cmbTeacher.DataSource = teacherRepo.GetTeacherList();
            cmbGroups.DataSource = groupRepo.GetGroupList();
            cmbDiscipline.DataSource = disciplineRepo.GetDisciplineList();
        }

        public frmAssignmentEdit(AssignmentRepository _assignmentRepo, Assignment _assignment )
        {
            InitializeComponent();

            assignment = _assignment;

            assignmentRepo = _assignmentRepo;
            teacherRepo = new TeacherRepository();
            groupRepo = new GroupRepository();
            disciplineRepo = new DisciplineRepository();

            //заполняем выподающие списки данными
            cmbTeacher.DataSource = teacherRepo.GetTeacherList();
            cmbGroups.DataSource = groupRepo.GetGroupList();
            cmbDiscipline.DataSource = disciplineRepo.GetDisciplineList();

            //если открываем форму для редактирования, заполняем поля
            if (assignment.Teacher!= null)
            {
                if (assignment.Teacher != null)
                {
                    for (int i = 0; i < cmbTeacher.Items.Count; i++)
                    {
                        if (((cmbTeacher.Items[i]) as Teacher).ID == assignment .Teacher.ID)
                            cmbTeacher.SelectedIndex = i;
                    }
                }

                foreach (SubItem  si in assignment.SubItems)
                {
                    SubItem sub = new SubItem();
                    sub.Group = si.Group;
                    sub.Discipline = si.Discipline;
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = sub.Group.GroupNum;
                    lvi.SubItems.Add(sub.Discipline.ToString());
                    lvi.Tag = sub;
                    listView1.Items.Add(lvi);

                }

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //проверка данных
            if (CheckData())
            {
                //если объект пустой, значит это создание нового документа
                if (assignment.Guid == Guid.Empty)
                {
                    assignment.Teacher = (cmbTeacher.SelectedItem as Teacher);
                    assignment.PersonalData =  txtPersonalData.Text;
                    assignment.NormHours = Convert.ToInt32(txtNormHours.Text);
                    assignment.Guid = Guid.NewGuid();

                    //добавление в БД
                    assignmentRepo.AddAssignment(assignment);
                }
                else
                {
                    //иначе изменение текущего
                    assignment.Teacher = (cmbTeacher.SelectedItem as Teacher);
                    assignment.PersonalData = txtPersonalData.Text;
                    assignment.NormHours = Convert.ToInt32(txtNormHours.Text);

                    //изменение в БД
                    assignmentRepo.EditAssignment(assignment);
                }
            }
            else
            {
                MessageBox.Show("Данные внесены некорректно!");
            }
        }

        private bool CheckData()
        {
            //проверяем, выбраны ли значения
            bool result = true;
            if (cmbTeacher.SelectedIndex == -1)
                result = false;
            if (assignment.SubItems.Count <= 0)
                result = false;

            return result;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SubItem si = new SubItem();
            si.Group = (cmbGroups.SelectedItem as Group);
            si.Discipline = (cmbDiscipline.SelectedItem as Discipline);
            ListViewItem lvi = new ListViewItem();
            lvi.Text = si.Group.GroupNum;
            lvi.SubItems.Add(si.Discipline.Name);
            lvi.Tag = si;
            listView1.Items.Add(lvi);
            assignment.SubItems.Add(si);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                SubItem si = (listView1.SelectedItems[0].Tag as SubItem);
                assignment.SubItems.Remove(assignment.SubItems.Where(x => x.Group.GroupID == si.Group.GroupID && x.Discipline.ID == si.Discipline.ID).First());
                listView1.SelectedItems[0].Remove();
            }
        }
    }
}
