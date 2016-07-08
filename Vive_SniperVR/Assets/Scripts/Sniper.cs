using UnityEngine;
using System.Collections;

public class Sniper : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public SteamVR_TrackedObject trackedObj;
    public float ZoomIncrement;
    public float ZoomMax;
    public float ZoomMin;
    public Camera scopeCamera;

    // Update is called once per frame
    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            //print("Right Controller has pulled the trigger");
            GameObject bullet = GameObject.Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.transform.forward * BulletSpeed;
            GetComponent<AudioSource>().Play();

            //joint = go.AddComponent<FixedJoint>();
            //joint.connectedBody = attachPoint;
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) {
            float touchY = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y;
            if (touchY > 0) {
                print("Zoom In");
                scopeCamera.fieldOfView -= ZoomIncrement;
            }
            if (touchY < 0) {
                print("Zoom Out");
                scopeCamera.fieldOfView += ZoomIncrement;
            }
            if (scopeCamera.fieldOfView < ZoomMin) scopeCamera.fieldOfView = ZoomMin;
            if (scopeCamera.fieldOfView > ZoomMax) scopeCamera.fieldOfView = ZoomMax;
        }
    }
}
