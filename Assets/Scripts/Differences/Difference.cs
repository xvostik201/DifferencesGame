using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difference : MonoBehaviour
{
    [SerializeField] private int _indexOfDifference;

    private DifferencesSystem _differenceSystem;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _differenceSystem = FindObjectOfType<DifferencesSystem>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (_gameManager.isTimeAboveZero)
        {
            _differenceSystem.DifferenceFound(_indexOfDifference);
        }
    }

    public int SetIndex(int index)
    {
        _indexOfDifference = index;
        return _indexOfDifference;
    }

}
