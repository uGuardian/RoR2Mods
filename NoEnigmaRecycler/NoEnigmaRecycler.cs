using BepInEx;
using RoR2;
using Mono.Cecil.Cil;
using MonoMod.Cil;


namespace NoEnigmaRecycler
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin(
        "com.uGuardian.NoEnigmaRecycler",
        "NoEnigmaRecycler",
        "2.0.0")]

    public class NoEnigmaRecycler:BaseUnityPlugin
    {
        public static BepInEx.Configuration.ConfigEntry<bool> Recycler { get; set; }
        public static BepInEx.Configuration.ConfigEntry<bool> Lightning { get; set; }
        public static BepInEx.Configuration.ConfigEntry<bool> LunarPotion { get; set; }
        public static BepInEx.Configuration.ConfigEntry<bool> LunarMeteor { get; set; }
        public static BepInEx.Configuration.ConfigEntry<bool> LunarHellfire { get; set; }

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

            IL.RoR2.EquipmentCatalog.Init += il => {

                var c = new ILCursor(il);

                if (!Recycler.Value) {
                    c.GotoNext(
                        x => x.MatchLdstr("EQUIPMENT_RECYCLER_NAME"),
                        x => x.MatchStfld<EquipmentDef>("nameToken"),
                        x => x.MatchDup()
                    );
                    c.GotoNext(
                        x => x.MatchDup(),
                        x => x.MatchLdcI4(1),
                        x => x.MatchStfld<EquipmentDef>("enigmaCompatible")
                    );
                    c.Index += 1;
                    c.RemoveRange(1);
                    c.Emit(OpCodes.Ldc_I4, 0);
                    c.Index = 0;
                }

                if (!Lightning.Value) {
                    c.GotoNext(
                        x => x.MatchLdstr("EQUIPMENT_LIGHTNING_NAME"),
                        x => x.MatchStfld<EquipmentDef>("nameToken"),
                        x => x.MatchDup()
                    );
                    c.GotoNext(
                        x => x.MatchDup(),
                        x => x.MatchLdcI4(1),
                        x => x.MatchStfld<EquipmentDef>("enigmaCompatible")
                    );
                    c.Index += 1;
                    c.RemoveRange(1);
                    c.Emit(OpCodes.Ldc_I4, 0);
                    c.Index = 0;
                }

                if (!LunarPotion.Value) {
                    //Tonic is weird, the equipment LunarPotion has the name, but the actual drop is the item Tonic.
                    c.GotoNext(
                        //EquipmentIndex.Tonic has no name, so we need to refer to something else.
                        x => x.MatchLdstr("Prefabs/PickupModels/PickupTonic"),
                        x => x.MatchStfld<EquipmentDef>("pickupModelPath"),
                        x => x.MatchDup()
                    );
                    c.GotoNext(
                        x => x.MatchDup(),
                        x => x.MatchLdcI4(1),
                        x => x.MatchStfld<EquipmentDef>("enigmaCompatible")
                    );
                    c.Index += 1;
                    c.RemoveRange(1);
                    c.Emit(OpCodes.Ldc_I4, 0);
                    c.Index = 0;
                }
                
                if (!LunarMeteor.Value) {
                    c.GotoNext(
                        x => x.MatchLdstr("EQUIPMENT_METEOR_NAME"),
                        x => x.MatchStfld<EquipmentDef>("nameToken"),
                        x => x.MatchDup()
                    );
                    c.GotoNext(
                        x => x.MatchDup(),
                        x => x.MatchLdcI4(1),
                        x => x.MatchStfld<EquipmentDef>("enigmaCompatible")
                    );
                    c.Index += 1;
                    c.RemoveRange(1);
                    c.Emit(OpCodes.Ldc_I4, 0);
                    c.Index = 0;
                }

                if (!LunarHellfire.Value) {
                    c.GotoNext(
                        x => x.MatchLdstr("EQUIPMENT_BURNNEARBY_NAME"),
                        x => x.MatchStfld<EquipmentDef>("nameToken"),
                        x => x.MatchDup()
                    );
                    c.GotoNext(
                        x => x.MatchDup(),
                        x => x.MatchLdcI4(1),
                        x => x.MatchStfld<EquipmentDef>("enigmaCompatible")
                    );
                    c.Index += 1;
                    c.RemoveRange(1);
                    c.Emit(OpCodes.Ldc_I4, 0);
                    c.Index = 0;
                }
            };
        }  
    }
}