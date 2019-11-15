using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;
using UnityEngine.Networking;

public class HotFixScript : MonoBehaviour
{
    private LuaEnv luaEnv;
    public static Dictionary<string, GameObject> prefabDict = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyLoader);
        luaEnv.DoString("require 'fish'");
    }    

    private byte[] MyLoader(ref string filePath)
    {
        string absPath = @"F:\GameResources\CatchFish\FishingJoy\Assets\" + filePath + ".lua.txt";
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(absPath));
    }

    private void OnDisable()
    {
        luaEnv.DoString("require 'fishDispose'");
    }

    private void OnDestroy()
    {
        luaEnv.Dispose();
    }
    [LuaCallCSharp]
    public  void LoadResource(string resName,string filePath)
    {
        StartCoroutine(LoaderResourceCorotine(resName,filePath));
       
    }

    IEnumerator LoaderResourceCorotine(string resName,string filePath)
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(@"http://localhost/AssetBundles/" + filePath);
        yield return request.SendWebRequest();
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        GameObject gameObject = ab.LoadAsset<GameObject>(resName);
        prefabDict.Add(resName, gameObject);
    }

    [LuaCallCSharp]
    public static GameObject GetGameObject(string goName)
    {
        return prefabDict[goName];
    }
}
