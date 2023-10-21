using Unity.Entities;

namespace CodeMonkey
{
    public partial class MovingSystemBase : SystemBase
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            // Brute force turn of the system because I don't really understand how this works yet. It messes with scenes it's not supposed to execute in when it's not turned off.
            this.Enabled = false;
        }

        protected override void OnUpdate()
        {
            var randomGenerator = SystemAPI.GetSingletonRW<RandomComponent>();
        
            Entities.ForEach(
                (CodeMonkey.MoveToPositionAspect moveTo) =>
                {
                    moveTo.Move(SystemAPI.Time.DeltaTime);
                }).Run();
        }
    }
}