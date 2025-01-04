using VoidManager.MPModChecks;

namespace Engine_Trim_Color
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public override MultiplayerType MPType => MultiplayerType.Client;

        public override string Author => "18107";

        public override string Description => "Makes the engine trim colors customisable";
    }
}
