using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

public readonly partial struct MoveToPositionAspect : IAspect
{
    private const uint Seed = 100;
    
    private readonly RefRW<LocalTransform> _transform;
    private readonly RefRO<Speed> _speed;
    private readonly RefRW<TargetPosition> _targetPosition;
 
    public void Move(float deltaTime, RandomComponent randomComponent)
    {
        var direction = math.normalize(_targetPosition.ValueRO.Value - _transform.ValueRO.Position );
        _transform.ValueRW.Position += direction * _speed.ValueRO.Value * deltaTime;
        
        //TODO: Replace with distanceSq for better performance.
        var distance = math.distance(_transform.ValueRO.Position, _targetPosition.ValueRO.Value);

        const float reachedTargetDistance = 0.5f;
        if (distance < reachedTargetDistance)
        {
            _targetPosition.ValueRW.Value = GetRandomPosition(randomComponent);
        }
    }
    
    private float3 GetRandomPosition(RandomComponent randomComponent)
    {
        var randomPosition =
            new float3(
                randomComponent.RandomGenerator.NextFloat(0f,15f),
                0,
                randomComponent.RandomGenerator.NextFloat(0f,15f)
            );
        
        //Debug.Log("RandomPosition: (" + randomPosition.x + "," + randomPosition.y + "," + randomPosition.z + ")");
        return randomPosition;
    }
}
