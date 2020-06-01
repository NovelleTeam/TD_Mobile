using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class space : MonoBehaviour
{
    [SerializeField] private GameObject[] Space;
    public float RocketSpeed;
    private float SpawnY = 20;
    private int spaceOnScreen = 3;

    public List<GameObject> activeSpace;

    private void Start()
    {
        for (int i = 0; i < spaceOnScreen; i++)
        {
            MakeSpace(i);
        }
    }
    private void Update()
    {
        if (0f > activeSpace[2].transform.position.y)
        {
            MakeSpace();
            DeleteSpace();
        }
    }
    void MakeSpace(int Sindex = 1)
    {
        GameObject go;
        go = Instantiate(Space[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector2(0,1) * SpawnY * Sindex;
        activeSpace.Add(go);
    }
    private void DeleteSpace()
    {
        Destroy(activeSpace[0]);
        activeSpace.RemoveAt(0);
    }
}
