using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HideIt
{
    public class HideManager : MonoBehaviour
    {
        private bool _initialized;

        private TerrainProperties _terrainProperties;
        private Vector3 _noColorOffset;
        private Vector3 _defaultGrassFertilityColorOffset;
        private Vector3 _defaultGrassFieldColorOffset;
        private Vector3 _defaultGrassForestColorOffset;
        private Vector3 _defaultGrassPollutionColorOffset;
        private Color _defaultWaterColorClean;
        private Color _defaultWaterColorDirty;
        private FogProperties _fogProperties;
        private float _defaultPollutionAmount;
        private float _defaultFogDensity;
        private float _defaultColorDecay;

        public void Start()
        {
            try
            {
                _terrainProperties = FindObjectOfType<TerrainProperties>();

                _noColorOffset = new Vector3(0f, 0f, 0f);
                _defaultGrassFertilityColorOffset = Shader.GetGlobalVector("_GrassFertilityColorOffset");
                _defaultGrassFieldColorOffset = Shader.GetGlobalVector("_GrassFieldColorOffset");
                _defaultGrassForestColorOffset = Shader.GetGlobalVector("_GrassForestColorOffset");
                _defaultGrassPollutionColorOffset = Shader.GetGlobalVector("_GrassPollutionColorOffset");
                _defaultWaterColorClean = Shader.GetGlobalColor("_WaterColorClean");
                _defaultWaterColorDirty = Shader.GetGlobalColor("_WaterColorDirty");

                _fogProperties = FindObjectOfType<FogProperties>();

                if (_fogProperties != null)
                {
                    _defaultPollutionAmount = _fogProperties.m_PollutionAmount;
                    _defaultFogDensity = _fogProperties.m_FogDensity;
                    _defaultColorDecay = _fogProperties.m_ColorDecay;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HideManager:Start -> Exception: " + e.Message);
            }
        }

        public void Update()
        {
            try
            {
                if (!_initialized || ModConfig.Instance.ConfigUpdated)
                {
                    ToggleSingleUIComponent("InfoMenu", ModConfig.Instance.InfoViewsButton);
                    if (SteamHelper.IsDLCOwned(SteamHelper.DLC.NaturalDisastersDLC))
                    {
                        ToggleSingleUIComponent("WarningPhasePanel", ModConfig.Instance.DisastersButton);
                    }
                    ToggleSingleUIComponent("ChirperPanel", ModConfig.Instance.ChirperButton);
                    ToggleSingleUIComponent("RadioPanel", ModConfig.Instance.RadioButton);
                    ToggleSingleUIComponent("Esc", ModConfig.Instance.GearButton);
                    ToggleSingleUIComponent("ZoomComposite", ModConfig.Instance.ZoomButton);
                    ToggleSingleUIComponent("UnlockButton", ModConfig.Instance.UnlockButton);
                    ToggleSingleUIComponent("AdvisorButton", ModConfig.Instance.AdvisorButton);
                    ToggleSingleUIComponent("BulldozerButton", ModConfig.Instance.BulldozerButton);
                    ToggleSingleUIComponent("CinematicCameraPanel", ModConfig.Instance.CinematicCameraButton);
                    ToggleSingleUIComponent("Freecamera", ModConfig.Instance.FreeCameraButton);
                    ToggleSingleUIComponent("PanelTime", ModConfig.Instance.TimePanel);
                    ToggleSingleUIComponent("Sprite", "TSBar", ModConfig.Instance.ZoomAndUnlockBackground);
                    ToggleMultipleUIComponents("Separator", "MainToolstrip", ModConfig.Instance.Separators);
                    ToggleMultipleUIComponents("SmallSeparator", "MainToolstrip", ModConfig.Instance.Separators);
                    ToggleBuildingProps(
                        ModConfig.Instance.Flags,
                        ModConfig.Instance.Ads,
                        ModConfig.Instance.Billboards,
                        ModConfig.Instance.Neons,
                        ModConfig.Instance.Logos,
                        ModConfig.Instance.Smoke,
                        ModConfig.Instance.Steam,
                        ModConfig.Instance.SolarPanels,
                        ModConfig.Instance.HvacSystems,
                        ModConfig.Instance.ParkingSpaces,
                        ModConfig.Instance.AbandonedCars,
                        ModConfig.Instance.CargoContainers,
                        ModConfig.Instance.GarbageContainers,
                        ModConfig.Instance.GarbageBinsAndCans,
                        ModConfig.Instance.GarbagePiles,
                        ModConfig.Instance.Tanks,
                        ModConfig.Instance.Barrels,
                        ModConfig.Instance.Pallets,
                        ModConfig.Instance.Crates,
                        ModConfig.Instance.Planks,
                        ModConfig.Instance.CableReels,
                        ModConfig.Instance.Hedges,
                        ModConfig.Instance.Fences,
                        ModConfig.Instance.Gates);
                    ToggleNetProps(
                        ModConfig.Instance.Delineators,
                        ModConfig.Instance.RoadArrows,
                        ModConfig.Instance.TramArrows,
                        ModConfig.Instance.BikeLanes,
                        ModConfig.Instance.BusLanes,
                        ModConfig.Instance.BusStops,
                        ModConfig.Instance.SightseeingBusStops,
                        ModConfig.Instance.TramStops,
                        ModConfig.Instance.RailwayCrossings,
                        ModConfig.Instance.StreetNameSigns,
                        ModConfig.Instance.StopSigns,
                        ModConfig.Instance.TurnSigns,
                        ModConfig.Instance.SpeedLimitSigns,
                        ModConfig.Instance.NoParkingSigns,
                        ModConfig.Instance.HighwaySigns,
                        ModConfig.Instance.PedestrianAndBikeStreetLights,
                        ModConfig.Instance.RoadStreetLights,
                        ModConfig.Instance.AvenueStreetLights,
                        ModConfig.Instance.HighwayStreetLights,
                        ModConfig.Instance.RunwayLights,
                        ModConfig.Instance.TaxiwayLights,
                        ModConfig.Instance.WarningLights,
                        ModConfig.Instance.RandomStreetDecorations,
                        ModConfig.Instance.Buoys);
                    ToggleDecorations(
                        ModConfig.Instance.CliffDecorations,
                        ModConfig.Instance.FertileDecorations,
                        ModConfig.Instance.GrassDecorations);
                    ToggleRuining(
                        ModConfig.Instance.TreeRuining,
                        ModConfig.Instance.PropRuining);
                    ToggleGroundColor(
                        ModConfig.Instance.GrassFertilityGroundColor,
                        ModConfig.Instance.GrassFieldGroundColor,
                        ModConfig.Instance.GrassForestGroundColor,
                        ModConfig.Instance.GrassPollutionGroundColor);
                    ToggleWaterColor(ModConfig.Instance.DirtyWaterColor);
                    ToggleFogEffects(
                        ModConfig.Instance.PollutionFog,
                        ModConfig.Instance.VolumeFog,
                        ModConfig.Instance.DistanceFog,
                        ModConfig.Instance.EdgeFog);

                    if (ModConfig.Instance.Seagulls)
                    {
                        HideUtils.RefreshSeagulls();
                    }

                    if (ModConfig.Instance.Wildlife)
                    {
                        HideUtils.RefreshWildlife();
                    }

                    HideUtils.RefreshTexture();

                    _initialized = true;
                    ModConfig.Instance.ConfigUpdated = false;
                }

                InfoViewManager.Instance.UpdateInfoView();

            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HideManager:Update -> Exception: " + e.Message);
            }
        }

        private void ToggleSingleUIComponent(string name, bool disable)
        {
            try
            {
                UIComponent component = GameObject.Find(name).GetComponent<UIComponent>();

                if (component != null)
                {
                    component.isVisible = !disable;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HideManager:ToggleSingleUIComponent -> Exception: " + e.Message);
            }
        }

        private void ToggleSingleUIComponent(string name, string parentName, bool disable)
        {
            try
            {
                UIComponent parent = GameObject.Find(parentName).GetComponent<UIComponent>();

                if (parent != null)
                {
                    UIComponent component = parent.Find(name).GetComponent<UIComponent>();

                    if (component != null)
                    {
                        component.isVisible = !disable;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HideManager:ToggleSingleUIComponent -> Exception: " + e.Message);
            }
        }

        private void ToggleMultipleUIComponents(string name, string parentName, bool disable)
        {
            try
            {
                UIComponent parent = GameObject.Find(parentName).GetComponent<UIComponent>();

                if (parent != null)
                {
                    foreach (UIComponent component in parent.components)
                    {
                        if (component.name.Equals(name))
                        {
                            component.isVisible = !disable;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HideManager:ToggleMultipleUIComponents -> Exception: " + e.Message);
            }
        }

        private void ToggleBuildingProps(bool disableFlags, bool disableAds, bool disableBillboards, bool disableNeons, bool disableLogos, bool disableSmoke, bool disableSteam, bool disableSolarPanels, bool disableHvacSystems, bool disableParkingSpaces, bool disableAbandonedCars, bool disableCargoContainers, bool disableGarbageContainers, bool disableGarbageBinsAndCans, bool disableGarbagePiles, bool disableTanks, bool disableBarrels, bool disablePallets, bool disableCrates, bool disablePlanks, bool disableCableReels, bool disableHedges, bool disableFences, bool disableGates)
        {
            try
            {
                List<string> enablePropNames = new List<string>();
                List<string> disablePropNames = new List<string>();

                AddProps(disableFlags, BuildingPropsHelper.FLAGS, ref enablePropNames, ref disablePropNames);
                AddProps(disableAds, BuildingPropsHelper.ADS, ref enablePropNames, ref disablePropNames);
                AddProps(disableBillboards, BuildingPropsHelper.BILLBOARDS, ref enablePropNames, ref disablePropNames);
                AddProps(disableNeons, BuildingPropsHelper.NEONS, ref enablePropNames, ref disablePropNames);
                AddProps(disableLogos, BuildingPropsHelper.LOGOS, ref enablePropNames, ref disablePropNames);
                AddProps(disableSmoke, BuildingPropsHelper.SMOKE, ref enablePropNames, ref disablePropNames);
                AddProps(disableSteam, BuildingPropsHelper.STEAM, ref enablePropNames, ref disablePropNames);
                AddProps(disableSolarPanels, BuildingPropsHelper.SOLAR_PANELS, ref enablePropNames, ref disablePropNames);
                AddProps(disableHvacSystems, BuildingPropsHelper.HVAC_SYSTEMS, ref enablePropNames, ref disablePropNames);
                AddProps(disableParkingSpaces, BuildingPropsHelper.PARKING_SPACES, ref enablePropNames, ref disablePropNames);
                AddProps(disableAbandonedCars, BuildingPropsHelper.ABANDONED_CARS, ref enablePropNames, ref disablePropNames);
                AddProps(disableCargoContainers, BuildingPropsHelper.CARGO_CONTAINERS, ref enablePropNames, ref disablePropNames);
                AddProps(disableGarbageContainers, BuildingPropsHelper.GARBAGE_CONTAINERS, ref enablePropNames, ref disablePropNames);
                AddProps(disableGarbageBinsAndCans, BuildingPropsHelper.GARBAGE_BINS_AND_CANS, ref enablePropNames, ref disablePropNames);
                AddProps(disableGarbagePiles, BuildingPropsHelper.GARBAGE_PILES, ref enablePropNames, ref disablePropNames);
                AddProps(disableTanks, BuildingPropsHelper.TANKS, ref enablePropNames, ref disablePropNames);
                AddProps(disableBarrels, BuildingPropsHelper.BARRELS, ref enablePropNames, ref disablePropNames);
                AddProps(disablePallets, BuildingPropsHelper.PALLETS, ref enablePropNames, ref disablePropNames);
                AddProps(disableCrates, BuildingPropsHelper.CRATES, ref enablePropNames, ref disablePropNames);
                AddProps(disablePlanks, BuildingPropsHelper.PLANKS, ref enablePropNames, ref disablePropNames);
                AddProps(disableCableReels, BuildingPropsHelper.CABLE_REELS, ref enablePropNames, ref disablePropNames);
                AddProps(disableHedges, BuildingPropsHelper.HEDGES, ref enablePropNames, ref disablePropNames);
                AddProps(disableFences, BuildingPropsHelper.FENCES, ref enablePropNames, ref disablePropNames);
                AddProps(disableGates, BuildingPropsHelper.GATES, ref enablePropNames, ref disablePropNames);

                BuildingPropsHelper.UpdateProps(enablePropNames, disablePropNames);
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HideManager:ToggleBuildingProps -> Exception: " + e.Message);
            }
        }

        private void ToggleNetProps(bool disableDelineators, bool disableRoadArrows, bool disableTramArrows, bool disableBikeLanes, bool disableBusLanes, bool disableBusStops, bool disableSightseeingBusStops, bool disableTramStops, bool disableRailwayCrossings, bool disableStreetNameSigns, bool disableStopSigns, bool disableTurnSigns, bool disableSpeedLimitSigns, bool disableNoParkingSigns, bool disableHighwaySigns, bool disablePedestrianAndBikeStreetLights, bool disableRoadStreetLights, bool disableAvenueStreetLights, bool disableHighwayStreetLights, bool disableRunwayLights, bool disableTaxiwayLights, bool disableWarningLights, bool disableRandomStreetDecorations, bool disableBuoys)
        {
            try
            {
                List<string> enablePropNames = new List<string>();
                List<string> disablePropNames = new List<string>();

                AddProps(disableDelineators, NetPropsHelper.DELINEATORS, ref enablePropNames, ref disablePropNames);
                AddProps(disableRoadArrows, NetPropsHelper.ROAD_ARROWS, ref enablePropNames, ref disablePropNames);
                AddProps(disableTramArrows, NetPropsHelper.TRAM_ARROWS, ref enablePropNames, ref disablePropNames);
                AddProps(disableBikeLanes, NetPropsHelper.BIKE_LANES, ref enablePropNames, ref disablePropNames);
                AddProps(disableBusLanes, NetPropsHelper.BUS_LANES, ref enablePropNames, ref disablePropNames);
                AddProps(disableBusStops, NetPropsHelper.BUS_STOPS, ref enablePropNames, ref disablePropNames);
                AddProps(disableSightseeingBusStops, NetPropsHelper.SIGHTSEEING_BUS_STOP, ref enablePropNames, ref disablePropNames);
                AddProps(disableTramStops, NetPropsHelper.TRAM_STOPS, ref enablePropNames, ref disablePropNames);
                AddProps(disableRailwayCrossings, NetPropsHelper.RAILWAY_CROSSINGS, ref enablePropNames, ref disablePropNames);
                AddProps(disableStreetNameSigns, NetPropsHelper.STREET_NAME_SIGNS, ref enablePropNames, ref disablePropNames);
                AddProps(disableStopSigns, NetPropsHelper.STOP_SIGNS, ref enablePropNames, ref disablePropNames);
                AddProps(disableTurnSigns, NetPropsHelper.TURN_SIGNS, ref enablePropNames, ref disablePropNames);
                AddProps(disableSpeedLimitSigns, NetPropsHelper.SPEED_LIMIT_SIGNS, ref enablePropNames, ref disablePropNames);
                AddProps(disableNoParkingSigns, NetPropsHelper.NO_PARKING_SIGNS, ref enablePropNames, ref disablePropNames);
                AddProps(disableHighwaySigns, NetPropsHelper.HIGHWAY_SIGNS, ref enablePropNames, ref disablePropNames);
                AddProps(disablePedestrianAndBikeStreetLights, NetPropsHelper.PEDESTRIAN_AND_BIKE_STREET_LIGHTS, ref enablePropNames, ref disablePropNames);
                AddProps(disableRoadStreetLights, NetPropsHelper.ROAD_STREET_LIGHTS, ref enablePropNames, ref disablePropNames);
                AddProps(disableAvenueStreetLights, NetPropsHelper.AVENUE_STREET_LIGHTS, ref enablePropNames, ref disablePropNames);
                AddProps(disableHighwayStreetLights, NetPropsHelper.HIGHWAY_STREET_LIGHTS, ref enablePropNames, ref disablePropNames);
                AddProps(disableRunwayLights, NetPropsHelper.RUNWAY_LIGHTS, ref enablePropNames, ref disablePropNames);
                AddProps(disableTaxiwayLights, NetPropsHelper.TAXIWAY_LIGHTS, ref enablePropNames, ref disablePropNames);
                AddProps(disableWarningLights, NetPropsHelper.WARNING_LIGHTS, ref enablePropNames, ref disablePropNames);
                AddProps(disableRandomStreetDecorations, NetPropsHelper.RANDOM_STREET_DECORATIONS, ref enablePropNames, ref disablePropNames);
                AddProps(disableBuoys, NetPropsHelper.BUOYS, ref enablePropNames, ref disablePropNames);

                NetPropsHelper.UpdateLaneProps(enablePropNames, disablePropNames);
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HideManager:ToggleNetProps -> Exception: " + e.Message);
            }
        }

        private void AddProps(bool disable, string propName, ref List<string> enablePropNames, ref List<string> disablePropNames)
        {
            if (disable)
            {
                disablePropNames.Add(propName);
            }
            else
            {
                enablePropNames.Add(propName);
            }
        }

        private void AddProps(bool disable, string[] propNames, ref List<string> enablePropNames, ref List<string> disablePropNames)
        {
            if (disable)
            {
                disablePropNames.AddRange(propNames);
            }
            else
            {
                enablePropNames.AddRange(propNames);
            }
        }

        private void ToggleDecorations(bool disableCliff, bool disableFertile, bool disableGrass)
        {
            try
            {
                if (_terrainProperties != null)
                {
                    _terrainProperties.m_useCliffDecorations = !disableCliff;
                    _terrainProperties.m_useFertileDecorations = !disableFertile;
                    _terrainProperties.m_useGrassDecorations = !disableGrass;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HideManager:ToggleDecorations -> Exception: " + e.Message);
            }
        }

        private void ToggleRuining(bool disableTreeRuining, bool disablePropRuining)
        {
            try
            {
                TreeInfo treeInfo;

                for (uint i = 0; i < PrefabCollection<TreeInfo>.LoadedCount(); i++)
                {
                    treeInfo = PrefabCollection<TreeInfo>.GetPrefab(i);

                    if (treeInfo != null)
                    {
                        treeInfo.m_createRuining = !disableTreeRuining;
                    }
                }

                PropInfo propInfo;

                for (uint i = 0; i < PrefabCollection<PropInfo>.LoadedCount(); i++)
                {
                    propInfo = PrefabCollection<PropInfo>.GetPrefab(i);

                    if (propInfo != null)
                    {
                        propInfo.m_createRuining = !disablePropRuining;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HideManager:ToggleRuining -> Exception: " + e.Message);
            }
        }

        private void ToggleGroundColor(bool disableGrassFertility, bool disableGrassField, bool disableGrassForest, bool disableGrassPollution)
        {
            try
            {
                if (_terrainProperties != null)
                {
                    Shader.SetGlobalVector("_GrassFertilityColorOffset", disableGrassFertility ? _noColorOffset : _defaultGrassFertilityColorOffset);
                    Shader.SetGlobalVector("_GrassFieldColorOffset", disableGrassField ? _noColorOffset : _defaultGrassFieldColorOffset);
                    Shader.SetGlobalVector("_GrassForestColorOffset", disableGrassForest ? _noColorOffset : _defaultGrassForestColorOffset);
                    Shader.SetGlobalVector("_GrassPollutionColorOffset", disableGrassPollution ? new Vector4(_noColorOffset.x, _noColorOffset.y, _noColorOffset.z, _terrainProperties.m_cliffSandNormalTiling) : new Vector4(_defaultGrassPollutionColorOffset.x, _defaultGrassPollutionColorOffset.y, _defaultGrassPollutionColorOffset.z, _terrainProperties.m_cliffSandNormalTiling));
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HideManager:ToggleGroundColor -> Exception: " + e.Message);
            }
        }

        private void ToggleWaterColor(bool disableDirtyWater)
        {
            try
            {
                Shader.SetGlobalColor("_WaterColorDirty", disableDirtyWater ? _defaultWaterColorClean : _defaultWaterColorDirty);
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HideManager:ToggleWaterColor -> Exception: " + e.Message);
            }
        }

        private void ToggleFogEffects(bool disablePollution, bool disableVolume, bool disableDistance, bool disableEdge)
        {
            try
            {
                if (_fogProperties != null)
                {
                    _fogProperties.m_PollutionAmount = disablePollution ? 0f : _defaultPollutionAmount;
                    _fogProperties.m_FogDensity = disableVolume ? 0f : _defaultFogDensity;
                    _fogProperties.m_ColorDecay = disableDistance ? 1f : _defaultColorDecay;
                    _fogProperties.m_edgeFog = !disableEdge;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HideManager:ToggleFogEffects -> Exception: " + e.Message);
            }
        }
    }
}
