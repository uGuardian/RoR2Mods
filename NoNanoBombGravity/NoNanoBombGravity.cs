using BepInEx;
using R2API;
using R2API.Utils;
using RoR2;
using UnityEngine;


namespace NoNanoBombGravity
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin(
        "com.uGuardian.NoNanoBombGravity",
        "NoNanoBombGravity",
        "1.1.0")]

    public class NoNanoBombGravity:BaseUnityPlugin
    {
        public static BepInEx.Configuration.ConfigEntry<float> antiGravitySetting { get; set; }

        public void Awake()
        {
            antiGravitySetting = Config.Bind<float>(
				"NoNanoBombGravity",
				"antiGravityCoefficient",
				1,
				"Changes how much Nano Bomb resists gravity. Mod default is 1, vanilla default is 0.7"
			);

            On.RoR2.AntiGravityForce.FixedUpdate += (orig, self) =>
            {
                self.antiGravityCoefficient = antiGravitySetting.Value;
                orig(self);
            };
        }
    }
}