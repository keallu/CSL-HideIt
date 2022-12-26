using System;
using System.Collections.Generic;
using UnityEngine;

namespace HideIt
{
    public static class BuildingPropsHelper
    {
        public static readonly string[] FLAGS = { "flag_pole", "flag_pole_wall" };

        public static readonly string[] ADS = {
            "cityad01",
            "cityad02",
            "roofad01",
            "roofad02",
            "roofad03",
            "roofad04",
            "roofad05",
            "roofad06",
            "roofad07",
            "roofad08",
            "roofad09",
            "roofad10",
            "roofad11",
            "roofad12",
            "sliding_ad01",
            "sliding_ad02",
            "street_ad01",
            "street_ad02",
            "street_ad03",
            "street_ad04",
            "street_ad05",
            "street_ad06",
            "street_ad07",
            "wall_ad01",
            "wall_ad02",
            "wall_ad03",
            "wall_ad04",
            "wall_ad05",
            "wall_ad06"
        };

        public static readonly string[] BILLBOARDS = {
            "Hologram Ad Game Arcade",
            "Clown",
            "Octopus",
            "Rotating_morelloscone",
            "Rotating_squirrel",
            "Billboard Large Variation 01",
            "Billboard Medium Variation 01",
            "Billboard_3D_variation",
            "Billboard_big_bigbite",
            "Billboard_big_bigbite_01",
            "Billboard_big_bigbite_02",
            "Billboard_big_bigbite_03",
            "billboard_big_Fallout",
            "billboard_big_Fallout_01",
            "billboard_big_Fallout_02",
            "billboard_big_Fallout_03",
            "billboard_big_Furniture",
            "billboard_big_Furniture_01",
            "billboard_big_Furniture_02",
            "billboard_big_Furniture_03",
            "Billboard_big_go_nuts",
            "Billboard_big_go_nuts_01",
            "Billboard_big_go_nuts_02",
            "Billboard_big_go_nuts_03",
            "Billboard_big_jubilee",
            "Billboard_big_jubilee_01",
            "Billboard_big_jubilee_02",
            "Billboard_big_jubilee_03",
            "Billboard_big_popsoda",
            "Billboard_big_popsoda_01",
            "Billboard_big_popsoda_02",
            "Billboard_big_popsoda_03",
            "billboard_big_realestate",
            "billboard_big_realestate_01",
            "billboard_big_Realestate_02",
            "billboard_big_realestate_03",
            "billboard_big_Sparkly",
            "billboard_big_Sparkly_01",
            "billboard_big_Sparkly_02",
            "billboard_big_Sparkly_03",
            "Billboard_big_variation",
            "Billboard_big_variation_01",
            "Billboard_big_variation_02",
            "Billboard_big_variation_03",
            "Billboard_big_variation_04",
            "Billboard_big_yakisoba",
            "Billboard_big_yakisoba_01",
            "Billboard_big_yakisoba_02",
            "Billboard_big_yakisoba_03",
            "Billboard_big_yaxu",
            "Billboard_big_yaxu_01",
            "Billboard_big_yaxu_02",
            "Billboard_big_yaxu_03",
            "Billboard_critter_anim",
            "Billboard_lehto_anim",
            "Billboard_medium_flat_bigbite_01",
            "Billboard_medium_flat_bigbite_02",
            "Billboard_medium_flat_go_nuts_01",
            "Billboard_medium_flat_go_nuts_02",
            "Billboard_medium_flat_variation_01",
            "Billboard_pop_soda_anim",
            "billboard_pylon",
            "Billboard_silky_anim",
            "Billboard_small_go_nuts_01",
            "Billboard_small_go_nuts_02",
            "Billboard_small_go_nuts_03",
            "Billboard_small_lehto_01",
            "Billboard_small_lehto_02",
            "Billboard_small_lehto_03",
            "Billboard_small_meaty_01",
            "Billboard_small_meaty_02",
            "Billboard_small_meaty_03",
            "Billboard_small_nightwatch_01",
            "Billboard_small_nightwatch_02",
            "Billboard_small_nightwatch_03",
            "Billboard_small_silky_01",
            "Billboard_small_silky_02",
            "Billboard_small_silky_03",
            "Billboard_small_variation_01",
            "Billboard_small_variation_02",
            "Billboard_small_variation_03",
            "billboard01",
            "billboard02",
            "billboard03",
            "Nightwatch_billboard_big_anim",
            "burnedbean_billboard_big_anim",
            "animated_billboard_big_anim_variation",
            "jubilee_billboard_big_anim",
            "Hightech Industrial Medium Billboard 01",
            "Hightech Industrial Medium Billboard 02",
            "Hightech Industrial Medium Billboard 03",
            "Hightech Industrial Medium Billboard 04",
            "Hightech Industrial Medium Billboard Random",
            "Hightech Industrial Small Billboard 01",
            "Hightech Industrial Small Billboard 02",
            "Hightech Industrial Small Billboard 03",
            "Hightech Industrial Small Billboard 04",
            "Hightech Industrial Small Billboard Random",
            "Organic Shop Medium Billboard 01",
            "Organic Shop Medium Billboard 02",
            "Organic Shop Medium Billboard 03",
            "Organic Shop Medium Billboard 04",
            "Organic Shop Medium Billboard 05",
            "Organic Shop Medium Billboard 06",
            "Organic Shop Medium Billboard 07",
            "Organic Shop Medium Billboard Random",
            "Organic Shop Small Billboard 01",
            "Organic Shop Small Billboard 02",
            "Organic Shop Small Billboard 03",
            "Organic Shop Small Billboard 04",
            "Organic Shop Small Billboard 05",
            "Organic Shop Small Billboard 06",
            "Organic Shop Small Billboard 07",
            "Organic Shop Small Billboard Random",
            "Park Billboard Large 01",
            "Park Billboard Medium 01",
            "Nature Reserve Billboard Large 01",
            "Nature Reserve Billboard Medium 01",
            "Amusement Park Billboard Large 01",
            "Amusement Park Billboard Medium 01",
            "Zoo Billboard Large 01",
            "Zoo Billboard Medium 01",
            "VS Sponsorship 01 Billboard Large 01",
            "VS Sponsorship 01 Billboard Medium 01",
            "VS Sponsorship 02 Billboard Large 01",
            "VS Sponsorship 02 Billboard Medium 01",
            "VS Sponsorship 03 Billboard Large 01",
            "VS Sponsorship 03 Billboard Medium 01",
            "VS Sponsorship 04 Billboard Large 01",
            "VS Sponsorship 04 Billboard Medium 01",
            "VS Sponsorship 05 Billboard Large 01",
            "VS Sponsorship 05 Billboard Medium 01",
            "VS Team 01 Billboard Large 01",
            "VS Team 01 Billboard Medium 01",
            "VS Team 02 Billboard Large 01",
            "VS Team 02 Billboard Medium 01",
            "VS Team 03 Billboard Large 01",
            "VS Team 03 Billboard Medium 01",
            "VS Team 04 Billboard Large 01",
            "VS Team 04 Billboard Medium 01",
            "VS Team 05 Billboard Large 01",
            "VS Team 05 Billboard Medium 01",
            "VS Team 06 Billboard Large 01",
            "VS Team 06 Billboard Medium 01",
            "VS Team 07 Billboard Large 01",
            "VS Team 07 Billboard Medium 01",
            "Festival Billboard Big 01",
            "Festival Billboard Big 02",
            "Festival Billboard Medium 01"
        };

