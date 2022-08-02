using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessBloom : MonoBehaviour
{

    private PostProcessVolume _postPrcessVolume;
    private Bloom _bloom;
    [Range(0, 255)]
    public float minRange;
    [Range(0,255)]
    public float maxRange;
    public float speedChange;
    public float HDRIntensity;
    private float r=255f;
 
    private float g;

    private float b;
     
    void Start()
    {
        r = maxRange;
        g = minRange;
        b = minRange;
   
        _postPrcessVolume = GetComponent<PostProcessVolume>();
        _postPrcessVolume.profile.TryGetSettings(out _bloom);
     
       
    }

    // Update is called once per frame
    void Update()
    {
        
      ChangeBloomColorVoume();
    }
    private void ChangeBloomColorVoume()
    {
        r = Mathf.Clamp(r, minRange, maxRange);
        g = Mathf.Clamp(g, minRange, maxRange);
        b= Mathf.Clamp(b, minRange, maxRange);
        if (r>=maxRange&&b<=minRange)
        {
            r = maxRange;
            b = minRange;
            g += speedChange * Time.deltaTime;
        }
       if(b<=minRange&&g>=maxRange)
        {
            g = maxRange;
            b = minRange;
           
            r -= speedChange * Time.deltaTime;
        }
        if(r<=minRange&&g>=maxRange)
        {
            r = minRange;
            g = maxRange;
            b += speedChange * Time.deltaTime;
        }
        if(r<=minRange&&b>=maxRange)
        {
            r = minRange;
            b = maxRange;
            g -= speedChange * Time.deltaTime;
        }
        if(g<=minRange&&b>=maxRange)
        {
            g = minRange;
            b = maxRange;
            r += speedChange * Time.deltaTime;
        }
        if(r>=maxRange&&g<=minRange)
        {
            r = maxRange;
            g = minRange;
            b -= speedChange * Time.deltaTime;
        }
    
       _bloom.color.value = new Color(r/255, g/255f, b/255f);
        _bloom.intensity.value = HDRIntensity;
    }
}
