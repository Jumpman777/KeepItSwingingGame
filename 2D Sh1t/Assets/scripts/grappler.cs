using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class grappler : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer line;
    public DistanceJoint2D distance;
    public Transform grappleStartPos;

    public Rigidbody2D rb2D;


    // Start is called before the first frame update
    void Start()
    {
        distance.enabled= false;
        line.enabled= false;

        rb2D= GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = Mathf.Abs(mainCamera.transform.position.z);
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(mouseScreenPosition);
           
            //Set starting line pos to grappleStartPos
            line.SetPosition(0, grappleStartPos.transform.position);
            //set end pos to mouisePos
            line.SetPosition(1, mousePos);

            //anchor for distantJoint is the world space mousePos
            distance.connectedAnchor = mousePos;

            // Enable distance joint
            distance.enabled = true;
            //enable line renderer
            line.enabled = true;

        }
        else if(Input.GetMouseButtonUp(0))
        {
            // disable line & distanceJoint
            distance.enabled = false;
            line.enabled = false;
        }
        if (distance.enabled)
        {
            // update when end of the line to follow grapple start pos
            line.SetPosition(0, grappleStartPos.transform.position);
        }


    }
}
