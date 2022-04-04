using System.Diagnostics;
using Algorithms.DesignPatterns.CreationalPatterns.Factory;

namespace Algorithms.DesignPatterns.CreationalPatterns.Factory
{
    public class AbilityFactory : AssemblyFactoryBase<Ability>
    {
        public AbilityFactory()
        {
            Debug.WriteLine("creating factory");
            base.Initialize(nameof(NullableAbility));
        }
    }
}
