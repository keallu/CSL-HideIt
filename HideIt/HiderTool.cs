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
                Debug.Log("[Hide It!] Hider:Awake -> Exception: " + e.Message);
            }
        }

        private void OnEnable()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] Hider:OnEnable -> Exception: " + e.Message);
            }
        }

        private void Start()
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
                Debug.Log("[Hide It!] Hider:Start -> Exception: " + e.Message);
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
                    ToggleUIComponent("Esc", ModConfig.Instance.PauseButton);
                    ToggleUIComponent("ZoomComposite", ModConfig.Instance.ZoomButton);
                    ToggleUIComponent("UnlockButton", ModConfig.Instance.UnlockButton);
                    ToggleUIComponent("AdvisorButton", ModConfig.Instance.AdvisorButton);
                    ToggleNotfications(ModConfig.Instance.Notifications);
                    ToggleBorders(ModConfig.Instance.Borders);
                    ToggleDistrictNames(ModConfig.Instance.DistrictNames);
                    ToggleDecorations(ModConfig.Instance.CliffDecorations, ModConfig.Instance.FertileDecorations, ModConfig.Instance.GrassDecorations);
                    ToggleGroundColor(ModConfig.Instance.GrassFertilityGroundColor, ModConfig.Instance.GrassFieldGroundColor, ModConfig.Instance.GrassForestGroundColor, ModConfig.Instance.GrassPollutionGroundColor);
                    ToggleWaterColor(ModConfig.Instance.DirtyWaterColor);
                    ToggleFogEffects(ModConfig.Instance.PollutionFog, ModConfig.Instance.VolumeFog, ModConfig.Instance.DistanceFog, ModConfig.Instance.EdgeFog);

                    _initialized = true;
                    ModConfig.Instance.ConfigUpdated = false;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] Hider:Update -> Exception: " + e.Message);
            }
        }

        private void OnDisable()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] Hider:OnDisable -> Exception: " + e.Message);
            }
        }

        private void OnDestroy()
        {
            try
            {
                
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] Hider:OnDestroy -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] Hider:ToggleUIComponent -> Exception: " + e.Message);
            }
        }

        private void ToggleNotfications(bool disableNotfications)
        {
            try
            {
                Singleton<NotificationManager>.instance.NotificationsVisible = !disableNotfications;
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] Hider:ToggleNotfications -> Exception: " + e.Message);
            }
        }

        private void ToggleBorders(bool disableBorders)
        {
            try
            {
                Singleton<GameAreaManager>.instance.BordersVisible = !disableBorders;
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] Hider:ToggleBorders -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] Hider:ToggleDistrictNames -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] Hider:ToggleDecorations -> Exception: " + e.Message);
            }
        }

        private void ToggleGroundColor(bool disableGrassFertility, bool disableGrassField, bool disableGrassForest, bool disableGrassPollution)
        {
            try
            {                
                Shader.SetGlobalVector("_GrassFertilityColorOffset", disableGrassFertility ? _noColorOffset : _defaultGrassFertilityColorOffset);
                Shader.SetGlobalVector("_GrassFieldColorOffset", disableGrassField ? _noColorOffset : _defaultGrassFieldColorOffset);
                Shader.SetGlobalVector("_GrassForestColorOffset", disableGrassForest ? _noColorOffset : _defaultGrassForestColorOffset);
                Shader.SetGlobalVector("_GrassPollutionColorOffset", disableGrassPollution ? _noColorOffset : _defaultGrassPollutionColorOffset);
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] Hider:ToggleGroundColor -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] Hider:ToggleWaterColor -> Exception: " + e.Message);
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
                Debug.Log("[Hide It!] Hider:ToggleFogEffects -> Exception: " + e.Message);
            }
        }
    }
}
