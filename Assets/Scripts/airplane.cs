using UnityEngine;
using System.Collections;

public class airplane : MonoBehaviour {

    public float minSpeed=10;
    public float maxSpeed=50;
    public float currentSpeed=20;
    public int maxNonLethalStrike = 3;

    private GameObject airScrew;
	private Transform thisTransform;
	private Rigidbody thisRigidBody;

	private Transform forceOnHead;
	private Transform forceOnLeftWin;
	private Transform forceOnRightWin;
	private Transform forceOnLeftNail;
	private Transform forceOnRightNail;

    private float rollAngleLeft = 0;
    private float rollAngleRight = 0;
    private float pullUpAngle = 0;
    private float pitchDownAngle = 0;

    private bool rollLeft = false;
    private bool rollRight = false;
    private bool pullUp = false;
    private bool pitchDown = false;

    private Transform planeMeshBody;
    private Transform planeRigidBody;

	void Start () {
        airScrew = GameObject.Find("airscrew");
        
		thisRigidBody = this.rigidbody;
		thisTransform = this.transform;
        planeMeshBody = thisTransform.Find("Model");
        planeRigidBody = thisTransform.Find("PlainBody");
        
	}
	
	// Update is called once per frame
    void Update()
    {


        #region control by keyboard
        //accelerate or decelerate
        if (Input.GetKey(KeyCode.W) && currentSpeed < maxSpeed)
            currentSpeed += 0.1F;

        if (Input.GetKey(KeyCode.S) && currentSpeed > minSpeed)
            currentSpeed -= 0.1F;

        // roll left or right
        if (Input.GetKeyDown(KeyCode.LeftArrow)) rollLeft = true;
        if (Input.GetKeyUp(KeyCode.LeftArrow)) rollLeft = false;

        if (Input.GetKeyDown(KeyCode.RightArrow)) rollRight = true;
        if (Input.GetKeyUp(KeyCode.RightArrow)) rollRight = false;

        //up or down
        if (Input.GetKeyDown(KeyCode.UpArrow)) pitchDown = true;
        if (Input.GetKeyUp(KeyCode.UpArrow)) pitchDown = false;
        if (Input.GetKeyDown(KeyCode.DownArrow)) pullUp = true;
        if (Input.GetKeyUp(KeyCode.DownArrow)) pullUp = false;


        #endregion

        #region roll left and right
        var rollangle = angle_360(planeRigidBody.up, planeMeshBody.forward);

        Debug.Log(planeMeshBody.forward);

        if (rollLeft && Mathf.Abs(rollangle) < 90)
        {
            planeMeshBody.Rotate(planeRigidBody.up, rollAngleLeft);
            rollAngleLeft -= 0.05F;

        }
        else
        {
            rollAngleLeft = 0;
        }

        if (!rollLeft && rollangle > 0)
        {
            rollAngleLeft -= 0.1F * rollangle;
            planeMeshBody.Rotate(planeRigidBody.up, -rollAngleLeft);
        }

        if (rollRight && rollangle - 0.1F > -90)
        {

            planeMeshBody.Rotate(planeRigidBody.up, -rollAngleRight);
            rollAngleRight -= 0.05F;
        }
        else
        {
            rollAngleRight = 0;
        }
        if (!rollRight && rollangle < 0)
        {
            rollAngleRight += 0.1F * -rollangle;
            planeMeshBody.Rotate(planeRigidBody.up, -rollAngleRight);
        }
        #endregion

        //modify plane 
        if (rollLeft)
        {
            thisTransform.Rotate(thisTransform.up, -0.5F);
        }

        if (rollRight)
        {
            thisTransform.Rotate(thisTransform.up, 0.5F);
        }
        airScrew.transform.Rotate(0, Time.deltaTime * currentSpeed * 50, 0);

        thisRigidBody.AddForce(thisTransform.forward * currentSpeed);
    }

    private float angle_360(Vector3 from_, Vector3 to_)
    {
        Vector3 v3 = Vector3.Cross(from_, to_);
        if (v3.z > 0)
            return Vector3.Angle(from_, to_);
        else
            return - Vector3.Angle(from_, to_);
    } 
}


