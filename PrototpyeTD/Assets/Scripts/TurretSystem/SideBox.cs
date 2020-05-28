using UnityEngine;

namespace TurretSystem
{
    public class SideBox : MonoBehaviour {
    
        [SerializeField] private Vector2 normaDir;

        private Grid _grid;

        private void Awake()
        {
            _grid = GetComponent<Grid>();
        }

        public Vector2 GetPosition(Vector2 pos){
            Vector3Int cellPosition = _grid.WorldToCell(pos);
            return _grid.GetCellCenterWorld(cellPosition);
        }

        public Vector2 GetNormalDir()
        {
            return normaDir;
        }
    }
}