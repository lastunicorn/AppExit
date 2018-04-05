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
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace WindowsFormsExit.CustomControls
{
    public partial class CustomButton : Button
    {
        private ICommand command;

        public ICommand Command
        {
            get => command;
            set
            {
                if (command != null)
                {
                    command.CanExecuteChanged -= HandleCommandCanExecuteChanged;
                    Enabled = true;
                }

                command = value;

                if (command != null)
                {
                    command.CanExecuteChanged += HandleCommandCanExecuteChanged;
                    Enabled = command.CanExecute(null);
                }
            }
        }

        private void HandleCommandCanExecuteChanged(object sender, EventArgs e)
        {
            Enabled = command.CanExecute(null);
        }

        public CustomButton()
        {
            InitializeComponent();
        }

        public CustomButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            command?.Execute(null);

            base.OnClick(e);
        }
    }
}
