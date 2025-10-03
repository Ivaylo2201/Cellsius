using Infrastructure.Utilities;

namespace Infrastructure.Database.Seed;

public class Seeder(DatabaseContext context)
{
    public async Task Run()
    {
        ColorConsole.WriteLine("Seeding database...");
        
        await Clear();
        await Seed();
        
        ColorConsole.WriteLine("Seeding complete.");
    }

    private async Task Clear()
    {
        ColorConsole.WriteLine("Truncating tables...", ConsoleColor.Red);
        
        await context.SaveChangesAsync();
    }

    private async Task Seed()
    {
        await context.SaveChangesAsync();
    }
}