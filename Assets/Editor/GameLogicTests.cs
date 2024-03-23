using Leopotam.Ecs;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Components;
using Systems;

namespace Tests
{
    [TestFixture]
    public class GameLogicTests
    {
        [Test]
        public void CheckHorizontalChain()
        {
            var world = new EcsWorld();
            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                { new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0, 0)) },
                { new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0, 1)) },
                { new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0, 2)) },
                { new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1, 0)) },
                { new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1, 1)) },
                { new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1, 2)) },
                { new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2, 0)) },
                { new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2, 1)) },
                { new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2, 2)) },
            };

            var chainLength = GameExtensions.GetLongestChain(cells, Vector2Int.zero);
            Assert.AreEqual(0, chainLength);
        }

        private EcsEntity CreateCell(EcsWorld world, Vector2Int position)
        {
            var entity = world.NewEntity();
            entity.Get<Position>().Value = position;
            entity.Get<Cell>();

            return entity;
        }
    }
}
