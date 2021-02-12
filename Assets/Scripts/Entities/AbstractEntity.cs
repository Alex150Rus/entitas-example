using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

//—ущность (Entity) не содержит данных или кода, лишь объедин€ет набор компонентов. GameObject
public abstract class AbstractEntity : MonoBehaviour
{
    protected Contexts contexts { get; private set; }
    protected GameEntity entity { get; private set; }

    protected virtual void Start()
    {
        //—оздаЄм новый экземпл€р контекстов
        contexts = Contexts.sharedInstance;
        //—оздаЄт новую сущность - пустой gameObject без единого компонента (даже трансформа нет)
        entity = contexts.game.CreateEntity();
        entity.AddPosition(transform.position);
        entity.AddRotation(transform.rotation.eulerAngles.z);
        //удал€ем GO в сцене, так как он временный, дл€ настройки игры. —уществует до того момента,
        //как мы создадим настойший entity в ECS
        Destroy(gameObject);
    }
}
