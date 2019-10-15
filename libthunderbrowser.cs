using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
namespace ThunderBrowser
{
    public sealed class ThunderBrowserUI : Form
    {
        private readonly WebBrowser webBrowser = new WebBrowser();
        private readonly ToolStrip toolStrip = new ToolStrip();
        private readonly ToolStripButton newTab = new ToolStripButton();
        private readonly ToolStripButton prev = new ToolStripButton();
        private readonly ToolStripButton next = new ToolStripButton();
        private readonly ToolStripButton about = new ToolStripButton();
        private readonly ToolStripButton reload = new ToolStripButton();
        private readonly ToolStripButton EMERGENCYSTOP = new ToolStripButton();
        private readonly TextBox URLbar = new TextBox();
        private readonly ToolStripSeparator[] tss = new ToolStripSeparator[5];

        public ThunderBrowserUI()
        {
            InitializeComponent();
        }
        private IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        private void InitializeComponent()
        {
            //INIT
            ComponentResourceManager resources = new ComponentResourceManager(GetType());
            toolStrip.SuspendLayout();
            SuspendLayout();
            //web browser
            webBrowser.Location = new Point(12, 72);
            webBrowser.Name = "webBrowser";
            webBrowser.Size = new Size(0, 0);
            webBrowser.TabIndex = 0;
            webBrowser.Url = new Uri("https://google.com", UriKind.Absolute);
            webBrowser.Navigating += WebBrowser_Navigating;
            //url bar
            URLbar.Location = new Point(12, 28);
            URLbar.Name = "URLbar";
            URLbar.Size = new Size(0, 20);
            URLbar.TabIndex = 1;
            URLbar.KeyUp += URLbar_KeyUp;
            //new tab button
            newTab.DisplayStyle = ToolStripItemDisplayStyle.Text;
            newTab.Name = "newTab";
            newTab.Size = new Size(75, 22);
            newTab.Text = "new tab";
            newTab.ToolTipText = "creates a new tab";
            newTab.Click += NewTab_Click;
            //prev button
            prev.DisplayStyle = ToolStripItemDisplayStyle.Text;
            prev.ImageTransparentColor = Color.Magenta;
            prev.Name = "prev";
            prev.Size = new Size(50, 22);
            prev.Text = "prev";
            prev.Click += Prev_Click;
            //next button
            next.DisplayStyle = ToolStripItemDisplayStyle.Text;
            next.ImageTransparentColor = Color.Magenta;
            next.Name = "next";
            next.Size = new Size(50, 22);
            next.Text = "next";
            next.Click += Next_Click;
            //about button
            about.DisplayStyle = ToolStripItemDisplayStyle.Text;
            about.Name = "about";
            about.Size = new Size(50, 22);
            about.Text = "about";
            about.Click += About_Click;
            //reload button
            reload.DisplayStyle = ToolStripItemDisplayStyle.Text;
            reload.Name = "reload";
            reload.Size = new Size(50, 22);
            reload.Text = "reload";
            reload.Click += Reload_Click;
            //EMERGENCYSTOP button
            EMERGENCYSTOP.DisplayStyle = ToolStripItemDisplayStyle.Text;
            EMERGENCYSTOP.Name = "EMERGENCYSTOP";
            EMERGENCYSTOP.Size = new Size(100, 22);
            EMERGENCYSTOP.Text = "EMERGENCY STOP";
            EMERGENCYSTOP.Click += EMERGENCYSTOP_Click;
            //toolstrip
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.RenderMode = ToolStripRenderMode.Professional;
            toolStrip.Size = new Size(300, 25);
            toolStrip.TabIndex = 0;
            tss[0] = new ToolStripSeparator
            {
                Size = new Size(1, 15)
            };
            tss[1] = new ToolStripSeparator
            {
                Size = new Size(1, 15)
            };
            tss[2] = new ToolStripSeparator
            {
                Size = new Size(1, 15)
            };
            tss[3] = new ToolStripSeparator
            {
                Size = new Size(1, 15)
            };
            tss[4] = new ToolStripSeparator
            {
                Size = new Size(1, 15)
            };
            toolStrip.Items.AddRange(new ToolStripItem[] { newTab, tss[0], prev, tss[1], next, tss[2], reload, tss[3], EMERGENCYSTOP, tss[4], about});
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            //ThunderBrowserUI's KLUI
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = Size;
            Controls.Add(toolStrip);
            Controls.Add(URLbar);
            Controls.Add(webBrowser);
            Name = "ThunderBrowserUI";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "ThunderBrowser: an extremely lightweight, simple and high-performance but quite restricted browser made by Jessie Lesbian all by herself.";
            WindowState = FormWindowState.Maximized;
            SizeChanged += Form1_SizeChanged;
            FormClosed += Form1_FormClosed;
            //DONE
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private async void EMERGENCYSTOP_Click(object sender, EventArgs e)
        {
            webBrowser.Stop();
            webBrowser.Navigate("about:blank");
        }

        private async void Reload_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private async void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ABOUT " + Application.ProductName + "\nThunderBrowser is an extremely lightweight, simple and high-performance but quite restricted browser made by Jessie Lesbian all by herself.\nCopyright © 2019 Jessie Lesbian\nThis software is liscenced under GNU AGPLv3.\nPowered by .NET WebBrowser.", "ABOUT " + Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void Next_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private async void Prev_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private async void NewTab_Click(object sender, EventArgs e)
        {
            new ThunderBrowserUI().Show();
        }
        private async void Form1_SizeChanged(object sender, EventArgs e)
        {
            URLbar.Size = new Size(Size.Width - 45, 15);
            webBrowser.Size = new Size(Size.Width - 45, Size.Height - 150);
        }

        private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
            Dispose(true);
        }

        private async void URLbar_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.ToString() == "Return")
            {
                Uri uri = null;
                string text = URLbar.Text;
                try
                {
                    uri = new Uri(text);
                }
                catch
                {
                    uri = new Uri("https://www.google.com/search?q=" + text);
                }
                webBrowser.Navigate(uri);
            }
        }

        private async void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            URLbar.Text = webBrowser.Url.ToString();
        }
    }

    static class Program
    {
        [STAThread] static void Main()
        {
            new ThunderBrowserUI().Show();
            Application.Run();
        }
    }
}
