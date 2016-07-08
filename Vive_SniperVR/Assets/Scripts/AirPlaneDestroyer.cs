using UnityEngine;
using System.Collections;

public class AirPlaneDestroyer : MonoBehaviour {

    public GameObject Explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision) {
        print("You hit a plane!");
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
