using Bogus;

namespace TournamentPulse.Infrastructure.Data.Generator
{
    public class DataGenerator
    {
        Faker<FighterRecordModel> fighterRecordModelFake;

        public DataGenerator()
        {
            //Randomizer.Seed = new Random(123); For generating the same data again
            Randomizer.Seed = new Random();

            //fighterRecordModelFake = new Faker<FighterRecordModel>()
            //    .RuleFor(f => f.FullName, fk => fk.Name.FullName())
            //    .RuleFor(f => f.Age, fk => fk.Random.Int(18, 60))
            //    .RuleFor(f => f.Weight, fk => fk.Random.Float(50, 100))
            //    .RuleFor(f => f.Rank, fk => fk.PickRandom<Rank>())
            //    .RuleFor(f => f.AcademyId, fk => fk.Random.Int(1, 2));

            fighterRecordModelFake = new Faker<FighterRecordModel>()
    .RuleFor(f => f.FullName, fk => fk.Name.FullName())
    .RuleFor(f => f.Age, fk => fk.Random.Int(18, 25))
    .RuleFor(f => f.Weight, fk => fk.Random.Float(70, 72))
    .RuleFor(f => f.Rank, fk => fk.PickRandom<Rank>())
    .RuleFor(f => f.AcademyId, fk => fk.Random.Int(1, 2));
        }

        public FighterRecordModel GenerateFighter() //Generate 1
        {
            return fighterRecordModelFake.Generate();
        }

        public IEnumerable<FighterRecordModel> GenerateFighters() //Generate Many
        {
            return fighterRecordModelFake.GenerateForever();
        }
    }
}
