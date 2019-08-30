using System;
using CoreBluetooth;
using Foundation;
using ObjCRuntime;

namespace BlueSTSDK
{
    // @interface BlueSTSDKFeatureField : NSObject
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKFeatureField
    {
        // @property (readonly) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly) NSString * _Nullable unit;
        [NullAllowed, Export("unit")]
        string Unit { get; }

        // @property (readonly) NSNumber * _Nonnull min;
        [Export("min")]
        NSNumber Min { get; }

        // @property (readonly) NSNumber * _Nonnull max;
        [Export("max")]
        NSNumber Max { get; }

        // @property (readonly) BlueSTSDKFeatureFieldType type;
        [Export("type")]
        BlueSTSDKFeatureFieldType Type { get; }

        // +(instancetype _Nonnull)createWithName:(NSString * _Nonnull)name unit:(NSString * _Nullable)unit type:(BlueSTSDKFeatureFieldType)type min:(NSNumber * _Nonnull)min max:(NSNumber * _Nonnull)max;
        [Static]
        [Export("createWithName:unit:type:min:max:")]
        BlueSTSDKFeatureField CreateWithName(string name, [NullAllowed] string unit, BlueSTSDKFeatureFieldType type, NSNumber min, NSNumber max);

        // -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name unit:(NSString * _Nullable)unit type:(BlueSTSDKFeatureFieldType)type min:(NSNumber * _Nonnull)min max:(NSNumber * _Nonnull)max;
        [Export("initWithName:unit:type:min:max:")]
        IntPtr Constructor(string name, [NullAllowed] string unit, BlueSTSDKFeatureFieldType type, NSNumber min, NSNumber max);

        // -(BOOL)hasUnit;
        [Export("hasUnit")]
        //[Verify(MethodToProperty)]
        bool HasUnit();
    }

    // @interface BlueSTSDKFeatureSample : NSObject
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKFeatureSample
    {
        // @property (readonly, retain) NSDate * _Nonnull notificaitonTime;
        [Export("notificaitonTime", ArgumentSemantic.Retain)]
        NSDate NotificaitonTime { get; }

        // @property (readonly) uint64_t timestamp;
        [Export("timestamp")]
        ulong Timestamp { get; }

        // @property (readonly, retain) NSArray<NSNumber *> * _Nonnull data;
        [Export("data", ArgumentSemantic.Retain)]
        NSNumber[] Data { get; }

        // +(instancetype _Nonnull)sampleWithTimestamp:(uint64_t)timestamp data:(NSArray<NSNumber *> * _Nonnull)data;
        [Static]
        [Export("sampleWithTimestamp:data:")]
        BlueSTSDKFeatureSample SampleWithTimestamp(ulong timestamp, NSNumber[] data);

        // -(instancetype _Nonnull)initWhitTimestamp:(uint64_t)timestamp data:(NSArray<NSNumber *> * _Nonnull)data;
        [Export("initWhitTimestamp:data:")]
        IntPtr Constructor(ulong timestamp, NSNumber[] data);
    }

