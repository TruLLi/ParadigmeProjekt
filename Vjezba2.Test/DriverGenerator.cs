using Bogus;
using Vjezba2.Models;

//https://github.com/bchavez/Bogus dokumentacija za Bogus Faker klasu

namespace Vjezba2.Test
{
    class DriverGenerator
    {
        public static Faker<Driver> Driver { get; } =
            new Faker<Driver>()
            .StrictMode(true)
            .RuleFor(c => c.Id, f => 0)
            .RuleFor(c => c.Name, f => f.Name.FirstName())
            .RuleFor(c => c.Surname, f => f.Name.LastName())
            .RuleFor(c => c.Money, f => f.Random.Int(100, 2000));
    }
}
