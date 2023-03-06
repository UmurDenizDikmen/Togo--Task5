using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CharacterState.instance.GatheringObject2());
         
            CharacterState.SpeedPlayer = 0f;
            other.transform.gameObject.GetComponent<Animator>().SetBool("IsRunnig", false);
        }
    }
   
}
