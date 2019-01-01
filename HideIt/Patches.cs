using ColossalFramework;
using Harmony;
using System;
using System.Reflection;
using System.Threading;
using UnityEngine;

namespace HideIt
{
    [HarmonyPatch(typeof(CameraController), "UpdateFreeCamera")]
    public static class CameraControllerUpdateFreeCameraPatch
    {
        private static bool m_cachedFreeCamera;

        static void Prefix(CameraController __instance)
        {
            try
            {
                m_cachedFreeCamera = (bool)typeof(CameraController).GetField("m_cachedFreeCamera", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance);
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] CameraControllerUpdateFreeCameraPatch:Prefix -> Exception: " + e.Message);
            }
        }

        static void Postfix(CameraController __instance)
        {
            try
            {
                if (__instance.m_freeCamera != m_cachedFreeCamera)
                {
                    m_cachedFreeCamera = __instance.m_freeCamera;
                    Singleton<NotificationManager>.instance.NotificationsVisible = !ModConfig.Instance.NotificationIcons;
                    Singleton<GameAreaManager>.instance.BordersVisible = !ModConfig.Instance.LineBorders;
                    Singleton<DistrictManager>.instance.NamesVisible = !ModConfig.Instance.DistrictNames;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] CameraControllerUpdateFreeCameraPatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(CinematicCameraController), "SetUIVisible")]
    public static class CinematicCameraControllerSetUIVisiblePatch
    {
        static void Postfix(bool visible)
        {
            try
            {
                if (visible)
                {
                    Singleton<NotificationManager>.instance.NotificationsVisible = !ModConfig.Instance.NotificationIcons;
                    Singleton<GameAreaManager>.instance.BordersVisible = !ModConfig.Instance.LineBorders;
                    Singleton<DistrictManager>.instance.NamesVisible = !ModConfig.Instance.DistrictNames;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] CinematicCameraControllerSetUIVisiblePatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(CargoHarborAI), "CountAnimals")]
    public static class CargoHarborAICountAnimalsPatch
    {
        static int Postfix(int __result)
        {
            try
            {
                if (ModConfig.Instance.Seagulls)
                {
                    return int.MaxValue;
                }
                else
                {
                    return __result;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] CargoHarborAICountAnimalsPatch:Postfix -> Exception: " + e.Message);
                return __result;
            }
        }
    }

    [HarmonyPatch(typeof(HarborAI), "CountAnimals")]
    public static class HarborAICountAnimalsPatch
    {
        static int Postfix(int __result)
        {
            try
            {
                if (ModConfig.Instance.Seagulls)
                {
                    return int.MaxValue;
                }
                else
                {
                    return __result;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HarborAICountAnimalsPatch:Postfix -> Exception: " + e.Message);
                return __result;
            }
        }
    }

    [HarmonyPatch(typeof(IndustryBuildingAI), "CountAnimals")]
    public static class IndustryBuildingAICountAnimalsPatch
    {
        static int Postfix(int __result)
        {
            try
            {
                if (ModConfig.Instance.Seagulls)
                {
                    return int.MaxValue;
                }
                else
                {
                    return __result;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] IndustryBuildingAICountAnimalsPatch:Postfix -> Exception: " + e.Message);
                return __result;
            }
        }
    }

    [HarmonyPatch(typeof(LandfillSiteAI), "CountAnimals")]
    public static class LandfillSiteAICountAnimalsPatch
    {
        static int Postfix(int __result)
        {
            try
            {
                if (ModConfig.Instance.Seagulls)
                {
                    return int.MaxValue;
                }
                else
                {
                    return __result;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] LandfillSiteAICountAnimalsPatch:Postfix -> Exception: " + e.Message);
                return __result;
            }
        }
    }

    [HarmonyPatch(typeof(ParkAI), "CountAnimals")]
    public static class ParkAICountAnimalsPatch
    {
        static int Postfix(int __result)
        {
            try
            {
                if (ModConfig.Instance.Seagulls)
                {
                    return int.MaxValue;
                }
                else
                {
                    return __result;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] ParkAICountAnimalsPatch:Postfix -> Exception: " + e.Message);
                return __result;
            }
        }
    }

    [HarmonyPatch(typeof(ParkBuildingAI), "CountAnimals")]
    public static class ParkBuildingAICountAnimalsPatch
    {
        static int Postfix(int __result)
        {
            try
            {
                if (ModConfig.Instance.Seagulls)
                {
                    return int.MaxValue;
                }
                else
                {
                    return __result;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] ParkBuildingAICountAnimalsPatch:Postfix -> Exception: " + e.Message);
                return __result;
            }
        }
    }

