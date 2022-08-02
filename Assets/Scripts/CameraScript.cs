using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [Range(0, 15)]
    [SerializeField] float PosY;
    [Range(-15, 0)]
    [SerializeField] float posZ;
    [Range(0, 1)]
    [SerializeField] float smootness;
    private void Update()
    {
       
    }
    private void CameraPosition()
    {
        var pos = transform.position;
        pos.y = player.position.y + PosY;
        pos.z = player.position.z + posZ;
        transform.position = Vector3.Lerp(transform.position, pos, smootness);

      
    }
    private void LateUpdate()
    {
        CameraPosition();
    }
}
