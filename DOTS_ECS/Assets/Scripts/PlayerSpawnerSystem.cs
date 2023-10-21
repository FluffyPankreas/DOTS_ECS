using Unity.Entities;

public partial class PlayerSpawnerSystem : SystemBase
{
    private int _spawnAmount = 20;
    protected override void OnUpdate()
    {
        var entityQuery = EntityManager.CreateEntityQuery(typeof(PlayerTag));
        var randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

        var entityCommandBuffer = 
            SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
            .CreateCommandBuffer(World.Unmanaged);
        
        
        var playerSpawnerComponent = SystemAPI.GetSingleton<PlayerSpawnerComponent>();
        if (entityQuery.CalculateEntityCount() < _spawnAmount)
        {
            var spawnedEntity = entityCommandBuffer.Instantiate(playerSpawnerComponent.PlayerPrefab);
            entityCommandBuffer.SetComponent(spawnedEntity, new Speed
            {
                Value = randomComponent.ValueRW.RandomGenerator.NextFloat(2f,5f)
            });
        }
    }
}
