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
using System.Windows;

namespace DustInTheWind.WpfExit
{
    internal class WpfExitApplication
    {
        public Project CurrentProject { get; }

        public WpfExitApplication()
        {
            CurrentProject = new Project();
        }

        public bool Exit()
        {
            if (CurrentProject.IsSaved)
                return true;

            MessageBoxResult result = MessageBox.Show("Do you want to save before exit?", "Save", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Yes);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    CurrentProject.Save();
                    MessageBox.Show("Project was saved.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;

                case MessageBoxResult.No:
                    MessageBox.Show("Project was NOT saved.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;

                case MessageBoxResult.Cancel:
                    return false;

                default:
                    throw new Exception("Invalid response when asked to save.");
            }
        }
    }
}