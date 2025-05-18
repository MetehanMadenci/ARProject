using UnityEngine;

public class TouchController : MonoBehaviour
{
    private Vector2 startTouch0, startTouch1;
    private float startDistance;
    private Vector3 startScale;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            // Döndürme
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotX = touch.deltaPosition.x * 0.3f;
                transform.Rotate(0, -rotX, 0, Space.World);
            }
        }
        else if (Input.touchCount == 2)
        {
            // Yakýnlaþtýrma/Uzaklaþtýrma (Pinch Zoom)
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Began)
            {
                startTouch0 = touch0.position;
                startTouch1 = touch1.position;
                startDistance = Vector2.Distance(startTouch0, startTouch1);
                startScale = transform.localScale;
            }

            float currentDistance = Vector2.Distance(touch0.position, touch1.position);
            float scaleFactor = currentDistance / startDistance;
            transform.localScale = startScale * scaleFactor;
        }
    }
}
