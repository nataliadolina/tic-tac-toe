using Client;
using Components;
using Leopotam.Ecs;
using MonoBehaviours;
using UnityEngine;

namespace Systems
{
    internal class ConstrolSystem : IEcsRunSystem
    {
        private readonly string SystemName = nameof(ConstrolSystem);
        private SceneData _sceneData;

        private EcsFilter<DisableControlSystemEvent> _filter;
        
        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                foreach (var index in _filter)
                {
                    _filter.GetEntity(index).Del<DisableControlSystemEvent>();
                }

                _sceneData.StartUp.SetRunSystemState(SystemName, false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                var camera = _sceneData.Camera;
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hitInfo))
                {
                    var cellView = hitInfo.collider.GetComponent<CellView>();
                    if (cellView)
                    {
                        cellView.Entity.Get<Clicked>();
                    }
                }
            }
        }
    }
}