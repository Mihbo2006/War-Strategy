using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjects : MonoBehaviour{
    public LayerMask layer;
    public float rotSpeed = 20f;

    private void Start(){
      PositionObject();
    }
    private void Update(){
      PositionObject();
      if(Input.GetMouseButtonDown(0)){
        gameObject.GetComponent<CreateCar>().enabled = true;
        Destroy(gameObject.GetComponent<PlaceObjects>());
      }
      if(Input.GetKey(KeyCode.R))
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
    }
    private void PositionObject(){
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      RaycastHit hit;
      if(Physics.Raycast(ray, out hit, 1000f, layer))
        transform.position = hit.point;
    }
}
