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
                    self.phone.$save();
                };
            }
        ]
});