    // @interface BlueSTSDKFeature : NSObject
    [iOS(5, 0)]
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKFeature : INativeObject
    {
        // @property (readonly) _Bool enabled;
        [Export("enabled")]
        bool Enabled { get; }

        // @property (readonly, retain, nonatomic) NSString * _Nonnull name;
        [Export("name", ArgumentSemantic.Retain)]
        string Name { get; }

        // @property (readonly, retain, nonatomic) BlueSTSDKNode * _Nonnull parentNode;
        [Export("parentNode", ArgumentSemantic.Retain)]
        BlueSTSDKNode ParentNode { get; }

        // @property (readonly) NSDate * _Nullable lastUpdate;
        [NullAllowed, Export("lastUpdate")]
        NSDate LastUpdate { get; }

        // @property (readonly, atomic) BlueSTSDKFeatureSample * _Nullable lastSample;
        [NullAllowed, Export("lastSample")]
        BlueSTSDKFeatureSample LastSample { get; }

        // -(NSString * _Nonnull)description;
        [Export("description")]
        //[Verify(MethodToProperty)]
        string Description { get; }

        // -(void)addFeatureDelegate:(id<BlueSTSDKFeatureDelegate> _Nonnull)delegate;
        [Export("addFeatureDelegate:")]
        void AddFeatureDelegate(BlueSTSDKFeatureDelegate @delegate);

        // -(void)removeFeatureDelegate:(id<BlueSTSDKFeatureDelegate> _Nonnull)delegate;
        [Export("removeFeatureDelegate:")]
        void RemoveFeatureDelegate(BlueSTSDKFeatureDelegate @delegate);

        // -(void)addFeatureLoggerDelegate:(id<BlueSTSDKFeatureLogDelegate> _Nonnull)delegate;
        [Export("addFeatureLoggerDelegate:")]
        void AddFeatureLoggerDelegate(BlueSTSDKFeatureLogDelegate @delegate);

        // -(void)removeFeatureLoggerDelegate:(id<BlueSTSDKFeatureLogDelegate> _Nonnull)delegate;
        [Export("removeFeatureLoggerDelegate:")]
        void RemoveFeatureLoggerDelegate(BlueSTSDKFeatureLogDelegate @delegate);

        // -(_Bool)disableNotification;
        [Export("disableNotification")]
        //[Verify(MethodToProperty)]
        bool DisableNotification { get; }

        // -(_Bool)enableNotification;
        [Export("enableNotification")]
        //[Verify(MethodToProperty)]
        bool EnableNotification { get; }

        // -(_Bool)read;
        [Export("read")]
        //[Verify(MethodToProperty)]
        bool Read { get; }

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node;
        [Export("initWhitNode:")]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc;
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }
    }

    //public interface IBlueSTSDKFeatureDelegate { }

    // @protocol BlueSTSDKFeatureDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKFeatureDelegate //: IBlueSTSDKFeatureDelegate
    {
        // @required -(void)didUpdateFeature:(BlueSTSDKFeature * _Nonnull)feature sample:(BlueSTSDKFeatureSample * _Nonnull)sample;
        [Abstract]
        [Export("didUpdateFeature:sample:")]
        void Sample(BlueSTSDKFeature feature, BlueSTSDKFeatureSample sample);
    }

    //public interface IBlueSTSDKFeatureLogDelegate { }

    // @protocol BlueSTSDKFeatureLogDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKFeatureLogDelegate //: IBlueSTSDKFeatureLogDelegate
    {
        // @required -(void)feature:(BlueSTSDKFeature * _Nonnull)feature rawData:(NSData * _Nonnull)raw sample:(BlueSTSDKFeatureSample * _Nonnull)sample;
        [Abstract]
        [Export("feature:rawData:sample:")]
        void RawData(BlueSTSDKFeature feature, NSData raw, BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKExtractResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKExtractResult
    {
        // @property (readonly) uint32_t nReadBytes;
        [Export("nReadBytes")]
        uint NReadBytes { get; }

        // @property (readonly, retain) BlueSTSDKFeatureSample * _Nullable sample;
        [NullAllowed, Export("sample", ArgumentSemantic.Retain)]
        BlueSTSDKFeatureSample Sample { get; }

        // +(instancetype _Nonnull)resutlWithSample:(BlueSTSDKFeatureSample * _Nullable)sample nReadData:(uint32_t)nReadData;
        [Static]
        [Export("resutlWithSample:nReadData:")]
        BlueSTSDKExtractResult ResutlWithSample([NullAllowed] BlueSTSDKFeatureSample sample, uint nReadData);

        // -(instancetype _Nonnull)initWhitSample:(BlueSTSDKFeatureSample * _Nullable)sample nReadData:(uint32_t)nReadData;
        [Export("initWhitSample:nReadData:")]
        IntPtr Constructor([NullAllowed] BlueSTSDKFeatureSample sample, uint nReadData);
    }

    // @interface  (BlueSTSDKFeature)
    [Category]
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeature_
    {
        // @property (readwrite, atomic) BlueSTSDKFeatureSample * _Nullable lastSample;
        [Export("lastSample")]
        BlueSTSDKFeatureSample LastSample();
        [Export("setLastSample:")]
        void SetLastSample(BlueSTSDKFeatureSample lastSample);

        // @property (readonly, retain, atomic) NSMutableSet * _Nonnull featureDelegates;
        [Export("featureDelegates")]
        NSMutableSet FeatureDelegates();

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node name:(NSString * _Nonnull)name;
        [Export("initWhitNode:name:")]
        IntPtr Constructor(BlueSTSDKNode node, string name);

        // -(void)notifyUpdateWithSample:(BlueSTSDKFeatureSample * _Nullable)sample;
        [Export("notifyUpdateWithSample:")]
        void NotifyUpdateWithSample([NullAllowed] BlueSTSDKFeatureSample sample);

        // -(void)logFeatureUpdate:(NSData * _Nonnull)rawData sample:(BlueSTSDKFeatureSample * _Nullable)sample;
        [Export("logFeatureUpdate:sample:")]
        void LogFeatureUpdate(NSData rawData, [NullAllowed] BlueSTSDKFeatureSample sample);

        // -(_Bool)sendCommand:(uint8_t)commandType data:(NSData * _Nullable)commandData;
        [Export("sendCommand:data:")]
        bool SendCommand(byte commandType, [NullAllowed] NSData commandData);

        // -(void)parseCommandResponseWithTimestamp:(uint64_t)timestamp commandType:(uint8_t)commandType data:(NSData * _Nonnull)data;
        [Export("parseCommandResponseWithTimestamp:commandType:data:")]
        void ParseCommandResponseWithTimestamp(ulong timestamp, byte commandType, NSData data);

        // -(void)writeData:(NSData * _Nonnull)data;
        [Export("writeData:")]
        void WriteData(NSData data);

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset;
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);

        // -(uint32_t)update:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset;
        [Export("update:data:dataOffset:")]
        uint Update(ulong timestamp, NSData data, uint offset);

        // -(void)setEnabled:(_Bool)enabled;
        [Export("setEnabled:")]
        void SetEnabled(bool enabled);
    }

    // @interface BlueSTSDKNode : NSObject
    [iOS(5, 0)]
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKNode
    {
        // @property (readonly, assign, nonatomic) BlueSTSDKNodeState state;
        [Export("state", ArgumentSemantic.Assign)]
        BlueSTSDKNodeState State { get; }

        // @property (readonly, assign, nonatomic) BlueSTSDKNodeType type;
        [Export("type", ArgumentSemantic.Assign)]
        BlueSTSDKNodeType Type { get; }

        // @property (readonly, assign, nonatomic) uint8_t typeId;
        [Export("typeId")]
        byte TypeId { get; }

        // @property (readonly, retain) NSString * _Nonnull name;
        [Export("name", ArgumentSemantic.Retain)]
        string Name { get; }

        // @property (readonly, retain) NSString * _Nullable address;
        [NullAllowed, Export("address", ArgumentSemantic.Retain)]
        string Address { get; }

        // @property (readonly) unsigned char protocolVersion;
        [Export("protocolVersion")]
        byte ProtocolVersion { get; }

        // @property (readonly, retain) NSString * _Nonnull tag;
        [Export("tag", ArgumentSemantic.Retain)]
        string Tag { get; }

        // @property (readonly) NSDate * _Nullable rssiLastUpdate;
        [NullAllowed, Export("rssiLastUpdate")]
        NSDate RssiLastUpdate { get; }

        // @property (readonly, retain) NSNumber * _Nullable RSSI;
        [NullAllowed, Export("RSSI", ArgumentSemantic.Retain)]
        NSNumber RSSI { get; }

        // @property (readonly, retain) BlueSTSDKDebug * _Nullable debugConsole;
        [NullAllowed, Export("debugConsole", ArgumentSemantic.Retain)]
        BlueSTSDKDebug DebugConsole { get; }

        // @property (readonly) BlueSTSDKConfigControl * _Nullable configControl;
        [NullAllowed, Export("configControl")]
        BlueSTSDKConfigControl ConfigControl { get; }

        // @property (readonly) BOOL isSleeping;
        [Export("isSleeping")]
        bool IsSleeping { get; }

        // @property (readonly) BOOL hasExtension;
        [Export("hasExtension")]
        bool HasExtension { get; }

        // @property (readonly) id<BleAdvertiseInfo> _Nonnull advertiseInfo;
        [Export("advertiseInfo")]
        BleAdvertiseInfo AdvertiseInfo { get; }

        // @property (readonly) uint32_t advertiseBitMask;
        [Export("advertiseBitMask")]
        uint AdvertiseBitMask { get; }

        // @property (readonly, retain) NSNumber * _Nonnull txPower;
        [Export("txPower", ArgumentSemantic.Retain)]
        NSNumber TxPower { get; }

        // -(NSString * _Nonnull)friendlyName;
        [Export("friendlyName")]
        //[Verify(MethodToProperty)]
        string FriendlyName { get; }

        // -(NSString * _Nonnull)addressEx;
        [Export("addressEx")]
        //[Verify(MethodToProperty)]
        string AddressEx { get; }

        // +(NSString * _Nonnull)stateToString:(BlueSTSDKNodeState)state;
        [Static]
        [Export("stateToString:")]
        string StateToString(BlueSTSDKNodeState state);

        // -(void)addBleConnectionParamiterDelegate:(id<BlueSTSDKNodeBleConnectionParamDelegate> _Nonnull)delegate;
        [Export("addBleConnectionParamiterDelegate:")]
        void AddBleConnectionParamiterDelegate(BlueSTSDKNodeBleConnectionParamDelegate @delegate);

        // -(void)removeBleConnectionParamiterDelegate:(id<BlueSTSDKNodeBleConnectionParamDelegate> _Nonnull)delegate;
        [Export("removeBleConnectionParamiterDelegate:")]
        void RemoveBleConnectionParamiterDelegate(BlueSTSDKNodeBleConnectionParamDelegate @delegate);

        // -(void)addNodeStatusDelegate:(id<BlueSTSDKNodeStateDelegate> _Nonnull)delegate;
        [Export("addNodeStatusDelegate:")]
        void AddNodeStatusDelegate(BlueSTSDKNodeStateDelegate @delegate);

        // -(void)removeNodeStatusDelegate:(id<BlueSTSDKNodeStateDelegate> _Nonnull)delegate;
        [Export("removeNodeStatusDelegate:")]
        void RemoveNodeStatusDelegate(BlueSTSDKNodeStateDelegate @delegate);

        // -(BOOL)equals:(BlueSTSDKNode * _Nonnull)node;
        [Export("equals:")]
        bool Equals(BlueSTSDKNode node);

        // -(NSArray<BlueSTSDKFeature *> * _Nonnull)getFeatures;
        [Export("getFeatures")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeature[] Features { get; }

        // -(NSArray<BlueSTSDKFeature *> * _Nonnull)getFeaturesOfType:(Class _Nonnull)type;
        [Export("getFeaturesOfType:")]
        BlueSTSDKFeature[] GetFeaturesOfType(Class type);

        // -(BlueSTSDKFeature * _Nullable)getFeatureOfType:(Class _Nonnull)type;
        [Export("getFeatureOfType:")]
        [return: NullAllowed]
        BlueSTSDKFeature GetFeatureOfType(Class type);

        // -(void)readRssi;
        [Export("readRssi")]
        void ReadRssi();

        // -(void)connect;
        [Export("connect")]
        void Connect();

        // -(BOOL)isConnected;
        [Export("isConnected")]
        //[Verify(MethodToProperty)]
        bool IsConnected { get; }

        // -(void)disconnect;
        [Export("disconnect")]
        void Disconnect();

        // -(void)addExternalCharacteristics:(NSDictionary<CBUUID *,NSArray<Class> *> * _Nonnull)userDefinedFeature;
        [Export("addExternalCharacteristics:")]
        void AddExternalCharacteristics(NSDictionary<CBUUID, NSArray<Class>> userDefinedFeature);

        // -(BOOL)readFeature:(BlueSTSDKFeature * _Nonnull)feature;
        [Export("readFeature:")]
        bool ReadFeature(BlueSTSDKFeature feature);

        // -(BOOL)isEnableNotification:(BlueSTSDKFeature * _Nonnull)feature;
        [Export("isEnableNotification:")]
        bool IsEnableNotification(BlueSTSDKFeature feature);

        // -(BOOL)enableNotification:(BlueSTSDKFeature * _Nonnull)feature;
        [Export("enableNotification:")]
        bool EnableNotification(BlueSTSDKFeature feature);

        // -(BOOL)disableNotification:(BlueSTSDKFeature * _Nonnull)feature;
        [Export("disableNotification:")]
        bool DisableNotification(BlueSTSDKFeature feature);

        // +(NSString * _Nonnull)nodeTypeToString:(BlueSTSDKNodeType)type;
        [Static]
        [Export("nodeTypeToString:")]
        string NodeTypeToString(BlueSTSDKNodeType type);

        // -(BOOL)writeDataToFeature:(BlueSTSDKFeature * _Nonnull)f data:(NSData * _Nonnull)data;
        [Export("writeDataToFeature:data:")]
        bool WriteDataToFeature(BlueSTSDKFeature f, NSData data);

        // -(BOOL)isExportingFeature:(Class _Nonnull)featureClass;
        [Export("isExportingFeature:")]
        bool IsExportingFeature(Class featureClass);

        // -(NSInteger)maximumWriteValueLength;
        [Export("maximumWriteValueLength")]
        //[Verify(MethodToProperty)]
        nint MaximumWriteValueLength { get; }
    }

    //public interface IBlueSTSDKNodeStateDelegate { }

    // @protocol BlueSTSDKNodeStateDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKNodeStateDelegate //: IBlueSTSDKNodeStateDelegate
    {
        // @required -(void)node:(BlueSTSDKNode * _Nonnull)node didChangeState:(BlueSTSDKNodeState)newState prevState:(BlueSTSDKNodeState)prevState;
        [Abstract]
        [Export("node:didChangeState:prevState:")]
        void DidChangeState(BlueSTSDKNode node, BlueSTSDKNodeState newState, BlueSTSDKNodeState prevState);
    }

    //public interface IBlueSTSDKNodeBleConnectionParamDelegate { }

    // @protocol BlueSTSDKNodeBleConnectionParamDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKNodeBleConnectionParamDelegate //: IBlueSTSDKNodeBleConnectionParamDelegate
    {
        // @required -(void)node:(BlueSTSDKNode * _Nonnull)node didChangeRssi:(NSInteger)newRssi;
        [Abstract]
        [Export("node:didChangeRssi:")]
        void DidChangeRssi(BlueSTSDKNode node, nint newRssi);

        // @optional -(void)node:(BlueSTSDKNode * _Nonnull)node didChangeTxPower:(NSInteger)newPower;
        [Export("node:didChangeTxPower:")]
        void DidChangeTxPower(BlueSTSDKNode node, nint newPower);
    }

    // @interface  (BlueSTSDKNode)
    [Category]
    [BaseType(typeof(BlueSTSDKNode))]
    interface BlueSTSDKNode_
    {
        // -(instancetype _Nonnull)init:(CBPeripheral * _Nonnull)peripheral rssi:(NSNumber * _Nonnull)rssi advertiseInfo:(id<BleAdvertiseInfo> _Nonnull)advertiseInfo;
        [Export("init:rssi:advertiseInfo:")]
        IntPtr Constructor(CBPeripheral peripheral, NSNumber rssi, BleAdvertiseInfo advertiseInfo);

        // -(void)updateRssi:(NSNumber * _Nonnull)rssi;
        [Export("updateRssi:")]
        void UpdateRssi(NSNumber rssi);

        // -(void)updateTxPower:(NSNumber * _Nonnull)txPower;
        [Export("updateTxPower:")]
        void UpdateTxPower(NSNumber txPower);

        // -(void)updateNodeStatus:(BlueSTSDKNodeState)newState;
        [Export("updateNodeStatus:")]
        void UpdateNodeStatus(BlueSTSDKNodeState newState);

        // -(BOOL)sendCommandMessageToFeature:(BlueSTSDKFeature * _Nonnull)f type:(uint8_t)commandType data:(NSData * _Nonnull)commandData;
        [Export("sendCommandMessageToFeature:type:data:")]
        bool SendCommandMessageToFeature(BlueSTSDKFeature f, byte commandType, NSData commandData);

        // -(void)completeConnection;
        [Export("completeConnection")]
        void CompleteConnection();

        // -(void)connectionError:(NSError *)error;
        [Export("connectionError:")]
        void ConnectionError(NSError error);

        // -(void)completeDisconnection:(NSError *)error;
        [Export("completeDisconnection:")]
        void CompleteDisconnection(NSError error);

        // -(void)characteristicUpdate:(CBCharacteristic *)characteristics;
        [Export("characteristicUpdate:")]
        void CharacteristicUpdate(CBCharacteristic characteristics);
    }

    // @interface BlueSTSDKDebug : NSObject
    [iOS(5, 0)]
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKDebug
    {
        // @property (readonly, strong) BlueSTSDKNode * _Nonnull parentNode;
        [Export("parentNode", ArgumentSemantic.Strong)]
        BlueSTSDKNode ParentNode { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        BlueSTSDKDebugOutputDelegate Delegate { [Bind("getDelegate")] get; [Bind("setDelegate:")] set; }

        // @property (getter = getDelegate, retain, nonatomic, setter = setDelegate:) id<BlueSTSDKDebugOutputDelegate> _Nullable delegate __attribute__((deprecated("")));
        [NullAllowed, Export("delegate", ArgumentSemantic.Retain)]
        NSObject WeakDelegate { [Bind("getDelegate")] get; [Bind("setDelegate:")] set; }

        // -(instancetype _Nonnull)initWithNode:(BlueSTSDKNode * _Nonnull)node periph:(CBPeripheral * _Nonnull)periph termChart:(CBCharacteristic * _Nonnull)termChar errChart:(CBCharacteristic * _Nonnull)errChar;
        [Export("initWithNode:periph:termChart:errChart:")]
        IntPtr Constructor(BlueSTSDKNode node, CBPeripheral periph, CBCharacteristic termChar, CBCharacteristic errChar);

        // -(void)addDebugOutputDelegate:(id<BlueSTSDKDebugOutputDelegate> _Nonnull)delegate;
        [Export("addDebugOutputDelegate:")]
        void AddDebugOutputDelegate(BlueSTSDKDebugOutputDelegate @delegate);

        // -(void)removeDebugOutputDelegate:(id<BlueSTSDKDebugOutputDelegate> _Nonnull)delegate;
        [Export("removeDebugOutputDelegate:")]
        void RemoveDebugOutputDelegate(BlueSTSDKDebugOutputDelegate @delegate);

        // -(NSUInteger)writeMessage:(NSString * _Nonnull)msg;
        [Export("writeMessage:")]
        nuint WriteMessage(string msg);

        // -(NSUInteger)writeMessageData:(NSData * _Nonnull)data;
        [Export("writeMessageData:")]
        nuint WriteMessageData(NSData data);

        // -(BOOL)writeMessageDataFast:(NSData * _Nonnull)data;
        [Export("writeMessageDataFast:")]
        bool WriteMessageDataFast(NSData data);
    }

    //public interface IBlueSTSDKDebugOutputDelegate { }

    // @protocol BlueSTSDKDebugOutputDelegate
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKDebugOutputDelegate //: IBlueSTSDKDebugOutputDelegate
    {
        // @required -(void)debug:(BlueSTSDKDebug * _Nonnull)debug didStdOutReceived:(NSString * _Nonnull)msg;
        [Abstract]
        [Export("debug:didStdOutReceived:")]
        void DidStdOutReceived(BlueSTSDKDebug debug, string msg);

        // @required -(void)debug:(BlueSTSDKDebug * _Nonnull)debug didStdErrReceived:(NSString * _Nonnull)msg;
        [Abstract]
        [Export("debug:didStdErrReceived:")]
        void DidStdErrReceived(BlueSTSDKDebug debug, string msg);

        // @required -(void)debug:(BlueSTSDKDebug * _Nonnull)debug didStdInSend:(NSString * _Nonnull)msg error:(NSError * _Nullable)error;
        [Abstract]
        [Export("debug:didStdInSend:error:")]
        void DidStdInSend(BlueSTSDKDebug debug, string msg, [NullAllowed] NSError error);
    }

    // @interface BlueSTSDKFeatureAcceleration : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureAcceleration
    {
        // +(float)getAccX:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getAccX:")]
        float GetAccX(BlueSTSDKFeatureSample data);

        // +(float)getAccY:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getAccY:")]
        float GetAccY(BlueSTSDKFeatureSample data);

        // +(float)getAccZ:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getAccZ:")]
        float GetAccZ(BlueSTSDKFeatureSample data);
    }

    // @interface BlueSTSDKFeatureAutoConfigurable : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureAutoConfigurable
    {
        // @property (readonly) BOOL isConfigured;
        [Export("isConfigured")]
        bool IsConfigured { get; }

        // -(BOOL)startAutoConfiguration;
        [Export("startAutoConfiguration")]
        //[Verify(MethodToProperty)]
        bool StartAutoConfiguration { get; }

        // -(BOOL)requestAutoConfigurationStatus;
        [Export("requestAutoConfigurationStatus")]
        //[Verify(MethodToProperty)]
        bool RequestAutoConfigurationStatus { get; }

        // -(BOOL)stopAutoConfiguration;
        [Export("stopAutoConfiguration")]
        //[Verify(MethodToProperty)]
        bool StopAutoConfiguration { get; }

        // -(void)addFeatureConfigurationDelegate:(id<BlueSTSDKFeatureAutoConfigurableDelegate>)delegate;
        [Export("addFeatureConfigurationDelegate:")]
        void AddFeatureConfigurationDelegate(BlueSTSDKFeatureAutoConfigurableDelegate @delegate);

        // -(void)removeFeatureConfigurationDelegate:(id<BlueSTSDKFeatureAutoConfigurableDelegate>)delegate;
        [Export("removeFeatureConfigurationDelegate:")]
        void RemoveFeatureConfigurationDelegate(BlueSTSDKFeatureAutoConfigurableDelegate @delegate);
    }

    // public interface IBlueSTSDKFeatureAutoConfigurableDelegate { }

    // @protocol BlueSTSDKFeatureAutoConfigurableDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKFeatureAutoConfigurableDelegate //: IBlueSTSDKFeatureAutoConfigurableDelegate
    {
        // @optional -(void)didAutoConfigurationStart:(BlueSTSDKFeatureAutoConfigurable *)feature;
        [Export("didAutoConfigurationStart:")]
        void DidAutoConfigurationStart(BlueSTSDKFeatureAutoConfigurable feature);

        // @optional -(void)didAutoConfigurationChange:(BlueSTSDKFeatureAutoConfigurable *)feature status:(int32_t)status;
        [Export("didAutoConfigurationChange:status:")]
        void DidAutoConfigurationChange(BlueSTSDKFeatureAutoConfigurable feature, int status);

        // @optional -(void)didConfigurationFinished:(BlueSTSDKFeatureAutoConfigurable *)feature status:(int32_t)status;
        [Export("didConfigurationFinished:status:")]
        void DidConfigurationFinished(BlueSTSDKFeatureAutoConfigurable feature, int status);
    }

    // @interface BlueSTSDKFeatureBattery : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureBattery
    {
        // +(BlueSTSDKFeatureBatteryStatus)getBatteryStatus:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getBatteryStatus:")]
        BlueSTSDKFeatureBatteryStatus GetBatteryStatus(BlueSTSDKFeatureSample data);

        // +(NSString *)getBatteryStatusStr:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getBatteryStatusStr:")]
        string GetBatteryStatusStr(BlueSTSDKFeatureSample data);

        // +(float)getBatteryLevel:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getBatteryLevel:")]
        float GetBatteryLevel(BlueSTSDKFeatureSample data);

        // +(float)getBatteryVoltage:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getBatteryVoltage:")]
        float GetBatteryVoltage(BlueSTSDKFeatureSample data);

        // +(float)getBatteryCurrent:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getBatteryCurrent:")]
        float GetBatteryCurrent(BlueSTSDKFeatureSample data);

        // -(BOOL)readBatteryCapacity;
        [Export("readBatteryCapacity")]
        //[Verify(MethodToProperty)]
        bool ReadBatteryCapacity { get; }

        // -(BOOL)readMaxAbsorbedCurrent;
        [Export("readMaxAbsorbedCurrent")]
        //[Verify(MethodToProperty)]
        bool ReadMaxAbsorbedCurrent { get; }

        // -(void)addBatteryDelegate:(id<BlueSTSDKFeatureBatteryDelegate>)delegate __attribute__((swift_name("addBatteryDelegate(_:)")));
        [Export("addBatteryDelegate:")]
        void AddBatteryDelegate(BlueSTSDKFeatureBatteryDelegate @delegate);

        // -(void)removeBatteryDelegate:(id<BlueSTSDKFeatureBatteryDelegate>)delegate __attribute__((swift_name("removeBatteryDelegate(_:)")));
        [Export("removeBatteryDelegate:")]
        void RemoveBatteryDelegate(BlueSTSDKFeatureBatteryDelegate @delegate);
    }

    //public interface IBlueSTSDKFeatureBatteryDelegate { }

    // @protocol BlueSTSDKFeatureBatteryDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKFeatureBatteryDelegate //: IBlueSTSDKFeatureBatteryDelegate
    {
        // @optional -(void)didCapacityRead:(BlueSTSDKFeatureBattery *)feature capacity:(uint16_t)capacity;
        [Export("didCapacityRead:capacity:")]
        void DidCapacityRead(BlueSTSDKFeatureBattery feature, ushort capacity);

        // @optional -(void)didMaxAssorbedCurrentRead:(BlueSTSDKFeatureBattery *)feature current:(float)current;
        [Export("didMaxAssorbedCurrentRead:current:")]
        void DidMaxAssorbedCurrentRead(BlueSTSDKFeatureBattery feature, float current);
    }

    // @interface BlueSTSDKFeatureCarryPosition : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureCarryPosition
    {
        // +(BlueSTSDKFeatureCarryPositionType)getPositionType:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getPositionType:")]
        BlueSTSDKFeatureCarryPositionType GetPositionType(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKFeatureFreeFall : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureFreeFall
    {
        // +(_Bool)getFreeFallStatus:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getFreeFallStatus:")]
        bool GetFreeFallStatus(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKFeatureGyroscope : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureGyroscope
    {
        // +(float)getGyroX:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getGyroX:")]
        float GetGyroX(BlueSTSDKFeatureSample data);

        // +(float)getGyroY:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getGyroY:")]
        float GetGyroY(BlueSTSDKFeatureSample data);

        // +(float)getGyroZ:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getGyroZ:")]
        float GetGyroZ(BlueSTSDKFeatureSample data);
    }

    // @interface BlueSTSDKFeatureHumidity : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureHumidity
    {
        // +(float)getHumidity:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getHumidity:")]
        float GetHumidity(BlueSTSDKFeatureSample data);
    }

    // @interface BlueSTSDKFeatureLuminosity : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureLuminosity
    {
        // +(uint16_t)getLuminosity:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getLuminosity:")]
        ushort GetLuminosity(BlueSTSDKFeatureSample data);
    }

    // @interface BlueSTSDKFeatureMagnetometer : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureMagnetometer
    {
        // +(float)getMagX:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getMagX:")]
        float GetMagX(BlueSTSDKFeatureSample data);

        // +(float)getMagY:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getMagY:")]
        float GetMagY(BlueSTSDKFeatureSample data);

        // +(float)getMagZ:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getMagZ:")]
        float GetMagZ(BlueSTSDKFeatureSample data);
    }

    // @interface BlueSTSDKFeatureMemsSensorFusion : BlueSTSDKFeatureAutoConfigurable
    [BaseType(typeof(BlueSTSDKFeatureAutoConfigurable))]
    interface BlueSTSDKFeatureMemsSensorFusion
    {
        // +(float)getQi:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getQi:")]
        float GetQi(BlueSTSDKFeatureSample data);

        // +(float)getQj:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getQj:")]
        float GetQj(BlueSTSDKFeatureSample data);

        // +(float)getQk:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getQk:")]
        float GetQk(BlueSTSDKFeatureSample data);

        // +(float)getQs:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getQs:")]
        float GetQs(BlueSTSDKFeatureSample data);
    }

    // @interface BlueSTSDKFeatureMemsSensorFusionCompact : BlueSTSDKFeatureMemsSensorFusion
    [BaseType(typeof(BlueSTSDKFeatureMemsSensorFusion))]
    interface BlueSTSDKFeatureMemsSensorFusionCompact
    {
        // +(float)getQi:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getQi:")]
        float GetQi(BlueSTSDKFeatureSample data);

        // +(float)getQj:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getQj:")]
        float GetQj(BlueSTSDKFeatureSample data);

        // +(float)getQk:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getQk:")]
        float GetQk(BlueSTSDKFeatureSample data);

        // +(float)getQs:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getQs:")]
        float GetQs(BlueSTSDKFeatureSample data);
    }

    // @interface BlueSTSDKFeaturePressure : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeaturePressure
    {
        // +(float)getPressure:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getPressure:")]
        float GetPressure(BlueSTSDKFeatureSample data);
    }

    // @interface BlueSTSDKFeatureProximity : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureProximity
    {
        // +(uint16_t)getProximityDistance:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getProximityDistance:")]
        ushort GetProximityDistance(BlueSTSDKFeatureSample data);

        // +(BOOL)isOutOfRangeSample:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("isOutOfRangeSample:")]
        bool IsOutOfRangeSample(BlueSTSDKFeatureSample sample);

        // +(uint16_t)outOfRangeValue;
        [Static]
        [Export("outOfRangeValue")]
        //[Verify(MethodToProperty)]
        ushort OutOfRangeValue { get; }
    }

    // @interface BlueSTSDKFeatureMicLevel : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureMicLevel
    {
        // +(int8_t)getMicLevel:(BlueSTSDKFeatureSample *)data micId:(uint8_t)micId;
        [Static]
        [Export("getMicLevel:micId:")]
        sbyte GetMicLevel(BlueSTSDKFeatureSample data, byte micId);
    }

    // @interface BlueSTSDKFeatureTemperature : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureTemperature
    {
        // +(float)getTemperature:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getTemperature:")]
        float GetTemperature(BlueSTSDKFeatureSample data);
    }

    // @interface BlueSTSDKFeatureProximityGesture : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureProximityGesture
    {
        // +(BlueSTSDKFeatureProximityGestureType)getGestureType:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getGestureType:")]
        BlueSTSDKFeatureProximityGestureType GetGestureType(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKFeatureMemsGesture : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureMemsGesture
    {
        // +(BlueSTSDKFeatureMemsGestureType)getGestureType:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getGestureType:")]
        BlueSTSDKFeatureMemsGestureType GetGestureType(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKFeaturePedometer : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeaturePedometer
    {
        // +(NSUInteger)getSteps:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getSteps:")]
        nuint GetSteps(BlueSTSDKFeatureSample sample);

        // +(uint16_t)getFrequency:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getFrequency:")]
        ushort GetFrequency(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKFeatureAccelerometerEvent : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureAccelerometerEvent
    {
        // @property (readonly) BlueSTSDKFeatureAccelerationDetectableEventType DEFAULT_ENABLED_EVENT __attribute__((swift_name("DEFAULT_ENABLED_EVENT")));
        [Export("DEFAULT_ENABLED_EVENT")]
        BlueSTSDKFeatureAccelerationDetectableEventType DEFAULT_ENABLED_EVENT { get; }

        // +(NSString *)detectableEventTypeToString:(BlueSTSDKFeatureAccelerationDetectableEventType)event;
        [Static]
        [Export("detectableEventTypeToString:")]
        string DetectableEventTypeToString(BlueSTSDKFeatureAccelerationDetectableEventType @event);

        // +(NSString *)eventTypeToString:(BlueSTSDKFeatureAccelerometerEventType)event;
        [Static]
        [Export("eventTypeToString:")]
        string EventTypeToString(BlueSTSDKFeatureAccelerometerEventType @event);

        // -(BOOL)enableEvent:(BlueSTSDKFeatureAccelerationDetectableEventType)type enable:(BOOL)enable;
        [Export("enableEvent:enable:")]
        bool EnableEvent(BlueSTSDKFeatureAccelerationDetectableEventType type, bool enable);

        // -(void)addFeatureAccelerationEnableTypeDelegate:(id<BlueSTSDKFeatureAccelerationEnableTypeDelegate>)delegate;
        [Export("addFeatureAccelerationEnableTypeDelegate:")]
        void AddFeatureAccelerationEnableTypeDelegate(BlueSTSDKFeatureAccelerationEnableTypeDelegate @delegate);

        // -(void)removeFeatureAccelerationEnableTypeDelegate:(id<BlueSTSDKFeatureAccelerationEnableTypeDelegate>)delegate;
        [Export("removeFeatureAccelerationEnableTypeDelegate:")]
        void RemoveFeatureAccelerationEnableTypeDelegate(BlueSTSDKFeatureAccelerationEnableTypeDelegate @delegate);

        // +(BlueSTSDKFeatureAccelerometerEventType)getAccelerationEvent:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getAccelerationEvent:")]
        BlueSTSDKFeatureAccelerometerEventType GetAccelerationEvent(BlueSTSDKFeatureSample sample);

        // +(BlueSTSDKFeatureAccelerometerEventType)extractOrientationEvent:(BlueSTSDKFeatureAccelerometerEventType)event;
        [Static]
        [Export("extractOrientationEvent:")]
        BlueSTSDKFeatureAccelerometerEventType ExtractOrientationEvent(BlueSTSDKFeatureAccelerometerEventType @event);

        // +(int32_t)getPedometerSteps:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getPedometerSteps:")]
        int GetPedometerSteps(BlueSTSDKFeatureSample sample);
    }

    //public interface IBlueSTSDKFeatureAccelerationEnableTypeDelegate { }

    // @protocol BlueSTSDKFeatureAccelerationEnableTypeDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKFeatureAccelerationEnableTypeDelegate //: IBlueSTSDKFeatureAccelerationEnableTypeDelegate
    {
        // @optional -(void)didTypeChangeStatus:(BlueSTSDKFeatureAccelerometerEvent *)feature type:(BlueSTSDKFeatureAccelerationDetectableEventType)type newStatus:(BOOL)newStatus;
        [Export("didTypeChangeStatus:type:newStatus:")]
        void Type(BlueSTSDKFeatureAccelerometerEvent feature, BlueSTSDKFeatureAccelerationDetectableEventType type, bool newStatus);
    }

    // @interface BlueSTSDKFeatureDirectionOfArrival : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureDirectionOfArrival
    {
        // +(int16_t)getAudioSourceAngle:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getAudioSourceAngle:")]
        short GetAudioSourceAngle(BlueSTSDKFeatureSample data);

        // -(void)enableLowSensitivity:(BOOL)enable;
        [Export("enableLowSensitivity:")]
        void EnableLowSensitivity(bool enable);
    }

    // @interface BlueSTSDKFeatureSwitch : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureSwitch
    {
        // +(uint8_t)getSwitchStatus:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getSwitchStatus:")]
        byte GetSwitchStatus(BlueSTSDKFeatureSample data);

        // -(_Bool)setSwitchStatus:(uint8_t)newStatus;
        [Export("setSwitchStatus:")]
        bool SetSwitchStatus(byte newStatus);
    }

    // @interface BlueSTSDKRemoteFeatureHumidity : BlueSTSDKFeatureHumidity
    [BaseType(typeof(BlueSTSDKFeatureHumidity))]
    interface BlueSTSDKRemoteFeatureHumidity
    {
        // +(int)getNodeId:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getNodeId:")]
        int GetNodeId(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKRemoteFeatureTemperature : BlueSTSDKFeatureTemperature
    [BaseType(typeof(BlueSTSDKFeatureTemperature))]
    interface BlueSTSDKRemoteFeatureTemperature
    {
        // +(int)getNodeId:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getNodeId:")]
        int GetNodeId(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKRemoteFeatureSwitch : BlueSTSDKFeatureSwitch
    [BaseType(typeof(BlueSTSDKFeatureSwitch))]
    interface BlueSTSDKRemoteFeatureSwitch
    {
        // +(int)getNodeId:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getNodeId:")]
        int GetNodeId(BlueSTSDKFeatureSample sample);

        // -(_Bool)setSwitchStatus:(uint16_t)nodeId newStatus:(uint8_t)newStatus;
        [Export("setSwitchStatus:newStatus:")]
        bool SetSwitchStatus(ushort nodeId, byte newStatus);
    }

    // @interface BlueSTSDKRemoteFeaturePressure : BlueSTSDKFeaturePressure
    [BaseType(typeof(BlueSTSDKFeaturePressure))]
    interface BlueSTSDKRemoteFeaturePressure
    {
        // +(int)getNodeId:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getNodeId:")]
        int GetNodeId(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKDeviceTimestampFeature : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKDeviceTimestampFeature
    {
    }

    // @interface ADPCMAudioSyncManager : NSObject
    [BaseType(typeof(NSObject))]
    interface ADPCMAudioSyncManager
    {
        // @property BOOL intra_flag;
        [Export("intra_flag")]
        bool Intra_flag { get; set; }

        // @property int16_t adpcm_index_in;
        [Export("adpcm_index_in")]
        short Adpcm_index_in { get; set; }

        // @property int32_t adpcm_predsample_in;
        [Export("adpcm_predsample_in")]
        int Adpcm_predsample_in { get; set; }

        // +(instancetype)audioManager;
        [Static]
        [Export("audioManager")]
        ADPCMAudioSyncManager AudioManager();

        // -(void)setSyncParam:(BlueSTSDKFeatureSample *)sample;
        [Export("setSyncParam:")]
        void SetSyncParam(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKFeatureAudioADPCM : BlueSTSDKDeviceTimestampFeature
    [BaseType(typeof(BlueSTSDKDeviceTimestampFeature))]
    interface BlueSTSDKFeatureAudioADPCM
    {
        // @property (readonly, retain, atomic) ADPCMAudioSyncManager * audioManager;
        [Export("audioManager", ArgumentSemantic.Retain)]
        ADPCMAudioSyncManager AudioManager { get; }

        // +(NSData *)getLinearPCMAudio:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getLinearPCMAudio:")]
        NSData GetLinearPCMAudio(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKFeatureAudioADPCMSync : BlueSTSDKDeviceTimestampFeature
    [BaseType(typeof(BlueSTSDKDeviceTimestampFeature))]
    interface BlueSTSDKFeatureAudioADPCMSync
    {
        // +(int32_t)getPredictedSample:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getPredictedSample:")]
        int GetPredictedSample(BlueSTSDKFeatureSample sample);

        // +(int16_t)getIndex:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getIndex:")]
        short GetIndex(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKFeatureCompass : BlueSTSDKFeatureAutoConfigurable
    [BaseType(typeof(BlueSTSDKFeatureAutoConfigurable))]
    interface BlueSTSDKFeatureCompass
    {
        // +(float)getCompassAngle:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getCompassAngle:")]
        float GetCompassAngle(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKFeatureBeamForming : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureBeamForming
    {
        // +(BlueSTSDKFeatureBeamFormingDirection)getDirection:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getDirection:")]
        BlueSTSDKFeatureBeamFormingDirection GetDirection(BlueSTSDKFeatureSample sample);

        // -(void)enablebeamForming:(BOOL)enabled;
        [Export("enablebeamForming:")]
        void EnablebeamForming(bool enabled);

        // -(void)useStrongbeamFormingAlgorithm:(BOOL)enabled;
        [Export("useStrongbeamFormingAlgorithm:")]
        void UseStrongbeamFormingAlgorithm(bool enabled);

        // -(void)setDirection:(BlueSTSDKFeatureBeamFormingDirection)direction;
        [Export("setDirection:")]
        void SetDirection(BlueSTSDKFeatureBeamFormingDirection direction);
    }

    // @interface BlueSTSDKFeatureMotionIntensity : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureMotionIntensity
    {
        // +(int8_t)getMotionIntensity:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getMotionIntensity:")]
        sbyte GetMotionIntensity(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKFeatureSDLogging : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureSDLogging
    {
        // +(BlueSTSDKFeatureSDLoggingStatus)getStatus:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getStatus:")]
        BlueSTSDKFeatureSDLoggingStatus GetStatus(BlueSTSDKFeatureSample data);

        // +(BOOL)isLogging:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("isLogging:")]
        bool IsLogging(BlueSTSDKFeatureSample data);

        // +(uint32_t)getLogInterval:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getLogInterval:")]
        uint GetLogInterval(BlueSTSDKFeatureSample data);

        // +(NSSet<BlueSTSDKFeature *> *)getLoggedFeature:(BlueSTSDKNode *)node data:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getLoggedFeature:data:")]
        NSSet<BlueSTSDKFeature> GetLoggedFeature(BlueSTSDKNode node, BlueSTSDKFeatureSample data);

        // -(void)sartLoggingFeature:(NSSet<BlueSTSDKFeature *> *)featureToLog evrey:(uint32_t)seconds;
        [Export("sartLoggingFeature:evrey:")]
        void SartLoggingFeature(NSSet<BlueSTSDKFeature> featureToLog, uint seconds);

        // -(void)stopLogging __attribute__((swift_name("stopLogging()")));
        [Export("stopLogging")]
        void StopLogging();
    }

    // @interface BlueSTSDKFeatureCOSensor : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureCOSensor
    {
        // +(float)getGasPresence:(BlueSTSDKFeatureSample * _Nonnull)data;
        [Static]
        [Export("getGasPresence:")]
        float GetGasPresence(BlueSTSDKFeatureSample data);

        // -(void)setSensorSensitivity:(float)newSensitivity;
        [Export("setSensorSensitivity:")]
        void SetSensorSensitivity(float newSensitivity);

        // -(void)requestSensitivity;
        [Export("requestSensitivity")]
        void RequestSensitivity();
    }

    // @protocol BlueSTSDKCOSensorFeatureDelegate <BlueSTSDKFeatureDelegate>
    [Protocol, Model(AutoGeneratedName = true)]
    interface BlueSTSDKCOSensorFeatureDelegate : BlueSTSDKFeatureDelegate
    {
        // @optional -(void)didUpdateFeature:(BlueSTSDKFeatureCOSensor * _Nonnull)feature sensitivity:(float)newSensitivity __attribute__((swift_name("didUpdate(_:sensitivity:)")));
        [Export("didUpdateFeature:sensitivity:")]
        void Sensitivity(BlueSTSDKFeatureCOSensor feature, float newSensitivity);
    }

    // @interface BlueSTSDKStdCharToFeatureMap : NSObject
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKStdCharToFeatureMap
    {
        // +(NSDictionary<CBUUID *,NSArray<Class> *> *)getManageStdCharacteristics;
        [Static]
        [Export("getManageStdCharacteristics")]
        //[Verify(MethodToProperty)]
        NSDictionary<CBUUID, NSArray<Class>> ManageStdCharacteristics { get; }
    }

    // @interface BlueSTSDKFeatureHeartRate : BlueSTSDKDeviceTimestampFeature
    [BaseType(typeof(BlueSTSDKDeviceTimestampFeature))]
    interface BlueSTSDKFeatureHeartRate
    {
        // +(int32_t)getHeartRate:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getHeartRate:")]
        int GetHeartRate(BlueSTSDKFeatureSample sample);

        // +(int32_t)getEnergyExtended:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getEnergyExtended:")]
        int GetEnergyExtended(BlueSTSDKFeatureSample sample);

        // +(float)getRRInterval:(BlueSTSDKFeatureSample *)sample;
        [Static]
        [Export("getRRInterval:")]
        float GetRRInterval(BlueSTSDKFeatureSample sample);
    }

    // @interface BlueSTSDKFeatureGenPurpose : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeatureGenPurpose
    {
        // @property (readonly, weak) CBCharacteristic * characteristics;
        [Export("characteristics", ArgumentSemantic.Weak)]
        CBCharacteristic Characteristics { get; }

        // +(NSData *)getRawData:(BlueSTSDKFeatureSample *)data;
        [Static]
        [Export("getRawData:")]
        NSData GetRawData(BlueSTSDKFeatureSample data);

        // -(instancetype)initWhitNode:(BlueSTSDKNode *)node characteristics:(CBCharacteristic *)c;
        [Export("initWhitNode:characteristics:")]
        IntPtr Constructor(BlueSTSDKNode node, CBCharacteristic c);
    }

    // @interface BlueSTSDKFeatureLogCSV : NSObject <BlueSTSDKFeatureLogDelegate>
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKFeatureLogCSV : BlueSTSDKFeatureLogDelegate
    {
        // @property (readonly, strong) NSDate * startupTimestamp;
        [Export("startupTimestamp", ArgumentSemantic.Strong)]
        NSDate StartupTimestamp { get; }

        // +(instancetype)logger;
        [Static]
        [Export("logger")]
        BlueSTSDKFeatureLogCSV Logger();

        // +(instancetype)loggerWithTimestamp:(NSDate *)timestamp nodes:(NSArray *)nodes;
        [Static]
        [Export("loggerWithTimestamp:nodes:")]
        //[Verify(StronglyTypedNSArray)]
        BlueSTSDKFeatureLogCSV LoggerWithTimestamp(NSDate timestamp, NSObject[] nodes);

        // +(instancetype)loggerWithNodes:(NSArray *)nodes;
        [Static]
        [Export("loggerWithNodes:")]
        //[Verify(StronglyTypedNSArray)]
        BlueSTSDKFeatureLogCSV LoggerWithNodes(NSObject[] nodes);

        // -(instancetype)initWithTimestamp:(NSDate *)timestamp nodes:(NSArray *)nodes;
        [Export("initWithTimestamp:nodes:")]
        //[Verify(StronglyTypedNSArray)]
        IntPtr Constructor(NSDate timestamp, NSObject[] nodes);

        // -(void)closeFiles;
        [Export("closeFiles")]
        void CloseFiles();

        // -(NSArray *)getLogFiles;
        [Export("getLogFiles")]
        //[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] LogFiles { get; }

        // -(void)removeLogFiles;
        [Export("removeLogFiles")]
        void RemoveLogFiles();

        // -(NSString *)sessionPrefix;
        [Export("sessionPrefix")]
        //[Verify(MethodToProperty)]
        string SessionPrefix { get; }

        // +(BOOL)areThereLogFiles;
        [Static]
        [Export("areThereLogFiles")]
        //[Verify(MethodToProperty)]
        bool AreThereLogFiles { get; }

        // +(NSInteger)countAllLogFiles;
        [Static]
        [Export("countAllLogFiles")]
        //[Verify(MethodToProperty)]
        nint CountAllLogFiles { get; }

        // +(NSArray<NSURL *> *)getAllLogFiles;
        [Static]
        [Export("getAllLogFiles")]
        //[Verify(MethodToProperty)]
        NSUrl[] AllLogFiles { get; }

        // +(void)clearLogFolder;
        [Static]
        [Export("clearLogFolder")]
        void ClearLogFolder();

        // +(NSURL *)getDumpFileDirectoryUrl;
        [Static]
        [Export("getDumpFileDirectoryUrl")]
        //[Verify(MethodToProperty)]
        NSUrl DumpFileDirectoryUrl { get; }
    }

    // @interface BlueSTSDKFeatureLogNSLog : NSObject <BlueSTSDKFeatureLogDelegate>
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKFeatureLogNSLog : BlueSTSDKFeatureLogDelegate
    {
        // @property (readonly, strong) NSDate * startupTimestamp;
        [Export("startupTimestamp", ArgumentSemantic.Strong)]
        NSDate StartupTimestamp { get; }

        // +(instancetype)loggerWithTimestamp:(NSDate *)timestamp;
        [Static]
        [Export("loggerWithTimestamp:")]
        BlueSTSDKFeatureLogNSLog LoggerWithTimestamp(NSDate timestamp);

        // -(instancetype)initWithTimestamp:(NSDate *)timestamp;
        [Export("initWithTimestamp:")]
        IntPtr Constructor(NSDate timestamp);
    }

    // @interface BlueSTSDKNodeStatusNSLog : NSObject <BlueSTSDKNodeStateDelegate>
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKNodeStatusNSLog : BlueSTSDKNodeStateDelegate
    {
    }

    // @interface BlueSTSDKRegister : NSObject
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKRegister
    {
        // @property (assign, nonatomic) NSInteger address;
        [Export("address")]
        nint Address { get; set; }

        // @property (assign, nonatomic) BlueSTSDKRegisterAccess_e access;
        [Export("access", ArgumentSemantic.Assign)]
        BlueSTSDKRegisterAccess_e Access { get; set; }

        // @property (assign, nonatomic) BlueSTSDKRegisterTarget_e target;
        [Export("target", ArgumentSemantic.Assign)]
        BlueSTSDKRegisterTarget_e Target { get; set; }

        // @property (assign, nonatomic) NSInteger size;
        [Export("size")]
        nint Size { get; set; }

        // +(instancetype)registerWithAddress:(NSInteger)address size:(NSInteger)size access:(BlueSTSDKRegisterAccess_e)access target:(BlueSTSDKRegisterTarget_e)target;
        [Static]
        [Export("registerWithAddress:size:access:target:")]
        BlueSTSDKRegister RegisterWithAddress(nint address, nint size, BlueSTSDKRegisterAccess_e access, BlueSTSDKRegisterTarget_e target);

        // +(instancetype)registerWithAddress:(NSInteger)address size:(NSInteger)size;
        [Static]
        [Export("registerWithAddress:size:")]
        BlueSTSDKRegister RegisterWithAddress(nint address, nint size);

        // +(instancetype)registerWithAddress:(NSInteger)address size:(NSInteger)size access:(BlueSTSDKRegisterAccess_e)access;
        [Static]
        [Export("registerWithAddress:size:access:")]
        BlueSTSDKRegister RegisterWithAddress(nint address, nint size, BlueSTSDKRegisterAccess_e access);

        // +(instancetype)registerWithAddress:(NSInteger)address size:(NSInteger)size target:(BlueSTSDKRegisterTarget_e)target;
        [Static]
        [Export("registerWithAddress:size:target:")]
        BlueSTSDKRegister RegisterWithAddress(nint address, nint size, BlueSTSDKRegisterTarget_e target);

        // -(instancetype)initWithAddress:(NSInteger)address size:(NSInteger)size access:(BlueSTSDKRegisterAccess_e)access target:(BlueSTSDKRegisterTarget_e)target;
        [Export("initWithAddress:size:access:target:")]
        IntPtr Constructor(nint address, nint size, BlueSTSDKRegisterAccess_e access, BlueSTSDKRegisterTarget_e target);

        // +(instancetype)registerWithData:(NSData *)data;
        [Static]
        [Export("registerWithData:")]
        BlueSTSDKRegister RegisterWithData(NSData data);

        // -(instancetype)initWithData:(NSData *)data;
        [Export("initWithData:")]
        IntPtr Constructor(NSData data);

        // -(void)setHeader:(BlueSTSDKRegisterHeader_t *)pHeader target:(BlueSTSDKRegisterTarget_e)target write:(BOOL)write ack:(BOOL)ack;
        [Export("setHeader:target:write:ack:")]
        void SetHeader(BlueSTSDKRegisterHeader_t pHeader, BlueSTSDKRegisterTarget_e target, bool write, bool ack);

        // -(NSData *)toReadPacketWithTarget:(BlueSTSDKRegisterTarget_e)target;
        [Export("toReadPacketWithTarget:")]
        NSData ToReadPacketWithTarget(BlueSTSDKRegisterTarget_e target);

        // -(NSData *)toWritePacketWithTarget:(BlueSTSDKRegisterTarget_e)target payloadData:(NSData *)payloadData;
        [Export("toWritePacketWithTarget:payloadData:")]
        NSData ToWritePacketWithTarget(BlueSTSDKRegisterTarget_e target, NSData payloadData);

        // +(NSData *)getPayloadFromData:(NSData *)data;
        [Static]
        [Export("getPayloadFromData:")]
        NSData GetPayloadFromData(NSData data);

        // +(BOOL)getHeaderFromData:(NSData *)data header:(BlueSTSDKRegisterHeader_t *)pheader;
        [Static]
        [Export("getHeaderFromData:header:")]
        bool GetHeaderFromData(NSData data, BlueSTSDKRegisterHeader_t pheader);

        // +(BlueSTSDKRegisterTarget_e)getTargetFromData:(NSData *)data;
        [Static]
        [Export("getTargetFromData:")]
        BlueSTSDKRegisterTarget_e GetTargetFromData(NSData data);

        // +(BOOL)isWriteOperationFromData:(NSData *)data;
        [Static]
        [Export("isWriteOperationFromData:")]
        bool IsWriteOperationFromData(NSData data);

        // +(BOOL)isReadOperationFromData:(NSData *)data;
        [Static]
        [Export("isReadOperationFromData:")]
        bool IsReadOperationFromData(NSData data);

        // +(NSInteger)getAddressFromData:(NSData *)data;
        [Static]
        [Export("getAddressFromData:")]
        nint GetAddressFromData(NSData data);

        // +(NSInteger)getErrorFromData:(NSData *)data;
        [Static]
        [Export("getErrorFromData:")]
        nint GetErrorFromData(NSData data);

        // +(NSInteger)getSizeFromData:(NSData *)data;
        [Static]
        [Export("getSizeFromData:")]
        nint GetSizeFromData(NSData data);
    }

    // @interface BlueSTSDKCommand : NSObject
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKCommand
    {
        // @property (retain, nonatomic) BlueSTSDKRegister * registerField;
        [Export("registerField", ArgumentSemantic.Retain)]
        BlueSTSDKRegister RegisterField { get; set; }

        // @property (assign, nonatomic) BlueSTSDKRegisterTarget_e target;
        [Export("target", ArgumentSemantic.Assign)]
        BlueSTSDKRegisterTarget_e Target { get; set; }

        // @property (retain, nonatomic) NSData * data;
        [Export("data", ArgumentSemantic.Retain)]
        NSData Data { get; set; }

        // -(instancetype)initWithRegister:(BlueSTSDKRegister *)reg target:(BlueSTSDKRegisterTarget_e)target data:(NSData *)data;
        [Export("initWithRegister:target:data:")]
        IntPtr Constructor(BlueSTSDKRegister reg, BlueSTSDKRegisterTarget_e target, NSData data);

        // +(instancetype)commandWithRegister:(BlueSTSDKRegister *)reg target:(BlueSTSDKRegisterTarget_e)target data:(NSData *)data;
        [Static]
        [Export("commandWithRegister:target:data:")]
        BlueSTSDKCommand CommandWithRegister(BlueSTSDKRegister reg, BlueSTSDKRegisterTarget_e target, NSData data);

        // +(instancetype)commandWithRegister:(BlueSTSDKRegister *)reg target:(BlueSTSDKRegisterTarget_e)target;
        [Static]
        [Export("commandWithRegister:target:")]
        BlueSTSDKCommand CommandWithRegister(BlueSTSDKRegister reg, BlueSTSDKRegisterTarget_e target);

        // +(instancetype)commandWithRegister:(BlueSTSDKRegister *)reg target:(BlueSTSDKRegisterTarget_e)target value:(NSInteger)value byteSize:(NSInteger)byteSize;
        [Static]
        [Export("commandWithRegister:target:value:byteSize:")]
        BlueSTSDKCommand CommandWithRegister(BlueSTSDKRegister reg, BlueSTSDKRegisterTarget_e target, nint value, nint byteSize);

        // +(instancetype)commandWithRegister:(BlueSTSDKRegister *)reg target:(BlueSTSDKRegisterTarget_e)target valueFloat:(float)value;
        [Static]
        [Export("commandWithRegister:target:valueFloat:")]
        BlueSTSDKCommand CommandWithRegister(BlueSTSDKRegister reg, BlueSTSDKRegisterTarget_e target, float value);

        // +(instancetype)commandWithRegister:(BlueSTSDKRegister *)reg target:(BlueSTSDKRegisterTarget_e)target valueString:(NSString *)str;
        [Static]
        [Export("commandWithRegister:target:valueString:")]
        BlueSTSDKCommand CommandWithRegister(BlueSTSDKRegister reg, BlueSTSDKRegisterTarget_e target, string str);

        // +(instancetype)commandWithData:(NSData *)dataReceived;
        [Static]
        [Export("commandWithData:")]
        BlueSTSDKCommand CommandWithData(NSData dataReceived);

        // -(NSData *)toWritePacket;
        [Export("toWritePacket")]
        //[Verify(MethodToProperty)]
        NSData ToWritePacket { get; }

        // -(NSData *)toReadPacket;
        [Export("toReadPacket")]
        //[Verify(MethodToProperty)]
        NSData ToReadPacket { get; }
    }

    // @interface BlueSTSDKConfigControl : NSObject
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKConfigControl
    {
        // @property (readonly, strong) BlueSTSDKNode * node;
        [Export("node", ArgumentSemantic.Strong)]
        BlueSTSDKNode Node { get; }

        // +(instancetype)configControlWithNode:(BlueSTSDKNode *)node periph:(CBPeripheral *)periph configControlChart:(CBCharacteristic *)configControlChar;
        [Static]
        [Export("configControlWithNode:periph:configControlChart:")]
        BlueSTSDKConfigControl ConfigControlWithNode(BlueSTSDKNode node, CBPeripheral periph, CBCharacteristic configControlChar);

        // -(instancetype)initWithNode:(BlueSTSDKNode *)node periph:(CBPeripheral *)periph configControlChart:(CBCharacteristic *)configControlChar;
        [Export("initWithNode:periph:configControlChart:")]
        IntPtr Constructor(BlueSTSDKNode node, CBPeripheral periph, CBCharacteristic configControlChar);

        // -(void)read:(BlueSTSDKCommand *)cmd;
        [Export("read:")]
        void Read(BlueSTSDKCommand cmd);

        // -(void)write:(BlueSTSDKCommand *)cmd;
        [Export("write:")]
        void Write(BlueSTSDKCommand cmd);

        // -(void)addConfigDelegate:(id<BlueSTSDKConfigControlDelegate>)delegate;
        [Export("addConfigDelegate:")]
        void AddConfigDelegate(BlueSTSDKConfigControlDelegate @delegate);

        // -(void)removeConfigDelegate:(id<BlueSTSDKConfigControlDelegate>)delegate;
        [Export("removeConfigDelegate:")]
        void RemoveConfigDelegate(BlueSTSDKConfigControlDelegate @delegate);
    }

    //public interface IBlueSTSDKConfigControlDelegate { }

    //@protocol BlueSTSDKConfigControlDelegate
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKConfigControlDelegate //: IBlueSTSDKConfigControlDelegate
    {
        // @required -(void)configControl:(BlueSTSDKConfigControl *)configControl didRegisterReadResult:(BlueSTSDKCommand *)cmd error:(NSInteger)error;
        [Abstract]
        [Export("configControl:didRegisterReadResult:error:")]
        [EventArgs("DidRegisterReadResult")]
        void DidRegisterReadResult(BlueSTSDKConfigControl configControl, BlueSTSDKCommand cmd, nint error);

        // @required -(void)configControl:(BlueSTSDKConfigControl *)configControl didRegisterWriteResult:(BlueSTSDKCommand *)cmd error:(NSInteger)error;
        [Abstract]
        [Export("configControl:didRegisterWriteResult:error:")]
        [EventArgs("DidRegisterWriteResult")]
        void DidRegisterWriteResult(BlueSTSDKConfigControl configControl, BlueSTSDKCommand cmd, nint error);

        // @required -(void)configControl:(BlueSTSDKConfigControl *)configControl didRequestResult:(BlueSTSDKCommand *)cmd success:(_Bool)success;
        [Abstract]
        [Export("configControl:didRequestResult:success:")]
        [EventArgs("DidRequestResult")]
        void DidRequestResult(BlueSTSDKConfigControl configControl, BlueSTSDKCommand cmd, bool success);
    }

    // @interface BlueSTSDKFwVersion : NSObject
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKFwVersion
    {
        // @property (readonly, retain) NSString * _Nullable name;
        [NullAllowed, Export("name", ArgumentSemantic.Retain)]
        string Name { get; }

        // @property (readonly, retain) NSString * _Nullable mcuType;
        [NullAllowed, Export("mcuType", ArgumentSemantic.Retain)]
        string McuType { get; }

        // @property (readonly) NSInteger major;
        [Export("major")]
        nint Major { get; }

        // @property (readonly) NSInteger minor;
        [Export("minor")]
        nint Minor { get; }

        // @property (readonly) NSInteger patch;
        [Export("patch")]
        nint Patch { get; }

        // +(instancetype _Nullable)version:(NSString * _Nonnull)string;
        [Static]
        [Export("version:")]
        [return: NullAllowed]
        BlueSTSDKFwVersion Version(string @string);

        // +(instancetype _Nonnull)versionMajor:(NSInteger)major minor:(NSInteger)minor patch:(NSInteger)patch;
        [Static]
        [Export("versionMajor:minor:patch:")]
        BlueSTSDKFwVersion VersionMajor(nint major, nint minor, nint patch);

        // +(instancetype _Nonnull)versionWithName:(NSString * _Nullable)name mcuType:(NSString * _Nullable)mcuType major:(NSInteger)major minor:(NSInteger)minor patch:(NSInteger)patch;
        [Static]
        [Export("versionWithName:mcuType:major:minor:patch:")]
        BlueSTSDKFwVersion VersionWithName([NullAllowed] string name, [NullAllowed] string mcuType, nint major, nint minor, nint patch);

        // -(NSComparisonResult)compareVersion:(BlueSTSDKFwVersion * _Nonnull)version;
        [Export("compareVersion:")]
        NSComparisonResult CompareVersion(BlueSTSDKFwVersion version);

        // -(NSString * _Nonnull)getVersionNumberStr;
        [Export("getVersionNumberStr")]
        //[Verify(MethodToProperty)]
        string VersionNumberStr { get; }
    }

    // @interface BlueSTSDKWeSUFeatureConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKWeSUFeatureConfig
    {
        // @property BOOL outputBLE;
        [Export("outputBLE")]
        bool OutputBLE { get; set; }

        // @property BOOL outputUSART;
        [Export("outputUSART")]
        bool OutputUSART { get; set; }

        // @property BOOL outputRAM;
        [Export("outputRAM")]
        bool OutputRAM { get; set; }

        // @property uint8_t subsampling;
        [Export("subsampling")]
        byte Subsampling { get; set; }

        // +(instancetype)configWithSubsampling:(uint8_t)subsampling outputBLE:(BOOL)outputBle outputUSART:(BOOL)outputUSART outputRAM:(BOOL)outputRAM;
        [Static]
        [Export("configWithSubsampling:outputBLE:outputUSART:outputRAM:")]
        BlueSTSDKWeSUFeatureConfig ConfigWithSubsampling(byte subsampling, bool outputBle, bool outputUSART, bool outputRAM);
    }

    // @interface BlueSTSDKWeSURegisterDefines : NSObject
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKWeSURegisterDefines
    {
        // +(BlueSTSDKRegister *)lookUpWithRegisterName:(BlueSTSDKWeSURegisterName_e)name;
        [Static]
        [Export("lookUpWithRegisterName:")]
        BlueSTSDKRegister LookUpWithRegisterName(BlueSTSDKWeSURegisterName_e name);

        // +(BlueSTSDKRegister *)lookUpRegisterWithAddress:(NSInteger)address target:(BlueSTSDKRegisterTarget_e)target;
        [Static]
        [Export("lookUpRegisterWithAddress:target:")]
        BlueSTSDKRegister LookUpRegisterWithAddress(nint address, BlueSTSDKRegisterTarget_e target);

        // +(BlueSTSDKWeSURegisterName_e)lookUpRegisterNameWithAddress:(NSInteger)address target:(BlueSTSDKRegisterTarget_e)target;
        [Static]
        [Export("lookUpRegisterNameWithAddress:target:")]
        BlueSTSDKWeSURegisterName_e LookUpRegisterNameWithAddress(nint address, BlueSTSDKRegisterTarget_e target);

        // +(NSDictionary *)registers;
        [Static]
        [Export("registers")]
        //[Verify(MethodToProperty)]
        NSDictionary Registers { get; }

        // +(BlueSTSDKFwVersion *)extractFwVersion:(BlueSTSDKCommand *)answer;
        [Static]
        [Export("extractFwVersion:")]
        BlueSTSDKFwVersion ExtractFwVersion(BlueSTSDKCommand answer);

        // +(BlueSTSDKWeSUFeatureConfig *)extractFeatureConfig:(BlueSTSDKCommand *)answer;
        [Static]
        [Export("extractFeatureConfig:")]
        BlueSTSDKWeSUFeatureConfig ExtractFeatureConfig(BlueSTSDKCommand answer);

        // +(void)encodeFeaturConfing:(BlueSTSDKWeSUFeatureConfig *)config forCommand:(BlueSTSDKCommand *)writeReq;
        [Static]
        [Export("encodeFeaturConfing:forCommand:")]
        void EncodeFeaturConfing(BlueSTSDKWeSUFeatureConfig config, BlueSTSDKCommand writeReq);
    }

    // @interface BlueSTSDKFeature (NSMutableDictionary)
    [Category]
    [BaseType(typeof(NSMutableDictionary))]
    interface NSMutableDictionary_BlueSTSDKFeature
    {
        // -(NSArray<Class> *)add:(CBUUID *)key feature:(Class)f;
        [Export("add:feature:")]
        Class[] Add(CBUUID key, Class f);
    }

    // @interface NumberConversion (NSData)
    [Category]
    [BaseType(typeof(NSData))]
    interface NSData_NumberConversion
    {
        // -(uint8_t)extractUInt8FromOffset:(NSUInteger)offset;
        [Export("extractUInt8FromOffset:")]
        byte ExtractUInt8FromOffset(nuint offset);

        // -(int8_t)extractInt8FromOffset:(NSUInteger)offset;
        [Export("extractInt8FromOffset:")]
        sbyte ExtractInt8FromOffset(nuint offset);

        // -(uint16_t)extractLeUInt16FromOffset:(NSUInteger)offset;
        [Export("extractLeUInt16FromOffset:")]
        ushort ExtractLeUInt16FromOffset(nuint offset);

        // -(uint16_t)extractBeUInt16FromOffset:(NSUInteger)offset;
        [Export("extractBeUInt16FromOffset:")]
        ushort ExtractBeUInt16FromOffset(nuint offset);

        // -(int16_t)extractLeInt16FromOffset:(NSUInteger)offset;
        [Export("extractLeInt16FromOffset:")]
        short ExtractLeInt16FromOffset(nuint offset);

        // -(int16_t)extractBeInt16FromOffset:(NSUInteger)offset;
        [Export("extractBeInt16FromOffset:")]
        short ExtractBeInt16FromOffset(nuint offset);

        // -(int32_t)extractLeInt32FromOffset:(NSUInteger)offset;
        [Export("extractLeInt32FromOffset:")]
        int ExtractLeInt32FromOffset(nuint offset);

        // -(uint32_t)extractLeUInt32FromOffset:(NSUInteger)offset;
        [Export("extractLeUInt32FromOffset:")]
        uint ExtractLeUInt32FromOffset(nuint offset);

        // -(uint32_t)extractBeUInt32FromOffset:(NSUInteger)offset;
        [Export("extractBeUInt32FromOffset:")]
        uint ExtractBeUInt32FromOffset(nuint offset);

        // -(int32_t)extractBeInt32FromOffset:(NSUInteger)offset;
        [Export("extractBeInt32FromOffset:")]
        int ExtractBeInt32FromOffset(nuint offset);

        // -(float)extractLeFloatFromOffset:(NSUInteger)offset;
        [Export("extractLeFloatFromOffset:")]
        float ExtractLeFloatFromOffset(nuint offset);

        // -(NSData *)int16ChangeEndianes;
        [Export("int16ChangeEndianes")]
        //[Verify(MethodToProperty)]
        NSData Int16ChangeEndianes();
    }

    // @interface BlueSTSDKNodeFake : BlueSTSDKNode
    [BaseType(typeof(BlueSTSDKNode))]
    interface BlueSTSDKNodeFake
    {
        // -(instancetype)initWithName:(NSString *)name tag:(NSString *)tag address:(NSString *)address;
        [Export("initWithName:tag:address:")]
        IntPtr Constructor(string name, string tag, string address);
    }

    // @protocol BleAdvertiseInfo <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol(Name = "_TtP9BlueSTSDK16BleAdvertiseInfo_")]
    [BaseType(typeof(NSObject), Name = "_TtP9BlueSTSDK16BleAdvertiseInfo_")]
    interface BleAdvertiseInfo
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nullable name;
        [Abstract]
        [NullAllowed, Export("name")]
        string Name { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable address;
        [Abstract]
        [NullAllowed, Export("address")]
        string Address { get; }

        // @required @property (readonly, nonatomic) uint32_t featureMap;
        [Abstract]
        [Export("featureMap")]
        uint FeatureMap { get; }

        // @required @property (readonly, nonatomic) uint8_t deviceId;
        [Abstract]
        [Export("deviceId")]
        byte DeviceId { get; }

        // @required @property (readonly, nonatomic) uint8_t protocolVersion;
        [Abstract]
        [Export("protocolVersion")]
        byte ProtocolVersion { get; }

        // @required @property (readonly, nonatomic) BlueSTSDKNodeType boardType;
        [Abstract]
        [Export("boardType")]
        BlueSTSDKNodeType BoardType { get; }

        // @required @property (readonly, nonatomic) BOOL isSleeping;
        [Abstract]
        [Export("isSleeping")]
        bool IsSleeping { get; }

        // @required @property (readonly, nonatomic) BOOL hasGeneralPurpose;
        [Abstract]
        [Export("hasGeneralPurpose")]
        bool HasGeneralPurpose { get; }

        // @required @property (readonly, nonatomic) uint8_t txPower;
        [Abstract]
        [Export("txPower")]
        byte TxPower { get; }
    }

    // @protocol BlueSTSDKAdvertiseFilter
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol(Name = "_TtP9BlueSTSDK24BlueSTSDKAdvertiseFilter_")]
    [BaseType(typeof(NSObject), Name = "_TtP9BlueSTSDK24BlueSTSDKAdvertiseFilter_")]
    interface BlueSTSDKAdvertiseFilter
    {
        // @required -(id<BleAdvertiseInfo> _Nullable)filter:(NSDictionary<NSString *,id> * _Nonnull)data __attribute__((warn_unused_result));
        [Abstract]
        [Export("filter:")]
        [return: NullAllowed]
        BleAdvertiseInfo Filter(NSDictionary<NSString, NSObject> data);
    }

    // @interface BlueSTSDKFeatureAILogging : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature), Name = "_TtC9BlueSTSDK25BlueSTSDKFeatureAILogging")]
    [DisableDefaultCtor]
    interface BlueSTSDKFeatureAILogging
    {
        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc __attribute__((warn_unused_result));
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset __attribute__((warn_unused_result));
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);
    }

    // @interface BlueSTSDKFeatureActivity : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature), Name = "_TtC9BlueSTSDK24BlueSTSDKFeatureActivity")]
    [DisableDefaultCtor]
    interface BlueSTSDKFeatureActivity
    {
        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc __attribute__((warn_unused_result));
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset __attribute__((warn_unused_result));
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);
    }

    // @interface BlueSTSDKFeatureAudioSceneCalssification : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature), Name = "_TtC9BlueSTSDK40BlueSTSDKFeatureAudioSceneCalssification")]
    [DisableDefaultCtor]
    interface BlueSTSDKFeatureAudioSceneCalssification
    {
        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc __attribute__((warn_unused_result));
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset __attribute__((warn_unused_result));
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);
    }

    // @interface BlueSTSDKFeatureEulerAngle : BlueSTSDKFeatureAutoConfigurable
    [BaseType(typeof(BlueSTSDKFeatureAutoConfigurable), Name = "_TtC9BlueSTSDK26BlueSTSDKFeatureEulerAngle")]
    [DisableDefaultCtor]
    interface BlueSTSDKFeatureEulerAngle
    {
        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc __attribute__((warn_unused_result));
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset __attribute__((warn_unused_result));
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);
    }

    // @interface BlueSTSDKFeatureEventCounter : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature), Name = "_TtC9BlueSTSDK28BlueSTSDKFeatureEventCounter")]
    [DisableDefaultCtor]
    interface BlueSTSDKFeatureEventCounter
    {
        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc __attribute__((warn_unused_result));
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset __attribute__((warn_unused_result));
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);
    }

    // @interface BlueSTSDKFeatureFFTAmplitude : BlueSTSDKDeviceTimestampFeature
    [BaseType(typeof(BlueSTSDKDeviceTimestampFeature), Name = "_TtC9BlueSTSDK28BlueSTSDKFeatureFFTAmplitude")]
    [DisableDefaultCtor]
    interface BlueSTSDKFeatureFFTAmplitude
    {
        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc __attribute__((warn_unused_result));
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }

        // -(BOOL)enableNotification __attribute__((warn_unused_result));
        [Export("enableNotification")]
        //[Verify(MethodToProperty)]
        bool EnableNotification { get; }

        // -(BOOL)disableNotification __attribute__((warn_unused_result));
        [Export("disableNotification")]
        //[Verify(MethodToProperty)]
        bool DisableNotification { get; }

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset __attribute__((warn_unused_result));
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);
    }

    // @interface BlueSTSDKFeatureFitnessActivity : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature), Name = "_TtC9BlueSTSDK31BlueSTSDKFeatureFitnessActivity")]
    [DisableDefaultCtor]
    interface BlueSTSDKFeatureFitnessActivity
    {
        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc __attribute__((warn_unused_result));
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset __attribute__((warn_unused_result));
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);
    }

    // @interface BlueSTSDKFeatureMemsNorm : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature), Name = "_TtC9BlueSTSDK24BlueSTSDKFeatureMemsNorm")]
    [DisableDefaultCtor]
    interface BlueSTSDKFeatureMemsNorm
    {
        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc __attribute__((warn_unused_result));
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset __attribute__((warn_unused_result));
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);
    }

    // @interface BlueSTSDKFeatureMotionAlogrithm : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature), Name = "_TtC9BlueSTSDK31BlueSTSDKFeatureMotionAlogrithm")]
    [DisableDefaultCtor]
    interface BlueSTSDKFeatureMotionAlogrithm
    {
        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc __attribute__((warn_unused_result));
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset __attribute__((warn_unused_result));
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);
    }

    // @interface BlueSTSDKFeatureMotorTimeParameters : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature), Name = "_TtC9BlueSTSDK35BlueSTSDKFeatureMotorTimeParameters")]
    [DisableDefaultCtor]
    interface BlueSTSDKFeatureMotorTimeParameters
    {
        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc __attribute__((warn_unused_result));
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset __attribute__((warn_unused_result));
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);
    }

    // @interface BlueSTSDKFeaturePredictiveStatus : BlueSTSDKFeature
    [BaseType(typeof(BlueSTSDKFeature), Name = "_TtC9BlueSTSDK32BlueSTSDKFeaturePredictiveStatus")]
    interface BlueSTSDKFeaturePredictiveStatus
    {
        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node name:(NSString * _Nonnull)name __attribute__((objc_designated_initializer));
        [Export("initWhitNode:name:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node, string name);
    }

    // @interface BlueSTSDKFeaturePredictiveAccelerationStatus : BlueSTSDKFeaturePredictiveStatus
    [BaseType(typeof(BlueSTSDKFeaturePredictiveStatus), Name = "_TtC9BlueSTSDK44BlueSTSDKFeaturePredictiveAccelerationStatus")]
    [DisableDefaultCtor]
    interface BlueSTSDKFeaturePredictiveAccelerationStatus
    {
        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc __attribute__((warn_unused_result));
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset __attribute__((warn_unused_result));
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);
    }

    // @interface BlueSTSDKFeaturePredictiveFrequencyDomainStatus : BlueSTSDKFeaturePredictiveStatus
    [BaseType(typeof(BlueSTSDKFeaturePredictiveStatus), Name = "_TtC9BlueSTSDK47BlueSTSDKFeaturePredictiveFrequencyDomainStatus")]
    [DisableDefaultCtor]
    interface BlueSTSDKFeaturePredictiveFrequencyDomainStatus
    {
        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc __attribute__((warn_unused_result));
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset __attribute__((warn_unused_result));
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);
    }

    // @interface BlueSTSDKFeaturePredictiveSpeedStatus : BlueSTSDKFeaturePredictiveStatus
    [BaseType(typeof(BlueSTSDKFeaturePredictiveStatus), Name = "_TtC9BlueSTSDK37BlueSTSDKFeaturePredictiveSpeedStatus")]
    [DisableDefaultCtor]
    interface BlueSTSDKFeaturePredictiveSpeedStatus
    {
        // -(NSArray<BlueSTSDKFeatureField *> * _Nonnull)getFieldsDesc __attribute__((warn_unused_result));
        [Export("getFieldsDesc")]
        //[Verify(MethodToProperty)]
        BlueSTSDKFeatureField[] FieldsDesc { get; }

        // -(instancetype _Nonnull)initWhitNode:(BlueSTSDKNode * _Nonnull)node __attribute__((objc_designated_initializer));
        [Export("initWhitNode:")]
        [DesignatedInitializer]
        IntPtr Constructor(BlueSTSDKNode node);

        // -(BlueSTSDKExtractResult * _Nonnull)extractData:(uint64_t)timestamp data:(NSData * _Nonnull)data dataOffset:(uint32_t)offset __attribute__((warn_unused_result));
        [Export("extractData:data:dataOffset:")]
        BlueSTSDKExtractResult ExtractData(ulong timestamp, NSData data, uint offset);
    }

    // @interface BlueSTSDKManager : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC9BlueSTSDK16BlueSTSDKManager")]
    [DisableDefaultCtor]
    interface BlueSTSDKManager
    {
        // @property (readonly, nonatomic, strong, class) BlueSTSDKManager * _Nonnull sharedInstance;
        [Static]
        [Export("sharedInstance", ArgumentSemantic.Strong)]
        BlueSTSDKManager SharedInstance { get; }

        // @property (readonly, copy, nonatomic) NSArray<BlueSTSDKNode *> * _Nonnull nodes;
        [Export("nodes", ArgumentSemantic.Copy)]
        BlueSTSDKNode[] Nodes { get; }

        // @property (readonly, nonatomic) BOOL isDiscovering;
        [Export("isDiscovering")]
        bool IsDiscovering { get; }

        // -(void)discoveryStart;
        [Export("discoveryStart")]
        void DiscoveryStart();

        // -(void)discoveryStart:(NSInteger)timeoutMs;
        [Export("discoveryStart:")]
        void DiscoveryStart(nint timeoutMs);

        // -(void)discoveryStart:(NSInteger)timeoutMs advertiseFilters:(NSArray<id<BlueSTSDKAdvertiseFilter>> * _Nonnull)advertiseFilters;
        [Export("discoveryStart:advertiseFilters:")]
        void DiscoveryStart(nint timeoutMs, BlueSTSDKAdvertiseFilter[] advertiseFilters);

        // -(void)discoveryStop;
        [Export("discoveryStop")]
        void DiscoveryStop();

        // -(void)resetDiscovery;
        [Export("resetDiscovery")]
        void ResetDiscovery();

        // -(void)resetDiscovery:(BOOL)disconnectAll;
        [Export("resetDiscovery:")]
        void ResetDiscovery(bool disconnectAll);

        // -(void)addVirtualNode;
        [Export("addVirtualNode")]
        void AddVirtualNode();

        // -(BlueSTSDKNode * _Nullable)nodeWithName:(NSString * _Nonnull)name __attribute__((warn_unused_result));
        [Export("nodeWithName:")]
        [return: NullAllowed]
        BlueSTSDKNode NodeWithName(string name);

        // -(BOOL)addFeatureForNodeWithNodeId:(uint8_t)nodeId features:(NSDictionary<NSNumber *,Class> * _Nonnull)features error:(NSError * _Nullable * _Nullable)error;
        [Export("addFeatureForNodeWithNodeId:features:error:")]
        bool AddFeatureForNodeWithNodeId(byte nodeId, NSDictionary<NSNumber, Class> features, [NullAllowed] out NSError error);

        // -(NSDictionary<NSNumber *,Class> * _Nonnull)getFeaturesForNode:(uint8_t)nodeId __attribute__((warn_unused_result));
        [Export("getFeaturesForNode:")]
        NSDictionary<NSNumber, Class> GetFeaturesForNode(byte nodeId);

        // -(void)removeDelegate:(id<BlueSTSDKManagerDelegate> _Nonnull)delegate;
        [Export("removeDelegate:")]
        void RemoveDelegate(BlueSTSDKManagerDelegate @delegate);

        // -(void)remove:(id<BlueSTSDKManagerDelegate> _Nonnull)delegate __attribute__((deprecated("Use removeDelegate")));
        [Export("remove:")]
        void Remove(BlueSTSDKManagerDelegate @delegate);

        // -(void)addDelegate:(id<BlueSTSDKManagerDelegate> _Nonnull)delegate;
        [Export("addDelegate:")]
        void AddDelegate(BlueSTSDKManagerDelegate @delegate);

        // -(void)add:(id<BlueSTSDKManagerDelegate> _Nonnull)delegate __attribute__((deprecated("Use addDelegate")));
        [Export("add:")]
        void Add(BlueSTSDKManagerDelegate @delegate);

        // -(void)connect:(CBPeripheral * _Nonnull)peripheral;
        [Export("connect:")]
        void Connect(CBPeripheral peripheral);

        // -(void)disconnect:(CBPeripheral * _Nonnull)peripheral;
        [Export("disconnect:")]
        void Disconnect(CBPeripheral peripheral);
    }

    // @interface BlueSTSDK_Swift_428 (BlueSTSDKManager) <CBCentralManagerDelegate>
    [Category]
    [BaseType(typeof(BlueSTSDKManager))]
    interface BlueSTSDKManager_BlueSTSDK_Swift_428 : ICBCentralManagerDelegate
    {
        // -(void)centralManager:(CBCentralManager * _Nonnull)central didDiscoverPeripheral:(CBPeripheral * _Nonnull)peripheral advertisementData:(NSDictionary<NSString *,id> * _Nonnull)advertisementData RSSI:(NSNumber * _Nonnull)RSSI;
        [Export("centralManager:didDiscoverPeripheral:advertisementData:RSSI:")]
        void CentralManager(CBCentralManager central, CBPeripheral peripheral, NSDictionary<NSString, NSObject> advertisementData, NSNumber RSSI);

        // -(void)centralManagerDidUpdateState:(CBCentralManager * _Nonnull)central;
        [Export("centralManagerDidUpdateState:")]
        void CentralManagerDidUpdateState(CBCentralManager central);

        // -(void)centralManager:(CBCentralManager * _Nonnull)central didConnectPeripheral:(CBPeripheral * _Nonnull)peripheral;
        [Export("centralManager:didConnectPeripheral:")]
        void CentralManager(CBCentralManager central, CBPeripheral peripheral);

        // -(void)centralManager:(CBCentralManager * _Nonnull)central didFailToConnectPeripheral:(CBPeripheral * _Nonnull)peripheral error:(NSError * _Nullable)error;
        [Export("centralManager:didFailToConnectPeripheral:error:")]
        void CentralManager(CBCentralManager central, CBPeripheral peripheral, [NullAllowed] NSError error, int x);

        // -(void)centralManager:(CBCentralManager * _Nonnull)central didDisconnectPeripheral:(CBPeripheral * _Nonnull)peripheral error:(NSError * _Nullable)error;
        [Export("centralManager:didDisconnectPeripheral:error:")]
        void CentralManager(CBCentralManager central, CBPeripheral peripheral, [NullAllowed] NSError error);
    }

    //public interface IBlueSTSDKManagerDelegate { }

    // @protocol BlueSTSDKManagerDelegate
    [Protocol(Name = "_TtP9BlueSTSDK24BlueSTSDKManagerDelegate_"), Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BlueSTSDKManagerDelegate //: IBlueSTSDKManagerDelegate
    {
        // @required -(void)manager:(BlueSTSDKManager * _Nonnull)manager didDiscoverNode:(BlueSTSDKNode * _Nonnull)didDiscoverNode;
        [Abstract]
        [Export("manager:didDiscoverNode:")]
        [EventArgs("DidDiscoverNode")]
        void DidDiscoverNode(BlueSTSDKManager manager, BlueSTSDKNode didDiscoverNode);

        // @required -(void)manager:(BlueSTSDKManager * _Nonnull)manager didChangeDiscovery:(BOOL)didChangeDiscovery;
        [Abstract]
        [Export("manager:didChangeDiscovery:")]
        [EventArgs("DidChangeDiscovery")]
        void DidChangeDiscovery(BlueSTSDKManager manager, bool didChangeDiscovery);
    }

    // @interface BlueSTSDK_Swift_451 (CBCharacteristic)
    [Category]
    [BaseType(typeof(CBCharacteristic))]
    interface CBCharacteristic_BlueSTSDK_Swift_451
    {
        // @property (readonly, nonatomic) BOOL isDebugCharacteristic;
        [Export("isDebugCharacteristic")]
        bool IsDebugCharacteristic();

        // @property (readonly, nonatomic) BOOL isDebugTermCharacteristic;
        [Export("isDebugTermCharacteristic")]
        bool IsDebugTermCharacteristic();

        // @property (readonly, nonatomic) BOOL isDebugErrorCharacteristic;
        [Export("isDebugErrorCharacteristic")]
        bool IsDebugErrorCharacteristic();
    }

    // @interface BlueSTSDK_Swift_458 (CBCharacteristic)
    [Category]
    [BaseType(typeof(CBCharacteristic))]
    interface CBCharacteristic_BlueSTSDK_Swift_458
    {
        // @property (readonly, nonatomic) BOOL isConfigCharacteristics;
        [Export("isConfigCharacteristics")]
        bool IsConfigCharacteristics();

        // @property (readonly, nonatomic) BOOL isConfigControlCharacteristic;
        [Export("isConfigControlCharacteristic")]
        bool IsConfigControlCharacteristic();

        // @property (readonly, nonatomic) BOOL isConfigFeatureCommandCharacteristic;
        [Export("isConfigFeatureCommandCharacteristic")]
        bool IsConfigFeatureCommandCharacteristic();
    }

    // @interface BlueSTSDK_Swift_465 (CBCharacteristic)
    [Category]
    [BaseType(typeof(CBCharacteristic))]
    interface CBCharacteristic_BlueSTSDK_Swift_465
    {
        // @property (readonly, nonatomic) BOOL isFeatureCaracteristics;
        [Export("isFeatureCaracteristics")]
        bool IsFeatureCaracteristics();

        // @property (readonly, nonatomic) BOOL isFeatureGeneralPurposeCharacteristics;
        [Export("isFeatureGeneralPurposeCharacteristics")]
        bool IsFeatureGeneralPurposeCharacteristics();

        // @property (readonly, copy, nonatomic) NSArray<Class> * _Nullable extendedFeature;
        [NullAllowed, Export("extendedFeature", ArgumentSemantic.Copy)]
        Class[] ExtendedFeature();
    }

    // @interface BlueSTSDK_Swift_477 (CBService)
    [Category]
    [BaseType(typeof(CBService))]
    interface CBService_BlueSTSDK_Swift_477
    {
        // @property (readonly, nonatomic) BOOL isDebugService;
        [Export("isDebugService")]
        bool IsDebugService();

        // @property (readonly, nonatomic) BOOL isConfigService;
        [Export("isConfigService")]
        bool IsConfigService();
    }

    // @interface BlueSTSDK_Swift_483 (CBUUID)
    [Category]
    [BaseType(typeof(CBUUID))]
    interface CBUUID_BlueSTSDK_Swift_483
    {
        // @property (readonly, nonatomic) uint32_t featureMask;
        [Export("featureMask")]
        uint FeatureMask();
    }

    // @interface Prv (BlueSTSDKDebug)
    [Category]
    [BaseType(typeof(BlueSTSDKDebug))]
    interface BlueSTSDKDebug_Prv
    {
        // -(void)receiveCharacteristicsWriteUpdate:(CBCharacteristic *)termChar error:(NSError *)error;
        [Export("receiveCharacteristicsWriteUpdate:error:")]
        void ReceiveCharacteristicsWriteUpdate(CBCharacteristic termChar, NSError error);

        // -(void)receiveCharacteristicsUpdate:(CBCharacteristic *)termChar;
        [Export("receiveCharacteristicsUpdate:")]
        void ReceiveCharacteristicsUpdate(CBCharacteristic termChar);
    }

    // @interface fake (BlueSTSDKFeature)
    [Category]
    [BaseType(typeof(BlueSTSDKFeature))]
    interface BlueSTSDKFeature_fake
    {
        // -(NSData *)generateFakeData;
        [Export("generateFakeData")]
        //[Verify(MethodToProperty)]
        NSData GenerateFakeData();
    }
    
}
