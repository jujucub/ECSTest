
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;

public class DeadTimeSystem : JobComponentSystem
{
	struct Job : IJobProcessComponentDataWithEntity<DeadTime>
	{
		public float DeltaTime;
		public EntityCommandBuffer Commands;
		public void Execute(Entity entity, int index, ref DeadTime deadTime)
		{
			deadTime = new DeadTime() { Time = deadTime.Time, Now = deadTime.Now + DeltaTime };
			if (deadTime.Now > deadTime.Time)
			{
				Commands.DestroyEntity(entity);
			}
		}
	}

	[Inject] EndFrameBarrier _endFrameBarrier;

	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		return new Job
		{
			DeltaTime = Time.deltaTime,
			Commands = _endFrameBarrier.CreateCommandBuffer()
		}.ScheduleSingle(this, inputDeps);
	}
}
