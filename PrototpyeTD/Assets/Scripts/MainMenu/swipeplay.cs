using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeplay : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    private bool stopSwipe;
    [SerializeField] private MainMenuManager manager;

    // Start is called before the first frame update
    void Start()
    {
        speedModifier = 0.01f;
        stopSwipe = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopSwipe)
        {
            if (transform.position.y >= 3f)
            {
                stopSwipe = true;
                LeanTween.moveY(gameObject, 9, 1);
                manager.goToPlayScene();
            }
            //this part is for mobile
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    if ((transform.position.y + touch.deltaPosition.y * speedModifier) >= 0)
                    {
                        transform.position = new Vector3(0, transform.position.y + touch.deltaPosition.y * speedModifier, -1);
                    }
                }
            }
            //this part is pc
            if (Input.GetKeyDown(KeyCode.W))
            {
                stopSwipe = true;
                LeanTween.moveY(gameObject, 9, 1);
                manager.goToPlayScene();
            }
        }
    }
}