using UnityEngine;
using Unity.Entities;
using Random = Unity.Mathematics.Random;

namespace Evolution.Components
{
    public class SpeedAuthoring : MonoBehaviour
    {
        [Tooltip("The lower end of the potential walking speed for the entity.")]
        public float speedLow;
        [Tooltip("The higher end of the potential walking speed for the entity.")]
        public float speedHigh;
    }

    public class SpeedBaker : Baker<SpeedAuthoring>
    {
        public override void Bake(SpeedAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, 
                new SpeedComponent
                {
                    //TODO: Figure out if there is a better way to do this. Ideally in the SpeedAuthoring class.
                    WalkSpeed = UnityEngine.Random.Range(authoring.speedLow,authoring.speedHigh)
                }
            );
        }
    }
}