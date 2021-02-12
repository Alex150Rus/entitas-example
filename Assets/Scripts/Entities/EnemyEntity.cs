using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Сущность (Entity) не содержит данных или кода, лишь объединяет набор компонентов. GameObject
public class EnemyEntity : AbstractEntity
{
    public GameObject prefab;
    public float health;
    public float speed;

    protected override void Start()
    {
        base.Start();
        entity.isEnemy = true;
        entity.AddPrefab(prefab);
        entity.AddHealth(health);
        entity.AddForwardMovement(speed);
    }
}
