using ColossalFramework;
using System;
using System.Collections;
using UnityEngine;

namespace HideIt
{
    public static class HiderUtils
    {
        public static void RefreshSeagulls()
        {
            try
            {
                if (SimulationManager.exists)
                {
                    SimulationManager.instance.AddAction(RefreshSeagullsAction());
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderUtils:RefreshSeagulls -> Exception: " + e.Message);
            }
        }

        public static void RefreshWildlife()
        {
            try
            {
                if (SimulationManager.exists)
                {
                    SimulationManager.instance.AddAction(RefreshWildlifeAction());
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderUtils:RefreshWildlife -> Exception: " + e.Message);
            }
        }

        private static IEnumerator RefreshSeagullsAction()
        {
            try
            {
                CitizenManager citizenManager = Singleton<CitizenManager>.instance;

                for (int i = 1; i < citizenManager.m_instances.m_buffer.Length; i++)
                {
                    if ((citizenManager.m_instances.m_buffer[i].m_flags & CitizenInstance.Flags.Created) != CitizenInstance.Flags.None)
                    {
                        if (citizenManager.m_instances.m_buffer[i].Info.m_citizenAI != null && citizenManager.m_instances.m_buffer[i].Info.m_citizenAI is BirdAI)
                        {
                            citizenManager.ReleaseCitizenInstance((ushort)i);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderUtils:RefreshSeagullsAction -> Exception: " + e.Message);
            }

            yield return null;
        }

        private static IEnumerator RefreshWildlifeAction()
        {
            try
            {
                CitizenManager citizenManager = Singleton<CitizenManager>.instance;

                for (int i = 1; i < citizenManager.m_instances.m_buffer.Length; i++)
                {
                    if ((citizenManager.m_instances.m_buffer[i].m_flags & CitizenInstance.Flags.Created) != CitizenInstance.Flags.None)
                    {
                        if (citizenManager.m_instances.m_buffer[i].Info.m_citizenAI != null && citizenManager.m_instances.m_buffer[i].Info.m_citizenAI is WildlifeAI)
                        {
                            citizenManager.ReleaseCitizenInstance((ushort)i);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderUtils:RefreshWildlifeAction -> Exception: " + e.Message);
            }

            yield return null;
        }

        public static void RefreshTexture()
        {
            try
            {
                if (SimulationManager.exists)
                {
                    SimulationManager.instance.AddAction(RefreshTextureAction());
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderUtils:RefreshTexture -> Exception: " + e.Message);
            }
        }

        private static IEnumerator RefreshTextureAction()
        {
            try
            {
                if (NaturalResourceManager.exists)
                {
                    NaturalResourceManager.instance.AreaModified(0, 0, 511, 511);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderUtils:RefreshTextureAction -> Exception: " + e.Message);
            }

            yield return null;
        }
    }
}
