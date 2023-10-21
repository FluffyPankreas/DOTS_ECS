using Unity.Entities;
using UnityEngine;

namespace CodeMonkey
{
    public class PlayerTagAuthoring : MonoBehaviour
    {

    }

    public class PlayerTagBaker : Baker<PlayerTagAuthoring>
    {
        public override void Bake(PlayerTagAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new PlayerTag());
        }
    }
}