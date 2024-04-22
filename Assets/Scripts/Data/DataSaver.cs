using UnityEngine;
using System.IO;

public class DataSaver : MonoBehaviour
{
    public PlayerData playerData;

    private string _filePath;

    private void Awake()
    {
        _filePath = Application.persistentDataPath + "/playerData.json";
        LoadPlayerData();
    }

    public void SavePlayerData()
    {
        playerData.playerLevel++;

        string jsonData = JsonUtility.ToJson(playerData);

        File.WriteAllText(_filePath, jsonData);

        Debug.LogWarning(_filePath);
    }

    public void LoadPlayerData()
    {
        if (File.Exists(_filePath))
        {
            string jsonData = File.ReadAllText(_filePath);

            playerData = JsonUtility.FromJson<PlayerData>(jsonData);

            Debug.LogWarning($"Player data loaded - {playerData.playerLevel}");
        }
        else
        {
            playerData = new PlayerData();
            SavePlayerData(); 
        }
    }
}
