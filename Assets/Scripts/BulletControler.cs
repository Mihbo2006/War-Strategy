using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour{
    public Vector3 position;
    public float speed = 8f;

    private void Update(){
      float step = speed * Time.deltaTime;
      transform.position = Vector3.MoveTowards(transform.position, position, step);
      if(transform.position == position)
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other){
      if(other.CompareTag("Enemy") || other.gameObject.CompareTag("Player")){
        CarAttack attack = other.GetComponent<CarAttack>();
        attack.health -= 20;
        Transform healthBar = other.transform.GetChild(0).transform;
        healthBar.localScale = new Vector3(healthBar.localScale.x - 0.3f, healthBar.localScale.y, healthBar.localScale.z);
        if(attack.health <= 0)
          Destroy(other.gameObject);
      }
    }
}
