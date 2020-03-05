using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AdvancedPlanetaryImaging.UI
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class API_UILoader : MonoBehaviour
    {
        
        private static GameObject panelPrefab;

        public static GameObject PanelPrefab
        {
            get { return panelPrefab; }
        }

        private void Awake()
        {
            AssetBundle prefabs = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "kspadvcam.delta"));
            panelPrefab = prefabs.LoadAsset("MainPanel") as GameObject;

        }
    }
}
