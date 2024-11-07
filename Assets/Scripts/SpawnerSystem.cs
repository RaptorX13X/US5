using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct SpawnerSystem : ISystem
{
    private Entity _spawnerEntity;
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        if (_spawnerEntity == Entity.Null) return;
        if (!SystemAPI.TryGetSingletonEntity<SpawnerComponent>(out Entity spawnerEntity)) return;
        
        _spawnerEntity = spawnerEntity;
        var spawnerComponent = SystemAPI.GetComponentRO<SpawnerComponent>(spawnerEntity);
        EntityCommandBuffer commandBuffer = new EntityCommandBuffer(Allocator.Temp);

        for (int z = 0; z < spawnerComponent.ValueRO.amountToSpawn/2; z++)
        {
            for (int x = 0; x < spawnerComponent.ValueRO.amountToSpawn/2; x++)
            {
                Entity newEntity = commandBuffer.Instantiate(spawnerComponent.ValueRO.Prefab);
                commandBuffer.SetComponent(newEntity, new LocalTransform()
                {
                    Position = new float3(spawnerComponent.ValueRO.basePosition.x + x, 
                        spawnerComponent.ValueRO.basePosition.y,
                        spawnerComponent.ValueRO.basePosition.z + z),
                    Rotation = quaternion.identity,
                    Scale = 0.5f
                });
                //commandBuffer.AddComponent(newEntity, new RotateAroundComponent());
            }
        }
        
        
        commandBuffer.Playback(state.EntityManager);
    }
}
