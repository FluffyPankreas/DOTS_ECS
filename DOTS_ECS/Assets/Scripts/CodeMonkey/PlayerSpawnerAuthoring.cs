using CodeMonkey;
using UnityEngine;
using Unity.Entities;
using UnityEngine.Serialization;

public class PlayerSpawnerAuthoring : MonoBehaviour
{
    public GameObject playerPrefab;
}

public class PlayerSpawnerBaker : Baker<PlayerSpawnerAuthoring>
{
    public override void Bake(PlayerSpawnerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity,
            new PlayerSpawnerComponent
            {
                PlayerPrefab = GetEntity(authoring.playerPrefab,TransformUsageFlags.Dynamic)  
            });

    }
}
