
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

public class Spawner : MonoBehaviour
{
	[SerializeField]
	MeshInstanceRenderer _meshInstanceRenderer;

	[SerializeField]
	int _count = 10;

	private void Update()
	{
		if(Input.anyKey)
		{
			var entityManager = World.Active.GetOrCreateManager<EntityManager>();
			var archetype = entityManager.CreateArchetype(typeof(Position), typeof(Velocity), typeof(DeadTime));

			for (int i = 0;i < _count; ++i)
			{
				var entity = entityManager.CreateEntity(archetype);
				entityManager.SetComponentData(entity, new Velocity()
				{
					Value = new float3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f))
				});
				entityManager.SetComponentData(entity, new DeadTime() { Time = float.MaxValue, Now = 0 });
				entityManager.AddSharedComponentData(entity, _meshInstanceRenderer);
			}
		}
	}
}

