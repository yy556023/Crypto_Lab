using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Crypto_Lab.DAL.EntityFrameworkCore;

internal class CryptoDbContextFactory : IDesignTimeDbContextFactory<CryptoDbContext>
{
    public CryptoDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CryptoDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=Crypto_Lab;Trusted_Connection=True;TrustServerCertificate=True");

        return new CryptoDbContext(optionsBuilder.Options);
    }
}
