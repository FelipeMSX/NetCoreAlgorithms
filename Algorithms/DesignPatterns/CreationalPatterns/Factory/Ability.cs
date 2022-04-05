namespace Algorithms.DesignPatterns.CreationalPatterns.Factory
{
    public abstract class Ability
    {
        public abstract string Name { get;set; }

        public abstract string CreateMessage();
    }

    public class FireAbility : Ability
    {
        public override string Name { get; set; } = "Fire";

        public override string CreateMessage() => "Does 1 damage.";
    }

    public class PoisonAbility : Ability
    {
        public override string Name { get; set; } = "Poison";

        public override string CreateMessage() => "does 1 damage over time during 5 seconds.";
    }

    public class ExplosionAbility : Ability
    {
        public override string Name { get; set; } = "Explosion";

        public override string CreateMessage() => "does 1 damage in a big radius.";
    }

    //Null Object Pattern
    public class NullableAbility : Ability
    {
        public override string Name { get; set; } = "Nullable";

        public override string CreateMessage() => "does nothing.";
    }
}
