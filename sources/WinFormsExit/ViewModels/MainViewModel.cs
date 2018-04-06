// AppExit
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

using System;
using System.Drawing;
using WindowsFormsExit.Commands;

namespace WindowsFormsExit.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly WindowsFormsExitApplication application;
        private string isSavedText;
        private Color isSavedColor;

        public string IsSavedText
        {
            get => isSavedText;
            private set
            {
                isSavedText = value;
                OnPropertyChanged();
            }
        }

        public Color IsSavedColor
        {
            get => isSavedColor;
            set
            {
                isSavedColor = value;
                OnPropertyChanged();
            }
        }

        public ExitCommand ExitCommand { get; }
        public ChangeCommand ChangeCommand { get; }
        public SaveCommand SaveCommand { get; }

        public MainViewModel(WindowsFormsExitApplication application)
        {
            this.application = application ?? throw new ArgumentNullException(nameof(application));

            ExitCommand = new ExitCommand(this.application);
            ChangeCommand = new ChangeCommand(this.application);
            SaveCommand = new SaveCommand(this.application);

            this.application.CurrentProject.IsSavedChanged += HandleCurrentProjectIsSavedChanged;

            UpdateData();
        }

        private void HandleCurrentProjectIsSavedChanged(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            if (application.CurrentProject.IsSaved)
            {
                IsSavedText = "yes";
                IsSavedColor = Color.DarkSeaGreen;
            }
            else
            {
                IsSavedText = "no";
                IsSavedColor = Color.OrangeRed;
            }
        }
    }
}