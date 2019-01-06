using ColossalFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HideIt
{
    public static class HiderUtils
    {
        public static readonly string[] ROAD_ARROWS = { "Road Arrow F", "Road Arrow FR", "Road Arrow L", "Road Arrow LF", "Road Arrow LFR", "Road Arrow LR", "Road Arrow R" };
        public static readonly string TRAM_ARROWS = "Tram Arrow";
        public static readonly string BIKE_LANES = "Bike Lane";
        public static readonly string BUS_LANES = "Bus Lane";
        public static readonly string[] BUS_STOP = { "Bus Stop Large", "Bus Stop Small" };
        public static readonly string[] SIGHTSEEING_BUS_STOP = { "Sightseeing Bus Stop Large", "Sightseeing Bus Stop Small" };
        public static readonly string TRAM_STOP = "Tram Stop";
        public static readonly string BUOYS = "Nautical Marker";

        public static void UpdateLaneProps(List<string> enablePropNames, List<string> disablePropNames)
        {
            UpdateLaneProps(enablePropNames, false);
            UpdateLaneProps(disablePropNames, true);
        }

        public static void UpdateLaneProp(string propName, bool disable)
        {
            List<string> propNames = new List<string>() { propName };

            UpdateLaneProps(propNames, disable);
        }

        public static void UpdateLaneProps(List<string> propNames, bool disable)
        {
            try
            {
                for (uint i = 0; i < PrefabCollection<NetInfo>.LoadedCount(); i++)
                {
                    var netInfo = PrefabCollection<NetInfo>.GetLoaded(i);

                    UpdateLaneProps(netInfo, propNames, disable);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderUtils:UpdateLaneProp -> Exception: " + e.Message);
            }
        }

        public static void UpdateLaneProp(string prefabName, string propName, bool disable)
        {
            List<string> propNames = new List<string>() { propName };

            UpdateLaneProps(prefabName, propNames, disable);
        }

        public static void UpdateLaneProps(string prefabName, List<string> propNames, bool disable)
        {
            try
            {
                NetInfo netInfo = PrefabCollection<NetInfo>.FindLoaded(prefabName);

                UpdateLaneProps(netInfo, propNames, disable);
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderUtils:UpdateLaneProp -> Exception: " + e.Message);
            }
        }

        private static void UpdateLaneProps(NetInfo netInfo, List<string> propNames, bool disable)
        {
            try
            {
                if (netInfo != null)
                {
                    if (netInfo.m_lanes != null)
                    {
                        foreach (NetInfo.Lane lane in netInfo.m_lanes)
                        {
                            if (lane?.m_laneProps?.m_props != null)
                            {
                                foreach (NetLaneProps.Prop laneProp in lane.m_laneProps.m_props)
                                {
                                    if (laneProp != null)
                                    {
                                        if (propNames.Contains(laneProp.m_finalProp?.name))
                                        {
                                            laneProp.m_probability = disable ? 0 : 100;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderUtils:UpdateLaneProp -> Exception: " + e.Message);
            }
        }

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

        public static void UpdateExistingPropRuining(bool disableRuining)
        {
            try
            {
                PropInstance[] propInstances = Singleton<PropManager>.instance.m_props.m_buffer;

                float minX;
                float minZ;
                float maxX;
                float maxZ;

                foreach (PropInstance propInstance in propInstances)
                {
                    if ((propInstance.m_flags & 1) == 1 && (propInstance.m_flags & 4) == 0 && propInstance.Info != null)
                    {
                        propInstance.Info.m_createRuining = !disableRuining;

                        minX = propInstance.Position.x - 4.5f;
                        minZ = propInstance.Position.z - 4.5f;
                        maxX = propInstance.Position.x + 4.5f;
                        maxZ = propInstance.Position.z + 4.5f;
                        TerrainModify.UpdateArea(minX, minZ, maxX, maxZ, heights: false, surface: true, zones: false);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderUtils:UpdateExistingPropRuining -> Exception: " + e.Message);
            }
        }

        public static void UpdateExistingTreeRuining(bool disableRuining)
        {
            try
            {
                TreeInstance[] treeInstances = Singleton<TreeManager>.instance.m_trees.m_buffer;

                float minX;
                float minZ;
                float maxX;
                float maxZ;

                foreach (TreeInstance treeInstance in treeInstances)
                {
                    if ((treeInstance.m_flags & 1) == 1 && (treeInstance.m_flags & 4) == 0 && treeInstance.Info != null)
                    {
                        treeInstance.Info.m_createRuining = !disableRuining;

                        minX = treeInstance.Position.x - 4f;
                        minZ = treeInstance.Position.z - 4f;
                        maxX = treeInstance.Position.x + 4f;
                        maxZ = treeInstance.Position.z + 4f;
                        TerrainModify.UpdateArea(minX, minZ, maxX, maxZ, heights: false, surface: true, zones: false);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderUtils:UpdateExistingTreeRuining -> Exception: " + e.Message);
            }
        }
    }
}
