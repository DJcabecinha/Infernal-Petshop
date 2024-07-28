using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager instance;
    [SerializeField] private Objective[] objectives;
    [SerializeField] private TextMeshProUGUI objectiveText;
    public Objective currentObjective;

    [SerializeField] private GameObject endgameScreen;
    [SerializeField] private TextMeshProUGUI endgameText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        int randomObj = Random.Range(0, objectives.Length);
        currentObjective = objectives[randomObj];

        objectiveText.text = currentObjective.description;
    }

    public void CheckObjective(Connection.AnimalType[] presentAnimals, Connection.ConnectionType[] presentParts)
    {
        foreach(Connection.AnimalType t in presentAnimals)
        {
            print(t);
        }
        foreach (Connection.ConnectionType t in presentParts)
        {
            print(t);
        }

        if (currentObjective.CheckObjective(Currency.instance.Money, presentAnimals, presentParts))
        {
            endgameScreen.SetActive(true);
            endgameText.text = "VITÓRIA";
            Time.timeScale = 0;
        }

    }
    public void TimeOut()
    {
        endgameScreen.SetActive(true);
        endgameText.text = "DERROTA";
        Time.timeScale = 0;
    }
    public void ReloadGame()
    {
        Time.timeScale = 1;
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
