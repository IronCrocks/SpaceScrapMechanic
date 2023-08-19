using System.Runtime.InteropServices;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public GameData PlayerInfo;

    public static Progress Instance;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadExtern();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        var text = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(text);
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<GameData>(value);
    }
}
