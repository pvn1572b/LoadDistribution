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
    public partial class frmAssignmentList : Form
    {
        AssignmentRepository assignmentRepository;
        public frmAssignmentList()
        {
            InitializeComponent();
        }

        private void frmAssignmentList_Load(object sender, EventArgs e)
        {
            assignmentRepository = new AssignmentRepository();
            LoadAssignments();
        }
        private void LoadAssignments()
        {

            dgvList.DataSource = assignmentRepository.GetAssignmentList();
            dgvList.Columns["ID"].HeaderText = "ID";
            dgvList.Columns["Teacher"].HeaderText = "Преподаватель";
            dgvList.Columns["NormHours"].HeaderText = "Норма аудиторных часов";
            dgvList.Columns["PersonalData"].HeaderText = "Персональная информация";
            dgvList.Columns["TotalHours"].HeaderText = "Всего часов";

            dgvList.Columns["Guid"].Visible = false;
            dgvList.Columns["ID"].Visible = false;


            dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmAssignmentEditSh assignmentEdit = new frmAssignmentEditSh(assignmentRepository);
            if (assignmentEdit.ShowDialog() == DialogResult.OK)
            {
                LoadAssignments();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count == 1)
            {
                Assignment assignment= (dgvList.SelectedRows[0].DataBoundItem as Assignment);
                frmAssignmentEditSh assignmentEdit = new frmAssignmentEditSh(assignmentRepository, assignment);
                if (assignmentEdit.ShowDialog() == DialogResult.OK)
                {
                    LoadAssignments();
                }
            }

        }
    }
}
