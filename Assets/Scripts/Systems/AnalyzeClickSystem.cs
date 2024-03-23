using Components;
using Enums;
using Leopotam.Ecs;

namespace Systems
{
    internal class AnalyzeClickSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Clicked>.Exclude<Taken> _filter;
        private GameState _gameState;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var ecsEntity = ref _filter.GetEntity(index);
                ecsEntity.Get<Taken>().Value = _gameState.CurrentSign;
                ecsEntity.Get<CheckWinEvent>();
                _gameState.CurrentSign = _gameState.CurrentSign == SignType.Cross ? SignType.Ring : SignType.Cross;
            }
        }
    }
}