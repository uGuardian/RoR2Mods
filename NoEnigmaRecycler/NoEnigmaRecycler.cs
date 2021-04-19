using BepInEx;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace NoEnigmaRecycler
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin(
        "com.uGuardian.NoEnigmaRecycler",
        "NoEnigmaRecycler",
        "3.0.0")]

    public class NoEnigmaRecycler:BaseUnityPlugin
    {
        public static BepInEx.Configuration.ConfigEntry<bool> Recycler { get; set; }
        public static BepInEx.Configuration.ConfigEntry<bool> Lightning { get; set; }
        public static BepInEx.Configuration.ConfigEntry<bool> FireBallDash { get; set; }
        public static BepInEx.Configuration.ConfigEntry<bool> LunarPotion { get; set; }
        public static BepInEx.Configuration.ConfigEntry<bool> LunarMeteor { get; set; }
        public static BepInEx.Configuration.ConfigEntry<bool> LunarHellfire { get; set; }
        public static BepInEx.Configuration.ConfigEntry<string> Custom { get; set; }

        public void Awake()
        {
            Recycler = Config.Bind<bool>(
				"Normal",
				"Recycler",
				false,
				"True if Enigma can roll this item"
			);
            Lightning = Config.Bind<bool>(
				"Normal",
				"Royal Capacitor",
				true,
				"True if Enigma can roll this item"
			);
            FireBallDash = Config.Bind<bool>(
				"Normal",
				"Volcanic Egg",
				true,
				"True if Enigma can roll this item"
			);
            LunarPotion = Config.Bind<bool>(
				"Lunar",
				"Spinel Tonic",
				true,
				"True if Enigma can roll this item"
			);
            LunarMeteor = Config.Bind<bool>(
				"Lunar",
				"Glowing Meteorite",
				true,
				"True if Enigma can roll this item"
			);
            LunarHellfire = Config.Bind<bool>(
				"Lunar",
				"Helfire Tincture",
				true,
				"True if Enigma can roll this item"
			);
            Custom = Config.Bind<string>(
				"Custom",
				"Custom <Advanced>",
				"",
				"A comma separated list of item m_Name IDs, mod compatible"
			);

            List<string> exceptionList = new List<string>();
            if (!Recycler.Value) {
                exceptionList.Add("Recycle");
            }
            if (!Lightning.Value) {
                exceptionList.Add("Lightning");
            }
            if (!LunarPotion.Value) {
                //The item Tonic is the correct one, LunarPotion is not directly accessed at any point.
                exceptionList.Add("Tonic");
            }
            if (!LunarMeteor.Value) {
                exceptionList.Add("Meteor");
            }
            if (!LunarHellfire.Value) {
                exceptionList.Add("BurnNearby");
            }
            if (!FireBallDash.Value) {
                exceptionList.Add("FireBallDash");
            }
            if (Custom.Value != "") {
                exceptionList.AddRange(Custom.Value.Split(','));
                Debug.LogWarning("Custom exceptions enabled");
            }
            Debug.Log("Enigma Exceptions: " + string.Join(",", exceptionList));

            On.RoR2.EquipmentCatalog.RegisterEquipment += (orig, equipmentIndex, equipmentDef) =>
            {
                if (exceptionList.Any(str => str == equipmentDef.name)) {
                    equipmentDef.enigmaCompatible = false;
                    Debug.LogWarning("Enigma Exception: " + equipmentDef.name);
                };
                orig(equipmentIndex, equipmentDef);
            };
        }  
    }
}