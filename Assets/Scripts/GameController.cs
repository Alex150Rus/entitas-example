using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    //класс дл€ управлени€ системами: запуск в нужном пор€дке, каждый кадр или на какие-то событи€
    Systems systems;
    public GameObject shotPrefab;

    void Awake()
    {
        //—оздаЄм новый экземпл€р контекстов
        var contexts = Contexts.sharedInstance;

        contexts.game.SetGlobals(shotPrefab);

        systems = new Systems();
        //добавл€ем системы в класс управлени€ системами
        systems.Add(new DeathSystem(contexts));
        systems.Add(new PrefabInstantiateSystem(contexts));
        systems.Add(new ViewDestroySystem(contexts));
        systems.Add(new PlayerInputSystem(contexts));
        systems.Add(new ForwardMovementSystem(contexts));
        systems.Add(new ShotCollisionSystem(contexts));
        systems.Add(new TransformApplySystem(contexts));
        //инициализируем системы. »менно в этот момент происходит вызов 1InitializeSystem
        systems.Initialize();
    }

    void OnDestroy()
    {
        //системы чист€т ресурсы, которые используют
        systems.TearDown();
    }

    void Update()
    {
        //вызов всех рабочих методов систем: обычных и реактивных.
        systems.Execute();
        systems.Cleanup();
    }
}
