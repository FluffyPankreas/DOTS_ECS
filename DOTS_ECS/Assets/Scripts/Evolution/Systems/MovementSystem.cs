using Unity.Burst;
using Unity.Entities;
using Evolution.Jobs;

namespace Evolution.Systems
{
    [BurstCompile]
    public partial struct MovementSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            new MoveToDestinationJob
            {
                DeltaTime = SystemAPI.Time.DeltaTime
            }.ScheduleParallel();
        }
    }
}