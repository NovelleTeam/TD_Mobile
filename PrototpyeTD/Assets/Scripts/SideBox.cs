using UnityEngine;

public class SideBox : MonoBehaviour {
    
    [SerializeField] private Vector2 normaDir;

    private Grid grid;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }

    public Vector3Int GetPosition(Vector2 pos){
        return grid.WorldToCell(pos);
    }

}