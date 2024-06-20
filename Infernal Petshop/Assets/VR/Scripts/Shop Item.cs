using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{

    [Header("Info")]
    [SerializeField] private int cost;
    [SerializeField] private string animalName;

    [Header("Objects")]
    [SerializeField] private GameObject animalPrefab;
    [SerializeField] private TextMeshProUGUI animalNameText;

    private Transform spawnPoint;
    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Shop Spawn Point").transform;
        animalNameText.text = animalName;
    }

    public void Buy()
    {
        if (Currency.instance.Money >= cost)
        {
            Currency.instance.Money -= cost;
            Instantiate(animalPrefab, spawnPoint.position, Quaternion.identity);
            ConnectionManager.Instance.RefreshConnections();
        }
    }
}
