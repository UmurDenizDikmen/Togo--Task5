using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colletc : MonoBehaviour
{
    
    public Mesh []ChangeMesh;
    
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.transform.gameObject.GetComponent<MeshFilter>().mesh = ChangeMesh[0];
            other.transform.tag = "Collectable1";
            
        }
        else if (other.gameObject.CompareTag("Collectable1"))
        {
            other.transform.gameObject.GetComponent<MeshFilter>().mesh = ChangeMesh[1];
            other.transform.tag = "Collectable";
        }
    }
  
}
