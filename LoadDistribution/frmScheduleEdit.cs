using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoadDistribution.Repository;
using LoadDistribution.Entity;

namespace LoadDistribution
{
    public partial class frmScheduleEdit : Form
    {
        Schedule schedule;
        ScheduleRepository scheduleRepository;
        DisciplineRepository disciplineRepository;
        GroupRepository  groupRepository;
        public frmScheduleEdit()
        {
            InitializeComponent();
        }

        public frmScheduleEdit(ScheduleRepository _scheduleRepository)
        {
            InitializeComponent();

            scheduleRepository = _scheduleRepository;
            disciplineRepository = new DisciplineRepository();
            groupRepository = new GroupRepository();

            cmbDiscipline.DataSource = disciplineRepository.GetDisciplineList();
            cmbGroup.DataSource = groupRepository.GetGroupList();
        }

        public frmScheduleEdit(ScheduleRepository _scheduleRepository, Schedule _schedule )
        {
            InitializeComponent();
            scheduleRepository = _scheduleRepository;
            disciplineRepository = new DisciplineRepository();
            groupRepository = new GroupRepository();

            schedule = _schedule;

            cmbDiscipline.DataSource = disciplineRepository.GetDisciplineList();
            cmbGroup.DataSource = groupRepository.GetGroupList();

            if (schedule != null)
            {
                if (schedule.Group != null)
                {
                    for (int i = 0; i < cmbGroup.Items.Count; i++)
                    {
                        if (((cmbGroup.Items[i]) as Group).GroupID == schedule.Group.GroupID)
                            cmbGroup.SelectedIndex = i;
                    }
                }

                if (schedule.Discipline != null)
                {
                    for (int i = 0; i < cmbDiscipline.Items.Count; i++)
                    {
                        if (((cmbDiscipline.Items[i]) as Discipline).ID == schedule.Discipline.ID)
                            cmbDiscipline.SelectedIndex = i;
                    }
                }

                txtHours.Text = schedule.Hours.ToString();
            }

        }
        private void frmScheduleEdit_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (CheckData())
            {
                if (schedule == null)
                {
                    schedule = new Schedule();

                    schedule.Hours = Convert.ToInt32(txtHours.Text);
                    schedule.Discipline = (cmbDiscipline.SelectedItem as Discipline);
                    schedule.Group = (cmbGroup.SelectedItem as Group);

                    scheduleRepository.AddSchedule(schedule);
                }
                else
                {
                    schedule.Hours = Convert.ToInt32(txtHours.Text);
                    schedule.Discipline = (cmbDiscipline.SelectedItem as Discipline);
                    schedule.Group = (cmbGroup.SelectedItem as Group);

                    scheduleRepository.EditSchedule(schedule);
                }
            }
            else
            {
                MessageBox.Show("Данные внесены некорректно!");
            }
        }

        private bool CheckData()
        {
            bool result = true;
            if (cmbDiscipline.SelectedIndex == -1)
                result = false;
            if (cmbGroup.SelectedIndex == -1)
                result = false;

            string str = txtHours.Text;
            int hours = 0;
            if (int.TryParse(str, out hours))
            {
                if (hours < 0 || hours > 30 * 24)
                    result = false;
            }
            else
            {
                result = false;
            }
            return result;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
