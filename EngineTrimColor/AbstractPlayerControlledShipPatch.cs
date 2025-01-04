using CG.Space;
using HarmonyLib;

namespace Engine_Trim_Color
{
    [HarmonyPatch(typeof(AbstractPlayerControlledShip), "Awake")]
    internal class AbstractPlayerControlledShipPatch
    {
        static void Postfix()
        {
            //Set the trim panel color when the ship is created
            Configs.UpdateColorConfig();
        }
    }
}
