using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SastCsharpClientTest
{
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// 命令能否执行
        /// </summary>
        readonly Func<bool> _canExecute;

        /// <summary>
        /// 命令能否执行
        /// </summary>
        readonly Action _execute;

        public RelayCommand(Action action, Func<bool> canExecute)
        {
            _canExecute = canExecute;
            _execute = action;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute();
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }
    }
}
