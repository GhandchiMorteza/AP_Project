using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using DataAccess;
using DataAccess.Models;

namespace Postal_Management_System.Pages.Employee;

public partial class OrdersReporting : Page
{
    public PackageDataAccess packageDataAccess = new PackageDataAccess();
    public ObservableCollection<Package> Packages = new ObservableCollection<Package>();
    public Package CurrentEmployee { get; set; } = new Package();
    
    public OrdersReporting()
    {
        InitializeComponent();
        fillData();
        PackagesGrid.ItemsSource = Packages;
    }

    private void fillData()
    {
        Packages = packageDataAccess.Packages;
    }
}