using UnityEngine;

namespace MonoBehaviours
{
    public class SaveClickButton : ButtonBase
    {
        [HideInInspector]
        public bool Clicked = false;

        protected override void OnClick()
        {
            Clicked = true;
        }
    }
}
