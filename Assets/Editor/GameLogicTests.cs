using Leopotam.Ecs;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Components;
using Systems;
using Enums;
using Extensions;

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

            int chainLength = GameExtensions.GetLongestChain(cells, Vector2Int.zero).Length;
            Assert.AreEqual(0, chainLength);
        }

        [Test]
        public void CheckHorizontalChainOne()
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

            cells[Vector2Int.zero].Get<Taken>().Value = SignType.Cross;
            int chainLength = GameExtensions.GetLongestChain(cells, Vector2Int.zero).Length;
            Assert.AreEqual(1, chainLength);
        }

        [Test]
        public void CheckHorizontalChainTwoLeft()
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

            cells[new Vector2Int(2, 0)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(1, 0)].Get<Taken>().Value = SignType.Cross;

            var chainLength = cells.GetLongestChain(new Vector2Int(2, 0)).Length;
            Assert.AreEqual(2, chainLength);
        }

        [Test]
        public void CheckHorizontalChainTwoRight()
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

            cells[new Vector2Int(2, 0)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(1, 0)].Get<Taken>().Value = SignType.Cross;

            var chainLength = cells.GetLongestChain(new Vector2Int(1, 0)).Length;
            Assert.AreEqual(2, chainLength);
        }

        [Test]
        public void CheckChainTwoVertical()
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

            cells[new Vector2Int(0, 0)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(0, 1)].Get<Taken>().Value = SignType.Cross;

            var chainLength = cells.GetLongestChain(new Vector2Int(0, 0)).Length;
            Assert.AreEqual(2, chainLength);
        }

        [Test]
        public void CheckChainThreeVertical()
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

            cells[new Vector2Int(0, 0)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(0, 1)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(0, 2)].Get<Taken>().Value = SignType.Cross;

            var chainLength = cells.GetLongestChain(new Vector2Int(0, 0)).Length;
            Assert.AreEqual(3, chainLength);
        }

        [Test]
        public void CheckChainThreeDiagonal()
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

            cells[new Vector2Int(0, 0)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(1, 1)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(2, 2)].Get<Taken>().Value = SignType.Cross;

            var chainLength = cells.GetLongestChain(new Vector2Int(0, 0)).Length;
            Assert.AreEqual(3, chainLength);
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
