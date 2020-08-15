using BepInEx;
using R2API;
using R2API.Utils;
using RoR2;
using UnityEngine;

namespace APIDependencies
{
    [BepInDependency("com.bepis.r2api")]

    [BepInPlugin(
        "com.uGuardian.APIDependencies",
        "APIDependencies",
        "1.0.0")]

    [R2APISubmoduleDependency(("ItemAPI"),("ItemDropAPI"),("AssetPlus"),("AssetAPI"),("Utils.CommandHelper"),("DifficultyAPI"),("EntityAPI"),("InventoryAPI"),("LoadoutAPI"),("LobbyConfigAPI"),("PlayerAPI"),("ResourcesAPI"),("SurvivorAPI"),("SkinAPI"),("SkillAPI"))]
    public class APIDependencies : BaseUnityPlugin
    {
        public void Awake() { Chat.AddMessage("APIDependencies stopgap fix loaded"); }
    }
}