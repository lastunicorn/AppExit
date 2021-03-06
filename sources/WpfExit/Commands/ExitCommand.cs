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

using System;
using System.Windows;
using System.Windows.Input;

namespace DustInTheWind.WpfExit.Commands
{
    internal class ExitCommand : ICommand
    {
        private readonly WpfExitApplication application;

        public event EventHandler CanExecuteChanged;

        public ExitCommand(WpfExitApplication application)
        {
            this.application = application ?? throw new ArgumentNullException(nameof(application));
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            bool allowExit = application.Exit();

            if (allowExit)
                Application.Current.Shutdown();
        }
    }
}