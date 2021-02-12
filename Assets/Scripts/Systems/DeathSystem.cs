using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;


//Весь код содержится в системах (Systems), оперирующих некторым набором сущностей на основе 
//наличия или отсутствия в них каких-либо компонентов

//Убивает сущности, когда их здоровье достигло нуля
public class DeathSystem : IExecuteSystem
{
    //получаем из конструктора набор entities, которыми будем оперировать
    IGroup<GameEntity> entities;
    List<Entity> deadEntities = new List<Entity>();

    //конструктор
    public DeathSystem(Contexts contexts)
    {
        //у контекста game просим группу сущностей, у которых есть компонент Health;
        entities = contexts.game.GetGroup(GameMatcher.Health);
    }

    //вызывается каждый кадр. Аналог апдэйта в юнити компонентах, но здесь мы не находимся в классе компонента
    //и не оперируем его полями.  
    public void Execute()
    {
        //переиспользуется таже память у листа. Она не будет каждый кадр выделяться, а потом освобождаться
        deadEntities.Clear();

        //проходимся по группе сущностей с компонетом Health
        foreach (var e in entities) {
            if (e.health.value <= 0)
                //мы не можем здесь применить e.Destroy(), так как возникнет ошибка (мы удаляем элемент из группы,
                //по которой итерируемся)
                deadEntities.Add(e);
        }

        foreach (var e in deadEntities)
            //полностью уничтожает сущность и освобождает занимаемую ей память
            e.Destroy();
    }
}
