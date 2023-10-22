using Evolution.Components;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace Evolution.Aspects
{
    public readonly partial struct MoveToDestinationAspect : IAspect
    {
        private readonly Entity _entity;
        
        private readonly RefRW<LocalTransform> _localTransform;
        private readonly RefRO<SpeedComponent> _speed;
        public readonly RefRW<DestinationComponent> Destination;

        public void Walk(float deltaTime)
        {
            var direction = math.normalize(Destination.ValueRO.Destination - _localTransform.ValueRO.Position);
            _localTransform.ValueRW.Position += direction * _speed.ValueRO.WalkSpeed * deltaTime;
        }
    }
}
