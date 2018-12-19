using Harmony;
using ICities;
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

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group;
            bool selected;

            group = helper.AddGroup(Name);

            group.AddSpace(20);

            group = helper.AddGroup("Graphical User Interface");

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

            selected = ModConfig.Instance.PauseButton;
            group.AddCheckbox("Pause Button", selected, sel =>
            {
                ModConfig.Instance.PauseButton = sel;
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

            group = helper.AddGroup("Gameplay");

            selected = ModConfig.Instance.Notifications;
            group.AddCheckbox("Notifications", selected, sel =>
            {
                ModConfig.Instance.Notifications = sel;
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

            selected = ModConfig.Instance.DistrictNames;
            group.AddCheckbox("District Names", selected, sel =>
            {
                ModConfig.Instance.DistrictNames = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Objects");

            selected = ModConfig.Instance.Buoys;
            group.AddCheckbox("Buoys", selected, sel =>
            {
                ModConfig.Instance.Buoys = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Decorations");

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

            group = helper.AddGroup("Colors");

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
    }
}