using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Choo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ChooDbContext dbContext;

        public MainWindow(ChooDbContext dbContext)
        {
            InitializeComponent();

            this.dbContext = dbContext;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dbContext.TrainPassages.OrderBy(item => item.PassTime).AsQueryable().Load();

            CollectionViewSource trainPassageViewSource = (CollectionViewSource)FindResource("TrainPassageViewSource");           
            trainPassageViewSource.Source = dbContext.TrainPassages.Local.ToObservableCollection();
            //passagesDataGrid.DataContext = trainPassageViewSource;
            //passagesDataGrid.ItemsSource = dbContext.TrainPassages.ToList();
        }

        private void passagesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            topSplitter.Visibility = Visibility.Visible;
            detailsPanel.Visibility = Visibility.Visible;

            //carPassagesDataGrid.ItemsSource = ;
        }

        private void ShowVideo(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
