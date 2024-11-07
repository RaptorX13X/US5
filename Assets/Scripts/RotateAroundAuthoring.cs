using UnityEngine;
using Unity.Entities;

public class RotateAroundAuthoring : MonoBehaviour
{
    public float speed;
    public class Baker : Baker<RotateAroundAuthoring>
    {
        public override void Bake(RotateAroundAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new RotateAroundComponent(authoring.speed));
        }
    }
}
