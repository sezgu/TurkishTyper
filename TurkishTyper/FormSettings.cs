using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsUtils;

namespace TurkishTyper
{
    public partial class FormSettings : Form
    {
        private bool m_CloseSuppressed = true;
        private ShortcutRecorder m_Recorder = null;
        private HookHandler m_HookHandler = null;
        private string ToString(IReadOnlyList<Key> keys)
        {
            return string.Join(" + ", keys.Select(k => k.ToUserString()).ToArray());
        }

        public FormSettings()
        {
            InitializeComponent();
        }

        internal FormSettings(HookHandler hookHandler)
            :this()
        {
            m_HookHandler = hookHandler;
            RefreshControls();
        }

        private void RefreshControls()
        {
            textBoxUpperCase.Text = ToString(m_HookHandler.UpperCombination);
            textBoxLowerCase.Text = ToString(m_HookHandler.LowerCombination);
            enableStartupMenuItem.Enabled = !File.Exists(Program.StartupLinkPath);
            disableToolStripMenuItem.Enabled = !enableStartupMenuItem.Enabled;
        }

        private void ButtonUpperCase_Click(object sender, EventArgs e)
        {
            RecordButton_Click(textBoxUpperCase, buttonUpperCase, buttonLowerCase, (keys) =>
            {
                Program.SaveShortcuts(null, keys.ToArray());
                m_HookHandler.UpperCombination = keys;

            });
        }

        private void ButtonLowerCase_Click(object sender, EventArgs e)
        {
            RecordButton_Click(textBoxLowerCase, buttonLowerCase, buttonUpperCase, (keys) => 
            {
                Program.SaveShortcuts(keys.ToArray(), null);
                m_HookHandler.LowerCombination = keys;

            });
        }

        private void RecordButton_Click(TextBox text, Button clicked, Button other, Action<IReadOnlyList<Key>> setter)
        {
            if (m_Recorder == null) //Start recording
            {
                m_Recorder = new ShortcutRecorder();
                m_Recorder.RecordChanged += () =>
                {
                    text.Text = string.Join(" + ", m_Recorder.RecordedKeys.Select(k => k.ToUserString()).ToArray());
                };
                other.Enabled = false;
                clicked.Text = "Bitir";
            }
            else //Stop recording
            {
                if (m_Recorder != null)
                {
                    if (m_Recorder.RecordedKeys.Count > 0 && MessageBox.Show($"{text.Text} kısayolunu kaydet?", "Kaydet",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        setter(m_Recorder.RecordedKeys);
                    }

                    m_Recorder.Dispose();
                    m_Recorder = null;
                    other.Enabled = true;
                    clicked.Text = "Değiştir";
                    RefreshControls();
                }
            }
        }


        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(m_CloseSuppressed)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
        }

        private void ToolStripMenuExit_Click(object sender, EventArgs e)
        {
            m_CloseSuppressed = false;
            Close();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(() => Hide()));
        }

        private void EnableStartupMenuItem_Click(object sender, EventArgs e)
        {
            new ApplicationShortcut(new string[] { })
                    .Save(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
            RefreshControls();
        }

        private void DisableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Program.StartupLinkPath))
                File.Delete(Program.StartupLinkPath);
            RefreshControls();
        }
    }
}
