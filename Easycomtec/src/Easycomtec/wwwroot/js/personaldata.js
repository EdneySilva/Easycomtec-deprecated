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
    angular.module("app").controller("Candidate", function Candidate(user, PhoneService) {
        this.level = Level;
        this.phoneService = PhoneService;
        this.candidate = user;
        var contexto = this;
        this.phoneService.onPhoneAdding(function (phone) {
            contexto.candidate.AddPhone(phone);
        });
        this.onAddAddress = function (address) {
            contexto.candidate.Address = address;
        }
        this.onAddSkill = function (skill) {
            contexto.candidate.AddSkill(skill);
        }
    }).component("candidator", {
        bindings: {
            candidate: '='
        },
        controller: function (CandidateService, $scope) {
            
        },
        templateUrl: function (Step) {
            return "/app/candidate/personaldata.html";
        }
    });
})(window.angular);
