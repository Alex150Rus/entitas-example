using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

//компонент, хран€щий глобальные значени€. Unique означает, что этот компонент может существовать только в единственном экземпл€ре
//“.е. он не будет компонентом на конкретной Entity, он будет компонентом на контексте и мы сможем получить к нему доступ из
//любого места, где у нас есть доступ к контексту, но при этом мы не сможем создать несколько экземпл€ров такого компонента
[Unique]
public class GlobalsComponent : IComponent
{
    public GameObject shotPrefab;
}
