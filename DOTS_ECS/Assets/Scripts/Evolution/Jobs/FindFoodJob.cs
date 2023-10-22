using Evolution.Aspects;
using Unity.Entities;
using UnityEngine;

namespace Evolution.Jobs
{
    public partial struct FindFoodJob : IJobEntity
    {

        public void Execute(HerbivoreAspect herbivoreAspect)
        {
            //Debug.Log("FindFoodJob::Execute");
            herbivoreAspect.FindFood();
        }
    }
}
