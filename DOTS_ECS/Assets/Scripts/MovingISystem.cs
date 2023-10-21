using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;

[BurstCompile]
public partial struct MovingISystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var randomGenerator = SystemAPI.GetSingletonRW<RandomComponent>();

        JobHandle moveJobHandle = new MoveJob {
            DeltaTime = SystemAPI.Time.DeltaTime
            }.ScheduleParallel(state.Dependency);

        moveJobHandle.Complete();
        
        new TestReachedTargetPositionJob {
            RandomGenerator    = randomGenerator
            }.Run();
    }
}

[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float DeltaTime;

    public void Execute(MoveToPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.Move(DeltaTime);
    }
}

[BurstCompile]
public partial struct TestReachedTargetPositionJob : IJobEntity
{
    [NativeDisableUnsafePtrRestriction] public RefRW<RandomComponent> RandomGenerator;
    public void Execute(MoveToPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.TestReachedTargetPosition(RandomGenerator);
        
    }
}