using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomWebBrowser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        WebBrowser web = new WebBrowser();
        int tabCount = 0;

        private void MainForm_Load(object sender, EventArgs e)
        {
            web = new WebBrowser();
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;

            web.DocumentCompleted += web_DocumentCompleted;

            mainTabControl.TabPages.Add("New Tab");
            mainTabControl.SelectTab(tabCount);
            mainTabControl.SelectedTab.Controls.Add(web);
            tabCount += 1;
        }

        void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            mainTabControl.SelectedTab.Text = ((WebBrowser)mainTabControl.SelectedTab.Controls[0]).DocumentTitle;
        }

        private void goToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)mainTabControl.SelectedTab.Controls[0]).Navigate(adressBox.Text);
            if (!adressBox.Items.Contains(adressBox.Text))
            {
                adressBox.Items.Add(adressBox.Text);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ((WebBrowser)mainTabControl.SelectedTab.Controls[0]).GoBack();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ((WebBrowser)mainTabControl.SelectedTab.Controls[0]).GoForward();
        }

        private void addPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            web = new WebBrowser();
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;

            web.DocumentCompleted += web_DocumentCompleted;

            mainTabControl.TabPages.Add("New Tab");
            mainTabControl.SelectTab(tabCount);
            mainTabControl.SelectedTab.Controls.Add(web);
            tabCount += 1;
        }

        private void removePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainTabControl.TabPages.Count - 1 > 0)
            {
                mainTabControl.TabPages.RemoveAt(mainTabControl.SelectedIndex);
                mainTabControl.SelectTab(mainTabControl.TabPages.Count - 1);
                tabCount -= 1;
            }
        }

        private void adressBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ((WebBrowser)mainTabControl.SelectedTab.Controls[0]).Navigate(adressBox.Text);
                if (!adressBox.Items.Contains(adressBox.Text))
                {
                    adressBox.Items.Add(adressBox.Text);
                }
            }
        }
    }
}
