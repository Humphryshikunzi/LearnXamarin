using System;

using Android.App;
using Android.Content;
using Android.OS;
using DependencyServiceSample;
using LearnXamarin.Droid.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(BatteryImplementation))]
namespace LearnXamarin.Droid.DependencyServices
{
    class BatteryImplementation : IBattery
    {
        public int RemainingChargePercent
        {
            get
            {
                try
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter))
                        {
                            var level = battery.GetIntExtra(BatteryManager.ExtraLevel, -1);
                            var scale = battery.GetIntExtra(BatteryManager.ExtraScale, -1);
                            return (int)Math.Floor(level * 100D / scale);
                        }
                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Ensure you have android.permission.BATTERY_STATS");
                    throw;
                }
            }
        }


        public DependencyServiceSample.BatteryStatus Status
        {
            get
            {
                try
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter))
                        {
                            int status = battery.GetIntExtra(BatteryManager.ExtraStatus, -1);
                            var isCharging = status == (int)Android.OS.BatteryStatus.Charging || status == (int)Android.OS.BatteryStatus.Full;
                            var chargePlug = battery.GetIntExtra(BatteryManager.ExtraPlugged, -1);
                            var usbCharge = chargePlug == (int)BatteryPlugged.Usb;
                            var acCharge = chargePlug == (int)BatteryPlugged.Ac;
                            bool wirelessCharge = false;
                            wirelessCharge = chargePlug == (int)BatteryPlugged.Wireless;
                            isCharging = (usbCharge || acCharge || wirelessCharge);
                            if (isCharging)
                                return DependencyServiceSample.BatteryStatus.Charging;
                            switch (status)
                            {
                                case (int)Android.OS.BatteryStatus.Charging:
                                    return DependencyServiceSample.BatteryStatus.Charging;
                                case (int)Android.OS.BatteryStatus.Discharging:
                                    return DependencyServiceSample.BatteryStatus.Discharging;
                                case (int)Android.OS.BatteryStatus.Full:
                                    return DependencyServiceSample.BatteryStatus.Full;
                                case (int)Android.OS.BatteryStatus.NotCharging:
                                    return DependencyServiceSample.BatteryStatus.NotCharging;
                                default:
                                    return DependencyServiceSample.BatteryStatus.Unknown;
                            }
                        }
                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Ensure you have android.permission.BATTERY_STATS");
                    throw;
                }
            }
        }


        public PowerSource PowerSource
        {
            get
            {
                try
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter))
                        {
                            int status = battery.GetIntExtra(BatteryManager.ExtraStatus, -1);
                            var isCharging = status == (int)Android.OS.BatteryStatus.Charging || status == (int)Android.OS.BatteryStatus.Full;
                            var chargePlug = battery.GetIntExtra(BatteryManager.ExtraPlugged, -1);
                            var usbCharge = chargePlug == (int)BatteryPlugged.Usb;
                            var acCharge = chargePlug == (int)BatteryPlugged.Ac;
                            bool wirelessCharge = false;
                            wirelessCharge = chargePlug == (int)BatteryPlugged.Wireless;
                            isCharging = (usbCharge || acCharge || wirelessCharge);
                            if (!isCharging)
                                return DependencyServiceSample.PowerSource.Battery;
                            else if (usbCharge)
                                return DependencyServiceSample.PowerSource.Usb;
                            else if (acCharge)
                                return DependencyServiceSample.PowerSource.Ac;
                            else if (wirelessCharge)
                                return DependencyServiceSample.PowerSource.Wireless;
                            else
                                return DependencyServiceSample.PowerSource.Other;
                        }
                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Ensure you have android.permission.BATTERY_STATS");
                    throw;
                }
            }
        }

    }
}