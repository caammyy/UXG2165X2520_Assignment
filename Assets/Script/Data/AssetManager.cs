using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class AssetManager
{
    private static string girlImagePath = "Assets/Script/Data/Images/{0}";

    public static void LoadSprite(string spriteName, System.Action<Sprite> onLoaded)
    {
        //async = can load in the bg
        Addressables.LoadAssetAsync<Sprite>(string.Format(girlImagePath, spriteName)).Completed += (loadedSprite) =>
        {
            onLoaded?.Invoke(loadedSprite.Result);
        };
    }
}
