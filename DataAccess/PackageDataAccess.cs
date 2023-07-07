using System.Collections.ObjectModel;
using DataAccess.Models;

namespace DataAccess;

public static class PackageDataAccess
{
    public static ObservableCollection<Package> Packages { get; set; } = new();
    public static Employee CurrentPackage = new();
    private static string Path = @"./DBPackages.csv";

    static PackageDataAccess()
    {
        ReadPackages();
    }

    private static void ReadPackages()
    {
        using var reader = new StreamReader(Path);
        Packages.Clear();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(",");
            var package = new Package
            {
                Id = Convert.ToInt32(values[0]),
                SenderAddress = values[1],
                ReceiverAddress = values[2],
                packageType =  (Package.PackageType)Enum.Parse(typeof(Package.PackageType), values[3]),
                ContainExpensive = Convert.ToBoolean(values[4]),
                postType = (Package.PostType) Enum.Parse(typeof(Package.PostType), values[5]),
                PhoneNo = values[6],
                Price = Convert.ToDouble(values[7])
            };
            Packages.Add(package);
        }
    }

    private static void SavePackages()
    {
        using var writer = new StreamWriter(Path);
        foreach (var package in Packages)
        {
            var Id = package.Id;
            var SenderAddress = package.SenderAddress;
            var ReceiverAddress = package.ReceiverAddress;
            var packageType = package.packageType;
            var ContainExpensive = package.ContainExpensive;
            var postType = package.postType;
            var PhoneNo = package.PhoneNo;
            var Price = package.Price;
        }
    }

    public static void AddPackage(Package package)
    {
        Packages.Add(package);
        SavePackages();
    }

    public static void RemovePackage(int id)
    {
        var temp = Packages.First(x => x.Id == id);
        Packages.Remove(temp);
        SavePackages();
    }

    public static void EditPackage(Package package)
    {
        var temp = Packages.First(x => x.Id == package.Id);
        var index = Packages.IndexOf(temp);
        Packages[index] = package;
        SavePackages();
    }

    public static int GetNextId()
    {
        var index = Packages.Any() ? Packages.Max(x => x.Id) + 1 : 1;
        return index;
    }
}