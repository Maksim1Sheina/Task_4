'use strict';

angular.
    module('phoneList').
    component('phoneList', {
        templateUrl: 'phone-list/phone-list.template.html',
        controller: ['Phone',
            function PhoneListController(Phone){
                this.phones = Phone.query().$promise.then(
                    function(response){
                        
                    },
                    
                    function(response){
                        alert('Server error. Update page or try again later. \n Error: ' + response.message);
                    }
                );
                
                this.orderProp = 'ID';
            }
        ]
});