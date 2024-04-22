using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ResourceLoader : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject[] _levels;

    public PlayerData playerData;
    private void Awake()
    {
        
    }
    private void Start()
    {
        LoadResourceAsync();
    }

    private void LoadResourceAsync()
    {
        _levels[playerData.playerLevel].LoadAssetAsync().Completed += OnResourceLoaded;
    }

    private void OnResourceLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(handle.Result);
        }
        else
        {
            Debug.LogError("Failed to upload");
        }
    }

}
