﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hexware.Programs.iDecryptIt
{
    public partial class SelectLangControl : Window
    {
        private MainWindow mainwindow;

        internal SelectLangControl(MainWindow mw)
        {
            InitializeComponent();
            mainwindow = mw;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string lang = Registry.CurrentUser
                .OpenSubKey("SOFTWARE\\Hexware\\iDecryptIt", true)
                .GetValue("language")
                .ToString();

            // Change language
            if (lang == "eng")
            {
                // English
                cmbSelect.SelectedIndex = 0;
            }
            else if (lang == "spa")
            {
                // Spanish
                cmbSelect.SelectedIndex = 1;
            }
            else
            {
                // Fall back to English if is not any of the above
                Registry.CurrentUser.DeleteSubKey("SOFTWARE\\Hexware\\iDecryptIt");
                cmbSelect.SelectedIndex = 0;
            }
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            int selected = cmbSelect.SelectedIndex;

            // Use else if to save execution time on the lower indexes
            if (selected == 0)
            {
                enter("eng");
                mainwindow.setlang("eng");
            }
            else if (selected == 1)
            {
                mainwindow.setlang("spa");
                enter("spa");
            }
            Close();
        }
        private void enter(string lang)
        {
            Registry.CurrentUser
                .CreateSubKey("SOFTWARE\\Hexware\\iDecryptIt")
                .OpenSubKey("SOFTWARE\\Hexware\\iDecryptIt", true);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Hexware\\iDecryptIt", "language", lang, RegistryValueKind.String);
        }
    }
}