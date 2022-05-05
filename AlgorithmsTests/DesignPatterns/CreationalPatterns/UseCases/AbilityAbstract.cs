using Algorithms.DesignPatterns.CreationalPatterns.Factory;

namespace AlgorithmsTests.DesignPatterns.CreationalPatterns.UseCases
{
    public abstract class AbilityAbstract
    {
        public abstract string Name { get; set; }

        public abstract string CreateMessage();
    }

    public class FireAbility : AbilityAbstract
    {
        public override string Name { get; set; } = "Fire";

        public override string CreateMessage() => "Does 1 damage.";
    }

    public class PoisonAbility : AbilityAbstract
    {
        public override string Name { get; set; } = "Poison";

        public override string CreateMessage() => "does 1 damage over time during 5 seconds.";
    }

    public class ExplosionAbility : AbilityAbstract
    {
        public override string Name { get; set; } = "Explosion";

        public override string CreateMessage() => "does 1 damage in a big radius.";
    }

    //Null Object Pattern
    public class NullableAbility : AbilityAbstract
    {
        public override string Name { get; set; } = "Nullable";

        public override string CreateMessage() => "does nothing.";
    }

    public class AbilityFactory : AssemblyCachedFactoryBase<AbilityAbstract>
    {
    }

}
