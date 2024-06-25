using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Connection;

public class MainBody : MonoBehaviour
{
    public int bodyValue;

    private List<AnimalType> presentAnimals = new List<AnimalType>();
    private List<ConnectionType> presentParts = new List<ConnectionType>();

    private AnimalType soundToMake;
    private AudioSource myAudioSource;
  
    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    public void Add(BodyPart part)
    {
        if(!presentAnimals.Contains(part.animalType)) presentAnimals.Add(part.animalType);
        if (!presentParts.Contains(part.bodyPartType))
        {
            presentParts.Add(part.bodyPartType);
            bodyValue += part.myValue * 2;
        }

        PlaySFX();
    }
    public void Remove(BodyPart part)
    {
        if (presentAnimals.Contains(part.animalType)) presentAnimals.Remove(part.animalType);
        if (presentParts.Contains(part.bodyPartType))
        {
            presentParts.Remove(part.bodyPartType);
            bodyValue -= part.myValue * 2;
        }

        PlaySFX();
    }
 
    public AnimalType[] currentPresentAnimals
    {
        get { return  presentAnimals.ToArray(); }
    }
    public ConnectionType[] currentPresentParts
    {
        get { return presentParts.ToArray(); }
    }

    private void PlaySFX()
    {
        if (presentParts.Contains(ConnectionType.head))
        {
            if (soundToMake == AnimalType.cat)
            {
                AudioManager.instance.PlaySFX("Cat", myAudioSource);
            }
            else if (soundToMake == AnimalType.reptile)
            {
                AudioManager.instance.PlaySFX("Reptile", myAudioSource);
            }
        }
    }
}
