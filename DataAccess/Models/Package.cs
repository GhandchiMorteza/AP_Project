using System.Reflection.Metadata;

namespace DataAccess.Models;



public class Package
{
    public enum PackageType 
    {
        Object,
        Document,
        Fragile
    }
    public enum PostType
    {
        Normal,
        Express
    }

    public int Id;
    public string SenderAddress { get; set; }
    public string ReceiverAddress { get; set; }
    public PackageType packageType { get; set; }
    public bool ContainExpensive { get; set; }
    public PostType postType { get; set; }
    public string PhoneNo { get; set; }
    public double Price { get; set; }
}