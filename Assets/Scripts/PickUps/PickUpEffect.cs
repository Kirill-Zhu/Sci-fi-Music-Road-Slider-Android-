using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEffect : MonoBehaviour
{
    private bool hasBeenPickedUp = false;
    MeshRenderer meshRender;
   

    private void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }
    public void DoPickUpEffect()
    {
        if(!hasBeenPickedUp)
        {
            hasBeenPickedUp = true; 
             
            
            GlobalEventSystem.SendOnShowScore();
            Destroy(gameObject);
        }
     
    }
}
