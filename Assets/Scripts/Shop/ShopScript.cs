using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Purchasing;

[Serializable]
public class ConumableItem
{
    public string name;
    public string id;
    public string desc;
    public float price;
}
[Serializable]
public class NonConumableItem
{
    public string name;
    public string id;
    public string desc;
    public float price;
}
[Serializable]
public class SubscriptionItem
{
    public string name;
    public string id;
    public string desc;
    public float price;
    public int time; // In days
}
public class ShopScript : MonoBehaviour, IStoreListener
{
    IStoreController m_storeController;
    public ConumableItem cItem;
    public NonConumableItem nCItem;
    public SubscriptionItem sItem;

    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        InitializeServicesAsync();
    }

    async Task InitializeServicesAsync()
    {
        try
        {
            await UnityServices.InitializeAsync();
            Debug.Log("Unity Gaming Services initialized successfully.");
            SetupIAP();
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to initialize services: " + e.Message);
        }
    }

    void SetupIAP()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(cItem.id, ProductType.Consumable);
        builder.AddProduct(nCItem.id, ProductType.NonConsumable);
        builder.AddProduct(sItem.id, ProductType.Consumable);
        UnityPurchasing.Initialize(this, builder);
    }

    public void ConsumablePressed()
    {
        Debug.Log("ConsumablePressed method called.");
        if (m_storeController == null)
        {
            Debug.LogError("Store Controller is not initialized.");
            return;
        }
        Debug.Log("Initiating purchase for: " + cItem.id);
        m_storeController.InitiatePurchase(cItem.id);
    }
    public void NonConsumablePressed()
    {
        m_storeController.InitiatePurchase(nCItem.id);
    }
    public void SubscriptionPressed()
    {
        m_storeController.InitiatePurchase(sItem.id);
    }

    public void Test()
    {
        _gameManager.PurchaseTime(10);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var product = purchaseEvent.purchasedProduct;

        switch (product.definition.id)
        {
            case "10_sec":
                _gameManager.PurchaseTime(10);
                break;
            case "noAd":
                _gameManager.PurchaseTime(10);
                break;
            case "100_sec":
                _gameManager.PurchaseTime(10);
                break;
        }

        return PurchaseProcessingResult.Complete;
    }


    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("Store Controller initialized successfully.");
        m_storeController = controller;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Init eror" + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("Init eror" + error + message);

    }



    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Init eror" + product + failureReason);
    }


}
