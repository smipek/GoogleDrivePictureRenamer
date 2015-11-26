using System;
using System.Text;
using System.Windows.Forms;

namespace GoogleDrivePictureRenamer
{
    public partial class frmMain : Form
    {
        private Renamer m_FormObject;
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bool bConnected = m_FormObject.Connected;

            if (!bConnected)
            {
                bConnected = m_FormObject.Connect();
            }

            lblConnected.Text = bConnected ? ""
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
