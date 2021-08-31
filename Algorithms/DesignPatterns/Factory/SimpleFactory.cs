using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Algorithms.DesignPatterns.Factory
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

    //Assembly load to remove the switch in the factory.
    public static class SimpleFactory
    {
        private static Dictionary<string, Type> _abilities;

        private static bool IsInitialized => _abilities != null;

        public static void Initialize()
        {
            if (IsInitialized)
                return;
            
            var abilitiesTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes()
                .Where(abilityType => abilityType.IsClass && !abilityType.IsAbstract && abilityType.IsSubclassOf(typeof(Ability)));

            _abilities = new Dictionary<string, Type>();

            foreach (Type type in abilitiesTypes)
            {
                Ability ability = Activator.CreateInstance(type) as Ability;
                _abilities.Add(ability.Name, type);
            }

        }

        public static Ability CreateInstance(string abilityType)
        {
            return _abilities.ContainsKey(abilityType) ?
                CreateType(abilityType) : CreateType("Nullable");
        }

        private static Ability CreateType(string key)
        {
            Type type = _abilities[key];
            Ability ability = Activator.CreateInstance(type) as Ability;
            return ability;
        }
    }

}
