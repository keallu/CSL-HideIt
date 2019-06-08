using ICities;
using System;
using UnityEngine;

namespace HideIt
{
    public class Loading : LoadingExtensionBase
    {
        private GameObject _hideManagerGameObject;

        public override void OnLevelLoaded(LoadMode mode)
        {
            try
            {
                if (ModConfig.Instance.AutoUpdateTreeRuiningAtLoad)
                {
                    RuiningHelper.UpdateExistingTreesRuining(ModConfig.Instance.TreeRuining);
                }

                if (ModConfig.Instance.AutoUpdatePropRuiningAtLoad)
                {
                    RuiningHelper.UpdateExistingPropsRuining(ModConfig.Instance.PropRuining);
                }

                _hideManagerGameObject = new GameObject("HideItHideManager");
                _hideManagerGameObject.AddComponent<HideManager>();
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] Loading:OnLevelLoaded -> Exception: " + e.Message);
            }
        }

        public override void OnLevelUnloading()
        {
            try
            {
                if (_hideManagerGameObject != null)
                {
                    UnityEngine.Object.Destroy(_hideManagerGameObject);
                }

            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] Loading:OnLevelUnloading -> Exception: " + e.Message);
            }
        }
    }
}