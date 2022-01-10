using ColossalFramework;
using System;
using System.Collections;
using UnityEngine;

namespace HideIt
{
    public static class ObjectHelper
    {
        public static void RefreshSeagulls()
        {
            try
            {
                if (Singleton<SimulationManager>.exists)
                {
                    Singleton<SimulationManager>.instance.AddAction(RefreshSeagullsAction());
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] ModUtils:RefreshSeagulls -> Exception: " + e.Message);
            }
        }

        public static void RefreshWildlife()
        {
            try
            {
                if (Singleton<SimulationManager>.exists)
                {
                    Singleton<SimulationManager>.instance.AddAction(RefreshWildlifeAction());
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] ModUtils:RefreshWildlife -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] ModUtils:RefreshSeagullsAction -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] ModUtils:RefreshWildlifeAction -> Exception: " + e.Message);
            }

            yield return null;
        }
    }
}
