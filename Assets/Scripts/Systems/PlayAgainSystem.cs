using Leopotam.Ecs;
using UnityEngine.SceneManagement;

namespace Client {
    sealed class PlayAgainSystem : IEcsRunSystem {
        private SceneData _sceneData;

        public void Run () {
            if (!_sceneData.PlayAgainButton.Clicked)
            {
                return;
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}