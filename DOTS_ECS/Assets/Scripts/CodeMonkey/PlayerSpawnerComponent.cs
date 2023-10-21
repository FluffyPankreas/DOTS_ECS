using Unity.Entities;

namespace CodeMonkey
{
    public struct PlayerSpawnerComponent : IComponentData
    {
        public Entity PlayerPrefab;
    }
}
