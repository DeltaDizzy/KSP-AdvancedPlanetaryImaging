using AdvancedPlanetaryImaging.PartModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AdvancedPlanetaryImaging.UI
{
    [KSPAddon(KSPAddon.Startup.Flight, true)]
    public class API_UI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public static GameObject ApiUICanvas = null;
        public static GameObject ApiUIText = null;
        public static List<APIModuleViewFeed> viewerParts = new List<APIModuleViewFeed>();
        private static Vector2 dragStart;
        private static Vector2 altstart;

        private void Awake()
        {
            // destruction callback
            GameEvents.onGameSceneSwitchRequested.Add(OnSceneSwitch);
        }

        void OnSceneSwitch(GameEvents.FromToAction<GameScenes, GameScenes> fromToScenes)
        {
            if (ApiUICanvas != null)
            {
                Destroy(this);
            }
        }

        public static void ShowUI()
        {
            if (ApiUICanvas != null) // if we already have one open
            {
                return;
            }

            ApiUICanvas = (GameObject)Instantiate(API_UILoader.PanelPrefab);
        }
    }
}
