using System.Collections.ObjectModel;
using DataAccess.Models;

namespace DataAccess;

public class PackageDataAccess
{
    public ObservableCollection<Package> Packages { get; set; } = new ObservableCollection<Package>();

    public PackageDataAccess()
    {
        ReadPackages();
    }

    private void ReadPackages()
    {
        var package1 = new Package()
        {
            Id = 1,
            SenderAddress = "Felanja",
            ReceiverAddress = "Oonja",
            packageType = Package.PackageType.Fragile,
            ContainExpensive = false,
            postType = Package.PostType.Normal,
            PhoneNo = "09128564523",
            Price = 2500
        };
        
        var package2 = new Package()
        {
            Id = 2,
            SenderAddress = "doorja",
            ReceiverAddress = "nazdicja",
            packageType = Package.PackageType.Object,
            ContainExpensive = true,
            postType = Package.PostType.Express,
            PhoneNo = "09127254523",
            Price = 10000
        };
        
        Packages.Add(package1);
        Packages.Add(package2);
    }

    private void AddPackage(Package package)
    {
        Packages.Add(package);
    }

    public void RemovePackage(int id)
    {
        var temp = Packages.First(x => x.Id == id);
        Packages.Remove(temp);
    }

    public void EditPackage(Package package)
    {
        var temp = Packages.First(x => x.Id == package.Id);
        var index = Packages.IndexOf(temp);
        Packages[index] = package;
    }

    public int GetNextId()
    {
        var index = Packages.Any() ? Packages.Max(x => x.Id) + 1 : 1;
        return index;
    }
}