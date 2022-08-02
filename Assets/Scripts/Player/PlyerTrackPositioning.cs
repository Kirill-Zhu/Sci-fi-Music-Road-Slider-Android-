using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerTrackPositioning : MonoBehaviour
{
    public float YPosOffset=1;
    [SerializeField] LayerMask mask;
    [Range(0, 1)]
    [SerializeField] float smothness;
    [SerializeField] bool rigidbodyIsOn = false;
    private void Update()
    {
        Ray ray = new Ray(transform.position+ new Vector3(0,2,0), Vector3.down);
        if(Physics.Raycast(ray, out RaycastHit hit,100, mask, QueryTriggerInteraction.Ignore))
        {
            var tmpPos = hit.point;
            tmpPos.y = hit.point.y + YPosOffset;                    
          
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, hit.normal), smothness);
            if(!rigidbodyIsOn)            
                transform.position = Vector3.Lerp(transform.position, tmpPos, smothness);           
        }
    }
}
