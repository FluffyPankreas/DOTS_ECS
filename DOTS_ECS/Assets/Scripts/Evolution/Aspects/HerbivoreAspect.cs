using Unity.Entities;

namespace Evolution.Aspects
{
    public readonly partial struct HerbivoreAspect : IAspect
    {
        private readonly Entity _entity;
        
        private readonly MoveToDestinationAspect _moveToDestinationAspect;

        public void FindFood()
        {
            //TODO: Implement the code to set the destination with a found food source. 
        }
    }
}
