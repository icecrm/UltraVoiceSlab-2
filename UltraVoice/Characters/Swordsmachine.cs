using HarmonyLib;
using System.Collections;
using UnityEngine;
using UltraVoice.Utilities;

namespace UltraVoice.Characters
{
    public class SwordsmachineCharacter
    {
        // Voice line storage
        public static AudioClip IntroClip;
        public static AudioClip IntroClipSecond;
        public static AudioClip BigPainClip;
        public static AudioClip DeathClip;
        public static AudioClip KnockdownClipSpecial;

        public static AudioClip AgonySpawnClip;
        public static AudioClip TundraSpawnClip;
        public static AudioClip AgonyKnockdownClip;
        public static AudioClip TundraKnockdownClip;

        public static AudioClip[] SpawnClips;
        public static AudioClip[] EnrageClips;
        public static AudioClip[] KnockdownClips;
        public static AudioClip[] RangedClips;
        public static AudioClip[] LungeClips;
        public static AudioClip[] ComboClips;
        public static AudioClip[] SpiralClips;

        public static AudioClip IntroClipGarri;
        public static AudioClip IntroClipSecondGarri;
        public static AudioClip BigPainClipGarri;
        public static AudioClip DeathClipGarri;
        public static AudioClip KnockdownClipSpecialGarri;

        public static AudioClip AgonySpawnClipGarri;
        public static AudioClip TundraSpawnClipGarri;
        public static AudioClip AgonyKnockdownClipGarri;
        public static AudioClip TundraKnockdownClipGarri;

        public static AudioClip[] SpawnClipsGarri;
        public static AudioClip[] EnrageClipsGarri;
        public static AudioClip[] KnockdownClipsGarri;
        public static AudioClip[] RangedClipsGarri;
        public static AudioClip[] LungeClipsGarri;
        public static AudioClip[] ComboClipsGarri;
        public static AudioClip[] SpiralClipsGarri;

        // Subtitle storage
        public static readonly string[] EnrageSubs =
        {
            "YOU.",
            "GAH!",
            "AGH!",
            "UGH!"
        };

        public static readonly string[] EnrageSubs2 =
        {
            "YOU. I AM SO SICK OF YOU.",
            "SON OF A-!",
            null,
            null
        };

        public static readonly string[] SpawnSubs =
        {
            "THERE YOU ARE",
            "I WON'T GO EASY ON YOU!",
            "YEAH, LETS DO THIS!",
            "GUESS WHO!",
            "I'LL CUT YOU ALL DOWN!",
            "A FEAST FOR ROYALTY!",
            "LET'S CAUSE SOME MAYHEM!",
        };

        public static readonly string[] KnockdownSubs =
        {
            "[violent coughing]",
            "OWWWWWWWWWWWWWW",
            "AUGH"
        };

        public static readonly string[] RangedSubs =
        {
            "I'M GONNA NEED THIS BACK BY THE WAY",
            "OH I'M NOT DONE WITH YOU!",
        };
       
        public static readonly string[] SpiralSubs =
        {
            "HEY LOOK AT WHAT I CAN DO! [...] PRETTY COOL, HUH?",
            "HEADS!",
            "I SUGGEST YOU TAKE A BOW!",
        };
        
        public static readonly string[] ComboSubs =
        {
            "COMING THROUGH!",
            "‘SCUSE ME!",
            "OH YOU GET BACK HERE!",
        };
        public static readonly string[] LungeSubs =
        {
            "OUTTA MY WAY!",
            "DUCK THIS ONE!",
            "A LITTLE OFF THE TOP!",
        };

        public static UnityEngine.Color SwordsmachineColor = new UnityEngine.Color(0.91f, 0.6f, 0.05f);
        public static UnityEngine.Color AgonyColor = new UnityEngine.Color(0.79f, 0.17f, 0.17f);
        public static UnityEngine.Color TundraColor = new UnityEngine.Color(0.2f, 0.73f, 0.87f);

        public static bool FirstFightDone = false;
        public static bool FirstFightLinePlayed = false;

        public static bool IsAgony(SwordsMachine sm)
        {
            if (sm == null) return false;
            string n = sm.gameObject.name;
            return n.Contains("Agony");
        }

