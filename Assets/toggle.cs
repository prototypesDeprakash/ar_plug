using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle : MonoBehaviour
{
    public GameObject user_camera;
    public GameObject arcamera;
    public GameObject ground_temp;

   public void Toggle_cam_mode_ar()
    {
        user_camera.SetActive(false);
        arcamera.SetActive(true);
        ground_temp.SetActive(false);
    }
    public void Toggle_Usercamer()
    {
        user_camera.SetActive(true);
        arcamera.SetActive(false);
        ground_temp.SetActive(true);
    }
}

