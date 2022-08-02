using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.z < -1)
        {
            Destroy(this.gameObject);
        }

    }
}
