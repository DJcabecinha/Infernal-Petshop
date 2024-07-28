using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Objective : MonoBehaviour
{
    public string description;


    //public int currencyNeeded;
    //public Connection.AnimalType[] specificAnimalsNeeded;
    //public Connection.ConnectionType[] specificBodyPartsNeeded;

    public abstract bool CheckObjective(int currency, Connection.AnimalType[] presentAnimals, Connection.ConnectionType[] presentParts);
}
