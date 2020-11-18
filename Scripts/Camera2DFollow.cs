using System.Collections;
using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{
    public Transform target;
    public float damping = 0.2f;
    public float lookAheadFactor = 3;
    public float lookAheadReturnSpeed = 0.5f;
    public float lookAheadMoveThreshold = 2;
    public float minYPos = -1;
    public float minXPos = -1;
    public float minZPos = -10;
    public float maxZPos = -10;

    float offsetZ;
    Vector3 lastTargetPosition;
    Vector3 currentVelocity;
    Vector3 lookAheadPos;

    float nextTimeToSearch =0;

    // Start is called before the first frame update
    void Start()
    {
       lastTargetPosition = target.position;
       offsetZ = (transform.position - target.position).z;
       transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            FindPlayer ();
            return;
        }
            

        //only update lookahead pos if moving or changed direction
        float xMoveDelta = (target.position - lastTargetPosition).x;

        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if( updateLookAheadTarget ) {
            lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
        } else {
            lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

        newPos = new Vector3(Mathf.Clamp(newPos.x, minXPos, 102.05f), Mathf.Clamp(newPos.y, minYPos, 1.6f), Mathf.Clamp(newPos.z, minZPos, maxZPos));
        transform.position = newPos;
        lastTargetPosition = target.position;
    }

    void FindPlayer() {
        if(nextTimeToSearch <= Time.time){
            GameObject SearchResult = GameObject.FindGameObjectWithTag("Player");
            if(SearchResult != null)
                target = SearchResult.transform;
            nextTimeToSearch = Time.time + 0.5f;
        }
    }
}

