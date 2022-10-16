using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour{
    public Transform[] points;
    public GameObject hangar;

    private void Start(){
      StartCoroutine(SpawnHangar());
    }

    IEnumerator SpawnHangar(){
      for(int i = 0; i < points.Length; i++){
        yield return new WaitForSeconds(10f);
        GameObject spawn = Instantiate(hangar);
        spawn.transform.position = points[i].position;
        spawn.transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360f), 0));
        spawn.GetComponent<CreateCar>().enabled = true;
        spawn.GetComponent<CreateCar>().isEnemy = true;
      }
    }
}
