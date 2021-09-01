using Algorithms.DesignPatterns.CreationalPatterns.Factory;

namespace Algorithms.DesignPatterns.CreationalPatterns.Factory
{
    public class AbilityFactory : AssemblyFactoryBase<Ability>
    {
        public AbilityFactory()
        {
            base.Initialize(nameof(NullableAbility));
        }
    }
}
