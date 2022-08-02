using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScaler : MonoBehaviour
{
   public int band;
   public float startScale;
   public float multiplierScale;
   


    private void Update()
    {
       // transform.localScale = new Vector3(transform.localScale.x, GetAudioSpectrum.freqBand[band]*multiplierScale + startScale, transform.localScale.z);
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, GetAudioSpectrum.freqBand[band] * multiplierScale + startScale, transform.localScale.z),.08f);
    }

}
