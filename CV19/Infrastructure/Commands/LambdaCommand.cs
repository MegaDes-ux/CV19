using System;
using CV19.Infrastructure.Commands.Base;

namespace CV19.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        //делаем их readonly, что бы работали быстрее!
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute = null;
        public LambdaCommand(Action<object> Execute, Func<object,bool> CanExecute = null) // конструктор класса
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute)); //проверяем, дали ли нам ссылку на делегат
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;
        //_CanExecute  - подразумеваем, что может быть пустая ссылка
        // ?? - если делегата нет, то считаем, что команду можно выполнить
        // метод Invoke принимает делегат и выполняет его в том потоке, в котором был создан элемент управления.

        public override void Execute(object parameter) => _Execute(parameter);
    }
}
