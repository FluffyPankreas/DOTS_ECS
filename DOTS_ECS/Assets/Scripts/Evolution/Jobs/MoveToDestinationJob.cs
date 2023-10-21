using Evolution.Aspects;
using Unity.Burst;
using Unity.Entities;

namespace Evolution.Jobs
{
    [BurstCompile]
    public partial struct MoveToDestinationJob : IJobEntity
    {
        public float DeltaTime;
        public void Execute(MoveToDestinationAspect moveToDestinationAspect)
        {
            //Debug.Log("MoveToDestinationJob::Execute");
            moveToDestinationAspect.Walk(DeltaTime);
        }
    }
}
