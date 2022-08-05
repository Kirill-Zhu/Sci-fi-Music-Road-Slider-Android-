using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, PlayerManager.instance.transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PickUpEffect>())
        {
            GlobalEventSystem.SendOnSlowDown();
            Debug.Log("SlowDown");
        }
    }
}
