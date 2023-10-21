using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace Evolution.Jobs
{
    [BurstCompile]
    public partial struct MoveToDestinationJob : IJobEntity
    {
        public void Execute()
        {
            //Debug.Log("MoveToDestinationJob::Execute");
        }
    }
}
