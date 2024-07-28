using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineAnimalsObjective : Objective
{
    public Connection.AnimalType firstType;
    public Connection.AnimalType secondType;
    public Connection.AnimalType thirdType;

    private bool firstTypeDone;
    private bool secondTypeDone;
    private bool thirdTypeDone;

    public override bool CheckObjective(int currency, Connection.AnimalType[] presentAnimals, Connection.ConnectionType[] presentParts)
    {
        foreach(Connection.AnimalType type in presentAnimals)
        {
            if (type == firstType) firstTypeDone = true;
            if (type == secondType) secondTypeDone = true;
            if (type == thirdType) thirdTypeDone = true;
        }
        if(firstTypeDone && secondTypeDone && thirdTypeDone)
        {
            return true;
        }

        else
        {
            firstTypeDone = false;
            secondTypeDone = false;
            thirdTypeDone = false;
            return false;
        }
    }

}
