using HarmonyLib;
using UnityEngine;
using UltraVoice.Utilities;

namespace UltraVoice.Characters
{
    public class MannequinCharacter
    {
        // Voice line storage
        public static AudioClip[] ChatterClips;
        public static AudioClip[] DeathClips;

        public static void LoadVoiceLines(AssetBundle bundle, BepInEx.Logging.ManualLogSource logger)
        {
            ChatterClips = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip(bundle, "mq_Laugh1"),
                UltraVoicePlugin.LoadClip(bundle, "mq_Laugh2"),
                UltraVoicePlugin.LoadClip(bundle, "mq_Laugh3"),
                UltraVoicePlugin.LoadClip(bundle, "mq_Laugh4"),
                UltraVoicePlugin.LoadClip(bundle, "mq_Laugh5")
            };

            DeathClips = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip(bundle, "mq_Death1"),
                UltraVoicePlugin.LoadClip(bundle, "mq_Death2"),
            };

            logger.LogInfo("Mannequin voice lines loaded successfully!");
        }

}

    // MANNEQUIN PATCHES

    [HarmonyPatch(typeof(Mannequin), "Update")]
    class MannequinChatterPatch
    {
        static void Postfix(Mannequin __instance)
        {
            if (!UltraVoicePlugin.MannequinVoiceEnabled.value) return;

            if (ULTRAKILL.Cheats.BlindEnemies.Blind)
                return;

            if (!VoiceManager.CheckCooldown(__instance, 4f))
                return;

            if (Random.Range(0f, 1f) < 0.75f)
                return;

            VoiceManager.PlayRandomVoice(__instance, "Mannequin",
                MannequinCharacter.ChatterClips,
                null
            );
        }
    }

    [HarmonyPatch(typeof(Mannequin), "MeleeAttack")]
    class MannequinSwingPatch
    {
        static void Postfix(Mannequin __instance)
        {
            if (!UltraVoicePlugin.MannequinVoiceEnabled.value) return;

            VoiceManager.PlayRandomVoice(__instance, "Mannequin",
                MannequinCharacter.ChatterClips,
                null
            );
        }
    }

    [HarmonyPatch(typeof(Mannequin), "OnDeath")]
    class MannequinDeathPatch
    {
        static void Postfix(Mannequin __instance)
        {
            if (!UltraVoicePlugin.MannequinVoiceEnabled.value) return;

            VoiceManager.PlayRandomVoice(__instance, "Mannequin",
                MannequinCharacter.DeathClips,
                null,
                true
            );
        }
    }
}