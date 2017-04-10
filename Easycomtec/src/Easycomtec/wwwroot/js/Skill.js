(function (angular) {
    'use-strict'
    angular.module("app").controller("Skill", function Address() {
        this.skill = {};
    }).component("skill", {
        bindings: {
            skill: '='
        },
        controller: function (CandidateService, Step, $scope) {

        },
        templateUrl: function (Step) {
            return "/app/candidate/skill.html";
        }
    });;
})(window.angular);