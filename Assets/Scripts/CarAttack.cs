using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAttack : MonoBehaviour{
    public float radius = 70f;
    public GameObject bullet;
    private Coroutine coroutine = null;
    public int health = 100;

    private void Update(){
      DetectCollision();
    }

    private void DetectCollision(){
      Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

      if(hitColliders.Length == 0 && coroutine != null){
        StopCoroutine(coroutine);
        coroutine = null;
        if(gameObject.CompareTag("Enemy"))
          GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(gameObject.transform.position);
      }

      foreach(var element in hitColliders){
        if((gameObject.CompareTag("Player") && element.gameObject.CompareTag("Enemy")) || (gameObject.CompareTag("Enemy") && element.gameObject.CompareTag("Player"))){
          if(gameObject.CompareTag("Enemy"))
            GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(element.transform.position);

          if(coroutine == null)
            coroutine = StartCoroutine(StartAttack(element));
        }
      }
    }

    IEnumerator StartAttack(Collider enemyPos){
      GameObject obj = Instantiate(bullet, transform.GetChild(1).position, Quaternion.identity);
      obj.GetComponent<BulletControler>().position = enemyPos.transform.position;
      yield return new WaitForSeconds(1f);
      StopCoroutine(coroutine);
      coroutine = null;
    }
}
