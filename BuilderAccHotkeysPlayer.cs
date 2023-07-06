using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace BuilderAccHotkeys;

public class BuilderAccHotkeysPlayer : ModPlayer
{
    public override void ProcessTriggers(TriggersSet triggersSet)
    {
        if (!BuilderAccHotkeysConfig.Instance.KeybindsEnabled) return;

        if (BuilderAccHotkeys.RulerLine.JustPressed) Toggle(Player.BuilderAccToggleIDs.RulerLine);
        if (BuilderAccHotkeys.RulerGrid.JustPressed) Toggle(Player.BuilderAccToggleIDs.RulerGrid);
        if (BuilderAccHotkeys.AutoActuate.JustPressed) Toggle(Player.BuilderAccToggleIDs.AutoActuate);
        if (BuilderAccHotkeys.AutoPaint.JustPressed) Toggle(Player.BuilderAccToggleIDs.AutoPaint);
        if (BuilderAccHotkeys.BlockSwap.JustPressed) Toggle(Player.BuilderAccToggleIDs.BlockSwap);
        if (BuilderAccHotkeys.TorchBiome.JustPressed) Toggle(Player.BuilderAccToggleIDs.TorchBiome);
        if (BuilderAccHotkeys.HideAllWires.JustPressed) Toggle(Player.BuilderAccToggleIDs.HideAllWires);
        if (BuilderAccHotkeys.WireVisibility_Red.JustPressed) Toggle(Player.BuilderAccToggleIDs.WireVisibility_Red, 2);
        if (BuilderAccHotkeys.WireVisibility_Blue.JustPressed) Toggle(Player.BuilderAccToggleIDs.WireVisibility_Green, 2);
        if (BuilderAccHotkeys.WireVisibility_Green.JustPressed) Toggle(Player.BuilderAccToggleIDs.WireVisibility_Blue, 2);
        if (BuilderAccHotkeys.WireVisibility_Yellow.JustPressed) Toggle(Player.BuilderAccToggleIDs.WireVisibility_Yellow, 2);
        if (BuilderAccHotkeys.WireVisibility_Actuators.JustPressed) Toggle(Player.BuilderAccToggleIDs.WireVisibility_Actuators, 2);

        if (BuilderAccHotkeys.WireVisibility_All.JustPressed) CycleAllWires();
    }

    private void Toggle(int Id, int Max = 1)
    {
        Player.builderAccStatus[Id] = (Player.builderAccStatus[Id] + 1) % (Max + 1);

        if (BuilderAccHotkeysConfig.Instance.ShowChatMessages)
            Main.NewText(BuilderAccHotkeys.ToggleMessages[Id][Player.builderAccStatus[Id]]);

        if (!BuilderAccHotkeysConfig.Instance.PlaySounds) return;

        switch (Id)
        {
            case Player.BuilderAccToggleIDs.BlockSwap:
            case Player.BuilderAccToggleIDs.TorchBiome:
                SoundEngine.PlaySound(SoundID.Unlock);
                break;
            default:
                SoundEngine.PlaySound(SoundID.MenuTick);
                break;
        }
    }

    private void CycleAllWires()
    {
        int V = (Player.builderAccStatus[Player.BuilderAccToggleIDs.WireVisibility_Red] + 1) % 3;
        Player.builderAccStatus[Player.BuilderAccToggleIDs.WireVisibility_Red] = V;
        Player.builderAccStatus[Player.BuilderAccToggleIDs.WireVisibility_Blue] = V;
        Player.builderAccStatus[Player.BuilderAccToggleIDs.WireVisibility_Green] = V;
        Player.builderAccStatus[Player.BuilderAccToggleIDs.WireVisibility_Yellow] = V;
        Player.builderAccStatus[Player.BuilderAccToggleIDs.WireVisibility_Actuators] = V;

        if (BuilderAccHotkeysConfig.Instance.ShowChatMessages)
            Main.NewText(BuilderAccHotkeys.ToggleMessages[-69][V]);

        if (!BuilderAccHotkeysConfig.Instance.PlaySounds)
            SoundEngine.PlaySound(SoundID.MenuTick);
    }
}
