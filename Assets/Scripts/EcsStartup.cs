using Leopotam.Ecs;
using UnityEngine;
using Systems;
using Components;
using System.Collections.Generic;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;

        public Configuration Configuration;
        public SceneData SceneData;

        private Dictionary<string, int> systemNameIndexMap = new Dictionary<string, int>();
        private void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            var gameState = new GameState();
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add(new InitializeFieldSystem())
                .Add(new CreateCellViewSystem())
                .Add(new SetCameraSystem())

                .Add(new ConstrolSystem(), nameof(ConstrolSystem))
                .Add(new AnalyzeClickSystem())
                .Add(new CreateTakenViewSystem())

                .Add(new CheckWinSystem())
                .Add(new DrawWinLineSystem())
                
                .Add(new PlayAgainSystem())

                .Add(new ShowPanelSystem())
                .Add(new SetWinTextSystem())
                .OneFrame<UpdateCameraEvent>()
                .OneFrame<Clicked>()
                .OneFrame<CheckWinEvent>()
                .OneFrame<ShowPanelEvent>()
                .OneFrame<SetWinTextEvent>()
                .Inject(Configuration)
                .Inject(SceneData)
                .Inject(gameState)
                .Init();
        }

        void Update () {
            _systems?.Run();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }

        public void SetRunSystemState(string name, bool state)
        {
            var idx = _systems.GetNamedRunSystem(name);
            _systems.SetRunSystemState(idx, state);
        }
    }
}