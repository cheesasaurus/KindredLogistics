using KindredLogistics;
using VampireCommandFramework;

namespace Logistics.Commands
{
    [CommandGroup(name: "logistics", "l")]
    public static class LogisticsCommands
    {
        [Command(name: "sortStash", shortHand: "ss", usage: ".l ss", description: "Toggles autostashing on double clicking sort button for player.")]
        public static void TogglePlayerAutoStash(ChatCommandContext ctx)
        {
            var SteamID = ctx.Event.User.PlatformId;

            var autoStash = Core.PlayerSettings.ToggleSortStash(SteamID);
            ctx.Reply($"AutoStash is {(autoStash ? "<color=green>enabled</color>" : "<color=red>disabled</color>")}.");
        }
       
        [Command(name: "craftPull", shortHand: "c", usage: ".l c", description: "Toggles right-clicking on recipes for missing ingredients.")]
        public static void TogglePlayerAutoPull(ChatCommandContext ctx)
        {
            var SteamID = ctx.Event.User.PlatformId;

            var autoPull = Core.PlayerSettings.ToggleCraftPull(SteamID);
            ctx.Reply($"AutoPull is {(autoPull ? "<color=green>enabled</color>" : "<color=red>disabled</color>")}.");
        }
        [Command(name: "autoStashMissions", shortHand: "asm", usage: ".l asm", description: "Toggles autostashing for servant missions.")]
        public static void ToggleServantAutoStash(ChatCommandContext ctx)
        {
            var SteamID = ctx.Event.User.PlatformId;

            var autoStashMissions = Core.PlayerSettings.ToggleAutoStashMissions(SteamID);
            ctx.Reply($"AutoStash for missions is {(autoStashMissions ? "<color=green>enabled</color>" : "<color=red>disabled</color>")}.");
        }

        [Command(name: "conveyor", shortHand: "co", usage: ".l co", description: "Toggles the ability of sender/receiver's to move items around.")]
        public static void ToggleConveyor(ChatCommandContext ctx)
        {
            var SteamID = ctx.Event.User.PlatformId;

            var conveyor = Core.PlayerSettings.ToggleConveyor(SteamID);
            ctx.Reply($"Conveyor is {(conveyor ? "<color=green>enabled</color>" : "<color=red>disabled</color>")}.");
        }

        [Command(name: "settings", shortHand: "s", usage: ".l s", description: "Displays current settings.")]
        public static void DisplaySettings(ChatCommandContext ctx)
        {
            var SteamID = ctx.Event.User.PlatformId;

            var settings = Core.PlayerSettings.GetSettings(SteamID);
            ctx.Reply("KindredLogistics settings:\n" +
                      $"SortStash: {(settings.SortStash ? "<color=green>enabled</color>" : "<color=red>disabled</color>")}\n" +
                      $"CraftPull: {(settings.CraftPull ? "<color=green>enabled</color>" : "<color=red>disabled</color>")}\n" +
                      $"AutoStashMissions: {(settings.AutoStashMissions ? "<color=green>enabled</color>" : "<color=red>disabled</color>")}\n" +
                      $"Conveyor: {(settings.Conveyor ? "<color=green>enabled</color>" : "<color=red>disabled</color>")}"
                      );
        }  
    }

    public static class AdditionalCommands
    {
        [Command(name: "stash", description: "Stashes all items in your inventory.")]
        public static void StashInventory(ChatCommandContext ctx)
        {
            Core.Stash.StashCharacterInventory(ctx.Event.SenderCharacterEntity);
        }
    }
}
