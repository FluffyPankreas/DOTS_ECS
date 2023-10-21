using Unity.Entities;
using UnityEngine;

namespace CodeMonkey
{
    public class SpeedAuthoring : MonoBehaviour
    {
        public float value;
    }

    public class SpeedBaker : Baker<SpeedAuthoring>
    {
        public override void Bake(SpeedAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity,
                new Speed { Value = authoring.value }
            );
        }
    }
}