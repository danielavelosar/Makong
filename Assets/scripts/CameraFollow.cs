using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //variable para que la cámara siga
    public Transform target;
    public Vector3 offset = new Vector3 (0.5f, 0.0f, -10f);
    //para que no siga tan bruscamente a la cámara
    public float dampingTime = 0.2f;
    public Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update

    void Awake(){
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCameraAlong(true);
    }

    void ResetCameraPosition()
    {
        MoveCameraAlong(false);
    }
    void MoveCameraAlong(bool smooth)
    {
        Vector3 destination = new Vector3(
            target.position.x-offset.x,
            offset.y,
            offset.z
        );
        if(smooth){
            this.transform.position = Vector3.SmoothDamp(
                this.transform.position,
                destination,
                ref velocity,
                dampingTime
            );
        }else{
            this.transform.position=destination;
        }
    }
}
