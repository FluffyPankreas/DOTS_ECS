using Unity.Entities;

namespace Evolution.Aspects
{
    public readonly partial struct HerbivoreAspect : IAspect
    {
        private readonly Entity _entity;
        
        private readonly MoveToDestinationAspect _moveToDestinationAspect;
    }
}
