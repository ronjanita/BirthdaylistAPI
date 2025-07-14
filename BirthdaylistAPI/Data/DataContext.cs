using Microsoft.EntityFrameworkCore;
using BirthdaylistAPI.Models;

namespace BirthdaylistAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Birthdaylist> Birthdaylist { get; set; }
}
