(function (angular) {
    'use-strict'
    var app = angular.module("app");
    app.service("Step", function Step() {
        var _url = "/Candidate/PersonalData";
        this.url = function (route) {
            _url = route;
        }
        this.getUrl = function () {
            return _url;
        }
        
    });
    angular.module("app").controller("Candidate", function Candidate(user) {
        this.candidate = user;
        var p = new Phone()
        p.Number = "(41)99998888";
        this.candidate.AddPhone(p);
        var p2 = new Phone()
        p2.Number = "(41)99992222";
        this.candidate.AddPhone(p2);
    }).component("candidator", {
        bindings: {
            candidate: '='
        },
        controller: function (CandidateService, Step, $scope) {
            this.teste = function () {

            }
        },
        templateUrl: function (Step) {
            return "/app/candidate/personaldata.html";
        }
    });
})(window.angular);
