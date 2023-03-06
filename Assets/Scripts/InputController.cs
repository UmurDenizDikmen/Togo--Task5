using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour,IDragHandler
{
    public Transform CurrentPlayer;
    private float MouseSense = 175f;
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 CurrentPos = CurrentPlayer.position;
        CurrentPos.x = Mathf.Clamp(CurrentPos.x + (eventData.delta.x / MouseSense), -3, 3);
        CurrentPlayer.position = new Vector3(CurrentPos.x, CurrentPlayer.position.y, CurrentPlayer.position.z);
    }

    
}
