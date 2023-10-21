using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Evolution.Components
{
    public class DestinationAuthoring : MonoBehaviour
    {
        public float3 destination;
    }

    public class DestinationBaker : Baker<DestinationAuthoring>
    {
        public override void Bake(DestinationAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity,new DestinationComponent
            {
                Destination = authoring.destination 
            });
        }
    }
}