    [HarmonyPatch(typeof(WarehouseAI), "CountAnimals")]
    public static class WarehouseAICountAnimalsPatch
    {
        static int Postfix(int __result)
        {
            try
            {
                if (ModConfig.Instance.Seagulls)
                {
                    return int.MaxValue;
                }
                else
                {
                    return __result;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] WarehouseAICountAnimalsPatch:Postfix -> Exception: " + e.Message);
                return __result;
            }
        }
    }

    [HarmonyPatch(typeof(WildlifeSpawnPointAI), "CountAnimals")]
    public static class WildlifeSpawnPointAICountAnimalsPatch
    {
        static int Postfix(int __result)
        {
            try
            {
                if (ModConfig.Instance.Wildlife)
                {
                    return int.MaxValue;
                }
                else
                {
                    return __result;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] WildlifeSpawnPointAICountAnimalsPatch:Postfix -> Exception: " + e.Message);
                return __result;
            }
        }
    }

    [HarmonyPatch(typeof(NaturalResourceManager), "UpdateTexture")]
    public static class NaturalResourceManagerUpdateTexturePatch
    {
        static bool Prefix(NaturalResourceManager __instance)
        {
            try
            {
                int[] m_modifiedX1 = (int[])typeof(NaturalResourceManager).GetField("m_modifiedX1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance);
                int[] m_modifiedX2 = (int[])typeof(NaturalResourceManager).GetField("m_modifiedX2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance);

                for (int i = 0; i < 512; i++)
                {
                    if (m_modifiedX2[i] >= m_modifiedX1[i])
                    {
                        while (!Monitor.TryEnter(__instance.m_naturalResources, SimulationManager.SYNCHRONIZE_TIMEOUT))
                        {
                        }
                        int num1;
                        int num2;
                        try
                        {
                            num1 = m_modifiedX1[i];
                            num2 = m_modifiedX2[i];
                            m_modifiedX1[i] = 10000;
                            m_modifiedX2[i] = -10000;
                        }
                        finally
                        {
                            Monitor.Exit(__instance.m_naturalResources);
                        }
                        for (int j = num1; j <= num2; j++)
                        {
                            Color color = default(Color);
                            if (i == 0 || j == 0 || i == 511 || j == 511)
                            {
                                color = new Color(0.5f, 0.5f, 0.5f, 0f);
                                InfoViewHelper.Instance.InfoViewResourceTexture.SetPixel(j, i, color);
                            }
                            else
                            {
                                int ore = 0;
                                int oil = 0;
                                int sand = 0;
                                int fertility = 0;
                                int forest = 0;
                                int shore = 0;

                                AddResource(j - 1, i - 1, 5, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j, i - 1, 7, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j + 1, i - 1, 5, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j - 1, i, 7, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j, i, 14, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j + 1, i, 7, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j - 1, i + 1, 5, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j, i + 1, 7, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);
                                AddResource(j + 1, i + 1, 5, ref ore, ref oil, ref sand, ref fertility, ref forest, ref shore);

                                color = CalculateColorComponents(ore, oil, sand, fertility, forest, shore);
                                InfoViewHelper.Instance.InfoViewResourceTexture.SetPixel(j, i, color);

                                ore = ModConfig.Instance.OreArea ? 0 : ore;
                                oil = ModConfig.Instance.OilArea ? 0 : oil;
                                sand = ModConfig.Instance.SandArea ? 0 : sand;
                                fertility = ModConfig.Instance.FertilityArea ? 0 : fertility;
                                forest = ModConfig.Instance.ForestArea ? 0 : forest;
                                shore = ModConfig.Instance.ShoreArea ? 0 : shore;

                                color = CalculateColorComponents(ore, oil, sand, fertility, forest, shore);
                            }
                            __instance.m_resourceTexture.SetPixel(j, i, color);
                        }
                    }
                }
                __instance.m_resourceTexture.Apply();

                InfoViewHelper.Instance.InfoViewResourceTexture.Apply();

                return false;
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] NaturalResourceManagerUpdateTexturePatch:Prefix -> Exception: " + e.Message);
                return true;
            }
        }

        private static Color CalculateColorComponents(int ore, int oil, int sand, int fertility, int forest, int shore)
        {
            Color color;

            color.r = (ore - oil + 15810) * 3.16255537E-05f;
            color.g = (sand - fertility + 15810) * 3.16255537E-05f;
            int num3 = shore * 4 - forest;
            if (num3 > 0)
            {
                color.b = (15810 + num3 / 4) * 3.16255537E-05f;
            }
            else
            {
                color.b = (15810 + num3) * 3.16255537E-05f;
            }
            color.a = 1f;

            return color;
        }

        private static void AddResource(int x, int z, int multiplier, ref int ore, ref int oil, ref int sand, ref int fertility, ref int forest, ref int shore)
        {
            try
            {
                x = Mathf.Clamp(x, 0, 511);
                z = Mathf.Clamp(z, 0, 511);
                NaturalResourceManager.ResourceCell resourceCell = Singleton<NaturalResourceManager>.instance.m_naturalResources[z * 512 + x];
                ore += resourceCell.m_ore * multiplier;
                oil += resourceCell.m_oil * multiplier;
                sand += resourceCell.m_sand * multiplier;
                fertility += resourceCell.m_fertility * multiplier;
                forest += resourceCell.m_forest * multiplier;
                shore += resourceCell.m_shore * multiplier;
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] NaturalResourceManagerUpdateTexturePatch:AddResource -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(NaturalResourceManager), "UpdateTextureB")]
    public static class NaturalResourceManagerUpdateTextureBPatch
    {
        static bool Prefix(NaturalResourceManager __instance)
        {
            try
            {
                int[] m_modifiedBX1 = (int[])typeof(NaturalResourceManager).GetField("m_modifiedBX1", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance);
                int[] m_modifiedBX2 = (int[])typeof(NaturalResourceManager).GetField("m_modifiedBX2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance);

                for (int i = 0; i < 512; i++)
                {
                    if (m_modifiedBX2[i] >= m_modifiedBX1[i])
                    {
                        while (!Monitor.TryEnter(__instance.m_naturalResources, SimulationManager.SYNCHRONIZE_TIMEOUT))
                        {
                        }
                        int num1;
                        int num2;
                        try
                        {
                            num1 = m_modifiedBX1[i];
                            num2 = m_modifiedBX2[i];
                            m_modifiedBX1[i] = 10000;
                            m_modifiedBX2[i] = -10000;
                        }
                        finally
                        {
                            Monitor.Exit(__instance.m_naturalResources);
                        }
                        for (int j = num1; j <= num2; j++)
                        {
                            Color color = default(Color);
                            if (i == 0 || j == 0 || i == 511 || j == 511)
                            {
                                color = new Color(0f, 0f, 0f, 1f);
                                InfoViewHelper.Instance.InfoViewDestructionTexture.SetPixel(j, i, color);
                            }
                            else
                            {
                                int pollution = 0;
                                int burned = 0;
                                int destroyed = 0;

                                AddResource(j - 1, i - 1, 5, ref pollution, ref burned, ref destroyed);
                                AddResource(j, i - 1, 7, ref pollution, ref burned, ref destroyed);
                                AddResource(j + 1, i - 1, 5, ref pollution, ref burned, ref destroyed);
                                AddResource(j - 1, i, 7, ref pollution, ref burned, ref destroyed);
                                AddResource(j, i, 14, ref pollution, ref burned, ref destroyed);
                                AddResource(j + 1, i, 7, ref pollution, ref burned, ref destroyed);
                                AddResource(j - 1, i + 1, 5, ref pollution, ref burned, ref destroyed);
                                AddResource(j, i + 1, 7, ref pollution, ref burned, ref destroyed);
                                AddResource(j + 1, i + 1, 5, ref pollution, ref burned, ref destroyed);

                                color = CalculateColorComponents(pollution, burned, destroyed);
                                InfoViewHelper.Instance.InfoViewDestructionTexture.SetPixel(j, i, color);

                                pollution = ModConfig.Instance.PollutedArea ? 0 : pollution;
                                burned = ModConfig.Instance.BurnedArea ? 0 : burned;
                                destroyed = ModConfig.Instance.DestroyedArea ? 0 : destroyed;

                                color = CalculateColorComponents(pollution, burned, destroyed);
                            }
                            __instance.m_destructionTexture.SetPixel(j, i, color);
                        }
                    }
                }
                __instance.m_destructionTexture.Apply();

                InfoViewHelper.Instance.InfoViewDestructionTexture.Apply();

                return false;
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] NaturalResourceManagerUpdateTextureBPatch:Prefix -> Exception: " + e.Message);
                return true;
            }
        }

        private static Color CalculateColorComponents(int pollution, int burned, int destroyed)
        {
            Color color;
            color.r = pollution * 6.325111E-05f;
            color.g = burned * 6.325111E-05f;
            color.b = destroyed * 6.325111E-05f;
            color.a = 1f;
            return color;
        }

        private static void AddResource(int x, int z, int multiplier, ref int pollution, ref int burned, ref int destroyed)
        {
            try
            {
                x = Mathf.Clamp(x, 0, 511);
                z = Mathf.Clamp(z, 0, 511);
                NaturalResourceManager.ResourceCell resourceCell = Singleton<NaturalResourceManager>.instance.m_naturalResources[z * 512 + x];
                pollution += resourceCell.m_pollution * multiplier;
                burned += resourceCell.m_burned * multiplier;
                destroyed += resourceCell.m_destroyed * multiplier;
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] NaturalResourceManagerUpdateTextureBPatch:AddResource -> Exception: " + e.Message);
            }
        }
    }
}