        public static bool IsTundra(SwordsMachine sm)
        {
            if (sm == null) return false;
            string n = sm.gameObject.name;
            return n.Contains("Tundra");
        }

        public static bool IsAgonyOrTundra(SwordsMachine sm)
        {
            return IsAgony(sm) || IsTundra(sm);
        }

        public static UnityEngine.Color? GetColorOverride(SwordsMachine sm)
        {
            if (IsAgony(sm))
                return AgonyColor;
            if (IsTundra(sm))
                return TundraColor;
            else return SwordsmachineColor;
        }

        public static AudioClip UseSwordsmachineClip(AudioClip EggsClip, AudioClip GarriClip)
        {
            return UltraVoicePlugin.SwordsmachineVoiceActorField != null && UltraVoicePlugin.SwordsmachineVoiceActorField.value == UltraVoicePlugin.SwordsmachineVoiceActor.Garri
                ? GarriClip
                : EggsClip;
        }

        public static AudioClip[] UseSwordsmachineClips(AudioClip[] EggsClips, AudioClip[] GarriClips)
        {
            return UltraVoicePlugin.SwordsmachineVoiceActorField != null && UltraVoicePlugin.SwordsmachineVoiceActorField.value == UltraVoicePlugin.SwordsmachineVoiceActor.Garri
                ? GarriClips
                : EggsClips;
        }

        public static void LoadVoiceLines(BepInEx.Logging.ManualLogSource logger)
        {
            IntroClip = UltraVoicePlugin.LoadClip("Swordsmachine.sm_SpawnSpecial.wav");
            IntroClipSecond = UltraVoicePlugin.LoadClip("Swordsmachine.sm_SpawnSpecial2.wav");
            BigPainClip = UltraVoicePlugin.LoadClip("Swordsmachine.sm_BigPain.wav");
            DeathClip = UltraVoicePlugin.LoadClip("Swordsmachine.sm_Death.wav");;
            KnockdownClipSpecial = UltraVoicePlugin.LoadClip("Swordsmachine.sm_KnockdownSpecial.wav");

            AgonySpawnClip = UltraVoicePlugin.LoadClip("Swordsmachine.sm_SpawnSpecialAgony.wav");
            TundraSpawnClip = UltraVoicePlugin.LoadClip("Swordsmachine.sm_SpawnSpecialTundra.wav");
            AgonyKnockdownClip = UltraVoicePlugin.LoadClip("Swordsmachine.sm_DownedAgony.wav");
            TundraKnockdownClip = UltraVoicePlugin.LoadClip("Swordsmachine.sm_DownedTundra.wav");

            SpawnClips = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn1.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn2.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn3.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn4.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn5.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn6.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn7.wav"),
            };

            EnrageClips = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Enrage1.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Enrage2.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Enrage3.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Enrage4.wav")
            };

