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

namespace WindowsFormsExit.Business
{
    public class Project
    {
        private bool isSaved = true;

        public bool IsSaved
        {
            get => isSaved;
            private set
            {
                isSaved = value;
                OnIsSavedChanged();
            }
        }

        public event EventHandler IsSavedChanged;

        public void Save()
        {
            IsSaved = true;
        }

        public void ModifySomeData()
        {
            IsSaved = false;
        }

        protected virtual void OnIsSavedChanged()
        {
            IsSavedChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}