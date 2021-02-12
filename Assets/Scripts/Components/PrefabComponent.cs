using UnityEngine;
using Entitas;

//в этом компоненте при создании entity мы сможем указать какой prefab она должна использовать
//для создания GO
public class PrefabComponent : IComponent
{
    public GameObject prefab;
}
