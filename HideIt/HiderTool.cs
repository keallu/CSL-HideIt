using ColossalFramework;
using ColossalFramework.UI;
using System;
using UnityEngine;

namespace HideIt
{
    class HiderTool : MonoBehaviour
    {
        private bool _initialized;

        private UIComponent _component;
        private Color _defaultValidColor;
        private Color _defaultWarningColor;
        private Color _defaultErrorColor;
        private Color _defaultValidColorInfo;
        private Color _defaultWarningColorInfo;
        private Color _defaultErrorColorInfo;
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

        private void Awake()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderTool:Awake -> Exception: " + e.Message);
            }
        }

        private void OnEnable()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderTool:OnEnable -> Exception: " + e.Message);
            }
        }

        private void Start()
        {
            try
            {
                ToolController toolController = ToolsModifierControl.toolController;

                _defaultValidColor = toolController.m_validColor;
                _defaultWarningColor = toolController.m_warningColor;
                _defaultErrorColor = toolController.m_errorColor;
                _defaultValidColorInfo = toolController.m_validColorInfo;
                _defaultWarningColorInfo = toolController.m_warningColorInfo;
                _defaultErrorColorInfo = toolController.m_errorColorInfo;

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
                Debug.Log("[Hide It!] HiderTool:Start -> Exception: " + e.Message);
            }
        }

        private void Update()
        {
            try
            {
                if (!_initialized || ModConfig.Instance.ConfigUpdated)
                {
                    ToggleUIComponent("InfoMenu", ModConfig.Instance.InfoViewsButton);
                    ToggleUIComponent("WarningPhasePanel", ModConfig.Instance.DisastersButton);
                    ToggleUIComponent("ChirperPanel", ModConfig.Instance.ChirperButton);
                    ToggleUIComponent("RadioPanel", ModConfig.Instance.RadioButton);
                    ToggleUIComponent("Esc", ModConfig.Instance.GearButton);
                    ToggleUIComponent("ZoomComposite", ModConfig.Instance.ZoomButton);
                    ToggleUIComponent("UnlockButton", ModConfig.Instance.UnlockButton);
                    ToggleUIComponent("AdvisorButton", ModConfig.Instance.AdvisorButton);
                    ToggleUIComponent("CinematicCameraPanel", ModConfig.Instance.CinematicCameraButton);
                    ToggleUIComponent("Freecamera", ModConfig.Instance.FreeCameraButton);
                    ToggleNotifications(ModConfig.Instance.Notifications);
                    ToggleLineBorders(ModConfig.Instance.LineBorders);
                    ToggleCameraBorders(ModConfig.Instance.CameraBorders);
                    ToggleDistrictNames(ModConfig.Instance.DistrictNames);
                    ToggleBuoys(ModConfig.Instance.Buoys);
                    ToggleToolColor(ModConfig.Instance.ValidColor, ModConfig.Instance.WarningColor, ModConfig.Instance.ErrorColor, ModConfig.Instance.ValidColorInfo, ModConfig.Instance.WarningColorInfo, ModConfig.Instance.ErrorColorInfo);
                    ToggleDecorations(ModConfig.Instance.CliffDecorations, ModConfig.Instance.FertileDecorations, ModConfig.Instance.GrassDecorations);
                    ToggleRuining(ModConfig.Instance.TreeRuining, ModConfig.Instance.PropRuining);
                    ToggleGroundColor(ModConfig.Instance.GrassFertilityGroundColor, ModConfig.Instance.GrassFieldGroundColor, ModConfig.Instance.GrassForestGroundColor, ModConfig.Instance.GrassPollutionGroundColor);
                    ToggleWaterColor(ModConfig.Instance.DirtyWaterColor);
                    ToggleFogEffects(ModConfig.Instance.PollutionFog, ModConfig.Instance.VolumeFog, ModConfig.Instance.DistanceFog, ModConfig.Instance.EdgeFog);

                    if (ModConfig.Instance.Seagulls)
                    {
                        HiderUtils.RefreshSeagulls();
                    }

                    if (ModConfig.Instance.Wildlife)
                    {
                        HiderUtils.RefreshWildlife();
                    }

                    HiderUtils.RefreshTexture();

                    _initialized = true;
                    ModConfig.Instance.ConfigUpdated = false;
                }

                InfoViewHelper.Instance.UpdateInfoView();
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderTool:Update -> Exception: " + e.Message);
            }
        }

        private void OnDisable()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderTool:OnDisable -> Exception: " + e.Message);
            }
        }

        private void OnDestroy()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderTool:OnDestroy -> Exception: " + e.Message);
            }
        }

        private void ToggleUIComponent(string name, bool disable)
        {
            try
            {
                _component = GameObject.Find(name).GetComponent<UIComponent>();

                if (_component != null)
                {
                    _component.enabled = !disable;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderTool:ToggleUIComponent -> Exception: " + e.Message);
            }
        }

        private void ToggleNotifications(bool disableNotifications)
        {
            try
            {
                Singleton<NotificationManager>.instance.NotificationsVisible = !disableNotifications;
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderTool:ToggleNotifications -> Exception: " + e.Message);
            }
        }

        private void ToggleLineBorders(bool disableLineBorders)
        {
            try
            {
                Singleton<GameAreaManager>.instance.BordersVisible = !disableLineBorders;
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderTool:ToggleLineBorders -> Exception: " + e.Message);
            }
        }

        private void ToggleCameraBorders(bool disableCameraBorders)
        {
            try
            {
                Camera.main.GetComponent<CameraController>().m_unlimitedCamera = disableCameraBorders;
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderTool:ToggleCameraBorders -> Exception: " + e.Message);
            }
        }

        private void ToggleDistrictNames(bool disableDistrictNames)
        {
            try
            {
                Singleton<DistrictManager>.instance.NamesVisible = !disableDistrictNames;
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderTool:ToggleDistrictNames -> Exception: " + e.Message);
            }
        }

        private void ToggleBuoys(bool disableBuoys)
        {
            try
            {
                NetInfo netInfo = PrefabCollection<NetInfo>.FindLoaded("Ferry Path");

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
                                        if (laneProp.m_finalProp.name == "Nautical Marker")
                                        {
                                            laneProp.m_probability = disableBuoys ? 0 : 100;
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
                Debug.Log("[Hide It!] HiderTool:ToggleBuoys -> Exception: " + e.Message);
            }
        }

        private void ToggleToolColor(bool disableValidColor, bool disableWarningColor, bool disableErrorColor, bool disableValidColorInfo, bool disableWarningColorInfo, bool disableErrorColorInfo)
        {
            try
            {
                ToolController toolController = ToolsModifierControl.toolController;

                if (toolController != null)
                {
                    toolController.m_validColor.a = disableValidColor ? 0f : _defaultValidColor.a;
                    toolController.m_warningColor.a = disableWarningColor ? 0f : _defaultWarningColor.a;
                    toolController.m_errorColor.a = disableErrorColor ? 0f : _defaultErrorColor.a;
                    toolController.m_validColorInfo.a = disableValidColorInfo ? 0f : _defaultValidColorInfo.a;
                    toolController.m_warningColorInfo.a = disableWarningColorInfo ? 0f : _defaultWarningColorInfo.a;
                    toolController.m_errorColorInfo.a = disableErrorColorInfo ? 0f : _defaultErrorColorInfo.a;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] HiderTool:ToggleToolColor -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] HiderTool:ToggleDecorations -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] HiderTool:ToggleRuining -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] HiderTool:ToggleGroundColor -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] HiderTool:ToggleWaterColor -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] HiderTool:ToggleFogEffects -> Exception: " + e.Message);
            }
        }
    }
}
