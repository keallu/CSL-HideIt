namespace HideIt
{
    [ConfigurationPath("HideItConfig.xml")]
    public class ModConfig
    {
        public bool ConfigUpdated { get; set; }
        public string Keymapping1 { get; set; } = "District Names";
        public string Keymapping2 { get; set; } = "Tool Colors";
        public string Keymapping3 { get; set; } = "Move It! Tool Colors";
        public bool KeymappingsEnabled { get; set; } = true;
        public bool NotificationIcons { get; set; }
        public bool DistrictNames { get; set; }
        public bool DistrictIcons { get; set; }
        public bool LineBorders { get; set; }
        public bool CameraBorders { get; set; }
        public bool ValidColor { get; set; }
        public bool WarningColor { get; set; }
        public bool ErrorColor { get; set; }
        public bool MoveItHoverColor { get; set; }
        public bool MoveItSelectedColor { get; set; }
        public bool MoveItMoveColor { get; set; }
        public bool MoveItRemoveColor { get; set; }
        public bool MoveItDespawnColor { get; set; }
        public bool MoveItAlignColor { get; set; }
        public bool MoveItPOHoverColor { get; set; }
        public bool MoveItPOSelectedColor { get; set; }
        public bool MoveItPODisabledColor { get; set; }
        public bool InfoViewsButton { get; set; }
        public bool DisastersButton { get; set; }
        public bool ChirperButton { get; set; }
        public bool RadioButton { get; set; }
        public bool GearButton { get; set; }
        public bool ZoomButton { get; set; }
        public bool UnlockButton { get; set; }
        public bool AdvisorButton { get; set; }
        public bool BulldozerButton { get; set; }
        public bool CinematicCameraButton { get; set; }
        public bool FreeCameraButton { get; set; }
        public bool Seagulls { get; set; }
        public bool Wildlife { get; set; }
        public bool Flags { get; set; }
        public bool Ads { get; set; }
        public bool Billboards { get; set; }
        public bool Neons { get; set; }
        public bool Logos { get; set; }
        public bool Smoke { get; set; }
        public bool Steam { get; set; }
        public bool SolarPanels { get; set; }
        public bool HvacSystems { get; set; }
        public bool ParkingSpaces { get; set; }
        public bool CargoContainers { get; set; }
        public bool GarbageContainers { get; set; }
        public bool GarbageBinsAndCans { get; set; }
        public bool GarbagePiles { get; set; }
        public bool Tanks { get; set; }
        public bool Barrels { get; set; }
        public bool Pallets { get; set; }
        public bool Crates { get; set; }
        public bool Planks { get; set; }
        public bool CableReels { get; set; }
        public bool Hedges { get; set; }
        public bool Fences { get; set; }
        public bool Gates { get; set; }
        public bool Delineators { get; set; }
        public bool RoadArrows { get; set; }
        public bool TramArrows { get; set; }
        public bool BikeLanes { get; set; }
        public bool BusLanes { get; set; }
        public bool BusStops { get; set; }
        public bool SightseeingBusStops { get; set; }
        public bool TramStops { get; set; }
        public bool RailwayCrossings { get; set; }
        public bool StreetNameSigns { get; set; }
        public bool StopSigns { get; set; }
        public bool TurnSigns { get; set; }
        public bool SpeedLimitSigns { get; set; }
        public bool NoParkingSigns { get; set; }
        public bool HighwaySigns { get; set; }
        public bool PedestrianAndBikeStreetLights { get; set; }
        public bool RoadStreetLights { get; set; }
        public bool AvenueStreetLights { get; set; }
        public bool HighwayStreetLights { get; set; }
        public bool RunwayLights { get; set; }
        public bool TaxiwayLights { get; set; }
        public bool WarningLights { get; set; }
        public bool RandomStreetDecorations { get; set; }
        public bool Buoys { get; set; }
        public bool CliffDecorations { get; set; }
        public bool FertileDecorations { get; set; }
        public bool GrassDecorations { get; set; }
        public bool TreeRuining { get; set; }
        public bool PropRuining { get; set; }
        public bool AutoUpdateTreeRuiningAtLoad { get; set; }
        public bool AutoUpdatePropRuiningAtLoad { get; set; }
        public bool GrassFertilityGroundColor { get; set; }
        public bool GrassFieldGroundColor { get; set; }
        public bool GrassForestGroundColor { get; set; }
        public bool GrassPollutionGroundColor { get; set; }
        public bool DirtyWaterColor { get; set; }
        public bool OreArea { get; set; }
        public bool OilArea { get; set; }
        public bool SandArea { get; set; }
        public bool FertilityArea { get; set; }
        public bool ForestArea { get; set; }
        public bool ShoreArea { get; set; }
        public bool PollutedArea { get; set; }
        public bool BurnedArea { get; set; }
        public bool DestroyedArea { get; set; }
        public bool PollutionFog { get; set; }
        public bool VolumeFog { get; set; }
        public bool DistanceFog { get; set; }
        public bool EdgeFog { get; set; }
        public bool ExportIncludeOnlyPropsWithEffects { get; set; }

        private static ModConfig instance;

        public static ModConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Configuration<ModConfig>.Load();
                }

                return instance;
            }
        }

        public void Save()
        {
            Configuration<ModConfig>.Save();
            ConfigUpdated = true;
        }
    }
}