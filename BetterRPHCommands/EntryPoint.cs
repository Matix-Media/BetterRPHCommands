using System;
using Rage;
using Rage.Attributes;


[assembly: Plugin("Better RagePluginHook Commands", Description = "Provides better commands for the RagePluginHook console", Author = "Matix")]
namespace BetterRPHCommands
{
    public class EntryPoint
    {

        public static void Main()
        {
            Log("Successfully loaded plugin");

            // Plugin loop, so that plugin doesn't get unloaded
            while (true)
            {
                GameFiber.Yield();
            }
        }

        private static void Log(string message)
        {
            Game.Console.Print(message);
        }

        private static Ped GetCharacter()
        {
            return Game.LocalPlayer.Character;
        }

        private static Vehicle GetVehicle()
        {
            return GetCharacter().CurrentVehicle;
        }

        [ConsoleCommand("Give money to the current character")]
        public static void Command_GiveMoney(int amount)
        {
            GetCharacter().Money += amount;
        }

        [ConsoleCommand("Set the money of the current character")]
        public static void Command_SetMoney(int amount)
        {
            GetCharacter().Money = amount;
        }

        [ConsoleCommand("Make the character (and his current vehicle) indestructible")]
        public static void Command_Indestructable(bool enable)
        {
            GetCharacter().IsInvincible = enable;

            Vehicle ve = GetVehicle();
            if (ve == null) return;

            ve.IsInvincible = enable;
            ve.CanBeDamaged = !enable;
            
        }

        [ConsoleCommand("Set the maximum speed of the current vehicle (in km/h)")]
        public static void Command_SetMaximumSpeed(float speed)
        {
            GetVehicle().TopSpeed = MathHelper.ConvertKilometersPerHourToMetersPerSecond(speed);
        }

        [ConsoleCommand("Warps the player to the location of his marker on the map")]
        public static void Command_WarpToMarker()
        {
            GetCharacter().Position = Game.LocalPlayer.M
        }
    }
}