        public static readonly string[] NEONS = {
            "neon-andys-bowling-alley",
            "neon-burned-bean-coffee",
            "neon-flaming-ring",
            "neon-go-nuts-doughnuts",
            "neon-morellos",
            "neon-open-sign",
            "neon-pinkunicorn",
            "neon-yakisoba-noodles"
        };

        public static readonly string[] LOGOS = {
            "Hightech Industrial Logo 01",
            "Hightech Industrial Logo 02",
            "Hightech Industrial Logo 03",
            "Hightech Industrial Logo 04",
            "Hightech Industrial Logo 05",
            "Hightech Industrial Logo 06",
            "Hightech Industrial Logo Random",
            "beergarden_sign",
            "Bigbite sign",
            "Organic Shop 3d Sign 02",
            "Organic Shop 3d Sign 03",
            "Organic Shop 3d Sign 04",
            "Logo_aukio",
            "Logo_banhammer",
            "Logo_barber",
            "Logo_bowling",
            "Logo_burned_bean",
            "Logo_cinema",
            "logo_colossalore",
            "Logo_commercial_variation",
            "Logo_commercial_variation01",
            "Logo_dino",
            "logo_dobbelbock",
            "Logo_electricity",
            "Logo_fault_tec",
            "Logo_flaming_ring",
            "logo_forestfoundation",
            "Logo_greed_grief",
            "Logo_industrial_variation",
            "Logo_itsy_bitsy",
            "Logo_jubilee",
            "Logo_lizard",
            "Logo_loimu",
            "Logo_mariina",
            "logo_mattockwinch",
            "logo_meatybits",
            "logo_morellos",
            "logo_myrtlebio",
            "Logo_neckbeard",
            "Logo_news",
            "Logo_nightwatch",
            "logo_office_random",
            "logo_orlysbookstore",
            "Logo_pernu",
            "Logo_plastimold",
            "Logo_radio",
            "logo_radiclean",
            "Logo_rapido",
            "Logo_silky",
            "Logo_sports",
            "Logo_square_packages",
            "Logo_steel_rhino",
            "Logo_sternberger",
            "Logo_sunnygrain",
            "logo_thelawaccounting",
            "logo_tyrell",
            "Logo_williams",
            "Random Commercial 1 Sign Long",
            "Random Commercial 1 Sign Long CRP Wireless",
            "Random Commercial 1 Sign Long Pernu",
            "Random Commercial 1 Sign Long Skytrust",
            "Random Commercial 1 Sign Long Vabor Vibez",
            "Random Commercial 2 Logo",
            "Random Commercial 2 Logo Cramburgers",
            "Random Commercial 2 Logo Custom Ts",
            "Random Commercial 2 Logo State City Insurance",
            "Random Commercial 2 Logo Game Go",
            "Random Commercial 3 Logo On Both Sides Records",
            "Random Commercial 3 Logo Other",
            "Random Commercial 3 Logo Other OK Sign",
            "Random Commercial 3 Logo RCI Sign",
            "Random Commercial 3 Logo Sparx",
            "Random Commercial 3 Logo Throwback Sign"
        };

