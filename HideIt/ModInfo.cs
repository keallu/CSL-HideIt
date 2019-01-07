using Harmony;
using ICities;
using System;
using System.Reflection;

namespace HideIt
{
    public class ModInfo : IUserMod
    {
        public string Name => "Hide It!";
        public string Description => "Allows to hide unwanted things in the game.";

        public void OnEnabled()
        {
            var harmony = HarmonyInstance.Create("com.github.keallu.csl.hideit");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void OnDisabled()
        {
            var harmony = HarmonyInstance.Create("com.github.keallu.csl.hideit");
            harmony.UnpatchAll();
        }

        private static readonly string[] KeymappingLabels =
        {
            "Notification Icons",
            "District Names",
            "District Icons",
            "Line Borders",
            "Camera Borders",
            "Tool Colors"
        };

        private static readonly string[] KeymappingValues =
        {
            "Notification Icons",
            "District Names",
            "District Icons",
            "Line Borders",
            "Camera Borders",
            "Tool Colors"
        };

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group;
            bool selected;
            int selectedIndex;

            group = helper.AddGroup(Name);

            selectedIndex = GetSelectedOptionIndex(KeymappingValues, ModConfig.Instance.Keymapping1);

            group.AddDropdown("LEFT CTRL + H", KeymappingLabels, selectedIndex, sel =>
            {
                ModConfig.Instance.Keymapping1 = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });

            selectedIndex = GetSelectedOptionIndex(KeymappingValues, ModConfig.Instance.Keymapping2);

            group.AddDropdown("LEFT CTRL + I", KeymappingLabels, selectedIndex, sel =>
            {
                ModConfig.Instance.Keymapping2 = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });

            selectedIndex = GetSelectedOptionIndex(KeymappingValues, ModConfig.Instance.Keymapping3);

            group.AddDropdown("LEFT CTRL + J", KeymappingLabels, selectedIndex, sel =>
            {
                ModConfig.Instance.Keymapping3 = KeymappingValues[sel];
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.KeymappingsEnabled;
            group.AddCheckbox("Keymappings enabled", selected, sel =>
            {
                ModConfig.Instance.KeymappingsEnabled = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Gameplay");

            selected = ModConfig.Instance.NotificationIcons;
            group.AddCheckbox("Notification Icons", selected, sel =>
            {
                ModConfig.Instance.NotificationIcons = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.DistrictNames;
            group.AddCheckbox("District Names", selected, sel =>
            {
                ModConfig.Instance.DistrictNames = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.DistrictIcons;
            group.AddCheckbox("District Icons", selected, sel =>
            {
                ModConfig.Instance.DistrictIcons = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.LineBorders;
            group.AddCheckbox("Line Borders", selected, sel =>
            {
                ModConfig.Instance.LineBorders = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.CameraBorders;
            group.AddCheckbox("Camera Borders", selected, sel =>
            {
                ModConfig.Instance.CameraBorders = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Tools");

            selected = ModConfig.Instance.ValidColor;
            group.AddCheckbox("Valid Color", selected, sel =>
            {
                ModConfig.Instance.ValidColor = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.WarningColor;
            group.AddCheckbox("Warning Color", selected, sel =>
            {
                ModConfig.Instance.WarningColor = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.ErrorColor;
            group.AddCheckbox("Error Color", selected, sel =>
            {
                ModConfig.Instance.ErrorColor = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.ValidColorInfo;
            group.AddCheckbox("Valid Color Info", selected, sel =>
            {
                ModConfig.Instance.ValidColorInfo = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.WarningColorInfo;
            group.AddCheckbox("Warning Color Info", selected, sel =>
            {
                ModConfig.Instance.WarningColorInfo = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.ErrorColorInfo;
            group.AddCheckbox("Error Color Info", selected, sel =>
            {
                ModConfig.Instance.ErrorColorInfo = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Buttons");

            selected = ModConfig.Instance.InfoViewsButton;
            group.AddCheckbox("Info Views Button", selected, sel =>
            {
                ModConfig.Instance.InfoViewsButton = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.DisastersButton;
            group.AddCheckbox("Disasters Button", selected, sel =>
            {
                ModConfig.Instance.DisastersButton = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.ChirperButton;
            group.AddCheckbox("Chirper Button", selected, sel =>
            {
                ModConfig.Instance.ChirperButton = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.RadioButton;
            group.AddCheckbox("Radio Button", selected, sel =>
            {
                ModConfig.Instance.RadioButton = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.GearButton;
            group.AddCheckbox("Gear Button", selected, sel =>
            {
                ModConfig.Instance.GearButton = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.ZoomButton;
            group.AddCheckbox("Zoom Button", selected, sel =>
            {
                ModConfig.Instance.ZoomButton = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.UnlockButton;
            group.AddCheckbox("Unlock Button", selected, sel =>
            {
                ModConfig.Instance.UnlockButton = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AdvisorButton;
            group.AddCheckbox("Advisor Button", selected, sel =>
            {
                ModConfig.Instance.AdvisorButton = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.BulldozerButton;
            group.AddCheckbox("Bulldozer Button", selected, sel =>
            {
                ModConfig.Instance.BulldozerButton = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.CinematicCameraButton;
            group.AddCheckbox("Cinematic Camera Button", selected, sel =>
            {
                ModConfig.Instance.CinematicCameraButton = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.FreeCameraButton;
            group.AddCheckbox("Free Camera Button", selected, sel =>
            {
                ModConfig.Instance.FreeCameraButton = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Objects & props");

            selected = ModConfig.Instance.Seagulls;
            group.AddCheckbox("Seagulls", selected, sel =>
            {
                ModConfig.Instance.Seagulls = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Wildlife;
            group.AddCheckbox("Wildlife", selected, sel =>
            {
                ModConfig.Instance.Wildlife = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Delineators;
            group.AddCheckbox("Delineators", selected, sel =>
            {
                ModConfig.Instance.Delineators = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.RoadArrows;
            group.AddCheckbox("Road Arrows", selected, sel =>
            {
                ModConfig.Instance.RoadArrows = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.TramArrows;
            group.AddCheckbox("Tram Arrows", selected, sel =>
            {
                ModConfig.Instance.TramArrows = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.BikeLanes;
            group.AddCheckbox("Bike Lanes", selected, sel =>
            {
                ModConfig.Instance.BikeLanes = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.BusLanes;
            group.AddCheckbox("Bus Lanes", selected, sel =>
            {
                ModConfig.Instance.BusLanes = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.BusStops;
            group.AddCheckbox("Bus Stops", selected, sel =>
            {
                ModConfig.Instance.BusStops = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.SightseeingBusStops;
            group.AddCheckbox("Sightseeing Bus Stops", selected, sel =>
            {
                ModConfig.Instance.SightseeingBusStops = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.TramStops;
            group.AddCheckbox("Tram Stops", selected, sel =>
            {
                ModConfig.Instance.TramStops = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.RailwayCrossings;
            group.AddCheckbox("Railway Crossings", selected, sel =>
            {
                ModConfig.Instance.RailwayCrossings = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.StreetNameSigns;
            group.AddCheckbox("Street Name Signs", selected, sel =>
            {
                ModConfig.Instance.StreetNameSigns = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.StopSigns;
            group.AddCheckbox("Stop Signs", selected, sel =>
            {
                ModConfig.Instance.StopSigns = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.TurnSigns;
            group.AddCheckbox("Turn Signs", selected, sel =>
            {
                ModConfig.Instance.TurnSigns = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.SpeedLimitSigns;
            group.AddCheckbox("Speed Limit Signs", selected, sel =>
            {
                ModConfig.Instance.SpeedLimitSigns = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.NoParkingSigns;
            group.AddCheckbox("No Parking Signs", selected, sel =>
            {
                ModConfig.Instance.NoParkingSigns = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.HighwaySigns;
            group.AddCheckbox("Highway Signs", selected, sel =>
            {
                ModConfig.Instance.HighwaySigns = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.PedestrianAndBikeStreetLights;
            group.AddCheckbox("Pedestrian and Bike Street Lights", selected, sel =>
            {
                ModConfig.Instance.PedestrianAndBikeStreetLights = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.RoadStreetLights;
            group.AddCheckbox("Road Street Lights", selected, sel =>
            {
                ModConfig.Instance.RoadStreetLights = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AvenueStreetLights;
            group.AddCheckbox("Avenue Street Lights", selected, sel =>
            {
                ModConfig.Instance.AvenueStreetLights = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.HighwayStreetLights;
            group.AddCheckbox("Highway Street Lights", selected, sel =>
            {
                ModConfig.Instance.HighwayStreetLights = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.RandomStreetDecorations;
            group.AddCheckbox("Random Street Decorations", selected, sel =>
            {
                ModConfig.Instance.RandomStreetDecorations = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Buoys;
            group.AddCheckbox("Buoys", selected, sel =>
            {
                ModConfig.Instance.Buoys = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Sprites");

            selected = ModConfig.Instance.CliffDecorations;
            group.AddCheckbox("Cliff Decorations", selected, sel =>
            {
                ModConfig.Instance.CliffDecorations = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.GrassDecorations;
            group.AddCheckbox("Grass Decorations", selected, sel =>
            {
                ModConfig.Instance.GrassDecorations = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.FertileDecorations;
            group.AddCheckbox("Fertile Decorations", selected, sel =>
            {
                ModConfig.Instance.FertileDecorations = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Ruining");

            selected = ModConfig.Instance.TreeRuining;
            group.AddCheckbox("Trees (requires reload to update existing trees)", selected, sel =>
            {
                ModConfig.Instance.TreeRuining = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.PropRuining;
            group.AddCheckbox("Props (requires reload to update existing props)", selected, sel =>
            {
                ModConfig.Instance.PropRuining = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Ground and Water Colors");

            selected = ModConfig.Instance.GrassFertilityGroundColor;
            group.AddCheckbox("Grass Fertility Ground Color", selected, sel =>
            {
                ModConfig.Instance.GrassFertilityGroundColor = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.GrassFieldGroundColor;
            group.AddCheckbox("Grass Field Ground Color", selected, sel =>
            {
                ModConfig.Instance.GrassFieldGroundColor = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.GrassForestGroundColor;
            group.AddCheckbox("Grass Forest Ground Color", selected, sel =>
            {
                ModConfig.Instance.GrassForestGroundColor = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.GrassPollutionGroundColor;
            group.AddCheckbox("Grass Pollution Ground Color", selected, sel =>
            {
                ModConfig.Instance.GrassPollutionGroundColor = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.DirtyWaterColor;
            group.AddCheckbox("Dirty Water Color", selected, sel =>
            {
                ModConfig.Instance.DirtyWaterColor = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Effects");

            selected = ModConfig.Instance.OreArea;
            group.AddCheckbox("Ore Area", selected, sel =>
            {
                ModConfig.Instance.OreArea = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.OilArea;
            group.AddCheckbox("Oil Area", selected, sel =>
            {
                ModConfig.Instance.OilArea = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.SandArea;
            group.AddCheckbox("Sand Area", selected, sel =>
            {
                ModConfig.Instance.SandArea = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.FertilityArea;
            group.AddCheckbox("Fertility Area", selected, sel =>
            {
                ModConfig.Instance.FertilityArea = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.ForestArea;
            group.AddCheckbox("Forest Area", selected, sel =>
            {
                ModConfig.Instance.ForestArea = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.ShoreArea;
            group.AddCheckbox("Shore Area", selected, sel =>
            {
                ModConfig.Instance.ShoreArea = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.PollutedArea;
            group.AddCheckbox("Polluted Area", selected, sel =>
            {
                ModConfig.Instance.PollutedArea = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.BurnedArea;
            group.AddCheckbox("Burned Area", selected, sel =>
            {
                ModConfig.Instance.BurnedArea = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.DestroyedArea;
            group.AddCheckbox("Destroyed Area", selected, sel =>
            {
                ModConfig.Instance.DestroyedArea = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.PollutionFog;
            group.AddCheckbox("Pollution Fog", selected, sel =>
            {
                ModConfig.Instance.PollutionFog = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.VolumeFog;
            group.AddCheckbox("Volume Fog", selected, sel =>
            {
                ModConfig.Instance.VolumeFog = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.DistanceFog;
            group.AddCheckbox("Distance Fog", selected, sel =>
            {
                ModConfig.Instance.DistanceFog = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.EdgeFog;
            group.AddCheckbox("Edge Fog", selected, sel =>
            {
                ModConfig.Instance.EdgeFog = sel;
                ModConfig.Instance.Save();
            });
        }

        private int GetSelectedOptionIndex(string[] option, string value)
        {
            int index = Array.IndexOf(option, value);
            if (index < 0) index = 0;

            return index;
        }
    }
}