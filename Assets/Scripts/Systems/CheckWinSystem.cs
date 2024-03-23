using Components;
using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    internal class CheckWinSystem : IEcsRunSystem
    {
        private EcsFilter<Position, Taken, CheckWinEvent> _filter;
        private GameState _gameState;
        private Configuration _configuration;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get1(index);
                ref var type = ref _filter.Get2(index);

                var chainLength = _gameState.Cells.GetLongestChain(position.Value);
                if (chainLength >= _configuration.ChainLength)
                {
                    _filter.GetEntity(index).Get<Winner>();
                }
            }
        }
    }

    public static class GameExtensions
    {
        public static int GetLongestChain(this Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position)
        {
            return 0;
        }
    }
}
