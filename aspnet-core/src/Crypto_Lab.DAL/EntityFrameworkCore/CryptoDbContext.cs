using Crypto_Lab.Common.Models.Exchanges;
using Crypto_Lab.Common.Models.MarketPairs;
using Crypto_Lab.DAL.Extensions.Exchanges;
using Crypto_Lab.DAL.Extensions.MarketPairs;
using Microsoft.EntityFrameworkCore;

namespace Crypto_Lab.DAL.EntityFrameworkCore;

public class CryptoDbContext : DbContext
{
    public DbSet<Exchange> Exchanges { get; set; }
    public DbSet<MarketPair> MarketPairs { get; set; }
    //public DbSet<Symbol> Symbols { get; set; }
    //public DbSet<SymbolDetail> SymbolDetails { get; set; }

    public CryptoDbContext(DbContextOptions<CryptoDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.ConfigureSymbol();
        modelBuilder.ConfigureExchange();
        modelBuilder.ConfigureMarketPair();
    }
}
