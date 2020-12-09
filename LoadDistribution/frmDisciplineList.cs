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
    public partial class frmDisciplineList : Form
    {
        DisciplineRepository disciplineRepository = new DisciplineRepository();
        public frmDisciplineList()
        {
            InitializeComponent();
        }

        private void frmDisciplineList_Load(object sender, EventArgs e)
        {

            LoadDisciplineList();
        }
        private void LoadDisciplineList()
        {

            dgvList.DataSource = disciplineRepository.GetDisciplineList();
            dgvList.Columns["ID"].HeaderText = "ID";
            dgvList.Columns["Name"].HeaderText = "Название";
            dgvList.Columns["ClassType"].HeaderText = "Вид занятия";
            dgvList.Columns["TermNum"].HeaderText = "Номер текущего семестра";

            dgvList.Columns["ID"].Visible = false;


            dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmDisciplineEdit editDiscipline = new frmDisciplineEdit(disciplineRepository);
            if (editDiscipline.ShowDialog() == DialogResult.OK)
            {
                LoadDisciplineList();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            EditDiscipline();
        }

        private void EditDiscipline()
        {
            if (dgvList.SelectedRows.Count == 1)
            {
                Discipline discipline = (dgvList.SelectedRows[0].DataBoundItem as Discipline);
                frmDisciplineEdit editDiscipline = new frmDisciplineEdit(disciplineRepository, discipline);
                if (editDiscipline.ShowDialog() == DialogResult.OK)
                {
                    LoadDisciplineList();
                }
            }
        }
    }
}
