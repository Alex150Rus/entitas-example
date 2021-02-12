using Entitas;
using System.Collections.Generic;
using UnityEngine;

//система реализует движение вперёд
public class ForwardMovementSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;

    public ForwardMovementSystem(Contexts contexts)
    {
        //сущности, у которых есть все 3 компонента. Если одного из них нет, то система не будет обрабатывать эту сущность
        entities = contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.ForwardMovement,
            GameMatcher.Position,
            GameMatcher.Rotation));
    }

    public void Execute()
    {
        foreach (var e in entities) {
            var angle = e.rotation.angle * Mathf.Deg2Rad;
            //направление движения
            var dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            //ReplacePosition делает Remove а потом Add Position
            e.ReplacePosition(e.position.value + dir * e.forwardMovement.speed * Time.deltaTime);
        }
    }
}
