using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace BuilderAccHotkeys;

public class BuilderAccHotkeysConfig : ModConfig
{
    public static BuilderAccHotkeysConfig Instance;
    public override void OnLoaded() => Instance = this;
    public override ConfigScope Mode => ConfigScope.ClientSide;

    [DefaultValue(true)]
    public bool KeybindsEnabled;

    [DefaultValue(true)]
    public bool ShowChatMessages;

    [DefaultValue(true)]
    public bool PlaySounds;
}
