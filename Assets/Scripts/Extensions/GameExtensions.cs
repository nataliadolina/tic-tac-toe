using Components;
using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public struct DirectionMaxLength
    {
        public int Length;
        public Vector2Int Direction;
        public DirectionMaxLength(int length, Vector2Int direction)
        {
            Length = length;
            Direction = direction;
        }
    }

    public static class GameExtensions
    {
        private static int CheckLine(this Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position, Vector2Int direction)
        {
            var startEntity = cells[position];
            if (!startEntity.Has<Taken>())
            {
                return 0;
            }

            var startType = startEntity.Ref<Taken>().Unref().Value;
            var length = 1;
            var currentPosition = position + direction;
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                {
                    break;
                }
                else
                {
                    var type = entity.Ref<Taken>().Unref().Value;
                    if (type != startType)
                    {
                        break;
                    }

                    length++;
                    currentPosition += direction;
                }
            }

            return length;

        }

        public static DirectionMaxLength GetLongestChain(this Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position)
        {
            Vector2Int[] directions = new Vector2Int[] {new Vector2Int(1, 0), new Vector2Int(-1, 0), new Vector2Int(0, 1), new Vector2Int(0, -1), new Vector2Int(1, 1), new Vector2Int(-1, -1), new Vector2Int(1, -1), new Vector2Int(-1, 1) };
            Vector2Int maxChainLengthDirection = Vector2Int.zero;
            int maxLength = 0;
            foreach (var direction in directions)
            {
                int length = CheckLine(cells, position, direction);
                if (length > maxLength)
                {
                    maxLength = length;
                    maxChainLengthDirection = direction;
                }
            }

            return new DirectionMaxLength(maxLength, maxChainLengthDirection);
        }
    }
}
