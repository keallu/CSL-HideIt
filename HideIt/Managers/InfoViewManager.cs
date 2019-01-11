using ColossalFramework;
using System;
using UnityEngine;

namespace HideIt
{
    public class InfoViewManager
    {
        public Texture2D InfoViewResourceTexture { get; set; }
        public Texture2D InfoViewDestructionTexture { get; set; }

        private InfoManager.InfoMode _cachedInfoMode;

        private static InfoViewManager instance;

        public static InfoViewManager Instance
        {
            get
            {
                return instance ?? (instance = new InfoViewManager());
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

                        Singleton<NotificationManager>.instance.NotificationsVisible = !ModConfig.Instance.NotificationIcons;
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

                        Singleton<NotificationManager>.instance.NotificationsVisible = true;
                    }

                    _cachedInfoMode = InfoManager.instance.CurrentMode;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] InfoViewHelper:UpdateInfoView -> Exception: " + e.Message);
            }
}

        private InfoViewManager()
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
