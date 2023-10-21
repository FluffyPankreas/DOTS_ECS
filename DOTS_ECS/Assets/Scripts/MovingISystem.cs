using Unity.Entities;

public partial struct MovingISystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var randomGenerator = SystemAPI.GetSingletonRW<RandomComponent>();

        foreach (var moveToPositionAspect in SystemAPI.Query<MoveToPositionAspect>())
        {
            moveToPositionAspect.Move(SystemAPI.Time.DeltaTime, randomGenerator);
        }
    }
}
