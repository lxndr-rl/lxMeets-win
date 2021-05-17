using Microsoft.Win32;
using NHotkey.WindowsForms;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace lxMeets
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
            keyboardShortCutText.Text = Properties.Settings.Default.KeyBoardShortCut.Replace("Keys.", "");
            autoRunCheck.Checked = Properties.Settings.Default.AutoStart;
            useKeyboardCheck.Checked = Properties.Settings.Default.UseKeyboard;
            sendNotificationsCheck.Checked = Properties.Settings.Default.Notifications;

            this.KeyPreview = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UseKeyboardCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (useKeyboardCheck.Checked)
            {
                var mainForm = Application.OpenForms.OfType<lxMeets>().Single();
                HotkeyManager.Current.AddOrReplace("AbrirClase", Keys.Control | Keys.Alt | Keys.Shift, mainForm.FromKeyboard);
                Properties.Settings.Default.UseKeyboard = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                HotkeyManager.Current.Remove("AbrirClase");
                Properties.Settings.Default.UseKeyboard = false;
                Properties.Settings.Default.Save();
            }
        }

        private void AutoRunCheck_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (autoRunCheck.Checked)
            {
                registryKey.SetValue("lxMeets", $"{Process.GetCurrentProcess().MainModule.FileName} --start-minimized");
                Properties.Settings.Default.AutoStart = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                registryKey.DeleteValue("lxMeets");
                Properties.Settings.Default.AutoStart = false;
                Properties.Settings.Default.Save();
            }


        }

        private void SendNotificationsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (sendNotificationsCheck.Checked)
            {
                Properties.Settings.Default.Notifications = true;
                Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.Notifications = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
