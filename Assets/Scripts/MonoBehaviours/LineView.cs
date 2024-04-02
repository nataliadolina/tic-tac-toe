using Leopotam.Ecs;
using UnityEngine;

namespace MonoBehaviours
{
    public class LineView : MonoBehaviour
    {
        public Transform spriteTransform;
        public EcsEntity Entity { get; set; }
    }
}
