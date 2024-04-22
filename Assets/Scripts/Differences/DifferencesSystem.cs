using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifferencesSystem : MonoBehaviour
{
    [Serializable]
    struct DifferencesOnLevel
    {
        public List<Transform> differencesTransformByIndex;
    }

    [SerializeField] private DifferencesOnLevel[] _differenceCount;
    [SerializeField] private ParticleSystem _particlePrefab;

    [SerializeField] private TextMeshProUGUI _differenceFindedCountText;

    private int _findedDifference;
    private bool[] _isDifferenceFound;

    private void Start()
    {
        for (int i = 0; i < _differenceCount.Length; i++)
        {
            List<Transform> transforms = _differenceCount[i].differencesTransformByIndex;

            foreach (Transform transform in transforms)
            {
                transform.gameObject.AddComponent<BoxCollider2D>();
                transform.gameObject.AddComponent<Difference>();
                transform.gameObject.GetComponent<Difference>().SetIndex(i);
            }
        }
        _isDifferenceFound = new bool[_differenceCount.Length];

        UpdateTextDifferenceFinded();
    }

    public void DifferenceFound(int indexOfDifference)
    {
        if (!_isDifferenceFound[indexOfDifference])
        {
            _isDifferenceFound[indexOfDifference] = true;

            List<Transform> transforms = _differenceCount[indexOfDifference].differencesTransformByIndex;

            foreach (Transform transform in transforms)
            {
                Instantiate(_particlePrefab, transform.position, Quaternion.identity);
            }
            _findedDifference++;

            UpdateTextDifferenceFinded();
        }
    }

    private void UpdateTextDifferenceFinded()
    {
        _differenceFindedCountText.text = $"Отличий найдено - {_findedDifference} / {_differenceCount.Length}";
    }

    public bool isAllDifferenceFinded
    {
        get {bool isAllFinded = (_findedDifference == _differenceCount.Length); return isAllFinded; }
    }
}
