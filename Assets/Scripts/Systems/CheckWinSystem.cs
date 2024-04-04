using Components;
using Leopotam.Ecs;
using UnityEngine;
using Extensions;

namespace Systems
{
    internal class CheckWinSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private GameState _gameState;
        private Configuration _configuration;

        private EcsFilter<Position, Taken, CheckWinEvent> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get1(index);
                ref var type = ref _filter.Get2(index);

                var chain = _gameState.Cells.GetLongestChain(position.Value);
                if (chain.Length >= _configuration.ChainLength)
                {
                    ref var entity = ref _filter.GetEntity(index);
                    entity.Get<Winner>();
                    entity.Get<WinChain>().Direction = chain.Direction;
                    Vector2Int currentPosition = position.Value;
                    for (int i = 0; i < chain.Length - 1; i++)
                    {
                        currentPosition += chain.Direction;
                        EcsEntity nextEntity = _gameState.Cells[currentPosition];
                        nextEntity.Get<WinChain>().Direction = chain.Direction;
                    }

                    entity.Get<ShowPanelEvent>().PanelType = PanelType.Win;
                    _world.NewEntity().Get<DisableControlSystemEvent>();
                    break;
                }
            }
        }
    }
}
