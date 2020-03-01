using AdvancedPlanetaryImaging.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPlanetaryImaging.PartModules
{
    /// <summary>
    /// This PartModule is meant to open the UI Window, while the UIController will handle all of the actual UI things
    /// </summary>
    public class APIModuleViewFeed : PartModule
    {
        // UI Switch
        [KSPField(guiName = "Toggle Viewer", guiActiveEditor = false, guiActive = true, isPersistant = false),
            UI_Toggle(controlEnabled = true, disabledText = "Closed", enabledText = "Open", invertButton = false, scene = UI_Scene.Flight)]
        public bool uiOpen = false;

        //progress bar to show it does something
        [KSPField(guiName = "Slider", guiActiveEditor = false, guiActive = true, isPersistant = true),
            UI_ProgressBar(minValue = 0f, maxValue = 1f, scene = UI_Scene.Flight)]
        public float uiSliderValue = 0.0f;

        public override void OnStart(StartState state)
        {
            // Create a callback so clicking the toggle opens the main UI
            Fields[nameof(uiOpen)].uiControlFlight.onFieldChanged =
                delegate (BaseField a, System.Object b)
                {
                    if (API_UI.ApiUICanvas)
                    {

                    }
                };
        }
    }
}
