﻿// AppExit
// Copyright (C) 2018 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Windows.Forms;
using WindowsFormsExit.ViewModels;

namespace WindowsFormsExit.Views
{
    public partial class MainForm : Form
    {
        private readonly MainViewModel mainViewModel;

        public MainForm()
        {
            InitializeComponent();

            mainViewModel = new MainViewModel();

            buttonExit.Command = mainViewModel.ExitCommand;
            buttonChange.Command = mainViewModel.ChangeCommand;
            buttonSave.Command = mainViewModel.SaveCommand;

            labelIsSavedValue.DataBindings.Add(nameof(Label.Text), mainViewModel, nameof(mainViewModel.IsSavedText));
            labelIsSavedValue.DataBindings.Add(nameof(Label.BackColor), mainViewModel, nameof(mainViewModel.IsSavedColor));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                mainViewModel.ExitCommand.Execute(null);
            }
        }
    }
}