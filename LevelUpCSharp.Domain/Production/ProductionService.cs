using LevelUpCSharp.Persistence;
using LevelUpCSharp.Products;

namespace LevelUpCSharp.Production
{
    public class ProductionService
    {
        public Vendor Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result<Vendor>.Failed();
            }

            var vendor = new Vendor(name, new Outsource());

            Repositories.Vendors.Add(vendor.Name, vendor);

            return Result<Vendor>.Success(vendor);
        }
    }
}