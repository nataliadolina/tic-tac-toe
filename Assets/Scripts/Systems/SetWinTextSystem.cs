using Components;
using Enums;
using Leopotam.Ecs;
using MonoBehaviours;

namespace Systems
{
    internal class SetWinTextSystem : IEcsRunSystem
    {
        private SceneData sceneData;
        private GameState _gameState;

        private EcsFilter<SetWinTextEvent> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                SignType winSign = _gameState.CurrentSign == SignType.Cross ? SignType.Ring : SignType.Cross;
                
                switch (winSign)
                {
                    case SignType.Ring:
                        sceneData.Panels.WinText.text = "Rign won";
                        break;
                    case SignType.Cross:
                        sceneData.Panels.WinText.text = "Cross won";
                        break;
                }
                 
            }
        }
    }
}