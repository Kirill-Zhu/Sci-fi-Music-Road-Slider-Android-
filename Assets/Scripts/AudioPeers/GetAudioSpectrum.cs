using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class GetAudioSpectrum : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] samples = new float[512];
    public static float [] freqBand = new float[8];

    void Start()
    {
    audioSource=GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSourece();

        MakeFrequencyBands();
    }
    void GetSpectrumAudioSourece()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;  
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            for(int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }
           average/=count;
            freqBand[i] = average*10;

        }
    }
}
