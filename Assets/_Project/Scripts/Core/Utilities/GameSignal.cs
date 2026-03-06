
using MyGame.Core.Enums;

public static class GameSignal 
{
    public class OnPlayerModeChangedSignal 
    {
        public PlayerMode NewMode;
        public OnPlayerModeChangedSignal(PlayerMode newMode) => NewMode = newMode;
    }
}
