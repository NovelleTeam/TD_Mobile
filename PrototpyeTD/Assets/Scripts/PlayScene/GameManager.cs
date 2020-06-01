using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup BalckPanel;

    private void Start()
    {
        LeanTween.alphaCanvas(BalckPanel, 0, 1);
    }
}
