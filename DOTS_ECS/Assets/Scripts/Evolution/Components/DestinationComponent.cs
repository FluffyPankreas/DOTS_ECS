using Unity.Entities;
using Unity.Mathematics;

namespace Evolution.Components
{
    public struct DestinationComponent : IComponentData
    {
        public float3 Destination;
    }
}