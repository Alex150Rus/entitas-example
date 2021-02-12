using Entitas;
using UnityEngine;

//компонент, хранящий наш View -  инстанцированный gameObject (представление нашей кодовой сущности в Unity)
public class ViewComponent : IComponent
{
    public GameObject gameObject;
}
