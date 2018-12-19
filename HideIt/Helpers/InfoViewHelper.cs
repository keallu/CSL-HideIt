using System;
using UnityEngine;

namespace HideIt
{
    public class InfoViewHelper
    {
        public Texture2D InfoViewResourceTexture { get; set; }
        public Texture2D InfoViewDestructionTexture { get; set; }

        private InfoManager.InfoMode _cachedInfoMode;

        private static InfoViewHelper instance;

        public static InfoViewHelper Instance
        {
            get
            {
                return instance ?? (instance = new InfoViewHelper());
            }
        }

        public void UpdateInfoView()
        {
            try
            {
                if (InfoManager.exists && InfoManager.instance.CurrentMode != _cachedInfoMode)
                {
                    if (InfoManager.instance.CurrentMode == InfoManager.InfoMode.None)
                    {
                        if (NaturalResourceManager.exists)
                        {
                            if (NaturalResourceManager.instance.m_resourceTexture != null)
                            {
                                Shader.SetGlobalTexture("_NaturalResources", NaturalResourceManager.instance.m_resourceTexture);
                            }
                            if (NaturalResourceManager.instance.m_destructionTexture != null)
                            {
                                Shader.SetGlobalTexture("_NaturalDestruction", NaturalResourceManager.instance.m_destructionTexture);
                            }
                        }
                    }
                    else
                    {
                        if (InfoViewResourceTexture != null)
                        {
                            Shader.SetGlobalTexture("_NaturalResources", InfoViewResourceTexture);
                        }
                        if (InfoViewDestructionTexture != null)
                        {
                            Shader.SetGlobalTexture("_NaturalDestruction", InfoViewDestructionTexture);
                        }
                    }

                    _cachedInfoMode = InfoManager.instance.CurrentMode;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] InfoViewHelper:UpdateInfoView -> Exception: " + e.Message);
            }
}

        private InfoViewHelper()
        {
            InfoViewResourceTexture = new Texture2D(512, 512, TextureFormat.RGB24, false, true)
            {
                wrapMode = TextureWrapMode.Clamp
            };

            InfoViewDestructionTexture = new Texture2D(512, 512, TextureFormat.RGB24, false, true)
            {
                wrapMode = TextureWrapMode.Clamp
            };

            _cachedInfoMode = InfoManager.InfoMode.None;
        }
    }
}
