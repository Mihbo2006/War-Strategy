using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour{
    public GameObject cube;
    public List<GameObject> players;
    public LayerMask layer, layerMask;
    private Camera camera;
    private GameObject cubeSelection;
    private RaycastHit hit;

    private void Awake(){
      camera = GetComponent<Camera>();
    }
    private void Update(){
      if(Input.GetMouseButtonDown(1) && players.Count > 0){
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit agentTarget, 1000f, layer))
          foreach(var element in players)
            if(element != null)
              element.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(agentTarget.point);
      }
      if(Input.GetMouseButtonDown(0)){
        foreach(var element in players)
          element.transform.GetChild(0).gameObject.SetActive(false);
        players.Clear();
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000f, layer))
          cubeSelection = Instantiate(cube, new Vector3(hit.point.x, 0.5f, hit.point.z), Quaternion.identity);
      }
      if(Input.GetMouseButtonUp(0) && cubeSelection){
        RaycastHit[] hits = Physics.BoxCastAll(cubeSelection.transform.position, cubeSelection.transform.localScale, Vector3.up, Quaternion.identity, 0, layerMask);
        foreach(var element in hits){
          if(element.collider.CompareTag("Enemy"))
            continue;
          players.Add(element.transform.gameObject);
          element.transform.GetChild(0).gameObject.SetActive(true);
        }
        Destroy(cubeSelection);
      }

      if(cubeSelection){
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitDrag, 1000f, layer)){
          float xScale = 0, zScale = 0;
          xScale = (hit.point.x - hitDrag.point.x) * -1;
          zScale = hit.point.z - hitDrag.point.z;
          if(xScale < 0 && zScale < 0)
            cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
          else if(xScale < 0)
            cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
          else if(zScale < 0)
            cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(180, 0, 0));
          else
            cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

          cubeSelection.transform.localScale = new Vector3(Mathf.Abs(xScale), 1, Mathf.Abs(zScale));
        }
      }
    }
}
