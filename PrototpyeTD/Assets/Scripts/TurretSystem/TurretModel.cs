using UnityEngine;

namespace TurretSystem
{
    [CreateAssetMenu(fileName = "New turret", menuName = "PrototpyeTD/TourretModel", order = 0)]
    public class TurretModel : ScriptableObject {
    
        [SerializeField] private float price;
        [SerializeField] private TempTurret turretHolder;
        [SerializeField] private GameObject turretObj;

        public TempTurret TurretHolder => turretHolder;
        public GameObject TurretObj => turretObj;
    }
}