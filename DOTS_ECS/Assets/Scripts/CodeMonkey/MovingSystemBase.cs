using Unity.Entities;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        var randomGenerator = SystemAPI.GetSingletonRW<RandomComponent>();
        
        Entities.ForEach(
            (MoveToPositionAspect moveTo) =>
            {
                moveTo.Move(SystemAPI.Time.DeltaTime);
            }).Run();
    }

    
    
}