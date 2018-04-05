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
using System.Windows.Forms;
using WindowsFormsExit.Business;

namespace WindowsFormsExit
{
    public class WindowsFormsExitApplication
    {
        public Project CurrentProject { get; }

        public WindowsFormsExitApplication()
        {
            CurrentProject = new Project();
        }

        public bool Exit()
        {
            if (CurrentProject.IsSaved)
                return true;

            DialogResult dialogResult = MessageBox.Show("Do you want to save before exit?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            switch (dialogResult)
            {
                case DialogResult.Yes:
                    CurrentProject.Save();
                    MessageBox.Show("Project was saved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;

                case DialogResult.No:
                    MessageBox.Show("Project was NOT saved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;

                case DialogResult.Cancel:
                    return false;

                default:
                    throw new Exception("Invalid response when asked to save.");
            }
        }
    }
}