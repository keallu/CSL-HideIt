using ColossalFramework;
using System;
using System.Collections;
using UnityEngine;

namespace HideIt
{
    public static class TextureHelper
    {
        public static void RefreshTexture()
        {
            try
            {
                if (Singleton<SimulationManager>.exists)
                {
                    Singleton<SimulationManager>.instance.AddAction(RefreshTextureAction());
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] TextureHelper:RefreshTexture -> Exception: " + e.Message);
            }
        }

        private static IEnumerator RefreshTextureAction()
        {
            try
            {
                if (Singleton<NaturalResourceManager>.exists)
                {
                    Singleton<NaturalResourceManager>.instance.AreaModified(0, 0, 511, 511);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] TextureHelper:RefreshTextureAction -> Exception: " + e.Message);
            }

            yield return null;
        }
    }
}
