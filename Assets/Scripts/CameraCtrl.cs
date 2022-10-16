using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour{
    public float moveSpeed = 20f, rotationSpeed = 20f, zoomSpeed = 20f;

    private void FixedUpdate(){
      float rotationAxis = 0f;
      float xAxis = 0, yAxis = 0;

      xAxis = Input.GetAxis("Horizontal");
      yAxis = Input.GetAxis("Vertical");

      if(Input.GetKey(KeyCode.Q))
        rotationAxis = -1f;
      else if(Input.GetKey(KeyCode.E))
        rotationAxis = 1f;

      transform.Rotate(Vector3.up * rotationSpeed * rotationAxis * Time.deltaTime, Space.World);
      transform.Translate(new Vector3(xAxis, 0, yAxis) * moveSpeed * Time.deltaTime);

      transform.position += transform.up * zoomSpeed * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;

      transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 10f, 30f) , transform.position.z);
    }
}
