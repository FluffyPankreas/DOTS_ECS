using Unity.Entities;
using Unity.Mathematics;

namespace CodeMonkey
{
    public struct TargetPosition : IComponentData
    {
        public float3 Value;
    }
}
