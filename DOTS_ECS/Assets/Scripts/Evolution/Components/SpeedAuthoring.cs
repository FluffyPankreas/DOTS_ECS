using UnityEngine;
using Unity.Entities;

namespace Evolution.Components
{
    public class SpeedAuthoring : MonoBehaviour
    {
        [SerializeField,Tooltip("The lower end of the potential walking speed for the entity.")]
        private float speedLow;
        [SerializeField,Tooltip("The higher end of the potential walking speed for the entity.")]
        private float speedHigh;

        public float WalkSpeed { get; private set; }

        public void Awake()
        {
            WalkSpeed = UnityEngine.Random.Range(speedLow, speedHigh);
        }
    }

    public class SpeedBaker : Baker<SpeedAuthoring>
    {
        public override void Bake(SpeedAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, 
                new SpeedComponent
                {
                    WalkSpeed = authoring.WalkSpeed
                }
            );
        }
    }
}