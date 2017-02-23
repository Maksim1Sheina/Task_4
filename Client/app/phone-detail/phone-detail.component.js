'use strict';

angular.
    module('phoneDetail').
    component('phoneDetail', {
        templateUrl: 'phone-detail/phone-detail.template.html',
        controller: ['$routeParams', 'Phone',
            function PhoneDetailController($routeParams, Phone){
                var self = this;
                
                self.phoneEditID = $routeParams.phoneId;
                
                self.phone = Phone.get({phoneId: 'Phones/' + $routeParams.phoneId}, function(phone){
                    self.setImage(phone.Images[0]);
                });
                    /*.$promise.then(
                    function(response){
                        
                    },
                    function(response){
                        alert('Server error. Update page or try again later. ' + response.message);
                    }
                );*/
                
                self.setImage = function setImage(imageUrl){
                    self.mainImageUrl = imageUrl;
                };
                
                self.onDblclick = function onDblclick(imageUrl){
                    alert('You double-clicked image: ' + imageUrl);
                };
            }
        ]
});