using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    public abstract class ButtonBase : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        protected abstract void OnClick();
    }
}