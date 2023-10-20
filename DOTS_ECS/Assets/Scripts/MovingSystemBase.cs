using Unity.Entities;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach(
            (MoveToPositionAspect moveTo) =>
            {
                moveTo.Move(SystemAPI.Time.DeltaTime);
            }).Schedule();
    }
}
