
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

public class MoveSystem : JobComponentSystem
{
	struct Job : IJobParallelFor
	{
		public ComponentDataArray<Position> Positions;
		public ComponentDataArray<Velocity> Velocitys;

		public void Execute(int index)
		{
			Positions[index] = new Position() { Value = Positions[index].Value + Velocitys[index].Value };
		}
	}

	ComponentGroup _group;

	protected override void OnCreateManager()
	{
		_group = GetComponentGroup(
			typeof(Position),
			typeof(Velocity));
	}

	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		return new Job()
		{
			Positions = _group.GetComponentDataArray<Position>(),
			Velocitys = _group.GetComponentDataArray<Velocity>()
		}.Schedule(_group.CalculateLength(), 64, inputDeps);
	}
}
