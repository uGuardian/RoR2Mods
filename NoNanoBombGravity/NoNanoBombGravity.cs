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
        "1.0.0")]

    public class NoNanoBombGravity:BaseUnityPlugin
    {
        public void Awake()
        {
            On.RoR2.AntiGravityForce.FixedUpdate += (orig, self) =>
            {
                self.antiGravityCoefficient = 1;
                orig(self);
            };
        }
    }
}