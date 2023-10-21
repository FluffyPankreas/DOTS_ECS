using Unity.Entities;
using UnityEngine;

namespace CodeMonkey
{
    public class RandomAuthoring : MonoBehaviour
    {
        [Tooltip("The seed to initialized the randomizer with.")]
        public uint seed = 1;
    }

    public class RandomBaker : Baker<RandomAuthoring>
    {
        public override void Bake(RandomAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity,
                new RandomComponent
                {
                    RandomGenerator = new Unity.Mathematics.Random(authoring.seed)
                }
            );
        }
    }
}