using Unity.Burst;
using Unity.Entities;
using Evolution.Jobs;

namespace Evolution.Systems
{
    [BurstCompile]
    public partial struct HerbivoreAgencySystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            new FindFoodJob
            {
            }.ScheduleParallel();
        }
    }
}
