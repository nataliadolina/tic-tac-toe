using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class DrawWinLineSystem : IEcsRunSystem
    {
        private Configuration _configuration;
        private EcsFilter<WinChain, Position>.Exclude<LineViewRef> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref WinChain chainArgs = ref _filter.Get1(index);
                for (int i = 0; i < _configuration.ChainLength; i++)
                {
                    ref var position = ref _filter.Get2(in index);
                    Vector3 lineViewPosition = new Vector3(position.Value.x + _configuration.Offset.x * position.Value.x, position.Value.y + _configuration.Offset.y * position.Value.y, 1);
                    var lineView = Object.Instantiate(_configuration.WinLine, lineViewPosition, Quaternion.identity);
                    Vector2Int direction = chainArgs.Direction;
                    lineView.spriteTransform.rotation = Quaternion.LookRotation(Vector3.forward, new Vector3(direction.x, direction.y));
                    if (Mathf.Abs(direction.x) == 1 && Mathf.Abs(direction.y) == 1)
                    {
                        lineView.spriteTransform.localScale = new Vector3(1, 1.3f, 1);
                    }

                    ref var entity = ref _filter.GetEntity(index);
                    lineView.Entity = entity;
                    entity.Get<LineViewRef>().Value = lineView;
                }
            }
        }
    }
}

