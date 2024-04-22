using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablesInitializer : MonoBehaviour
{
    void Start()
    {
        InitializeAddressables();
    }

    void InitializeAddressables()
    {
        Addressables.InitializeAsync();
    }
}
