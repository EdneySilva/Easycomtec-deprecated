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
    angular.module("app").controller("Candidate", function Candidate(user, PhoneService, $http) {
        this.level = Level;
        this.phoneService = PhoneService;
        this.candidate = user;
        var contexto = this;

        this.toMessageError = function (list) {
            var msg = "";
            for (var i in list) {
                msg += (msg.length > 0 ? "\n" : "") + list[i];
            }
            return msg;
        }

        this.phoneService.onPhoneAdding(function (phone) {
            contexto.candidate.AddPhone(phone);
        });

        this.onAddAddress = function (address) {
            contexto.candidate.Address = address;
        }
        this.onAddSkill = function (skill) {
            contexto.candidate.AddSkill(skill);
        }
        this.save = function () {
            var _candidate = this.candidate;
            $http.post("/Candidate/" + (this.candidate.Id == 0 ? "Create" : "Edit"), JSON.stringify(this.candidate),
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }).then(function (response) {
                    if (response.data.Success === true) {
                        if (_candidate.Id === 0)
                            window.location = "/home/thanks";
                        else
                            alert(response.data.Message);

                    }else {
                        console.log(response.data.Trace);
                        alert(contexto.toMessageError(response.data.Erros));
                    }
                });
        }
    }).component("candidator", {
        bindings: {
            candidate: '=',
            candidateLoad: '='
        },
        controller: function (CandidateService, $scope) {
            this.load = function (a) {
                this.candidate.Id = a.Id;
                this.candidate.Name = a.Name;
                this.candidate.BirthDate = new Date(a.BirthDate);
                this.candidate.Account = a.Account;
                this.candidate.Address = a.Address;
                for (var i in a.Phones) {
                    this.candidate.AddPhone(a.Phones[i]);
                }
                for (var i in a.Skills) {
                    this.candidate.AddSkill(a.Skills[i]);
                }
                return true;
            }
            this.$onChanges = function () {
                if (this.candidateLoad !== undefined && this.candidateLoad !== null)
                    this.load(this.candidateLoad);
            }

        },
        templateUrl: function (Step) {
            return "/app/candidate/personaldata.html";
        }
    });
})(window.angular);
