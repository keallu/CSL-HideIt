using System;
using System.IO;
using UnityEngine;

namespace HideIt
{
    public static class ExportUtils
    {
        public static void ExportBuildingInfoWithPropsToFile(string fileName, bool includeTimeStampInFileName, bool includeOnlyPropsWithEffects)
        {
            try
            {
                if (includeTimeStampInFileName)
                {
                    fileName = fileName + string.Format("-{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
                }

                using (StreamWriter sw = new StreamWriter(fileName + ".html"))
                {
                    sw.WriteLine(@"<!DOCTYPE html>");
                    sw.WriteLine(@"<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">");
                    sw.WriteLine(@"<head>");
                    sw.WriteLine(@"<meta charset=""utf-8"" />");
                    sw.WriteLine(@"<title>Hide It! - Cities: Skylines - List of BuildingInfo with Props</title>");
                    sw.WriteLine(@"<style>");
                    sw.WriteLine(@"table {border: 3px solid #000000;text-align: left;border-collapse: collapse;}");
                    sw.WriteLine(@"table td, table th {border: 1px solid #000000;padding: 5px 4px;}");
                    sw.WriteLine(@"table tbody td {font-size: 13px;}");
                    sw.WriteLine(@"table thead {background: #CFCFCF;border-bottom: 3px solid #000000;}");
                    sw.WriteLine(@"table thead th {font-size: 15px;font-weight: bold;color: #000000;text-align: left;}");
                    sw.WriteLine(@"</style>");
                    sw.WriteLine(@"</head>");
                    sw.WriteLine(@"<body>");
                    sw.WriteLine(@"<h1>Cities: Skylines - List of BuildingInfo with Props</h1>");
                    sw.WriteLine(@"<table>");
                    sw.WriteLine(@"<thead>");
                    sw.WriteLine(@"<tr>");
                    sw.WriteLine(@"<th>BuildingInfo</th>");
                    sw.WriteLine(@"<th>Prop</th>");
                    sw.WriteLine(@"<th>Probability</th>");
                    sw.WriteLine(@"<th>Effects</th>");
                    sw.WriteLine(@"<th>EffectLayer</th>");
                    sw.WriteLine(@"</tr>");
                    sw.WriteLine(@"<thead>");
                    sw.WriteLine(@"<tbody>");

                    for (uint i = 0; i < PrefabCollection<BuildingInfo>.LoadedCount(); i++)
                    {
                        BuildingInfo buildingInfo = PrefabCollection<BuildingInfo>.GetLoaded(i);

                        if (buildingInfo != null)
                        {
                            foreach (BuildingInfo.Prop prop in buildingInfo.m_props)
                            {
                                if (prop?.m_finalProp != null)
                                {
                                    if (includeOnlyPropsWithEffects && !prop.m_finalProp.m_hasEffects)
                                    {
                                        continue;
                                    }

                                    string effects = "";

                                    foreach (PropInfo.Effect effect in prop.m_finalProp.m_effects)
                                    {
                                        if (effect.m_effect != null)
                                        {
                                            if (effects.Length > 0)
                                            {
                                                effects += ", ";
                                            }

                                            effects += effect.m_effect.name;
                                        }
                                    }

                                    sw.WriteLine(@"<tr>");
                                    sw.WriteLine(@"<td>" + buildingInfo.name + @"</td>");
                                    sw.WriteLine(@"<td>" + prop.m_finalProp.name + @"</td>");
                                    sw.WriteLine(@"<td>" + prop.m_probability + @"</td>");
                                    sw.WriteLine(@"<td>" + effects + @"</td>");
                                    sw.WriteLine(@"<td>" + prop.m_finalProp.m_effectLayer + @"</td>");
                                    sw.WriteLine(@"</tr>");
                                }
                            }
                        }
                    }

                    sw.WriteLine(@"</tbody>");
                    sw.WriteLine(@"</table>");
                    sw.WriteLine(@"<p>This list was exported from Cities: Skylines with <a target=""_blank"" href=""https://steamcommunity.com/sharedfiles/filedetails/?id=1591417160""> Hide It!</a><p/>");
                    sw.WriteLine(@"</body>");
                    sw.WriteLine(@"</html>");
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] ExportUtils:ExportBuildingInfoWithPropsToFile -> Exception: " + e.Message);
            }
        }

        public static void ExportNetInfoWithLanePropsToFile(string fileName, bool includeTimeStampInFileName, bool includeOnlyPropsWithEffects)
        {
            try
            {
                if (includeTimeStampInFileName)
                {
                    fileName = fileName + string.Format("-{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
                }

                using (StreamWriter sw = new StreamWriter(fileName + ".html"))
                {
                    sw.WriteLine(@"<!DOCTYPE html>");
                    sw.WriteLine(@"<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">");
                    sw.WriteLine(@"<head>");
                    sw.WriteLine(@"<meta charset=""utf-8"" />");
                    sw.WriteLine(@"<title>Hide It! - Cities: Skylines - List of NetInfo with Lane Props</title>");
                    sw.WriteLine(@"<style>");
                    sw.WriteLine(@"table {border: 3px solid #000000;text-align: left;border-collapse: collapse;}");
                    sw.WriteLine(@"table td, table th {border: 1px solid #000000;padding: 5px 4px;}");
                    sw.WriteLine(@"table tbody td {font-size: 13px;}");
                    sw.WriteLine(@"table thead {background: #CFCFCF;border-bottom: 3px solid #000000;}");
                    sw.WriteLine(@"table thead th {font-size: 15px;font-weight: bold;color: #000000;text-align: left;}");
                    sw.WriteLine(@"</style>");
                    sw.WriteLine(@"</head>");
                    sw.WriteLine(@"<body>");
                    sw.WriteLine(@"<h1>Cities: Skylines - List of NetInfo with Lane Props</h1>");
                    sw.WriteLine(@"<table>");
                    sw.WriteLine(@"<thead>");
                    sw.WriteLine(@"<tr>");
                    sw.WriteLine(@"<th>NetInfo</th>");
                    sw.WriteLine(@"<th>Lane</th>");
                    sw.WriteLine(@"<th>Prop</th>");
                    sw.WriteLine(@"<th>Probability</th>");
                    sw.WriteLine(@"<th>Effects</th>");
                    sw.WriteLine(@"<th>EffectLayer</th>");
                    sw.WriteLine(@"</tr>");
                    sw.WriteLine(@"<thead>");
                    sw.WriteLine(@"<tbody>");

                    for (uint i = 0; i < PrefabCollection<NetInfo>.LoadedCount(); i++)
                    {
                        NetInfo netInfo = PrefabCollection<NetInfo>.GetLoaded(i);

                        if (netInfo?.m_lanes != null)
                        {
                            foreach (NetInfo.Lane lane in netInfo.m_lanes)
                            {
                                if (lane?.m_laneProps?.m_props != null)
                                {
                                    foreach (NetLaneProps.Prop laneProp in lane.m_laneProps.m_props)
                                    {
                                        if (laneProp?.m_finalProp != null)
                                        {
                                            if (includeOnlyPropsWithEffects && !laneProp.m_finalProp.m_hasEffects)
                                            {
                                                continue;
                                            }

                                            string effects = "";

                                            foreach (PropInfo.Effect effect in laneProp.m_finalProp.m_effects)
                                            {
                                                if (effects.Length > 0)
                                                {
                                                    effects += ", ";
                                                }

                                                effects += effect.m_effect.name;
                                            }

                                            sw.WriteLine(@"<tr>");
                                            sw.WriteLine(@"<td>" + netInfo.name + @"</td>");
                                            sw.WriteLine(@"<td>" + lane.m_laneType.ToString() + @"</td>");
                                            sw.WriteLine(@"<td>" + laneProp.m_finalProp.name + @"</td>");
                                            sw.WriteLine(@"<td>" + laneProp.m_probability + @"</td>");
                                            sw.WriteLine(@"<td>" + effects + @"</td>");
                                            sw.WriteLine(@"<td>" + laneProp.m_finalProp.m_effectLayer + @"</td>");
                                            sw.WriteLine(@"</tr>");
                                        }
                                    }
                                }
                            }
                        }
                    }

                    sw.WriteLine(@"</tbody>");
                    sw.WriteLine(@"</table>");
                    sw.WriteLine(@"<p>This list was exported from Cities: Skylines with <a target=""_blank"" href=""https://steamcommunity.com/sharedfiles/filedetails/?id=1591417160""> Hide It!</a><p/>");
                    sw.WriteLine(@"</body>");
                    sw.WriteLine(@"</html>");
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] ExportUtils:ExportNetInfoWithLanePropsToFile -> Exception: " + e.Message);
            }
        }
    }
}
