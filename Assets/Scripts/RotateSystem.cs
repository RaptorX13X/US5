using Unity.Entities;
using Unity.Transforms;

public partial struct RotateSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach ((RefRW<LocalTransform> localTransform, RefRO<RotateAroundComponent> rotateAround) 
                 in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateAroundComponent>>())
        {
            localTransform.ValueRW =
                localTransform.ValueRW.RotateY(rotateAround.ValueRO.Speed * SystemAPI.Time.DeltaTime);
        }
    }
}
