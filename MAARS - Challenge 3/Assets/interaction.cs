using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    string target;
    bool isOpen;
    bool isClosed;
    Animator a;
    // Start is called before the first frame update
    void Start()
    {
        isClosed = true;
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                target = Hit.transform.name;
                switch (target)
                {
                    case "door":
                        a = Hit.collider.GetComponent<Animator>();
                        a.SetBool("touch", true);
                        
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
