using System.Windows;
using WorkRegistry.model;
using WorkRegistry.viewmodel;

namespace WorkRegistry.view
{
    /// <summary>
    /// Interaction logic for NewWorkWindow.xaml
    /// </summary>
    public partial class NewWorkWindow : Window
    {
        public Work CurrentWork { get; set; }
        public WorksViewModel worksViewModel { get; set; }

        public NewWorkWindow(WorksViewModel worksViewModel, Work work)
        {
            this.worksViewModel = worksViewModel;
            this.CurrentWork = work;
            this.DataContext = this;
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            worksViewModel.addNewWork(this.CurrentWork);
            this.Close();
        }
    }
}
