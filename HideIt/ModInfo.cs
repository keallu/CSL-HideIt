﻿using CitiesHarmony.API;
using ICities;
using HideIt.Helpers;
using System.Reflection;

namespace HideIt
{
    public class ModInfo : IUserMod
    {
        public string Name => "Hide It!";
        public string Description => "Allows to hide unwanted things in the game.";

        public void OnEnabled()
        {
            HarmonyHelper.DoOnHarmonyReady(() => Patcher.PatchAll());
        }

        public void OnDisabled()
        {
            if (HarmonyHelper.IsHarmonyInstalled)
            {
                Patcher.UnpatchAll();
            }
        }

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group;

            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();

            group = helper.AddGroup(Name + " - " + assemblyName.Version.Major + "." + assemblyName.Version.Minor);

            bool selected;

            selected = ModConfig.Instance.EnforcePropsHiding;
            group.AddCheckbox("Enforce hiding of Props (not recommended for normal users)", selected, sel =>
            {
                ModConfig.Instance.EnforcePropsHiding = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.EnforceSpriteDecorationsHiding;
            group.AddCheckbox("Enforce hiding of Sprite Decorations (not recommended for normal users)", selected, sel =>
            {
                ModConfig.Instance.EnforceSpriteDecorationsHiding = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.EnforceRuiningsHiding;
            group.AddCheckbox("Enforce hiding of Ruinings (not recommended for normal users)", selected, sel =>
            {
                ModConfig.Instance.EnforceRuiningsHiding = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("User Interface");

            selected = ModConfig.Instance.PauseOutline;
            group.AddCheckbox("Pause Outline", selected, sel =>
            {
                ModConfig.Instance.PauseOutline = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.InfoViewsButton;
            group.AddCheckbox("Info Views Button", selected, sel =>
            {
                ModConfig.Instance.InfoViewsButton = sel;
                ModConfig.Instance.Save();
            });

            if (SteamHelper.IsDLCOwned(SteamHelper.DLC.NaturalDisastersDLC))
            {
                selected = ModConfig.Instance.DisastersButton;
                group.AddCheckbox("Disasters Button", selected, sel =>
                {
                    ModConfig.Instance.DisastersButton = sel;
                    ModConfig.Instance.Save();
                });
            }

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

            selected = ModConfig.Instance.CongratulationPanel;
            group.AddCheckbox("Congratulation Panel", selected, sel =>
            {
                ModConfig.Instance.CongratulationPanel = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AdvisorPanel;
            group.AddCheckbox("Advisor Panel", selected, sel =>
            {
                ModConfig.Instance.AdvisorPanel = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.TimePanel;
            group.AddCheckbox("Time Panel", selected, sel =>
            {
                ModConfig.Instance.TimePanel = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.NamePanel;
            group.AddCheckbox("Name Panel", selected, sel =>
            {
                ModConfig.Instance.NamePanel = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.DemandPanel;
            group.AddCheckbox("Demand Panel", selected, sel =>
            {
                ModConfig.Instance.DemandPanel = sel;
                ModConfig.Instance.Save();
            });

            if (SteamHelper.IsDLCOwned(SteamHelper.DLC.SnowFallDLC))
            {
                selected = ModConfig.Instance.HeatPanel;
                group.AddCheckbox("Heat Panel", selected, sel =>
                {
                    ModConfig.Instance.HeatPanel = sel;
                    ModConfig.Instance.Save();
                });
            }

            selected = ModConfig.Instance.IncomePanel;
            group.AddCheckbox("Income Panel", selected, sel =>
            {
                ModConfig.Instance.IncomePanel = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.PopulationPanel;
            group.AddCheckbox("Population Panel", selected, sel =>
            {
                ModConfig.Instance.PopulationPanel = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.HappinessPanel;
            group.AddCheckbox("Happiness Panel", selected, sel =>
            {
                ModConfig.Instance.HappinessPanel = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.ZoomAndUnlockBackground;
            group.AddCheckbox("Zoom and Unlock Background", selected, sel =>
            {
                ModConfig.Instance.ZoomAndUnlockBackground = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Separators;
            group.AddCheckbox("Separators in Toolbar", selected, sel =>
            {
                ModConfig.Instance.Separators = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Objects");

            selected = ModConfig.Instance.Birds;
            group.AddCheckbox("Birds", selected, sel =>
            {
                ModConfig.Instance.Birds = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Wildlife;
            group.AddCheckbox("Wildlife", selected, sel =>
            {
                ModConfig.Instance.Wildlife = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.RescueAnimals;
            group.AddCheckbox("Rescue Animals", selected, sel =>
            {
                ModConfig.Instance.RescueAnimals = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Livestock;
            group.AddCheckbox("Livestock", selected, sel =>
            {
                ModConfig.Instance.Livestock = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Pets;
            group.AddCheckbox("Pets", selected, sel =>
            {
                ModConfig.Instance.Pets = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup("Sounds");

            selected = ModConfig.Instance.NetsDrawSound;
            group.AddCheckbox("Networks Draw", selected, sel =>
            {
                ModConfig.Instance.NetsDrawSound = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AmbientWorldSound;
            group.AddCheckbox("Ambient World", selected, sel =>
            {
                ModConfig.Instance.AmbientWorldSound = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AmbientForestSound;
            group.AddCheckbox("Ambient Forest", selected, sel =>
            {
                ModConfig.Instance.AmbientForestSound = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AmbientSeaSound;
            group.AddCheckbox("Ambient Sea", selected, sel =>
            {
                ModConfig.Instance.AmbientSeaSound = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AmbientStreamSound;
            group.AddCheckbox("Ambient Stream", selected, sel =>
            {
                ModConfig.Instance.AmbientStreamSound = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AmbientIndustrialSound;
            group.AddCheckbox("Ambient Industrial", selected, sel =>
            {
                ModConfig.Instance.AmbientIndustrialSound = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AmbientPlazaSound;
            group.AddCheckbox("Ambient Plaza", selected, sel =>
            {
                ModConfig.Instance.AmbientPlazaSound = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AmbientSuburbanSound;
            group.AddCheckbox("Ambient Suburban", selected, sel =>
            {
                ModConfig.Instance.AmbientSuburbanSound = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AmbientCitySound;
            group.AddCheckbox("Ambient City", selected, sel =>
            {
                ModConfig.Instance.AmbientCitySound = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AmbientAgriculturalSound;
            group.AddCheckbox("Ambient Agricultural", selected, sel =>
            {
                ModConfig.Instance.AmbientAgriculturalSound = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AmbientLeisureSound;
            group.AddCheckbox("Ambient Leisure", selected, sel =>
            {
                ModConfig.Instance.AmbientLeisureSound = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AmbientTouristSound;
            group.AddCheckbox("Ambient Tourist", selected, sel =>
            {
                ModConfig.Instance.AmbientTouristSound = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AmbientRainSound;
            group.AddCheckbox("Ambient Rain", selected, sel =>
            {
                ModConfig.Instance.AmbientRainSound = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup($"Props{(CompatibilityHelper.IsAnyPropsAndTreesManipulatingModsEnabled() ? " (Disabled unless enforcement is selected)" : "")}");

            selected = ModConfig.Instance.Flags;
            group.AddCheckbox("Flags", selected, sel =>
            {
                ModConfig.Instance.Flags = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Ads;
            group.AddCheckbox("Ads", selected, sel =>
            {
                ModConfig.Instance.Ads = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Billboards;
            group.AddCheckbox("Billboards", selected, sel =>
            {
                ModConfig.Instance.Billboards = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Neons;
            group.AddCheckbox("Neons", selected, sel =>
            {
                ModConfig.Instance.Neons = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Logos;
            group.AddCheckbox("Logos", selected, sel =>
            {
                ModConfig.Instance.Logos = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Smoke;
            group.AddCheckbox("Smoke", selected, sel =>
            {
                ModConfig.Instance.Smoke = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Steam;
            group.AddCheckbox("Steam", selected, sel =>
            {
                ModConfig.Instance.Steam = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.SolarPanels;
            group.AddCheckbox("Solar Panels", selected, sel =>
            {
                ModConfig.Instance.SolarPanels = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.HvacSystems;
            group.AddCheckbox("HVAC Systems", selected, sel =>
            {
                ModConfig.Instance.HvacSystems = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.ParkingSpaces;
            group.AddCheckbox("Parking Spaces", selected, sel =>
            {
                ModConfig.Instance.ParkingSpaces = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AbandonedAndDestroyedCars;
            group.AddCheckbox("Abandoned and Destroyed Cars", selected, sel =>
            {
                ModConfig.Instance.AbandonedAndDestroyedCars = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.CargoContainers;
            group.AddCheckbox("Cargo Containers", selected, sel =>
            {
                ModConfig.Instance.CargoContainers = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.GarbageContainers;
            group.AddCheckbox("Garbage Containers", selected, sel =>
            {
                ModConfig.Instance.GarbageContainers = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.GarbageBinsAndCans;
            group.AddCheckbox("Garbage Bins and Cans", selected, sel =>
            {
                ModConfig.Instance.GarbageBinsAndCans = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.GarbagePiles;
            group.AddCheckbox("Garbage Piles", selected, sel =>
            {
                ModConfig.Instance.GarbagePiles = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Tanks;
            group.AddCheckbox("Tanks", selected, sel =>
            {
                ModConfig.Instance.Tanks = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Barrels;
            group.AddCheckbox("Barrels", selected, sel =>
            {
                ModConfig.Instance.Barrels = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Pallets;
            group.AddCheckbox("Pallets", selected, sel =>
            {
                ModConfig.Instance.Pallets = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Crates;
            group.AddCheckbox("Crates", selected, sel =>
            {
                ModConfig.Instance.Crates = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Planks;
            group.AddCheckbox("Planks", selected, sel =>
            {
                ModConfig.Instance.Planks = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.CableReels;
            group.AddCheckbox("Cable Reels", selected, sel =>
            {
                ModConfig.Instance.CableReels = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Hedges;
            group.AddCheckbox("Hedges", selected, sel =>
            {
                ModConfig.Instance.Hedges = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Fences;
            group.AddCheckbox("Fences", selected, sel =>
            {
                ModConfig.Instance.Fences = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Gates;
            group.AddCheckbox("Gates", selected, sel =>
            {
                ModConfig.Instance.Gates = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Mailboxes;
            group.AddCheckbox("Mailboxes", selected, sel =>
            {
                ModConfig.Instance.Mailboxes = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Chairs;
            group.AddCheckbox("Chairs", selected, sel =>
            {
                ModConfig.Instance.Chairs = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Tables;
            group.AddCheckbox("Tables", selected, sel =>
            {
                ModConfig.Instance.Tables = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Parasols;
            group.AddCheckbox("Parasols", selected, sel =>
            {
                ModConfig.Instance.Parasols = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Grills;
            group.AddCheckbox("Grills", selected, sel =>
            {
                ModConfig.Instance.Grills = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Sandboxes;
            group.AddCheckbox("Sandboxes", selected, sel =>
            {
                ModConfig.Instance.Sandboxes = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.Swings;
            group.AddCheckbox("Swings", selected, sel =>
            {
                ModConfig.Instance.Swings = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.SwimmingPools;
            group.AddCheckbox("Swimming Pools", selected, sel =>
            {
                ModConfig.Instance.SwimmingPools = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.PotsAndBeds;
            group.AddCheckbox("Pots and Beds", selected, sel =>
            {
                ModConfig.Instance.PotsAndBeds = sel;
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

            selected = ModConfig.Instance.Manholes;
            group.AddCheckbox("Manholes", selected, sel =>
            {
                ModConfig.Instance.Manholes = sel;
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

            selected = ModConfig.Instance.RunwayLights;
            group.AddCheckbox("Runway Lights", selected, sel =>
            {
                ModConfig.Instance.RunwayLights = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.TaxiwayLights;
            group.AddCheckbox("Taxiway Lights", selected, sel =>
            {
                ModConfig.Instance.TaxiwayLights = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.WarningLights;
            group.AddCheckbox("Warning Lights", selected, sel =>
            {
                ModConfig.Instance.WarningLights = sel;
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

            group = helper.AddGroup($"Sprite Decorations{(CompatibilityHelper.IsAnySpriteDecorationsManipulatingModsEnabled() ? " (Disabled unless enforcement is selected)" : "")}");

            selected = ModConfig.Instance.CliffDecoration;
            group.AddCheckbox("Cliff", selected, sel =>
            {
                ModConfig.Instance.CliffDecoration = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.GrassDecoration;
            group.AddCheckbox("Grass", selected, sel =>
            {
                ModConfig.Instance.GrassDecoration = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.FertileDecoration;
            group.AddCheckbox("Fertile", selected, sel =>
            {
                ModConfig.Instance.FertileDecoration = sel;
                ModConfig.Instance.Save();
            });

            group = helper.AddGroup($"Ruinings{(CompatibilityHelper.IsAnyPropsAndTreesManipulatingModsEnabled() ? " (Disabled unless enforcement is selected)" : "")}");

            selected = ModConfig.Instance.TreeRuining;
            group.AddCheckbox("Trees", selected, sel =>
            {
                ModConfig.Instance.TreeRuining = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.PropRuining;
            group.AddCheckbox("Props", selected, sel =>
            {
                ModConfig.Instance.PropRuining = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AutoUpdateTreeRuiningAtLoad;
            group.AddCheckbox("Automatic update existing trees at load", selected, sel =>
            {
                ModConfig.Instance.AutoUpdateTreeRuiningAtLoad = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.AutoUpdatePropRuiningAtLoad;
            group.AddCheckbox("Automatic update existing props at load", selected, sel =>
            {
                ModConfig.Instance.AutoUpdatePropRuiningAtLoad = sel;
                ModConfig.Instance.Save();
            });

            group.AddSpace(10);

            group.AddButton("Update ruining on existing trees and props in-game now!", () =>
            {
                RuiningHelper.UpdateExistingTreesRuining(ModConfig.Instance.TreeRuining);
                RuiningHelper.UpdateExistingPropsRuining(ModConfig.Instance.PropRuining);
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

            selected = ModConfig.Instance.BuildingsBulldoze;
            group.AddCheckbox("Buildings Bulldoze", selected, sel =>
            {
                ModConfig.Instance.BuildingsBulldoze = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.BuildingsPlacement;
            group.AddCheckbox("Buildings Placement", selected, sel =>
            {
                ModConfig.Instance.BuildingsPlacement = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.NetsBulldoze;
            group.AddCheckbox("Networks Bulldoze", selected, sel =>
            {
                ModConfig.Instance.NetsBulldoze = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.NetsPlacement;
            group.AddCheckbox("Networks Placement", selected, sel =>
            {
                ModConfig.Instance.NetsPlacement = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.PropsBulldoze;
            group.AddCheckbox("Props Bulldoze", selected, sel =>
            {
                ModConfig.Instance.PropsBulldoze = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.PropsPlacement;
            group.AddCheckbox("Props Placement", selected, sel =>
            {
                ModConfig.Instance.PropsPlacement = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.TreesBulldoze;
            group.AddCheckbox("Trees Bulldoze", selected, sel =>
            {
                ModConfig.Instance.TreesBulldoze = sel;
                ModConfig.Instance.Save();
            });

            selected = ModConfig.Instance.TreesPlacement;
            group.AddCheckbox("Trees Placement", selected, sel =>
            {
                ModConfig.Instance.TreesPlacement = sel;
                ModConfig.Instance.Save();
            });
        }
    }
}