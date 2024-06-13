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
            MainBody body = other.gameObject.GetComponent<MainBody>();
            Currency.currency.Money += body.myValue;
            animator.SetTrigger("Chomp");
            Destroy(body.gameObject, 2);
        }
    }
}
