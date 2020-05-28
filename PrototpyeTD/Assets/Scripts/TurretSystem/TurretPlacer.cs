using UnityEngine;

namespace TurretSystem
{
    public class TurretPlacer : MonoBehaviour
    {
        [SerializeField] private TurretModel model;

        public TurretModel Model
        {
            get => model;
            set => model = value;
        }

        private Camera _camera;

        private TempTurret _tempTurret;
        private Vector2 _pointer;
        private Vector2 _normalDir;
        private bool _canPlace;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.touchCount == 0)
                return;

            if (_tempTurret == null)
            {
                ShowTempModel();
                _normalDir = Vector2.right;
                _canPlace = true;
            }

            Touch touch = Input.touches[0];
            Ray touchRay = _camera.ScreenPointToRay(touch.position);
            Vector2 touchWorldPos = _camera.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(touchRay.origin, touchRay.direction);
            if (hit && hit.collider.TryGetComponent(out SideBox box))
            {
                var gridPos = box.GetPosition(touchWorldPos);
                _pointer = new Vector2(gridPos.x, gridPos.y);
                _normalDir = box.GetNormalDir();
                if (!_canPlace)
                {
                    _canPlace = true;
                    _tempTurret.CanPlace = _canPlace;
                }
            }
            else
            {
                _pointer = touchWorldPos;

                if (_canPlace)
                {
                    _canPlace = false;
                    _tempTurret.CanPlace = _canPlace;
                }
            }

            _tempTurret.transform.position = _pointer;
            _tempTurret.transform.right = _normalDir;


            if (touch.phase == TouchPhase.Ended)
            {
                Destroy(_tempTurret.gameObject);
                if (_canPlace)
                    Place();
                _canPlace = false;
            }
        }

        private void Place()
        {
            GameObject tempObj = Instantiate(model.TurretObj, _pointer, Quaternion.identity);
            tempObj.transform.right = _normalDir;
        }

        private void ShowTempModel()
        {
            GameObject tempObj = Instantiate(model.TurretHolder.gameObject, _pointer, Quaternion.identity);
            _tempTurret = tempObj.GetComponent<TempTurret>();
        }
    }
}