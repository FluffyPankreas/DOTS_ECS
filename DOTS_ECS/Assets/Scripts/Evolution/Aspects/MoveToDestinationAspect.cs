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
        private readonly RefRO<DestinationComponent> _destination;

        public void Walk(float deltaTime)
        {
            var direction = math.normalize(_destination.ValueRO.Destination - _localTransform.ValueRO.Position);
            _localTransform.ValueRW.Position += direction * _speed.ValueRO.WalkSpeed * deltaTime;
        }
    }
}
