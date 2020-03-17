using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using MvvmLightDemo.Model;

namespace MvvmLightDemo.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class StudentViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public StudentViewModel()
        {
            if (IsInDesignMode)
            {
                Student = new StudentModel() { Age = 11, Name = "zs" };

                // Code runs in Blend --> create design time data.
            }
            else
            {
                Student = new StudentModel() { Age = 21, Name = "ls" };
                AddAgeCmd = new RelayCommand<string>(AddAge,CanAddAge);
                showMsgCmd = new RelayCommand(ShowMsg);

                GoPage = new RelayCommand<string>(ExecuteGoPage);
                // Code runs "for real"
            }
        }

        private void ExecuteGoPage(string obj)
        {
            
            var nav = CommonServiceLocator.ServiceLocator.Current.GetInstance<INavigationService>();
            if (obj == "Back")
            {
                nav.GoBack();
            }else
            nav.NavigateTo(obj);
        }

        public RelayCommand<string> GoPage { get; set; }
        private void ShowMsg()
        {
            Messenger.Default.Send<string>("来自ViewModel的消息", "myMsg");
        }

        private bool CanAddAge(string arg)
        {
            if (Student.Age > 23)
                return false;
            return true;
        }

        

        private void AddAge(string arg)
        {
            Student.Age=Student.Age+Convert.ToInt32( arg);
        }

        private StudentModel stu;
         
        public RelayCommand<string> AddAgeCmd { get; set; }
        public RelayCommand showMsgCmd { get; set; }
        public StudentModel Student
        {
            get => stu;
            set
            {
                Set(ref stu, value);
            }
        }
       
    }
}