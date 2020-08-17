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
        "1.0.0")]

    public class NoEnigmaRecycler:BaseUnityPlugin
    {

        public void Awake()
        {
            IL.RoR2.EquipmentCatalog.Init += il =>
            {
                var c = new ILCursor(il);

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

            };

        }  
    }
}