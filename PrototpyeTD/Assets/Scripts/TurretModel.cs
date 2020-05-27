using UnityEngine;

[CreateAssetMenu(fileName = "New turret", menuName = "PrototpyeTD/TourretModel", order = 0)]
public class TurretModel : ScriptableObject {
    
    [SerializeField] private float price;
    [SerializeField] private GameObject turretHolder;
    [SerializeField] private GameObject turretObj;

    public GameObject TurretHolder { get => turretHolder; set => turretHolder = value; }
    public GameObject TurretObj { get => turretObj; set => turretObj = value; }
}