using Leopotam.Ecs;
using Components;
using MonoBehaviours;
using UnityEngine;

namespace Systems {
    sealed class ShowPanelSystem : IEcsRunSystem {
        private EcsFilter<ShowPanelEvent> _filter;
        private SceneData _sceneData;

        public void Run ()
        {
            foreach (var index in _filter)
            {
                ref var showPanelEvent = ref _filter.Get1(index);
                PanelType panelType = showPanelEvent.PanelType;

                if (panelType == PanelType.None)
                {
                    foreach (var key in _sceneData.Panels.PanelsMap.Keys)
                    {
                        _sceneData.Panels.PanelsMap[key].SetActive(false);
                    }
                }

                else
                {
                    GameObject panel = _sceneData.Panels.PanelsMap[panelType];
                    panel.SetActive(true);
                    _filter.GetEntity(index).Get<SetWinTextEvent>();
                }
            }
        }
    }
}