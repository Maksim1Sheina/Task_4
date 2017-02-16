'use strict';

angular.
    module('phoneAdd').
    component('phoneAdd', {
        templateUrl: 'phone-add/phone-add.template.html',
        controller: ['Phone',
            function PhoneAddController(Phone){
                var self = this;
                var phone;
                
                self.btnClick = function btnClick(){
                    var outData = new Phone();
                    outData.Name = self.phone.Name;
                    outData.Description = self.phone.Description;
                    outData.$save();
                };
            }
        ]
});

/*
'use strict';

angular.
    module('phoneAdd').
    component('phoneAdd', {
        templateUrl: 'phone-add/phone-add.template.html',
        controller: ['Phone',
            function PhoneAddController(Phone, $http){
                var self = this;
                var phone;
                var res = false;
                
                self.btnClick = function btnClick(){
                    self.phone.$save();
                };
                
                if(res){
                    $http.post('http://localhost:4871/api/Phones', phone, config)
                        .then(function successCallback(response) {
                                // this callback will be called asynchronously
                                // when the response is available
                                alert("Data delivered successfully");
                              }, function errorCallback(response) {
                                // called asynchronously if an error occurs
                                // or server returns response with an error status.
                                alert("Error with data sending");
                              });
                }
                
                self.btnClick = function btnClick(){
                    self.res = true;
                };
            }
        ]
});
*/