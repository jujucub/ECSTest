
using UnityEngine;

public class NormalMoveComponent : MonoBehaviour
{
	[SerializeField]
	Vector3 _velocity;
	public Vector3 Velocity { get { return _velocity; } set { _velocity = value; } }

	private void Update()
	{
		transform.position += _velocity;
	}
}
