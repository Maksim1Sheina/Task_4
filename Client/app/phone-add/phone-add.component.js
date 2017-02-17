'use strict';

angular.
    module('phoneAdd').
    component('phoneAdd', {
        templateUrl: 'phone-add/phone-add.template.html',
        controller: ['Phone',
            function PhoneAddController(Phone){
                var self = this;
                var phone;
                
                self.Name = 'No data';
                self.Description = 'No data';
                self.Availabilities = ['No data', 'no data'];
                self.BatteryType = 'No data';
                self.BatteryTalkTime = 'No data';
                self.BatteryStandbyTime = 'No data';
                self.StorageRAM = 64;
                self.StorageFlash = 64;
                self.ConnectivityCell = 'No data';
                self.ConnectivityWiFi = 'No data';
                self.ConnectivityBluetooth = 'No data';
                self.ConnectivityInfrared = false;
                self.ConnectivityGPS = false;
                self.PlatformType = 'No data';
                self.PlatrormVersion = 'No data';
                self.PlatformUI = 'No data';
                self.Width = 0;
                self.Height = 0;
                self.Depth = 0;
                self.Weight = 0;
                self.DisplayScreenSize = 'No data';
                self.DisplayScreenResolution = 'No data';
                self.DisplayTouchScreen = false;
                self.HardwareCPU = 'No data';
                self.HardwareUSB = 'No data';
                self.HardwareAudioJack = 'No data';
                self.HardwareFMRadio = false;
                self.HardwareAccelerometer = false;
                self.HardwarePhysicalKeyboard = false;
                self.CameraPrimary = 0;
                self.CameraFeatures = ['No data', 'no data'];
                self.AdditionalFeatures = 'No data';
                
                self.btnClick = function btnClick(){
                    var outData = new Phone();
                    outData.Name = self.Name;
                    outData.Description = self.Description;
                    outData.Availabilities = self.Availabilities;
                    outData.BatteryType = self.BatteryType;
                    outData.BatteryTalkTime = self.atteryTalkTime;
                    outData.BatteryStandbyTime = self.BatteryStandbyTime;
                    outData.StorageRAM = self.StorageRAM;
                    outData.StorageFlash = self.StorageFlash;
                    outData.ConnectivityCell = self.ConnectivityCell;
                    outData.ConnectivityWiFi = self.ConnectivityWiFi;
                    outData.ConnectivityBluetooth = self.ConnectivityBluetooth;
                    outData.ConnectivityInfrared = self.ConnectivityInfrared;
                    outData.ConnectivityGPS = self.ConnectivityGPS;
                    outData.PlatformType = self.PlatformType;
                    outData.PlatrormVersion = self.PlatrormVersion;
                    outData.PlatformUI = self.PlatformUI;
                    outData.Width = self.Width;
                    outData.Height = self.Height;
                    outData.Depth = self.Depth;
                    outData.Weight = self.Weight;
                    outData.DisplayScreenSize = self.DisplayScreenSize;
                    outData.DisplayScreenResolution = self.DisplayScreenResolution;
                    outData.DisplayTouchScreen = self.DisplayTouchScreen;
                    outData.HardwareCPU = self.HardwareCPU;
                    outData.HardwareUSB = self.HardwareUSB;
                    outData.HardwareAudioJack = self.HardwareAudioJack;
                    outData.HardwareFMRadio = self.HardwareFMRadio;
                    outData.HardwareAccelerometer = self.HardwareAccelerometer;
                    outData.HardwarePhysicalKeyboard = self.HardwarePhysicalKeyboard;
                    outData.CameraPrimary = self.CameraPrimary;
                    outData.CameraFeatures = self.CameraFeatures;
                    outData.AdditionalFeatures = self.AdditionalFeatures;
                    
                    outData.$save();
                };
            }
        ]
});