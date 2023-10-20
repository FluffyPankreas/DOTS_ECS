using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach(
            (ref LocalTransform t, in Speed s) =>
            {
                t.Position += new float3(SystemAPI.Time.DeltaTime * s.Value, 0, 0);
            }).Schedule();
                //.Run(): Runs the code on the main thread.
                //.Schedule(): Runs the code in a single worker thread.
                //.ScheduleParallel(): Runs the code on multiple worker threads.
    }
}
