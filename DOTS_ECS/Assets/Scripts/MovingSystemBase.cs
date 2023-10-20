using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach(
            (ref LocalTransform t, in Speed s, in TargetPosition p) =>
            {
                var direction = math.normalize(p.Value - t.Position);
                t.Position += direction * s.Value * SystemAPI.Time.DeltaTime;
            }).Schedule();
                //.Run(): Runs the code on the main thread.
                //.Schedule(): Runs the code in a single worker thread.
                //.ScheduleParallel(): Runs the code on multiple worker threads.
    }
}
