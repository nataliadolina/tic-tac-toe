using Components;
using Leopotam.Ecs;
using MonoBehaviours;
using UnityEngine;

namespace Systems
{
    internal class ConstrolSystem : IEcsRunSystem
    {
        private SceneData _sceneData;

        public void Run()
        {
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