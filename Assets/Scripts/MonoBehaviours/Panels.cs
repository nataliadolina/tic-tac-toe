using Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MonoBehaviours
{
    public class Panels : MonoBehaviour
    {
        [SerializeField]
        private List<PanelsMap> panels;

        public TMP_Text WinText;

        public Dictionary<PanelType, GameObject> PanelsMap = new Dictionary<PanelType, GameObject>();
        
        private void Start()
        {
            foreach (var panelMap in panels)
            {
                PanelsMap.Add(panelMap.PanelType, panelMap.GameObject);
                panelMap.GameObject.SetActive(false);
            }
        }
    }
}