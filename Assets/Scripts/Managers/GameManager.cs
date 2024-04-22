using AppodealAds.Unity.Api;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private float _timeAtLevel;
    [SerializeField] private TextMeshProUGUI _timeText;

    [SerializeField] private GameObject[] _canvasMenuObject; // 0 - winGameMenu // 1 - loseGameMenu

    private DifferencesSystem _differenceSystem;

    private void Awake()
    {
        _differenceSystem = FindObjectOfType<DifferencesSystem>();
    }
    private void Start()
    {
        UpdateTimeDisplay();
    }

    private void Update()
    {
        if (_timeAtLevel > 0f && !_differenceSystem.isAllDifferenceFinded)
        {
            _timeAtLevel -= Time.deltaTime;
            UpdateTimeDisplay();
        }
        else if (_differenceSystem.isAllDifferenceFinded)
        {
            _canvasMenuObject[0].SetActive(true);
        }
        else
        {
            _canvasMenuObject[1].SetActive(true);
        }
    }

    private void UpdateTimeDisplay()
    {
        string formattedTime = ConvertSecondsToTimeString((int)_timeAtLevel);

        _timeText.text = formattedTime;
    }

    private string ConvertSecondsToTimeString(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        return formattedTime;
    }

    public float PurchaseTime(float newTime)
    {
        _timeAtLevel += newTime;
        UpdateTimeDisplay();
        return _timeAtLevel;
    }

    public bool isTimeAboveZero
    {
        get { bool isTrue = _timeAtLevel > 0f; return isTrue; }
    }

}
