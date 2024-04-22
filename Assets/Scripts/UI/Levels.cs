using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Levels : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;

    public DataSaver dataSaver;

    void Start()
    {
    }

    private void UpdateLevelText(int level)
    {
        _levelText.text = $"Уровень - {level}";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevelText(dataSaver.playerData.playerLevel);
    }
}
