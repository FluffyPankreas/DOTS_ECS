using Unity.Entities;
using UnityEngine;

namespace Evolution.Components
{
    public class FoodSourceAuthoring : MonoBehaviour
    {
        [Tooltip("The amount of nourishment this food source can provide.")]
        public float nourishment;
    }

    public class FoodBaker : Baker<FoodSourceAuthoring>
    {
        public override void Bake(FoodSourceAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new FoodSourceComponent
            {
                Nourishment = authoring.nourishment
            });
        }
    }
}
