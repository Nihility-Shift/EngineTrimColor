using CG.Space;
using HarmonyLib;

namespace EngineTrimColor
{
    [HarmonyPatch(typeof(PlayerControlledShip), "Awake")]
    internal class PlayerControlledShipPatch
    {
        static void Postfix()
        {
            //Set the trim panel color when the ship is created
            Configs.UpdateColorConfig();
        }
    }
}
