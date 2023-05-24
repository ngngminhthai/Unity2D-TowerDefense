using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class InitRotateScreen : MonoBehaviour
    {
        private void Start()
        {
            //if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
            //{
            //    Screen.orientation = ScreenOrientation.LandscapeLeft;
            //}
            //else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
            //{
            //    Screen.orientation = ScreenOrientation.LandscapeRight;
            //}
            //else if (Input.deviceOrientation == DeviceOrientation.Portrait)
            //{
            //    Screen.orientation = ScreenOrientation.Portrait;
            //}
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = false;
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
}
