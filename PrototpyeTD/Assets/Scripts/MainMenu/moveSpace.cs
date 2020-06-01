using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSpace : MonoBehaviour
{
    [SerializeField] private space SpaceManager;

    private void Update()
    {
        gameObject.transform.position += new Vector3(0,SpaceManager.RocketSpeed) * Time.deltaTime * -1;
    }
}
