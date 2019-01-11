using ColossalFramework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HideIt
{
    public static class NetPropsHelper
    {
        public static readonly string[] DELINEATORS = { "Delineator 01", "Delineator 02" };
        public static readonly string[] ROAD_ARROWS = { "Road Arrow F", "Road Arrow FR", "Road Arrow L", "Road Arrow LF", "Road Arrow LFR", "Road Arrow LR", "Road Arrow R" };
        public static readonly string TRAM_ARROWS = "Tram Arrow";
        public static readonly string BIKE_LANES = "Bike Lane";
        public static readonly string BUS_LANES = "Bus Lane";
        public static readonly string[] BUS_STOPS = { "Bus Stop Large", "Bus Stop Small" };
        public static readonly string[] SIGHTSEEING_BUS_STOP = { "Sightseeing Bus Stop Large", "Sightseeing Bus Stop Small" };
        public static readonly string TRAM_STOPS = "Tram Stop";
        public static readonly string[] RAILWAY_CROSSINGS = { "Railway Crossing Short", "Railway Crossing Medium", "Railway Crossing Long", "Railway Crossing Very Long" };
        public static readonly string STREET_NAME_SIGNS = "Street Name Sign";
        public static readonly string[] STOP_SIGNS = { "Stop Sign", "Tram Stop Sign" };
        public static readonly string[] TURN_SIGNS = { "No Left Turn Sign", "No Right Turn Sign" };
        public static readonly string[] SPEED_LIMIT_SIGNS = { "30 Speed Limit", "40 Speed Limit", "50 Speed Limit", "60 Speed Limit", "100 Speed Limit" };
        public static readonly string NO_PARKING_SIGNS = "No Parking Sign";
        public static readonly string[] HIGHWAY_SIGNS = { "Motorway Sign", "Motorway Overroad Signs" };
        public static readonly string[] RANDOM_STREET_DECORATIONS = { "Random Street Prop", "Random Street Prop NoParking", "Random Industrial Street Prop" };
        public static readonly string PEDESTRIAN_AND_BIKE_STREET_LIGHTS = "StreetLamp02";
        public static readonly string[] ROAD_STREET_LIGHTS = { "New Street Light", "New Street Light Small Road", "Industry Road Light Single", "Industry Road Light Single Medium" };
        public static readonly string[] AVENUE_STREET_LIGHTS = { "Avenue Light", "New Street Light Avenue", "Industry Road Light Double" };
        public static readonly string HIGHWAY_STREET_LIGHTS = "New Street Light Highway";
        public static readonly string RUNWAY_LIGHTS = "Runway Light";
        public static readonly string TAXIWAY_LIGHTS = "Taxiway Light";
        public static readonly string WARNING_LIGHTS = "Warning Light Orange";
        public static readonly string BUOYS = "Nautical Marker";

        private static readonly List<string> PROBABILITY25 = new List<string>() { "Random Street Prop", "Random Street Prop NoParking", "Random Industrial Street Prop" };

        private static readonly List<string> HAS_LIGHT_EFFECTS = new List<string>() { "Bus Stop Large", "Tram Stop", "StreetLamp02", "New Street Light", "New Street Light Small Road", "Industry Road Light Single", "Industry Road Light Single Medium", "Avenue Light", "New Street Light Avenue", "Industry Road Light Double", "New Street Light Highway", "Runway Light", "Taxiway Light", "Warning Light Orange" };

        public static void UpdateExistingSegmentsLightEffects()
        {
            try
            {
                NetSegment[] netSegments = Singleton<NetManager>.instance.m_segments.m_buffer;

                foreach (NetSegment netSegment in netSegments)
                {

                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] NetPropsHelper:UpdateExistingSegmentsLightEffects -> Exception: " + e.Message);
            }
        }

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
                Debug.Log("[Hide It!] NetPropsHelper:UpdateLaneProps -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] NetPropsHelper:UpdateLaneProps -> Exception: " + e.Message);
            }
        }

        private static void UpdateLaneProps(NetInfo netInfo, List<string> propNames, bool disable)
        {
            try
            {
                int probability;

                if (netInfo != null)
                {
                    foreach (NetInfo.Lane lane in netInfo.m_lanes)
                    {
                        if (lane?.m_laneProps != null)
                        {
                            foreach (NetLaneProps.Prop laneProp in lane.m_laneProps.m_props)
                            {
                                if (laneProp?.m_finalProp != null)
                                {
                                    if (propNames.Contains(laneProp.m_finalProp.name))
                                    {
                                        if (HAS_LIGHT_EFFECTS.Contains(laneProp.m_finalProp.name))
                                        {
                                            if (disable)
                                            {
                                                laneProp.m_finalProp.m_hasEffects = false;
                                                laneProp.m_finalProp.m_effectLayer = -1;
                                            }
                                            else
                                            {
                                                laneProp.m_finalProp.m_hasEffects = true;
                                                laneProp.m_finalProp.m_effectLayer = 24;
                                            }
                                        }

                                        probability = 100;

                                        if (PROBABILITY25.Contains(laneProp.m_finalProp.name))
                                        {
                                            probability = 25;
                                        }

                                        laneProp.m_probability = disable ? 0 : probability;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] NetPropsHelper:UpdateLaneProps -> Exception: " + e.Message);
            }
        }
    }
}
