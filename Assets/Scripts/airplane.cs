using UnityEngine;
using System.Collections;

public class airplane : MonoBehaviour {

    public float speed = 90.0f;

    public Camera camera;
	void Start () {

      
	}
	
	// Update is called once per frame
    void Update()
    {
        Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;
        float bise = 0.7f;

        camera.transform.position = camera.transform.position * bise + moveCamTo * (1 - bise);
       
        camera.transform.LookAt(transform.position+transform.forward*30.0f);
        transform.position += transform.forward * Time.deltaTime * speed;
        speed = -transform.forward.y * Time.deltaTime * 50.0f;
        if (speed < 35.0f)
        {
            speed = 35.0f;
        }
        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal")*10.0f);
        float terrianHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);
        if (terrianHeightWhereWeAre > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrianHeightWhereWeAre, transform.position.z);
        }

        if (Input.GetKey(UnityEngine.KeyCode.Escape))
        {
            Application.LoadLevelAsync(Global.startUI);
        }
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


