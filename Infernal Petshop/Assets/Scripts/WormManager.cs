using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WormManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource myAudioSource;
    [SerializeField] private Transform bloodPosition;
    private GameObject bloodEffect;
    private void Start()
    {
        bloodEffect = Resources.Load("Blood").GameObject();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<MainBody>() != null)
        {     
            animator.SetTrigger("Chomp");
            AudioManager.instance.PlaySFX("Worm", myAudioSource);
            Instantiate(bloodEffect, bloodPosition.position, Quaternion.identity);


            MainBody body = other.gameObject.GetComponent<MainBody>();

            Currency.instance.Money += body.bodyValue;

            ObjectiveManager.instance.CheckObjective(body.currentPresentAnimals, body.currentPresentParts);

            Destroy(body.gameObject, 2);
        }
    }
}
