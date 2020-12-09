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
    public partial class frmGroupEdit : Form
    {
        Group group;
        GroupRepository groupRepository;

        public frmGroupEdit()
        {
            InitializeComponent();
        }

        public frmGroupEdit(GroupRepository _groupRepository)
        {
            InitializeComponent();
            groupRepository = _groupRepository;
        }

        public frmGroupEdit(GroupRepository _groupRepository, Group _group)
        {
            InitializeComponent();
            group = _group;
            groupRepository = _groupRepository;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private bool CheckData()
        {
            bool result = true;
            if (txtGroupNum.Text.Trim() == "")
                result = false;
            if (txtEducationForm.Text.Trim() == "")
                result = false;

            string str = txtStudentCount.Text;
            int studCount = 0;
            if (int.TryParse(str, out studCount))
            {
                if (studCount < 0 || studCount > 50)
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

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (CheckData())
            {
                if (group == null)
                {
                    group = new Group();

                    group.GroupNum = txtGroupNum.Text;
                    group.StudentCount = Convert.ToInt32(txtStudentCount.Text);
                    group.EducationForm = txtEducationForm.Text;

                    groupRepository.AddGroup(group);
                }
                else
                {
                    group.GroupNum = txtGroupNum.Text;
                    group.StudentCount = Convert.ToInt32(txtStudentCount.Text);
                    group.EducationForm = txtEducationForm.Text;

                    groupRepository.EditGroup(group);
                }
            }
            else
            {
                MessageBox.Show("Данные внесены некорректно!");
            }
        }
    }
}
