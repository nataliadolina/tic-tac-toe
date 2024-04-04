using Components;
using Leopotam.Ecs;
using UnityEngine;
using MonoBehaviours;
using Enums;
using System;

namespace Systems
{
    sealed class CreateTakenViewSystem : IEcsRunSystem {
        private EcsFilter<Taken, CellViewRef>.Exclude<TakenRef> _filter;
        private Configuration _configuration;

        void IEcsRunSystem.Run () {

            foreach (var index in _filter)
            {
                var position = _filter.Get2(index).Value.transform.position;
                var takenType = _filter.Get1(index).Value;

                SignView signView;

                switch (takenType)
                {
                    case SignType.Cross:
                        signView = _configuration.CrossView;
                        break;
                    case SignType.Ring:
                        signView = _configuration.RingView;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                var instance = UnityEngine.Object.Instantiate(signView, position, Quaternion.identity);
                _filter.GetEntity(index).Get<TakenRef>().Value = instance;
            }
        }
    }
}