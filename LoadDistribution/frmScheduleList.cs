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
    public partial class frmScheduleList : Form
    {
        ScheduleRepository scheduleRepository= new ScheduleRepository();
        public frmScheduleList()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmScheduleEdit editSchedule = new frmScheduleEdit(scheduleRepository);
            if (editSchedule.ShowDialog() == DialogResult.OK)
            {
                LoadScheduleList();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            EditSchedule();
        }

        private void EditSchedule()
        {
            if (dgvList.SelectedRows.Count == 1)
            {
                Schedule schedule = (dgvList.SelectedRows[0].DataBoundItem as Schedule);
                frmScheduleEdit editSchedule = new frmScheduleEdit(scheduleRepository, schedule);
                if (editSchedule.ShowDialog() == DialogResult.OK)
                {
                    LoadScheduleList();
                }
            }
        }

        private void frmScheduleList_Load(object sender, EventArgs e)
        {
            LoadScheduleList();
        }
        private void LoadScheduleList()
        {

            dgvList.DataSource = scheduleRepository.GetScheduleList();
            dgvList.Columns["ID"].HeaderText = "ID";
            dgvList.Columns["Group"].HeaderText = "Группа";
            dgvList.Columns["Discipline"].HeaderText = "Дисциплина";
            dgvList.Columns["Hours"].HeaderText = "Количество аудиторных часов";

            dgvList.Columns["ID"].Visible = false;


            dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
