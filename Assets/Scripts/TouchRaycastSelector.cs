using UnityEngine;

public class PartSelector : MonoBehaviour
{
    Camera arCamera;

    void Start()
    {
        arCamera = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("AnatomyPart"))
                {
                    Debug.Log("Seçilen parça: " + hit.transform.name);
                    // Ýsteðe baðlý: renklendir, bilgi kutusu aç, vurgula vs.
                    hit.transform.GetComponent<Renderer>().material.color = Color.yellow;
                }
            }
        }
    }
}
