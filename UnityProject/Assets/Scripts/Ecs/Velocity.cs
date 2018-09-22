
using Unity.Entities;
using Unity.Mathematics;

[System.Serializable]
public struct Velocity : IComponentData
{
	public float3 Value;
}
