namespace HideIt
{
    [ConfigurationPath("HideItConfig.xml")]
    public class ModConfig
    {
        public bool ConfigUpdated { get; set; }
        public bool InfoViewsButton { get; set; }
        public bool DisastersButton { get; set; }
        public bool ChirperButton { get; set; }
        public bool RadioButton { get; set; }
        public bool GearButton { get; set; }
        public bool ZoomButton { get; set; }
        public bool UnlockButton { get; set; }
        public bool AdvisorButton { get; set; }
        public bool CinematicCameraButton { get; set; }
        public bool FreeCameraButton { get; set; }
        public bool Notifications { get; set; }
        public bool LineBorders { get; set; }
        public bool CameraBorders { get; set; }
        public bool DistrictNames { get; set; }
        public bool ValidColor { get; set; }
        public bool WarningColor { get; set; }
        public bool ErrorColor { get; set; }
        public bool ValidColorInfo { get; set; }
        public bool WarningColorInfo { get; set; }
        public bool ErrorColorInfo { get; set; }
        public bool Buoys { get; set; }
        public bool Seagulls { get; set; }
        public bool Wildlife { get; set; }
        public bool CliffDecorations { get; set; }
        public bool FertileDecorations { get; set; }
        public bool GrassDecorations { get; set; }
        public bool TreeRuining { get; set; }
        public bool PropRuining { get; set; }
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