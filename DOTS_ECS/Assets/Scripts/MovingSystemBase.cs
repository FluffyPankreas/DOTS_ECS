using Unity.Entities;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        //TODO: Fix this to pass by reference instead of passing by value/copy. SystemAPI.GetSingletonRW<>() is required. 
        var randomGenerator = SystemAPI.GetSingleton<RandomComponent>();
        
        
        Entities.ForEach(
            (MoveToPositionAspect moveTo) =>
            {
                moveTo.Move(SystemAPI.Time.DeltaTime,randomGenerator);
            }).Schedule();
        
    }
}