using System.Collections.Generic;
using UnityEngine;
using KSP.UI.Screens;

namespace AdvancedPlanetaryImaging.UI
{
    /// <summary>
    /// Flight Page
    /// </summary>
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class UIController : MonoBehaviour
    {
        private ApplicationLauncherButton albutton;
        public static UIController Instance;
        private PopupDialog window;
        private int dialogXPos = 0;
        private int dialogYPos = 0;
        private string iconpath;
        private int padding;
        private Texture camTex;

        private void Awake()
        {
            Instance = this;
            GameEvents.onGUIApplicationLauncherReady.Add(SetupALButton);
            GameEvents.onGUIApplicationLauncherUnreadifying.Add(DestroyALButton);
        }

        public void SetupALButton()
        {
            albutton = ApplicationLauncher.Instance.AddModApplication(
                () => ActivateWindow(),
                () => CloseWindow(),
                null,
                null,
                null,
                () => OnDisable(),
                ApplicationLauncher.AppScenes.FLIGHT,
                GameDatabase.Instance.GetTexture(iconpath, false)
                );
        }

        private void OnDisable()
        {
            DestroyALButton(HighLogic.LoadedScene);
        }

        public void DestroyALButton(GameScenes data)
        {
            ApplicationLauncher.Instance.RemoveModApplication(albutton);
        }

        public PopupDialog ActivateWindow()
        {
            padding = 0;
            List<DialogGUIBase> dialogElements = new List<DialogGUIBase>();

            dialogElements.Add(new DialogGUIVerticalLayout(
                // Title
                new DialogGUILabel("AdvancedPlanetaryImaging", true),
                // Texture
                new DialogGUIImage(new Vector2(100, 100), new Vector2(dialogXPos, dialogYPos), Color.blue, camTex),
                new DialogGUIHorizontalLayout(  new DialogGUIToggleButton(true, "Red", value => GetRedToggleSetected = value), 
                                                new DialogGUIToggleButton(true, "Green", value => GetGreenToggleSetected = value),
                                                new DialogGUIToggleButton(true, "Blue", value => GetBlueToggleSetected = value)
                                             ),
                new DialogGUIScrollList(new Vector2(50, 5), false, true, new DialogGUIVerticalLayout(
                    new DialogGUIToggle
                ));
            // texture
            window = PopupDialog.SpawnPopupDialog()

        }

        public void CloseWindow()
        {
            if (albutton == null) return;
            window.Dismiss();
        }

    }
}
