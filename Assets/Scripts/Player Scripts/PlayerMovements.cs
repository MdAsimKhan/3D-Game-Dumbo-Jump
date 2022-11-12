using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovements : MonoBehaviour
{
    public Camera cam;
    float moveF = 0.5f, jumpF = 0.15f, jumpT = 0.15f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            print("Presses A/left arrow");
            Jump(true);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            print("Presses D/right arrow");
            Jump(false);
        }
    }

    void Jump(bool left)
    {
        if (left)
        {
            rb.DORotate(new Vector3(0f, 90f, 0f), 0f);
            Vector3 temp = transform.position;
            rb.DOJump(new Vector3(temp.x - moveF, temp.y + jumpF, temp.z), 0.5f, 1, jumpT);
            // cam movements trial
            Vector3 camPos = cam.transform.position;
            cam.transform.position = new Vector3(camPos.x - moveF, camPos.y + jumpF, camPos.z);
        }
        else
        {
            rb.DORotate(new Vector3(0f, -180f, 0f), 0f);
            Vector3 temp = transform.position;
            rb.DOJump(new Vector3(temp.x + moveF, temp.y + jumpF, temp.z), 0.5f, 1, jumpT);
            // cam movements trial
            Vector3 camPos = cam.transform.position;
            cam.transform.position = new Vector3(camPos.x - moveF, camPos.y + jumpF, camPos.z);
        }
    }
}
