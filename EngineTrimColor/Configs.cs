using BepInEx.Configuration;
using CG.Client.Player.Interactions;
using CG.Client.Ship.Views;
using CG.Game;
using Gameplay.Ship;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Engine_Trim_Color
{
    internal class Configs
    {
        private static readonly FieldInfo diodeSetting = AccessTools.Field(typeof(Diode), "setting");
        private static readonly FieldInfo settingNeutralColor = AccessTools.Field(typeof(DiodeSetting), "neutralColor");

        internal static Color DefaultColor = new(0, 4, 10, 1);
        internal static Color CurrentColor;
        internal static ConfigEntry<float> TrimColorR;
        internal static ConfigEntry<float> TrimColorG;
        internal static ConfigEntry<float> TrimColorB;

        internal static void UpdateColorConfig()
        {
            TrimColorR.Value = CurrentColor.r;
            TrimColorG.Value = CurrentColor.g;
            TrimColorB.Value = CurrentColor.b;

            //Update trim panel colors
            try
            {
                Diode[] diodes = ClientGame.Current.PlayerShip.GameObject.GetComponentInChildren<ShipEngine>().GameObject.GetComponentsInChildren<AbstractInteractable>().Where(a => a.name == "TrimAdvisoryPanel").First().gameObject.GetComponentsInChildren<Diode>();
                IEnumerable<DiodeSetting> settings = diodes.Select(d => (DiodeSetting)diodeSetting.GetValue(d)).Distinct();
                settings.Do(setting => settingNeutralColor.SetValue(setting, Configs.CurrentColor));
                diodes.Do(d => { d.SetPoweredColorNegative(); d.SetPoweredColorNeutral(); });
            }
            catch(NullReferenceException)
            {
                //If ship doesn't exist yet
            }
        }

        internal static void Load(BepinPlugin plugin)
        {
            TrimColorR = plugin.Config.Bind("TrimColor", "TrimColorR", DefaultColor.r);
            TrimColorG = plugin.Config.Bind("TrimColor", "TrimColorG", DefaultColor.g);
            TrimColorB = plugin.Config.Bind("TrimColor", "TrimColorB", DefaultColor.b);
            CurrentColor = new(TrimColorR.Value, TrimColorG.Value, TrimColorB.Value, 1);
        }
    }
}
