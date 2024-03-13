
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

class Program
{
    static void Main(string[] args)
    {
        var context = new MyDbContext();
        

    }
}

public class Family
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? ParentId { get; set; }
}

public class AirportDeparture
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? stop { get; set; }
    public ICollection<FlightPlan>? Flights { get; set; }
}

public class AirportArrival
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? stop { get; set; }

    public ICollection<FlightPlan>? Flights { get; set; }
}

public class FlightPlan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DepartureId { get; set; } 
    public int FlightNumber { get; set; }
    public double Cost { get; set; }
    public double FlightTime { get; set; }
    public AirportDeparture? Departure { get; set; } 
    public int ArrivalId { get; set; } 
    public AirportArrival? Arrival { get; set; }
}


public class DataLog2
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public double? Value { get; set; }
    public int SourceID { get; set; }
    public int QuantityID { get; set; }

    // Navigation properties
    public Source? Source { get; set; }
    public Quantity? Quantity { get; set; }
}

public class Source
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SourceID { get; set; }

    // Other properties...

    // Navigation property
    public ICollection<DataLog2>? DataLog2s { get; set; }
}

public class Quantity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int QuantityID { get; set; }

    // Other properties...

    // Navigation property
    public ICollection<DataLog2>? DataLog2s { get; set; }
}


public class MyDbContext: DbContext
{
    public DbSet<Family> Family { get; set; }
    public DbSet<AirportDeparture> AirportDeparture { get; set; }
    public DbSet<AirportArrival> AirportArrival { get; set; }
    public DbSet<FlightPlan> Flight { get; set; }
    public DbSet<Source> Sources { get; set; }
    public DbSet<Quantity> Quantities { get; set; }
    public DbSet<DataLog2> DataLog2 { get; set; }

    
    public MyDbContext()
    {}
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataLog2>()
            .HasOne(p => p.Source)
            .WithMany()
            .HasForeignKey(p => p.SourceID);

        modelBuilder.Entity<DataLog2>()
            .HasOne(p => p.Quantity)
            .WithMany()
            .HasForeignKey(p => p.QuantityID);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=ESDEATH;Database=TestData;Trusted_Connection=True;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }
}
