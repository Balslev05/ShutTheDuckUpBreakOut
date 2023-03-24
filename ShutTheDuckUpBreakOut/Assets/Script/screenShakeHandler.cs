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

        noise.m_AmplitudeGain = Streangth;
        noise.m_FrequencyGain = Freqency;
        ScreenShakeDuration = Duration;

        StartCoroutine(ShakeScreen());
    
    }



  
  

  
  public IEnumerator ShakeScreen()
   {  

    yield return new WaitForSeconds(ScreenShakeDuration);
    
    noise.m_AmplitudeGain = 0;
    noise.m_FrequencyGain = 0;
   }
}