            KnockdownClips = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Knockdown1.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Knockdown2.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Knockdown3.wav")
            };

            RangedClips = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Ranged1.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Ranged2.wav"),
            };
            ComboClips = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Combo1.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Combo2.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Combo3.wav"),
            };
            SpiralClips = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spiral1.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spiral2.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spiral3.wav"),
            };
            LungeClips = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Lunge1.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Lunge2.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Lunge3.wav"),
            };
            // I don't feel like changing all the file names from Noto to Garri aswell TBH, sorry future me! :-)
            IntroClipGarri = UltraVoicePlugin.LoadClip("Swordsmachine.sm_SpawnSpecialNoto.wav");
            IntroClipSecondGarri = UltraVoicePlugin.LoadClip("Swordsmachine.sm_SpawnSpecial2Noto.wav");
            BigPainClipGarri = UltraVoicePlugin.LoadClip("Swordsmachine.sm_BigPainNoto.wav");
            DeathClipGarri = UltraVoicePlugin.LoadClip("Swordsmachine.sm_DeathNoto.wav");
            KnockdownClipSpecialGarri = UltraVoicePlugin.LoadClip("Swordsmachine.sm_KnockdownSpecialNoto.wav");

            AgonySpawnClipGarri = UltraVoicePlugin.LoadClip("Swordsmachine.sm_SpawnSpecialAgonyNoto.wav");
            TundraSpawnClipGarri = UltraVoicePlugin.LoadClip("Swordsmachine.sm_SpawnSpecialTundraNoto.wav");
            AgonyKnockdownClipGarri = UltraVoicePlugin.LoadClip("Swordsmachine.sm_DownedAgonyNoto.wav");
            TundraKnockdownClipGarri = UltraVoicePlugin.LoadClip("Swordsmachine.sm_DownedTundraNoto.wav");

            SpawnClipsGarri = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn1Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn2Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn3Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn4Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn5Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn6Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spawn7Noto.wav")
            };

            EnrageClipsGarri = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Enrage1Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Enrage2Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Enrage3Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Enrage4Noto.wav")
            };

            KnockdownClipsGarri = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Knockdown1Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Knockdown2Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Knockdown3Noto.wav")
            };

            RangedClipsGarri = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Ranged1Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Ranged2Noto.wav"),
            };
            ComboClipsGarri = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Combo1Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Combo2Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Combo3Noto.wav"),
            };
            SpiralClipsGarri = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spiral1Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spiral2Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Spiral3Noto.wav"),
            };
            LungeClipsGarri = new AudioClip[]
            {
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Lunge1Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Lunge2Noto.wav"),
                UltraVoicePlugin.LoadClip("Swordsmachine.sm_Lunge3Noto.wav"),
            };

            logger.LogInfo("Swordsmachine voice lines loaded successfully!");
        }

    }

    // SWORDSMACHINE PATCHES

    [HarmonyPatch(typeof(SwordsMachine), "Start")]
    class SwordsmachineSpawnPatch
    {
        static void Postfix(SwordsMachine __instance)
        {
            VoiceManager.enemySpawnTimes[__instance] = Time.time;

            if (!UltraVoicePlugin.SwordsmachineVoiceEnabled.value)
                return;

            if (SwordsmachineCharacter.IsAgonyOrTundra(__instance))
                return;

            if (__instance.bossVersion)
            {
                if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "5bcb2e0461e7fce408badfcb6778c271") // Prelude Third Scene
                    return;

                UltraVoicePlugin.Instance.StartCoroutine(PlayBossIntro(__instance));
                return;
            }

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "7927c42db92e4164cae682a55e6b7725") // Prelude Second Scene
                return;

            VoiceManager.PlayRandomVoice(__instance, "Swordsmachine",
                SwordsmachineCharacter.UseSwordsmachineClips(SwordsmachineCharacter.SpawnClips, SwordsmachineCharacter.SpawnClipsGarri),
                SwordsmachineCharacter.SpawnSubs,
                true
            );
        }

        static IEnumerator PlayBossIntro(SwordsMachine sm)
        {
            yield return null;

            AudioClip clip;
            string subtitle;

            if (!SwordsmachineCharacter.FirstFightDone)
            {
                clip = SwordsmachineCharacter.UseSwordsmachineClip(SwordsmachineCharacter.IntroClip, SwordsmachineCharacter.IntroClipGarri);
                subtitle = "HAHA, GOTCHA! NOWHERE TO RUN NOW!";
            }
            else
            {
                clip = SwordsmachineCharacter.UseSwordsmachineClip(SwordsmachineCharacter.IntroClipSecond, SwordsmachineCharacter.IntroClipSecondGarri);
                subtitle = "DON’T EXPECT ME TO GO EASY ON YOU!";
            }

            var src = VoiceManager.CreateVoiceSource(sm, "SwordsmachineIntro", clip, subtitle, true);
            if (src != null)
            {
                VoiceManager.spawnVoiceEndTimes[sm] = Time.time + clip.length;
            }
        }
    }

    [HarmonyPatch(typeof(SwordsMachine), "Start")]
    class SwordsmachineSpecialSpawnPatch
    {
        static void Postfix(SwordsMachine __instance)
        {
            if (!UltraVoicePlugin.SwordsmachineVoiceEnabled.value)
                return;

            if (!SwordsmachineCharacter.IsAgonyOrTundra(__instance))
                return;

            VoiceManager.enemySpawnTimes[__instance] = Time.time;

            if (SwordsmachineCharacter.IsAgony(__instance))
            {
                VoiceManager.CreateVoiceSource(
                    __instance,
                    "AgonySpawn",
                    SwordsmachineCharacter.UseSwordsmachineClip(SwordsmachineCharacter.AgonySpawnClip, SwordsmachineCharacter.AgonySpawnClipGarri),
                    "SHOULDN'T'VE COME HERE!",
                    true,
                    SwordsmachineCharacter.AgonyColor
                );
            }
            else if (SwordsmachineCharacter.IsTundra(__instance))
            {
                VoiceManager.CreateVoiceSource(
                    __instance,
                    "TundraSpawn",
                    SwordsmachineCharacter.UseSwordsmachineClip(SwordsmachineCharacter.TundraSpawnClip, SwordsmachineCharacter.TundraSpawnClipGarri),
                    "THERE THEY ARE!",
                    true,
                    SwordsmachineCharacter.TundraColor
                );
            }
        }
    }

    [HarmonyPatch(typeof(SwordsMachine), "Enrage")]
    class SwordsmachineEnragePatch
    {
        static void Prefix(SwordsMachine __instance)
        {
            if (!UltraVoicePlugin.SwordsmachineVoiceEnabled.value)
                return;

            if (SwordsmachineCharacter.IsAgonyOrTundra(__instance))
                return;

            if (__instance.enraged)
                return;

            UltraVoicePlugin.Instance.StartCoroutine(PlayEnrage(__instance));
        }

        static IEnumerator PlayEnrage(SwordsMachine sm)
        {
            yield return new WaitForSeconds(0.75f);

            int i = UnityEngine.Random.Range(0, SwordsmachineCharacter.EnrageClips.Length);

            if (!sm.enraged)
                yield break;

            var src = VoiceManager.CreateVoiceSource(
                sm,
                "SwordsmachineEnrage",
                SwordsmachineCharacter.UseSwordsmachineClip(SwordsmachineCharacter.EnrageClips[i], SwordsmachineCharacter.EnrageClipsGarri[i]),
                SwordsmachineCharacter.EnrageSubs[i],
                true,
                SwordsmachineCharacter.GetColorOverride(sm)
            );

            if (src == null)
                yield break;

            if (!string.IsNullOrEmpty(SwordsmachineCharacter.EnrageSubs2[i]))
            {
                yield return new WaitForSeconds(0.75f);

                VoiceManager.ShowSubtitle(
                    SwordsmachineCharacter.EnrageSubs2[i],
                    src,
                    SwordsmachineCharacter.GetColorOverride(sm)
                );
            }
        }
    }

    [HarmonyPatch(typeof(SwordsMachine), "EndFirstPhase")]
    class SwordsmachinePhaseChangePatch
    {
        static void Postfix(SwordsMachine __instance)
        {
            if (!UltraVoicePlugin.SwordsmachineVoiceEnabled.value)
                return;

            if (SwordsmachineCharacter.IsAgonyOrTundra(__instance))
                return;

            VoiceManager.CreateVoiceSource(
                __instance,
                "SwordsmachineBigPain",
                SwordsmachineCharacter.UseSwordsmachineClip(SwordsmachineCharacter.BigPainClip, SwordsmachineCharacter.BigPainClipGarri),
                null,
                true
            );

            if (__instance.bossVersion && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "5bcb2e0461e7fce408badfcb6778c271" && __instance.difficulty <= 2 && !SwordsmachineCharacter.FirstFightLinePlayed)
                UltraVoicePlugin.Instance.StartCoroutine(PlayKnockdownSpecial(__instance));
            else
                UltraVoicePlugin.Instance.StartCoroutine(PlayKnockdown(__instance));
        }

        static IEnumerator PlayKnockdown(SwordsMachine sm)
        {
            yield return new WaitForSeconds(0.85f);

            int i = UnityEngine.Random.Range(0, SwordsmachineCharacter.KnockdownClips.Length);

            var src = VoiceManager.CreateVoiceSource(
                sm,
                "SwordsmachineKnockdown",
                SwordsmachineCharacter.UseSwordsmachineClip(SwordsmachineCharacter.KnockdownClips[i], SwordsmachineCharacter.KnockdownClipsGarri[i]),
                SwordsmachineCharacter.KnockdownSubs[i],
                true,
                SwordsmachineCharacter.GetColorOverride(sm)
            );
        }

        static IEnumerator PlayKnockdownSpecial(SwordsMachine sm)
        {
            SwordsmachineCharacter.FirstFightLinePlayed = true;
            yield return new WaitForSeconds(0.85f);

            var src = VoiceManager.CreateVoiceSource(
                sm,
                "SwordsmachineKnockdownSpecial",
                SwordsmachineCharacter.UseSwordsmachineClip(SwordsmachineCharacter.KnockdownClipSpecial, SwordsmachineCharacter.KnockdownClipSpecialGarri),
                "I’M NOT DONE WITH YOU!",
                true,
                SwordsmachineCharacter.GetColorOverride(sm)
            );
        }
    }

    [HarmonyPatch(typeof(SwordsMachine), "Knockdown")]
    class SwordsmachineKnockdownPatch
    {
        static void Postfix(SwordsMachine __instance)
        {
            if (!UltraVoicePlugin.SwordsmachineVoiceEnabled.value)
                return;

            if (!VoiceManager.CheckCooldown(__instance, 0.1f))
                return;

            VoiceManager.CreateVoiceSource(
                __instance,
                "SwordsmachineBigPain",
                SwordsmachineCharacter.UseSwordsmachineClip(SwordsmachineCharacter.BigPainClip, SwordsmachineCharacter.BigPainClipGarri),
                null,
                true
            );

            UltraVoicePlugin.Instance.StartCoroutine(PlaySpecialKnockdown(__instance));
        }

        static IEnumerator PlaySpecialKnockdown(SwordsMachine sm)
        {
            yield return new WaitForSeconds(0.75f);

            if (SwordsmachineCharacter.IsAgony(sm))
            {
                VoiceManager.CreateVoiceSource(
                    sm,
                    "AgonyKnockdown",
                    SwordsmachineCharacter.UseSwordsmachineClip(SwordsmachineCharacter.AgonyKnockdownClip, SwordsmachineCharacter.AgonyKnockdownClipGarri),
                    "STOP THEM!",
                    true,
                    SwordsmachineCharacter.AgonyColor
                );
            }
            else if (SwordsmachineCharacter.IsTundra(sm))
            {
                VoiceManager.CreateVoiceSource(
                    sm,
                    "TundraKnockdown",
                    SwordsmachineCharacter.UseSwordsmachineClip(SwordsmachineCharacter.TundraKnockdownClip, SwordsmachineCharacter.TundraKnockdownClipGarri),
                    "I'M HIT!",
                    true,
                    SwordsmachineCharacter.TundraColor
                );
            }
        }
    }

    [HarmonyPatch(typeof(SwordsMachine), "TeleportAway")]
    class SwordsmachineTeleportPatch
    {
        static void Postfix(SwordsMachine __instance)
        {
            SwordsmachineCharacter.FirstFightDone = true;
            VoiceManager.InterruptVoices(__instance);
        }
    }

    [HarmonyPatch(typeof(SwordsMachine), "ShootGun")]
    class SwordsmachineShotgunPatch
    {
        static void Postfix(SwordsMachine __instance)
        {
            if (!UltraVoicePlugin.SwordsmachineVoiceEnabled.value)
                return;

            if (!VoiceManager.CheckCooldown(__instance, 3f))
                return;

            if (VoiceManager.IsEnemyVoicePlaying(__instance))
                return;

            if (VoiceManager.TooSoonAfterSpawn(__instance, 2f))
                return;

            VoiceManager.PlayRandomVoice(__instance, "Swordsmachine",
                SwordsmachineCharacter.UseSwordsmachineClips(SwordsmachineCharacter.RangedClips, SwordsmachineCharacter.RangedClipsGarri),
                SwordsmachineCharacter.RangedSubs,
                colorOverride: SwordsmachineCharacter.GetColorOverride(__instance)
            );
        }
    }

    [HarmonyPatch(typeof(SwordsMachine), "SwordThrow")]
    class SwordsmachineSwordThrowPatch
    {
        static void Postfix(SwordsMachine __instance)
        {
            if (!UltraVoicePlugin.SwordsmachineVoiceEnabled.value)
                return;

            if (!VoiceManager.CheckCooldown(__instance, 3f))
                return;

            if (VoiceManager.IsEnemyVoicePlaying(__instance))
                return;

            if (VoiceManager.TooSoonAfterSpawn(__instance, 2f))
                return;

            VoiceManager.PlayRandomVoice(__instance, "Swordsmachine",
                SwordsmachineCharacter.UseSwordsmachineClips(SwordsmachineCharacter.RangedClips, SwordsmachineCharacter.RangedClipsGarri),
                SwordsmachineCharacter.RangedSubs,
                colorOverride: SwordsmachineCharacter.GetColorOverride(__instance)
            );
        }
    }

    [HarmonyPatch(typeof(SwordsMachine), "SwordSpiral")]
    class SwordsmachineSwordSpiralPatch
    {
        static void Postfix(SwordsMachine __instance)
        {
            if (!UltraVoicePlugin.SwordsmachineVoiceEnabled.value)
                return;

            if (!VoiceManager.CheckCooldown(__instance, 3f))
                return;

            if (VoiceManager.IsEnemyVoicePlaying(__instance))
                return;

            if (VoiceManager.TooSoonAfterSpawn(__instance, 2f))
                return;

            VoiceManager.PlayRandomVoice(__instance, "Swordsmachine",
                 SwordsmachineCharacter.UseSwordsmachineClips(SwordsmachineCharacter.SpiralClips, SwordsmachineCharacter.SpiralClipsGarri),
                 SwordsmachineCharacter.SpiralSubs,
                 colorOverride: SwordsmachineCharacter.GetColorOverride(__instance)
            );
        }
    }

    [HarmonyPatch(typeof(SwordsMachine), "Combo")]
    class SwordsmachineComboPatc
    {
        static void Postfix(SwordsMachine __instance)
        {
            if (!UltraVoicePlugin.SwordsmachineVoiceEnabled.value)
                return;

            if (!VoiceManager.CheckCooldown(__instance, 3f))
                return;

            if (VoiceManager.IsEnemyVoicePlaying(__instance))
                return;

            VoiceManager.PlayRandomVoice(__instance, "Swordsmachine",
                 SwordsmachineCharacter.UseSwordsmachineClips(SwordsmachineCharacter.ComboClips, SwordsmachineCharacter.ComboClipsGarri),
                 SwordsmachineCharacter.ComboSubs,
                 colorOverride: SwordsmachineCharacter.GetColorOverride(__instance)
            );
        }
    }

    [HarmonyPatch(typeof(SwordsMachine), "RunningSwing")]
    class SwordsmachineLungePatch
    {
        static void Postfix(SwordsMachine __instance)
        {
            if (!UltraVoicePlugin.SwordsmachineVoiceEnabled.value)
                return;

            if (!VoiceManager.CheckCooldown(__instance, 3f))
                return;

            if (VoiceManager.IsEnemyVoicePlaying(__instance))
                return;

            VoiceManager.PlayRandomVoice(__instance, "Swordsmachine",
                 SwordsmachineCharacter.UseSwordsmachineClips(SwordsmachineCharacter.LungeClips, SwordsmachineCharacter.LungeClipsGarri),
                 SwordsmachineCharacter.LungeSubs,
                 colorOverride: SwordsmachineCharacter.GetColorOverride(__instance)
            );
        }
    }

    [HarmonyPatch(typeof(SwordsMachine), "OnGoLimp")]
    class SwordsmachineDeathPatch
    {
        static void Postfix(SwordsMachine __instance)
        {
            if (!UltraVoicePlugin.SwordsmachineVoiceEnabled.value)
                return;

            VoiceManager.InterruptVoices(__instance);

            var src = VoiceManager.CreateVoiceSource(
                __instance,
                "SwordsmachineDeath",
                SwordsmachineCharacter.UseSwordsmachineClip(SwordsmachineCharacter.DeathClip, SwordsmachineCharacter.DeathClipGarri),
                null,
                true,
                subtitleColor: SwordsmachineCharacter.GetColorOverride(__instance)
            );
        }
    }
}