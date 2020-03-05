using AdvancedPlanetaryImaging.PartModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AdvancedPlanetaryImaging.UI
{
    [KSPAddon(KSPAddon.Startup.Flight, true)]
    public class API_UI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public static GameObject ApiUICanvas = null;
        public static GameObject ApiUITitleText = null;
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

            ApiUICanvas = Instantiate(API_UILoader.PanelPrefab);
            ApiUICanvas.transform.SetParent(MainCanvasUtil.MainCanvas.transform);
            ApiUICanvas.AddComponent<API_UI>();

            // find go names
            ApiUITitleText = GameObject.Find("TitleText");

            // toggle needs a callback
            GameObject checkredtoggle = GameObject.Find("RedToggle");
            Toggle redToggle = checkredtoggle.GetComponent<Toggle>();
            redToggle.onValueChanged.AddListener(delegate
            {
                OnToggleClicked(redToggle.isOn, checkredtoggle);
            });
        }

        static void OnToggleClicked(bool ison, GameObject caller)
        {
            if (ison) // is it checked
            {
                ScreenMessages.PostScreenMessage($"{caller.name} toggled on.");
            }
            else
            {
                ScreenMessages.PostScreenMessage($"{caller.name} turned off.");
            }
        }

        public static void UpdateText(string message)
        {
            ApiUITitleText.GetComponent<Text>().text = message;
        }

        public void OnBeginDrag(PointerEventData data)
        {
            dragStart = new Vector2(data.position.x - Screen.width / 2, data.position.y - Screen.height / 2);
            altstart = ApiUICanvas.transform.position;
        }

        public void OnDrag(PointerEventData data)
        {
            Vector2 dpos = new Vector2(data.position.x - Screen.width / 2, data.position.y - Screen.height / 2);
            Vector2 dragDist = dpos - dragStart;
            ApiUICanvas.transform.position = altstart + dragDist;
        }

        public static void Destroy()
        {
            ApiUICanvas.DestroyGameObject();
            ApiUICanvas = null;
            for (int i = 0; i < viewerParts.Count; i++)
            {
                viewerParts.ElementAt(i).uiOpen = false;
            }
        }
    }
}
