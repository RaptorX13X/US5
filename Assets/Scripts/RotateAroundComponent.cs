using Unity.Entities;

public struct RotateAroundComponent : IComponentData
{
    public float Speed;

    public RotateAroundComponent(float speed)
    {
        Speed = speed;
    }
}
