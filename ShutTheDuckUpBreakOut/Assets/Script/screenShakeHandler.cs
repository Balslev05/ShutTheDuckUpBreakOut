using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class screenShakeHandler : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    private CinemachineBasicMultiChannelPerlin noise;
    private float ScreenShakeDuration; 

    void Start()
    {
        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();   
    }


    public void StartShake(float Duration ,float Streangth, float Freqency)
    {

        float UpdatetStreangt =+ Streangth;
        float UpdatetDuration =+ Duration;
        float UpdatetFreqency =+ Freqency;

        noise.m_AmplitudeGain = UpdatetStreangt;
        noise.m_FrequencyGain = UpdatetFreqency;
        ScreenShakeDuration = UpdatetDuration;

        StartCoroutine(ShakeScreen());
    
    }



  
  

  
    IEnumerator ShakeScreen()
   {  

    yield return new WaitForSeconds(ScreenShakeDuration);
    
    transform.rotation = Quaternion.identity;
    noise.m_AmplitudeGain = 0;
    noise.m_FrequencyGain = 0;
   }
}