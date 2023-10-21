using CodeMonkey;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;

[BurstCompile]
public partial struct MovingISystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        // Brute force turn of the system because I don't really understand how this works yet. It messes with scenes it's not supposed to execute in when it's not turned off. 
        state.Enabled = false;
    }
    
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

    public void Execute(CodeMonkey.MoveToPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.Move(DeltaTime);
    }
}

[BurstCompile]
public partial struct TestReachedTargetPositionJob : IJobEntity
{
    [NativeDisableUnsafePtrRestriction] public RefRW<RandomComponent> RandomGenerator;
    public void Execute(CodeMonkey.MoveToPositionAspect moveToPositionAspect)
    {
        moveToPositionAspect.TestReachedTargetPosition(RandomGenerator);
        
    }
}