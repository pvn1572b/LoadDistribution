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
    public partial class frmGroupList : Form
    {
        GroupRepository groupRepository = new GroupRepository();
        public frmGroupList()
        {
            InitializeComponent();
        }

        private void frmGroupList_Load(object sender, EventArgs e)
        {
            LoadGroupList();
        }
        private void LoadGroupList()
        {

            dgvList.DataSource = groupRepository.GetGroupList();
            dgvList.Columns["GroupID"].HeaderText = "ID";
            dgvList.Columns["GroupNum"].HeaderText = "Номер";
            dgvList.Columns["StudentCount"].HeaderText = "Количество студентов";
            dgvList.Columns["EducationForm"].HeaderText = "Форма обучения";

            dgvList.Columns["GroupID"].Visible = false;


            dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmGroupEdit editGroup = new frmGroupEdit(groupRepository);
            if (editGroup.ShowDialog() == DialogResult.OK)
            {
                LoadGroupList();
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
                Group group = (dgvList.SelectedRows[0].DataBoundItem as Group);
                frmGroupEdit editGroup = new frmGroupEdit(groupRepository, group);
                if (editGroup.ShowDialog() == DialogResult.OK)
                {
                    LoadGroupList();
                }
            }
        }
    }
}
