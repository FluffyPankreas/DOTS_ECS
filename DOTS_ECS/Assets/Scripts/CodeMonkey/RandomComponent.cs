using Unity.Entities;
using Unity.Mathematics;

namespace CodeMonkey
{
   public struct RandomComponent : IComponentData
   {
      public Random RandomGenerator;
   }
}
