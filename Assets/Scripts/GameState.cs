using Enums;
using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public SignType CurrentSign = SignType.Cross;
    public readonly Dictionary<Vector2Int, EcsEntity> Cells = new Dictionary<Vector2Int, EcsEntity>();
}