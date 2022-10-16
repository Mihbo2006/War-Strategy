using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCar : MonoBehaviour{
    public GameObject car;
    public float time = 5f;
    public bool isEnemy = false;

    private void Start(){
      StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar(){
      for(int i = 1; i < 3; i++){
        yield return new WaitForSeconds(time);
        Vector3 pos = new Vector3(transform.GetChild(0).position.x + Random.Range(3f, 7f), transform.GetChild(0).position.y, transform.GetChild(0).position.z + Random.Range(3f, 7f));
        GameObject spawn = Instantiate(car, transform.GetChild(0).position, Quaternion.identity);
        if(isEnemy)
          spawn.tag = "Enemy";
      }
    }
}
