using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

public readonly partial struct MoveToPositionAspect : IAspect
{
    private readonly Entity _entity;//This is an optional field.
    
    private readonly RefRW<LocalTransform> _transform;
    private readonly RefRO<Speed> _speed;
    private readonly RefRO<TargetPosition> _targetPosition;
 
    public void Move(float deltaTime)
    {
        var direction = math.normalize(_targetPosition.ValueRO.Value - _transform.ValueRO.Position );
        _transform.ValueRW.Position += direction * _speed.ValueRO.Value * deltaTime;
    }
}
