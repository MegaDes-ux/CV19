﻿using System;
using System.Collections.Generic;
using System.Text;
using CV19.ViewModels.Base;

namespace CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
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
        private string _Status;

        ///<summary>Статус программы</summary>
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        #endregion      
    }
}
