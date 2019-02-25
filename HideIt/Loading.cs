using ColossalFramework.UI;
using ICities;
using System;
using UnityEngine;

namespace HideIt
{

    public class Loading : LoadingExtensionBase
    {
        private LoadMode _loadMode;
        private GameObject _gameObject;

        public override void OnLevelLoaded(LoadMode mode)
        {
            try
            {
                _loadMode = mode;

                if (_loadMode != LoadMode.LoadGame && _loadMode != LoadMode.NewGame && _loadMode != LoadMode.LoadMap && _loadMode != LoadMode.NewMap && _loadMode != LoadMode.NewGameFromScenario)
                {
                    return;
                }

                if (ModConfig.Instance.AutoUpdateTreeRuiningAtLoad)
                {
                    RuiningHelper.UpdateExistingTreesRuining(ModConfig.Instance.TreeRuining);
                }

                if (ModConfig.Instance.AutoUpdatePropRuiningAtLoad)
                {
                    RuiningHelper.UpdateExistingPropsRuining(ModConfig.Instance.PropRuining);
                }

                UIView objectOfType = UnityEngine.Object.FindObjectOfType<UIView>();
                if (objectOfType != null)
                {
                    _gameObject = new GameObject("HideItHider");
                    _gameObject.transform.parent = objectOfType.transform;
                    _gameObject.AddComponent<Hider>();
                }
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
                if (_loadMode != LoadMode.LoadGame && _loadMode != LoadMode.NewGame && _loadMode != LoadMode.NewGameFromScenario)
                {
                    return;
                }

                if (_gameObject == null)
                {
                    return;
                }

                UnityEngine.Object.Destroy(_gameObject);
            }
            catch (Exception e)
            {
                Debug.Log("[Hide It!] Loading:OnLevelUnloading -> Exception: " + e.Message);
            }
        }
    }
}