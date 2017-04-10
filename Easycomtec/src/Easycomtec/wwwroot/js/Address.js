(function (angular) {
    'use-strict'
    angular.module("app").controller("Address", function Address() {
        this.address = {};
    }).component("address", {
        bindings: {
            address: '='
        },
        controller: function (CandidateService, Step, $scope) {

        },
        templateUrl: function (Step) {
            return "/app/candidate/address.html";
        }
    });;
})(window.angular);