using UnityEngine;

public class TurretPlacer : MonoBehaviour {

    
    public TurretModel Model { get => model; set => model = value; }

    private Camera camera;
    private TurretModel model;
    private GameObject tempTurret;
    private Vector3Int pointer;

    private void Update()
    {
        Touch touch = Input.touches[0];
        Ray touchRay = camera.ScreenPointToRay(touch.position);
        Vector2 touchWorldPos = camera.ScreenToWorldPoint(touch.position);
        RaycastHit2D hit = Physics2D.Raycast(touchRay.origin,touchRay.direction);
        if(hit && hit.collider.TryGetComponent(out SideBox box)){
            
            pointer = box.GetPosition(touchWorldPos);

            if(tempTurret != null){
                tempTurret.transform.position = pointer;
            }else{
                ShowTempModel();
            }

        }
    }

    private void Place(){

    }
    private void ShowTempModel(){
        tempTurret = Instantiate(model.TurretHolder,pointer,Quaternion.identity);
    }

}