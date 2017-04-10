(function (angular) {
    'use-strict'
    angular.module("app").controller("Phone", function Address() {
        this.phone = {};
    }).component("phone", {
        bindings: {
            phone: '='
        },
        controller: function (CandidateService, Step, $scope) {

        },
        templateUrl: function (Step) {
            return "/app/candidate/phone.html";
        }
    });;
})(window.angular);