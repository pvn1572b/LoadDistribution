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
    public partial class frmDisciplineEdit : Form
    {
        Discipline discipline;
        DisciplineRepository  disciplineRepository;

        public frmDisciplineEdit()
        {
            InitializeComponent();
        }

        public frmDisciplineEdit(DisciplineRepository _disciplineRepository)
        {
            InitializeComponent();
            disciplineRepository = _disciplineRepository;
        }

        public frmDisciplineEdit(DisciplineRepository _disciplineRepository, Discipline _discipline)
        {
            InitializeComponent();
            discipline = _discipline;
            disciplineRepository = _disciplineRepository;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                if (discipline == null)
                {
                    discipline = new  Discipline();

                    discipline.Name = txtName.Text;
                    discipline.ClassType = txtClassType.Text;
                    discipline.TermNum = Convert.ToInt32( txtTermNum.Text);

                    disciplineRepository.AddDiscipline(discipline);
                }
                else
                {
                    discipline.Name = txtName.Text;
                    discipline.ClassType = txtClassType.Text;
                    discipline.TermNum = Convert.ToInt32(txtTermNum.Text);

                    disciplineRepository.EditDiscipline(discipline);
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
            if (txtName.Text.Trim() == "")
                result = false;
            if (txtClassType.Text.Trim() == "")
                result = false;
            if (txtTermNum.Text.Trim() == "")
                result = false;

            string str = txtTermNum.Text;
            int termNum = 0;
            if (int.TryParse(str, out termNum))
            {
                if (termNum < 0 || termNum > 2)
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
