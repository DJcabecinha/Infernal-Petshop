using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<MainBody>() != null)
        {     
            animator.SetTrigger("Chomp");
            MainBody body = other.gameObject.GetComponent<MainBody>();

            Currency.instance.Money += body.bodyValue;

            ObjectiveManager.instance.CheckObjective(body.currentPresentAnimals, body.currentPresentParts);

            Destroy(body.gameObject, 2);
        }
    }
}
