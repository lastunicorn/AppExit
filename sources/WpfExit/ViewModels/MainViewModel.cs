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
using DustInTheWind.WpfExit.Commands;

namespace DustInTheWind.WpfExit.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly WpfExitApplication application;
        private bool isSaved;

        public ExitCommand ExitCommand { get; }
        public ChangeCommand ChangeCommand { get; }
        public SaveCommand SaveCommand { get; }

        public bool IsSaved
        {
            get => isSaved;
            private set
            {
                isSaved = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            application = new WpfExitApplication();

            ExitCommand = new ExitCommand(application);
            ChangeCommand = new ChangeCommand(application);
            SaveCommand = new SaveCommand(application);

            application.CurrentProject.IsSavedChanged += HandleCurrentProjectIsSavedChanged;

            UpdateData();
        }

        private void HandleCurrentProjectIsSavedChanged(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            IsSaved = application.CurrentProject.IsSaved;
        }
    }
}