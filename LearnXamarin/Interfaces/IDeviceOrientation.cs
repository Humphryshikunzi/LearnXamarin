using System;
using System.Collections.Generic;
using System.Text;

namespace LearnXamarin.ViewModels
{
    public enum DeviceOrientations
    {
        Undefined,
        Portrait,
        Landscape
    }
     public interface IDeviceOrientation
    {
        DeviceOrientations GetOrientation();
    }
}
