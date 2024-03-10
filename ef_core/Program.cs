
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

class Program
{
    static void Main(string[] args)
    {
        var context = new MyDbContext();
        context.AirportArrival.AddRange(
            new AirportArrival { Name = "Paris", stop = 1 },
            new AirportArrival { Name = "Tokyo", stop = 2 },
            new AirportArrival { Name = "Sydney", stop = 3 },
            new AirportArrival { Name = "Vienna", stop = 4 });
        context.AirportDeparture.AddRange(
            new AirportDeparture { Name = "London", stop = 1 },
            new AirportDeparture { Name = "San Francisco", stop = 2 },
            new AirportDeparture { Name = "New York", stop = 3 },
            new AirportDeparture { Name = "Vienna", stop = 4 });
        context.Flight.AddRange(
                   new FlightPlan { DepartureId = 1, ArrivalId = 2, FlightNumber = 1, Cost = 100, FlightTime = 10 },
                    new FlightPlan { DepartureId = 1, ArrivalId = 3, FlightNumber = 2, Cost = 200, FlightTime = 20 },
                    new FlightPlan { DepartureId = 1, ArrivalId = 4, FlightNumber = 3, Cost = 300, FlightTime = 30 },
                    new FlightPlan { DepartureId = 1, ArrivalId = 5, FlightNumber = 4, Cost = 400, FlightTime = 40 },
                    new FlightPlan { DepartureId = 2, ArrivalId = 1, FlightNumber = 5, Cost = 500, FlightTime = 50 },
                    new FlightPlan { DepartureId = 2, ArrivalId = 3, FlightNumber = 6, Cost = 600, FlightTime = 60 },
                    new FlightPlan { DepartureId = 2, ArrivalId = 4, FlightNumber = 7, Cost = 700, FlightTime = 70 },
                    new FlightPlan { DepartureId = 2, ArrivalId = 5, FlightNumber = 8, Cost = 800, FlightTime = 80 },
                    new FlightPlan { DepartureId = 3, ArrivalId = 1, FlightNumber = 9, Cost = 900, FlightTime = 90 },
                    new FlightPlan { DepartureId = 3, ArrivalId = 2, FlightNumber = 10, Cost = 1000, FlightTime = 100 },
                    new FlightPlan { DepartureId = 3, ArrivalId = 4, FlightNumber = 11, Cost = 1100, FlightTime = 110 },
                    new FlightPlan { DepartureId = 3, ArrivalId = 5, FlightNumber = 12, Cost = 1200, FlightTime = 120 },
                    new FlightPlan { DepartureId = 4, ArrivalId = 1, FlightNumber = 13, Cost = 1300, FlightTime = 130 },
                    new FlightPlan { DepartureId = 4, ArrivalId = 2, FlightNumber = 14, Cost = 1400, FlightTime = 10 });
        //delete all data from 3 table departure, arrival and flight
        //context.Database.ExecuteSqlRaw("DELETE FROM AirportDeparture");
        //context.Database.ExecuteSqlRaw("DELETE FROM AirportArrival");
        //context.Database.ExecuteSqlRaw("DELETE FROM Flight");
        context.SaveChanges();

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


public class MyDbContext: DbContext
{
    public DbSet<Family> Family { get; set; }
    public DbSet<AirportDeparture> AirportDeparture { get; set; }
    public DbSet<AirportArrival> AirportArrival { get; set; }
    public DbSet<FlightPlan> Flight { get; set; }
    public MyDbContext()
    {}
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FlightPlan>()
            .HasKey(f => new { f.DepartureId, f.ArrivalId });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=ESDEATH;Database=TestData;Trusted_Connection=True;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }
}
