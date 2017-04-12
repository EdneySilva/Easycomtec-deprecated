(function (angular) {
    'use-strict'
    angular.module("app").controller("Phone", function Phone() {
        this.phone = new PhoneNumber();
    }).component("phonecontrol", {
        bindings: {
            phone: '=',
            candidate: "="
        },
        controller: function (PhoneService, $scope) {
            this.add = function () {
                var _phone = new PhoneNumber();
                _phone.Id = this.phone.Id;
                _phone.Number = this.phone.Number;
                this.candidate.AddPhone(_phone);
                //PhoneService.addPhone(_phone);
                this.phone.Number = "";
            }
        },
        templateUrl: function () {
            return "/app/candidate/phone.html";
        }
    });
    angular.module("app").service("PhoneService", function PhoneService() {
        var _defaultOnPhoneAdding = function (phone) { };
        var _onPhoneAdding = _defaultOnPhoneAdding;
        this.addPhone = function (phone) {
            (_onPhoneAdding || _defaultOnPhoneAdding)(phone);
        }

        this.onPhoneAdding = function (phoneAddingCallback) {
            _onPhoneAdding = phoneAddingCallback;
        }
    });
})(window.angular);