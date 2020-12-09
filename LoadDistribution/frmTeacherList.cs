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
    public partial class frmTeacherList : Form
    {
        TeacherRepository  teacherRepository = new TeacherRepository();
        public frmTeacherList()
        {
            InitializeComponent();
        }

        private void frmTeacherList_Load(object sender, EventArgs e)
        {
            LoadTeacherList();
        }
        private void LoadTeacherList()
        {

            dgvList.DataSource = teacherRepository.GetTeacherList();
            dgvList.Columns["ID"].HeaderText = "ID";
            dgvList.Columns["FirstName"].HeaderText = "Фамилия";
            dgvList.Columns["LastName"].HeaderText = "Имя";
            dgvList.Columns["Patronimyc"].HeaderText = "Отчество";
            dgvList.Columns["Chair"].HeaderText = "Кафедра";
            dgvList.Columns["Post"].HeaderText = "Должность";

            dgvList.Columns["ID"].Visible = false;


            dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmTeacherEdit editteacher = new frmTeacherEdit(teacherRepository);
            if (editteacher.ShowDialog() == DialogResult.OK)
            {
                LoadTeacherList();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            EditTeacher();
        }

        private void EditTeacher()
        {
            if (dgvList.SelectedRows.Count == 1)
            {
                Teacher teacher = (dgvList.SelectedRows[0].DataBoundItem as Teacher);
                frmTeacherEdit editteacher = new frmTeacherEdit(teacherRepository, teacher);
                if (editteacher.ShowDialog() == DialogResult.OK)
                {
                    LoadTeacherList();
                }
            }
        }
    }
}
