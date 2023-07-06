using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BuilderAccHotkeys;

public class BuilderAccHotkeys : Mod
{
    internal static ModKeybind RulerLine;
    internal static ModKeybind RulerGrid;
    internal static ModKeybind AutoActuate;
    internal static ModKeybind AutoPaint;
    internal static ModKeybind WireVisibility_Red;
    internal static ModKeybind WireVisibility_Green;
    internal static ModKeybind WireVisibility_Blue;
    internal static ModKeybind WireVisibility_Yellow;
    internal static ModKeybind HideAllWires;
    internal static ModKeybind WireVisibility_Actuators;
    internal static ModKeybind BlockSwap;
    internal static ModKeybind TorchBiome;
    internal static ModKeybind WireVisibility_All;

    internal static string[] WireViews;
    internal static Dictionary<int, string[]> ToggleMessages = new();

    public override void Load()
    {
        RulerLine = KeybindLoader.RegisterKeybind(this, "ToggleRuler", "H");
        RulerGrid = KeybindLoader.RegisterKeybind(this, "ToggleMechanicalRuler", "H");
        AutoActuate = KeybindLoader.RegisterKeybind(this, "TogglePresserator", "H");
        AutoPaint = KeybindLoader.RegisterKeybind(this, "TogglePaintSprayer", "H");
        BlockSwap = KeybindLoader.RegisterKeybind(this, "ToggleBlockSwap", "H");
        TorchBiome = KeybindLoader.RegisterKeybind(this, "ToggleBiomeTorchSwap", "H");
        HideAllWires = KeybindLoader.RegisterKeybind(this, "ToggleForcedWireDisplay", "H");
        WireVisibility_Red = KeybindLoader.RegisterKeybind(this, "CycleRedWireMode", "H");
        WireVisibility_Blue = KeybindLoader.RegisterKeybind(this, "CycleBlueWireMode", "H");
        WireVisibility_Green = KeybindLoader.RegisterKeybind(this, "CycleGreenWireMode", "H");
        WireVisibility_Yellow = KeybindLoader.RegisterKeybind(this, "CycleYellowWireMode", "H");
        WireVisibility_Actuators = KeybindLoader.RegisterKeybind(this, "CycleActuatorMode", "H");
        WireVisibility_All = KeybindLoader.RegisterKeybind(this, "CycleAllWireModes", "H");


        WireViews = new string[] {
            ": [c/FFFFFF:" + Language.GetTextValue("GameUI.Bright") + "]",
            ": [c/BBBBBB:" + Language.GetTextValue("GameUI.Normal") + "]",
            ": [c/888888:" + Language.GetTextValue("GameUI.Faded" ) + "]"
        };

        AddToggleMessage(Player.BuilderAccToggleIDs.RulerLine, "GameUI.RulerOn", "GameUI.RulerOff", "[i:486]");
        AddToggleMessage(Player.BuilderAccToggleIDs.RulerGrid, "GameUI.MechanicalRulerOn", "GameUI.MechanicalRulerOff", "[i:2799]");
        AddToggleMessage(Player.BuilderAccToggleIDs.AutoActuate, "GameUI.ActuationDeviceOn", "GameUI.ActuationDeviceOff", "[i:3624]");
        AddToggleMessage(Player.BuilderAccToggleIDs.AutoPaint, "GameUI.PaintSprayerOn", "GameUI.PaintSprayerOff", "[i:2216]");
        AddToggleMessage(Player.BuilderAccToggleIDs.BlockSwap, "GameUI.BlockReplacerOn", "GameUI.BlockReplacerOff", "[i:5126]");
        AddToggleMessage(Player.BuilderAccToggleIDs.TorchBiome, "GameUI.TorchTypeSwapperOn", "GameUI.TorchTypeSwapperOff", "[i:5043]");
        AddToggleMessage(Player.BuilderAccToggleIDs.HideAllWires, "GameUI.WireModeForced", "GameUI.WireModeNormal", "[i:3619]");

        AddWireToggleMessage(Player.BuilderAccToggleIDs.WireVisibility_Red, "Game.RedWires", "[i:509]");
        AddWireToggleMessage(Player.BuilderAccToggleIDs.WireVisibility_Blue, "Game.GreenWires", "[i:851]"); // WireVisibility_Blue and green are swapped??? the fuck
        AddWireToggleMessage(Player.BuilderAccToggleIDs.WireVisibility_Green, "Game.BlueWires", "[i:850]");
        AddWireToggleMessage(Player.BuilderAccToggleIDs.WireVisibility_Yellow, "Game.YellowWires", "[i:3612]");
        AddWireToggleMessage(Player.BuilderAccToggleIDs.WireVisibility_Actuators, "Game.Actuators", "[i:849]");

        AddWireToggleMessage(-69, "ItemName.Wire", "[i:3625]");
    }

    public override void Unload()
    {
        RulerLine = null;
        RulerGrid = null;
        AutoActuate = null;
        AutoPaint = null;
        BlockSwap = null;
        TorchBiome = null;
        HideAllWires = null;
        WireVisibility_Red = null;
        WireVisibility_Blue = null;
        WireVisibility_Green = null;
        WireVisibility_Yellow = null;
        WireVisibility_Actuators = null;

        WireViews = null;
        ToggleMessages = null;
    }

    private static void AddToggleMessage(int Id, string Enabled, string Disabled, string Icon)
    {
        ToggleMessages.Add(Id, new string[] {
            Icon + " [c/66ff66:" + Language.GetTextValue(Enabled ) + "]",
            Icon + " [c/ff6666:" + Language.GetTextValue(Disabled) + "]"
        });
    }

    private static void AddWireToggleMessage(int Id, string Key, string Icon)
    {
        string Text = Icon + " " + Language.GetTextValue(Key);
        ToggleMessages.Add(Id, new string[]
        {
            Text + WireViews[0],
            Text + WireViews[1],
            Text + WireViews[2]
        });
    }
}
