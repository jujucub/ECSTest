using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSpawner : MonoBehaviour
{
	[SerializeField]
	NormalMoveComponent _prefab;

	[SerializeField]
	int _count;

	[SerializeField]
	int _totalCount;

	private void Update()
	{
		if(Input.anyKey)
		{
			for(int i = 0;i < _count; ++i)
			{
				var normalMoveComponent = Instantiate(_prefab);
				normalMoveComponent.Velocity = new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f));
				_totalCount++;
			}
		}
	}
}
