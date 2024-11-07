using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject Prefab;
    public float amountToSpawn;
    public Vector3 basePosition;
    private class Baker : Baker<SpawnerAuthoring>
    {
        public override void Bake(SpawnerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            var p = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic);
            AddComponent(entity, new SpawnerComponent
            {
                Prefab = p,
                amountToSpawn = authoring.amountToSpawn,
                basePosition = authoring.basePosition,
            });
        }
    }
}

public struct SpawnerComponent : IComponentData
{
    public Entity Prefab;
    public float amountToSpawn;
    public float3 basePosition;
}
