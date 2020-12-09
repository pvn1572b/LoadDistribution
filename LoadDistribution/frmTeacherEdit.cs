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
    public partial class frmTeacherEdit : Form
    {
        Teacher teacher;
        TeacherRepository  teacherRepository;
        public frmTeacherEdit(TeacherRepository _teacherRepository)
        {
            InitializeComponent();
            teacherRepository = _teacherRepository;
        }

        public frmTeacherEdit(TeacherRepository _teacherRepository, Teacher _teacher)
        {
            InitializeComponent();
            teacher = _teacher;
            teacherRepository = _teacherRepository;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                if (teacher == null)
                {
                    teacher = new Teacher();

                    teacher.FirstName = txtSurname.Text;
                    teacher.LastName = txtName.Text;
                    teacher.Patronimyc = txtPatronimyc.Text;
                    teacher.Chair= txtChair.Text;
                    teacher.Post = txtPost.Text;

                    teacherRepository.AddTeacher(teacher);
                }
                else
                {
                    teacher.FirstName = txtSurname.Text;
                    teacher.LastName = txtName.Text;
                    teacher.Patronimyc = txtPatronimyc.Text;
                    teacher.Chair = txtChair.Text;
                    teacher.Post = txtPost.Text;

                    teacherRepository.EditTeacher(teacher);
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
            if (txtSurname.Text.Trim() == "")
                result = false;
            if (txtName.Text.Trim() == "")
                result = false;
            if (txtPatronimyc.Text.Trim() == "")
                result = false;
            if (txtChair.Text.Trim() == "")
                result = false;
            if (txtPost.Text.Trim() == "")
                result = false;
            return result;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
