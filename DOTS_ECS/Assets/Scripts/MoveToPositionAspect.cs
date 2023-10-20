using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct MoveToPositionAspect : IAspect
{
    private readonly Entity _entity;//This is an optional field.
    
    private readonly RefRO<LocalTransform> _transform;
    private readonly RefRO<Speed> _speed;
    private readonly RefRW<TargetPosition> _targetPosition;
}
