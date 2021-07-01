using System;
using System.Windows.Input;

namespace CV19.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand   //класс абстрактный
        
    {
        public event EventHandler CanExecuteChanged  //будет генерироваться при изменении состоянии CanExecute
        
        {
            //Передаем управление системе WPF с помощью CommandManager
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        //сделали методы абстрактными, т.к. их реализацией займется наследник
        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
