using System.Runtime.InteropServices;
using ObjCRuntime;

namespace BlueSTSDK
{
    [Native]
    public enum BlueSTSDKFeatureFieldType : long
    {
        Float,
        Double,
        Int64,
        UInt32,
        Int32,
        UInt16,
        Int16,
        UInt8,
        Int8,
        UInt8Array,
        Int16Array
    }

    [Native]
    public enum BlueSTSDKNodeState : long
    {
        Init = 0,
        Idle = 1,
        Connecting = 2,
        Connected = 3,
        Disconnecting = 4,
        Lost = 5,
        Unreachable = 6,
        Dead = 7
    }

    [Native]
    public enum BlueSTSDKNodeType : long
    {
        Generic = 0,
        StevalWesu1 = 1,
        Sensor_Tile = 2,
        Blue_Coin = 3,
        StevalIdb008vx = 4,
        StevalBcn002v1 = 5,
        Sensor_Tile_Box = 6,
        Discovery_IOT01A = 7,
        Nucleo = 128
    }

    [Native]
    public enum BlueSTSDKFeatureBatteryStatus : long
    {
        LowBattery = 0,
        Discharging = 1,
        PluggedNotCharging = 2,
        Charging = 3,
        Unknown = 4,
        Error = 255
    }

    [Native]
    public enum BlueSTSDKFeatureCarryPositionType : long
    {
        Unknown = 0,
        OnDesk = 1,
        InHand = 2,
        NearHead = 3,
        ShirtPocket = 4,
        TrousersPocket = 5,
        ArmSwing = 6,
        Error = 255
    }

    [Native]
    public enum BlueSTSDKFeatureProximityGestureType : long
    {
        Unknown = 0,
        Tap = 1,
        Left = 2,
        Right = 3,
        Error = 255
    }

    [Native]
    public enum BlueSTSDKFeatureMemsGestureType : long
    {
        Unknown = 0,
        PickUp = 1,
        Glance = 2,
        WakeUp = 3,
        Error = 255
    }

    [Native]
    public enum BlueSTSDKFeatureAccelerometerEventType : long
    {
        NoEvent = 0,
        OrientationTopRight = 1,
        OrientationBottomRight = 2,
        OrientationBottomLeft = 3,
        OrientationTopLeft = 4,
        OrientationUp = 5,
        OrientationDown = 6,
        Tilt = 8,
        FreeFall = 16,
        SingleTap = 32,
        DoubleTap = 64,
        WakeUp = 128,
        Pedometer = 256,
        Error
    }

    public enum BlueSTSDKFeatureAccelerationDetectableEventType : sbyte
    {
        Orientation = 111,
        Multiple = 109,
        FreeFall = 102,
        SingleTap = 115,
        DoubleTap = 100,
        WakeUp = 119,
        Tilt = 116,
        Pedometer = 112,
        None = 0
    }

    public enum BlueSTSDKFeatureBeamFormingDirection : byte
    {
        Top = 1,
        TopRight = 2,
        Right = 3,
        BottomRight = 4,
        Bottom = 5,
        BottomLeft = 6,
        Left = 7,
        TopLeft = 8,
        Unknown = 255
    }

    public enum BlueSTSDKFeatureSDLoggingStatus : byte
    {
        Stopped = 0,
        Started = 1,
        NoSd = 2,
        IoError = 255
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BlueSTSDKRegisterHeader_t
    {
        public byte ctrl;

        public byte addr;

        public byte err;

        public byte len;
    }

    [Native]
    public enum BlueSTSDKRegisterAccess_e : long
    {
        R = 1,
        W = 2,
        Rw = R | W
    }

    [Native]
    public enum BlueSTSDKRegisterTarget_e : long
    {
        Persistent = 1,
        Session = 2,
        Both = 3
    }

    [Native]
    public enum BlueSTSDKWeSURegisterName_e : long
    {
        None,
        FwVer,
        LedConfig,
        BleLocName,
        BlePubAddr,
        BleAddrType,
        BatteryLevel,
        BatteryVoltage,
        Current,
        PwrmngStatus,
        RadioTxpwrConfig,
        TimerFreq,
        PwrModeConfig,
        GroupAFeatureCtrls0001,
        GroupAFeatureCtrls0002,
        GroupAFeatureCtrls0004,
        GroupAFeatureCtrls0008,
        GroupAFeatureCtrls0010,
        GroupAFeatureCtrls0020,
        GroupAFeatureCtrls0040,
        GroupAFeatureCtrls0080,
        GroupAFeatureCtrls0100,
        GroupAFeatureCtrls0200,
        GroupAFeatureCtrls0400,
        GroupAFeatureCtrls0800,
        GroupAFeatureCtrls1000,
        GroupAFeatureCtrls2000,
        GroupAFeatureCtrls4000,
        GroupAFeatureCtrls8000,
        GroupBFeatureCtrls0001,
        GroupBFeatureCtrls0002,
        GroupBFeatureCtrls0004,
        GroupBFeatureCtrls0008,
        GroupBFeatureCtrls0010,
        GroupBFeatureCtrls0020,
        GroupBFeatureCtrls0040,
        GroupBFeatureCtrls0080,
        GroupBFeatureCtrls0100,
        GroupBFeatureCtrls0200,
        GroupBFeatureCtrls0400,
        GroupBFeatureCtrls0800,
        GroupBFeatureCtrls1000,
        GroupBFeatureCtrls2000,
        GroupBFeatureCtrls4000,
        GroupBFeatureCtrls8000,
        BleDebugConfig,
        UsbDebugConfig,
        GroupACalibrationMap,
        GroupBCalibrationMap,
        GroupAFeaturesMap,
        GroupBFeaturesMap,
        BluenrgInfo,
        MagnetometerCalibrationStart,
        AccelerometerConfigFs,
        AccelerometerConfigOdr,
        GyroscopeConfigFs,
        GyroscopeConfigOdr,
        MagnetometerConfigFs,
        MagnetometerConfigOdr,
        PressureConfigFs,
        PressureConfigOdr,
        MotionFxCalibrationLicStatus,
        MotionArValueLicStatus,
        MotionCpValueLicStatus,
        RtcDateTime,
        DfuReboot,
        PowerOff
    }
}
