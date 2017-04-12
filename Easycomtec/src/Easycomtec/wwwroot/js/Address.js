(function (angular) {
    'use-strict'
    angular.module("app").controller("AddressControl", function AddressControl() {
        this.address = new Address();
    }).component("address", {
        bindings: {
            address: '=',
            addressCreated: '&'
        },
        controller: function ($scope) {
            this.$onChanges = function () {
                this.addressCreated({ address: this.address });
            }
        },
        templateUrl: function () {
            return "/app/candidate/address.html";
        }
    });
    angular.module("app").service("AddressService", function AddressService() {

    });
})(window.angular);