        public static readonly string[] SMOKE = { "Factory Smoke", "Factory Smoke Small" };
        public static readonly string[] STEAM = { "Factory Steam", "Pool Steam", "Large Pool Steam" };
        public static readonly string[] SOLAR_PANELS = { "Horizontal Solar Panel 01", "Horizontal Solar Panel 02", "Solar panel 01", "Solar panel 02", "Solar panel 03" };
        public static readonly string[] HVAC_SYSTEMS = { "Ac box 01", "Ac box 02", "Ac box 03", "Ac box random", "Air Source Heat Pump 01", "Air Source Heat Pump 02", "Rotating ac", "Ventilation Pipe 01", "Ventilation Pipe 02" };
        public static readonly string[] PARKING_SPACES = { "Invisible Parking Space", "Parking Space", "Parking Space Electric", "Parking Spaces 01", "Parking Spaces 02" };
        public static readonly string[] ABANDONED_AND_DESTROYED_CARS = { "Abandoned Car 01", "Abandoned Car 02", "Destroyed Vehicle 01", "Destroyed Vehicle 02", "Destroyed Vehicle 03" };
        public static readonly string[] CARGO_CONTAINERS = { "Cargo container", "Cargo container - disaster response unit" };
        public static readonly string[] GARBAGE_CONTAINERS = { "Large Recycling Container 01", "Large Recycling Container 02", "Small Recycling Container 01", "Small Recycling Container 02", "Small Recycling Container 03", "Trash container 01" };
        public static readonly string[] GARBAGE_BINS_AND_CANS = { "Garbage Bin", "Park Trashbin 01", "Park Trashbin 02", "TrashCan01", "TrashCan02" };
        public static readonly string[] GARBAGE_PILES = { "Trashpile", "Trash Pile 02", "Trash Pile 04", "Trash Pile 05" };
        public static readonly string[] TANKS = { "Tank 01", "Tank 02", "Tank 03", "Tank 04" };
        public static readonly string[] BARRELS = { "Barrel 01", "Barrel 02", "Barrel 03", "Barrel 04", "Barrels" };
        public static readonly string[] PALLETS = { "Barrel Pallet 01", "Barrel Pallet 02", "Barrel Pallet 03", "Pallet 01", "Pallet 02", "Pallet 03", "Pallet 04" };
        public static readonly string[] CRATES = { "Crate 01", "Crate pile" };
        public static readonly string[] PLANKS = { "Plank pile", "Plank stack" };
        public static readonly string[] CABLE_REELS = { "Cable reel 01", "Cable reel 02" };
        public static readonly string[] HEDGES = { "hedge", "hedge2", "Hedge 01", "Hedge 02" };
        public static readonly string[] FENCES = { "Amusement Park Fence Queue", "Amusement Park Fence Small 8m", "Amusement Park Fence Small 16m", "Antelope Enclosure Fence 8m", "Antelope Enclosure Fence 16m", "Antelope Enclosure Fence Corner", "Bison Enclosure Fence 8m", "Chainlink Fence 8m", "Chainlink Fence 16m", "industrial_fence", "Modern Fence 01", "Modern Fence 02", "Prison fence", "Prison fence long", "Riding Stable Fence Long", "Riding Stable Fence Short", "Arena Fence 01", "Bamboo Fence 8m", "Bamboo Fence Tall 8m" };
        public static readonly string[] GATES = { "Antelope Enclosure Gate", "Chainlink Fence Gate", "industrial_gate", "Bamboo Fence Gate" };
        public static readonly string[] MAILBOXES = { "Mailbox01", "mailbox02", "High Mailbox" };
        public static readonly string[] CHAIRS = { "deck-chair", "High deck chair", "Folding Chair 01", "Folding Chair 02" };
        public static readonly string[] TABLES = { "table-set", "High Tableset", "Modern Table Set 01", "Park Tableset 01", "Park Tableset 02", "Prison table", "Rustic_Table", "Nature Reserve Tableset 01", "Nature Reserve Tableset 02", "Amusement Park Tableset 01", "Zoo Tableset 01", "Liberal Arts Table 01", "Trade School Table 01", "University Table 01" };
        public static readonly string[] PARASOLS = { "parasol", "High Parasol" };
        public static readonly string[] GRILLS = { "grill", "High Grill" };
        public static readonly string[] SANDBOXES = { "High Sandbox", "sandbox", "Sandbox 01", "Sandbox 02" };
        public static readonly string[] SWINGS = { "High Swing set", "swing-set" };
        public static readonly string[] SWIMMING_POOLS = { "Swimming pool", "High swimming pool" };
        public static readonly string[] POTS_AND_BEDS = { "High Flower Pot 01", "High Flower Pot 02", "High Flower Pot 03", "Flower pot 01", "Flower pot 02", "Flower pot 03", "Flower pot random", "High Flower Pot random", "Flowerpot 04", "Garden_pot", "Plant Pot 01", "Plant Pot 02", "Plant Pot 03", "Plant Pot 04", "Plant Pot 05", "Plant Pot 06", "Tree Sapling Field Pot 01", "Bonsai Pot 01", "Bonsai Pot 02", "Bamboo Pot 01", "Bamboo Pot 02", "Flowerbed 01", "Flowerbed 02", "Flowerbed 03", "Flowerbed 04" };

