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
        public bool PauseButton { get; set; }
        public bool ZoomButton { get; set; }
        public bool UnlockButton { get; set; }
        public bool AdvisorButton { get; set; }
        public bool Notifications { get; set; }
        public bool Borders { get; set; }
        public bool DistrictNames { get; set; }
        public bool CliffDecorations { get; set; }
        public bool FertileDecorations { get; set; }
        public bool GrassDecorations { get; set; }
        public bool GrassFertilityGroundColor { get; set; }
        public bool GrassFieldGroundColor { get; set; }
        public bool GrassForestGroundColor { get; set; }
        public bool GrassPollutionGroundColor { get; set; }
        public bool DirtyWaterColor { get; set; }
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