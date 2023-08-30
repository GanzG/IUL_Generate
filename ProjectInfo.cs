using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IUL_Generate
{
    public partial class ProjectInfo : Form
    {
        public ProjectInfo()
        {
            InitializeComponent();
        }

        private void Close_bt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_bt_Click(object sender, EventArgs e)
        {
            MainView.ProjectName = ProjectName_tb.Text;
            MainView.GIP = GIP_tb.Text;
            MainView.GIP_Date = GIP_dtp.Text;
            MainView.Developer = Developer_tb.Text;
            MainView.Developer_Date = Developer_dtp.Text;
            MainView.DR = DialogResult.OK;
            this.Close();
        }
    }
}
