using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class AssetManager
{
    private static string girlImagePath = "Assets/Script/Data/Images/{0}";
    private static string prefabPath = "Assets/Prefab/{0}.prefab";

    public static void LoadSprite(string spriteName, System.Action<Sprite> onLoaded)
    {
        //async = can load in the bg
        Addressables.LoadAssetAsync<Sprite>(string.Format(girlImagePath, spriteName)).Completed += (loadedSprite) =>
        {
            onLoaded?.Invoke(loadedSprite.Result);
        };
    }
    public static void LoadPrefabs(string gameObjectName, System.Action<GameObject> onLoaded)
    {
        Addressables.LoadAssetAsync<GameObject>(string.Format(prefabPath, gameObjectName)).Completed += (loadedGameObject) =>
        {
            onLoaded?.Invoke(loadedGameObject.Result);
        };  
    }
}
