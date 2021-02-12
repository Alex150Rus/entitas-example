using Entitas;
using System.Collections.Generic;
using UnityEngine;

//система для перекидования в GO значений угла поворота и положения в пространстве нашеё сущности.
//тоже реактивная система, так как нам нужно работать лишь с теми сущностями, которые поменялись
public class TransformApplySystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;

    public TransformApplySystem(Contexts contexts)
        : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        //просим реагировать на ситуацию, когда у нас меняется (либо Position, либо Rotation) Или View
        //можно писать более сложные коллекторы, которые реагируют на добавление одного компонента и удаление другого
        //(т.е. можно смешивать условия.)
        return new Collector<GameEntity>(
            new [] {
                context.GetGroup(GameMatcher.AnyOf(GameMatcher.Position, GameMatcher.Rotation)),
                context.GetGroup(GameMatcher.View),
            }, new [] {
                //можно писать .Removed, AddedOrRemoved
                GroupEvent.Added,
                GroupEvent.Added,
            }
        );
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities) {
            //берём у GO transform
            var t = e.view.gameObject.transform;
            if (e.hasPosition)
                t.position = e.position.value;
            if (e.hasRotation)
                t.rotation = Quaternion.Euler(0.0f, 0.0f, e.rotation.angle);
        }
    }
}
