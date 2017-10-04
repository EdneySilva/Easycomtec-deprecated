(function (angular) {
    'use-strict'
    angular.module("app").controller("Phone", function Phone() {
        this.phone = new PhoneNumber();
    }).component("phonecontrol", {
        bindings: {
            phone: '=',
            candidate: "="
        },
        controller: function (PhoneService, $scope, $http) {
            this.add = function () {
                var context = this;
                var _phone = new PhoneNumber();
                _phone.Id = this.phone.Id;
                _phone.Number = this.phone.Number;

                if (this.candidate.Id > 0) {
                    _phone.CandidateId = this.candidate.Id;
                    $http.post("/Candidate/AddPhone", JSON.stringify(_phone), {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }).then((response) => {
                        if (response.data.Success === true) {
                            _phone.Id = response.data.Model.Id;
                            context.candidate.AddPhone(_phone);
                        }
                        else {
                            console.log(response.data.Trace);
                            alert(contexto.toMessageError(response.data.Erros));
                        }
                    }, function (response) {

                    });
                }else
                    this.candidate.AddPhone(_phone);
                //PhoneService.addPhone(_phone);
                this.phone.Number = "";
            }
            this.remove = function (phone) {
                var context = this;
                if (phone.Id > 0)
                    $http.post("/Candidate/RemovePhone", JSON.stringify(phone), {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }).then((response) => {
                        if (response.data.Success === true)
                            context.candidate.RemovePhone(phone);
                        else {
                            console.log(response.data.Trace);
                            alert(contexto.toMessageError(response.data.Erros));
                        }
                    }, function (response) {

                    });
                else
                    this.candidate.RemovePhone(phone);
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