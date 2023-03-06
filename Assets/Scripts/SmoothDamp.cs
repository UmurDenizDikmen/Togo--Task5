using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDamp : MonoBehaviour
{
 
    public Transform CurrentLeadTransform;
    private float CurrentVel = 0.0f;
    private float SmootTime = 0.1f;
   
    void Update()
    {
        if(CurrentLeadTransform == null)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x,CurrentLeadTransform.position.x,ref CurrentVel,SmootTime),transform.position.y,transform.position.z);
        }
    }
    public void SetLeadTransform(Transform leadTransform)
    {
        CurrentLeadTransform = leadTransform;
    }
}
