﻿using CitiesHarmony.API;
using ICities;
using HideIt.Helpers;

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
            bool selected;

            group = helper.AddGroup(Name);

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

            if (!CompatibilityHelper.IsAnyPropAndTreeManipulatingModsEnabled())
            {
                group = helper.AddGroup("Props");

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
            }

            if (!CompatibilityHelper.IsAnySpriteManipulatingModsEnabled())
            {
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
            }

            if (!CompatibilityHelper.IsAnyPropAndTreeManipulatingModsEnabled())
            {
                group = helper.AddGroup("Ruining");

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

            }

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
    }
}