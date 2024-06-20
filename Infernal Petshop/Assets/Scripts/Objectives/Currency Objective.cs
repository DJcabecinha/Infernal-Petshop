using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyObjective : Objective
{
    [SerializeField] private int currencyNeeded;

    public override bool CheckObjective(int currency, Connection.AnimalType[] presentAnimals, Connection.ConnectionType[] presentParts)
    {
        if (currency > currencyNeeded)
        {
            return true;
        }
        else return false;
    }

}
