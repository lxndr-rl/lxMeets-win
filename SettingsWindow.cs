using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using NHotkey.WindowsForms;
using System.Collections.Generic;
using System.Linq;

namespace lxMeets
{
    public partial class SettingsWindow : Form
    {
        private bool recording = false;
        private List<String> list = new List<String>();
        public SettingsWindow()
        {
            InitializeComponent();
            keyboardShortCutText.Text = Properties.Settings.Default.KeyBoardShortCut.Replace("Keys.", "");
            autoRunCheck.Checked = Properties.Settings.Default.AutoStart;
            useKeyboardCheck.Checked = Properties.Settings.Default.UseKeyboard;
            sendNotificationsCheck.Checked = Properties.Settings.Default.Notifications;

            this.KeyPreview = true;

            if (Properties.Settings.Default.UseKeyboard)
            {
                recordKeyboardButton.Enabled = true;
            }
            else
            {
                recordKeyboardButton.Enabled = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Form1_KeyPress(object sender, KeyEventArgs e)
        {
            if (recording)
            {
                string keyboardKey = e.KeyCode.ToString().Replace("Key", "");
                keyboardKey = keyboardKey.Replace("Menu", "Alt");
                keyboardShortCutText.Text += keyboardKey + " | ";
                //list.Add(e.KeyData.ToString());
            }
        }

        private void record_Click(object sender, EventArgs e)
        {
            keyboardShortCutText.Text = "";
            recordKeyboardButton.Visible = false;
            stopRecordButton.Visible = true;
            recording = true;
        }

        private void stoprecord_Click(object sender, EventArgs e)
        {
            try
            {
                keyboardShortCutText.Text = keyboardShortCutText.Text.Remove(keyboardShortCutText.Text.Length - 3);
            }
            catch
            {
                keyboardShortCutText.Text = Properties.Settings.Default.KeyBoardShortCut;
            }
            recordKeyboardButton.Visible = true;
            stopRecordButton.Visible = false;
            recording = false;
        }

        private void useKeyboardCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (useKeyboardCheck.Checked)
            {
                var mainForm = Application.OpenForms.OfType<lxMeets>().Single();
                HotkeyManager.Current.AddOrReplace("AbrirClase", Keys.Control | Keys.Alt | Keys.Shift, mainForm.fromKeyboard);
                recordKeyboardButton.Enabled = true;
                Properties.Settings.Default.UseKeyboard = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                HotkeyManager.Current.Remove("AbrirClase");
                recordKeyboardButton.Enabled = false;
                Properties.Settings.Default.UseKeyboard = false;
                Properties.Settings.Default.Save();
            }
        }

        private void autoRunCheck_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (autoRunCheck.Checked)
            {
                registryKey.SetValue("lxMeets", Process.GetCurrentProcess().MainModule.FileName.ToString());
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
    }
}
