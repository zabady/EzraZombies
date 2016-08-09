using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ViveControllerShooting : MonoBehaviour
{

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;
    public static bool isFiring = false;
    public static bool isReloading = false;
    // Use this for initialization
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("trigger");
            isFiring = true;
        }
        else
            isFiring = false;
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log("trigger");
            isReloading = true;
        }
        else
            isReloading = false;
    }
}
