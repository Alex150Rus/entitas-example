using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Сущность (Entity) не содержит данных или кода, лишь объединяет набор компонентов. GameObject
public class PlayerEntity : AbstractEntity
{
    public GameObject playerPrefab;
    public float health;

    protected override void Start()
    {
        //вызываем метод из AnstractEntity, который создаст entity и контексты
        base.Start();
        //добавляем в entity компонент Player (к go Добавляем компонент)
        entity.isPlayer = true;
        entity.AddPrefab(playerPrefab);
        //добавляем компонент здоровья AddHealth вместо isHealth = true, так как есть параметр в компоненте
        entity.AddHealth(health);
    }
}
