using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlaceBuilds : MonoBehaviour{
    public GameObject building;

    public void PlaceBuilding(){
      Instantiate(building, Vector3.zero, Quaternion.identity);
    }
}
