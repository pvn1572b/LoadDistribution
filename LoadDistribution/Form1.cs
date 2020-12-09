using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadDistribution
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void учителяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTeacherList teacherList = new frmTeacherList();
            teacherList.MdiParent = this;
            teacherList.Show();
        }

        private void дисциплиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDisciplineList disciplineList = new frmDisciplineList();
            disciplineList.MdiParent = this;
            disciplineList.Show();
        }

        private void группыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGroupList groupList = new frmGroupList();
            groupList.MdiParent = this;
            groupList.Show();
        }

        private void данныеОГруппахИДисциплинахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleList scheduleList = new frmScheduleList();
            scheduleList.MdiParent = this;
            scheduleList.Show();
        }

        private void выдачаУчебныхПорученийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssignmentList assignmentList = new frmAssignmentList();
            assignmentList.MdiParent = this;
            assignmentList.Show();
        }
    }
}
