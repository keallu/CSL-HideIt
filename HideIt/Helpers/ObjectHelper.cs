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
                Debug.Log("[Hide It!] ObjectHelper:RefreshSeagulls -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] ObjectHelper:RefreshWildlife -> Exception: " + e.Message);
            }
        }

        public static void RefreshLivestock()
        {
            try
            {
                if (Singleton<SimulationManager>.exists)
                {
                    Singleton<SimulationManager>.instance.AddAction(RefreshLivestockAction());
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] ObjectHelper:RefreshLivestock -> Exception: " + e.Message);
            }
        }

        public static void RefreshPets()
        {
            try
            {
                if (Singleton<SimulationManager>.exists)
                {
                    Singleton<SimulationManager>.instance.AddAction(RefreshPetsAction());
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] ObjectHelper:RefreshPets -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] ObjectHelper:RefreshSeagullsAction -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] ObjectHelper:RefreshWildlifeAction -> Exception: " + e.Message);
            }

            yield return null;
        }

        private static IEnumerator RefreshLivestockAction()
        {
            try
            {
                CitizenManager citizenManager = Singleton<CitizenManager>.instance;

                for (int i = 1; i < citizenManager.m_instances.m_buffer.Length; i++)
                {
                    if ((citizenManager.m_instances.m_buffer[i].m_flags & CitizenInstance.Flags.Created) != CitizenInstance.Flags.None)
                    {
                        if (citizenManager.m_instances.m_buffer[i].Info.m_citizenAI != null && citizenManager.m_instances.m_buffer[i].Info.m_citizenAI is LivestockAI)
                        {
                            citizenManager.ReleaseCitizenInstance((ushort)i);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] ObjectHelper:RefreshLivestockAction -> Exception: " + e.Message);
            }

            yield return null;
        }

        private static IEnumerator RefreshPetsAction()
        {
            try
            {
                CitizenManager citizenManager = Singleton<CitizenManager>.instance;

                for (int i = 1; i < citizenManager.m_instances.m_buffer.Length; i++)
                {
                    if ((citizenManager.m_instances.m_buffer[i].m_flags & CitizenInstance.Flags.Created) != CitizenInstance.Flags.None)
                    {
                        if (citizenManager.m_instances.m_buffer[i].Info.m_citizenAI != null && citizenManager.m_instances.m_buffer[i].Info.m_citizenAI is PetAI)
                        {
                            citizenManager.ReleaseCitizenInstance((ushort)i);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] ObjectHelper:RefreshPetsAction -> Exception: " + e.Message);
            }

            yield return null;
        }
    }
}
