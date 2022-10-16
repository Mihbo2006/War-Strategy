using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour{
    public Light dirLight;

    private ParticleSystem ps;
    private bool isRain = false;

    private void Start(){
      ps = GetComponent<ParticleSystem>();
      StartCoroutine(Weather());
    }
    private void Update(){
      if(isRain && dirLight.intensity > 0.25f)
        LightIntensity(-1);
      else if(!isRain && dirLight.intensity < 0.5f)
        LightIntensity(1);
    }
    private void LightIntensity(int value){
      dirLight.intensity += 0.1f * Time.deltaTime * value;
    }
    IEnumerator Weather(){
      while(true){
        yield return new WaitForSeconds(Random.Range(20f, 100f));
        if(isRain)
          ps.Stop();
        else
          ps.Play();

        isRain = !isRain;
      }
    }
}
