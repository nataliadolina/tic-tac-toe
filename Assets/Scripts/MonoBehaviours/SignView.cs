using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonoBehaviours
{
    public class SignView : MonoBehaviour
    {
        public EcsEntity Entity { get; set; }

        public void DestroyGameObject()
        {
            Destroy(gameObject);
        }
    }
}
