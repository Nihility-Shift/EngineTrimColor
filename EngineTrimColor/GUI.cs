using UnityEngine;
using VoidManager.CustomGUI;
using VoidManager.Utilities;

namespace EngineTrimColor
{
    internal class GUI : ModSettingsMenu
    {
        public override string Name() => "Engine Trim Color";

        public override void Draw()
        {
            if (GUITools.DrawColorPicker(new Rect(8, 58, 480, 160), "Engine Trim Color", ref Configs.CurrentColor, Configs.DefaultColor, false))
            {
                Configs.UpdateColorConfig();
            }
        }
    }
}