        private static readonly List<string> PROBABILITY77 = new List<string>() { "flag_pole", "flag_pole_wall", "Solar panel 01", "Solar panel 02", "Solar panel 03", "Ac box random" };
        private static readonly List<string> PROBABILITY88 = new List<string>() { "Rotating ac" };

        private static readonly List<string> HAS_LIGHT_EFFECTS = new List<string>() { "Billboard_pop_soda_anim" };

        public static void UpdateProps(List<string> enablePropNames, List<string> disablePropNames)
        {
            UpdateProps(enablePropNames, false);
            UpdateProps(disablePropNames, true);
        }

        public static void UpdateProp(string propName, bool disable)
        {
            List<string> propNames = new List<string>() { propName };

            UpdateProps(propNames, disable);
        }

        public static void UpdateProps(List<string> propNames, bool disable)
        {
            try
            {
                for (uint i = 0; i < PrefabCollection<BuildingInfo>.LoadedCount(); i++)
                {
                    var buildingInfo = PrefabCollection<BuildingInfo>.GetLoaded(i);

                    UpdateProps(buildingInfo, propNames, disable);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] BuildingPropsHelper:UpdateProps -> Exception: " + e.Message);
            }
        }

        public static void UpdateProp(string prefabName, string propName, bool disable)
        {
            List<string> propNames = new List<string>() { propName };

            UpdateProps(prefabName, propNames, disable);
        }

        public static void UpdateProps(string prefabName, List<string> propNames, bool disable)
        {
            try
            {
                BuildingInfo buildingInfo = PrefabCollection<BuildingInfo>.FindLoaded(prefabName);

                UpdateProps(buildingInfo, propNames, disable);
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] BuildingPropsHelper:UpdateProps -> Exception: " + e.Message);
            }
        }

        private static void UpdateProps(BuildingInfo buildingInfo, List<string> propNames, bool disable)
        {
            try
            {
                int probability;

                if (buildingInfo != null && buildingInfo.m_props != null)
                {
                    foreach (BuildingInfo.Prop prop in buildingInfo.m_props)
                    {
                        if (prop?.m_finalProp != null)
                        {
                            if (propNames.Contains(prop.m_finalProp.name))
                            {
                                if (HAS_LIGHT_EFFECTS.Contains(prop.m_finalProp.name))
                                {
                                    if (disable)
                                    {
                                        prop.m_finalProp.m_hasEffects = false;
                                        prop.m_finalProp.m_effectLayer = -1;
                                    }
                                    else
                                    {
                                        prop.m_finalProp.m_hasEffects = true;
                                        prop.m_finalProp.m_effectLayer = 24;
                                    }
                                }

                                probability = 100;

                                if (PROBABILITY77.Contains(prop.m_finalProp.name))
                                {
                                    probability = 77;
                                }
                                else if (PROBABILITY88.Contains(prop.m_finalProp.name))
                                {
                                    probability = 88;
                                }

                                prop.m_probability = disable ? 0 : probability;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] BuildingPropsHelper:UpdateProps -> Exception: " + e.Message);
            }
        }
    }
}
