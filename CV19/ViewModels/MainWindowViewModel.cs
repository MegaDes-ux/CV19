using System;
using System.Collections.Generic;
using CV19.Infrastructure.Commands;
using CV19.ViewModels.Base;
using CV19.Models;
using System.Windows;
using System.Windows.Input;

namespace CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        #region TestDataPoint : IEnumerable<DataPoint> - Тестовый набор данных для визуализации

        ///<summary>Тестовый набор данных для визуализации</summary>
        private IEnumerable<DataPoint> _TestDataPoint;

        ///<summary>Тестовый набор данных для визуализации</summary>
        public IEnumerable<DataPoint> TestDataPoint
        {
            get => _TestDataPoint;
            set => Set(ref _TestDataPoint, value);
        }

        #endregion

        #region Заголовок окна

        private string _Title= "Анализ статистики CV19";
        /// <summary> Заголовок окна </summary>
        public string Title
        {
            get => _Title;
            /*set
             {
                if (Equals(_Title, value)) return;
                _Title = value;
                OnPropertyChanged();
            //Можно сократить в Set(ref _Title, value);
            } */
            //Можно сократить в 
            set => Set(ref _Title, value);
        }

        #endregion

        #region Status : string - Статус программы

        ///<summary>Статус программы</summary>
        private string _Status = "Готов!";

        ///<summary>Статус программы</summary>
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        #endregion

        #region Команды

        #region CloseApplicationCommand

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion
    
        #endregion

    public MainWindowViewModel()  // конструктор 
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x < 360; x += 0.1)
            {
                const double TO_RAD = Math.PI / 180;
                var y = Math.Sin(2 * Math.PI * x * TO_RAD);

                data_points.Add(new DataPoint{ XValue = x, YValue = y});
            }

            TestDataPoint = data_points;
        }
    }
}
