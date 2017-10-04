(function (angular) {
    'use-strict'
    angular.module("app").controller("SkillControl", function SkillControl() {
        this.skill = {};        
    }).component("skill", {
        bindings: {
            candidate: '=',
            skill: '=',
            skillAdded: "&"
        },
        controller: function (SkillService, Step, $scope, $http) {
            this.levels = [];
            function createLevel(name, value) {
                return {
                    name: name,
                    value: value
                };
            }
            this.levels.push(createLevel("DONOT KNOW", 1));
            this.levels.push(createLevel("KNOW", 2));
            this.levels.push(createLevel("BASIC", 3));
            this.levels.push(createLevel("INTERMEDIATE", 4));
            this.levels.push(createLevel("ADVANCED", 5));
            this.levels.push(createLevel("EXPERT", 6));
            this.add = function () {
                var _skill = new Skill();
                _skill.Id = this.skill.Id;
                _skill.Level = this.skill.Level;
                _skill.LevelName = Level[this.skill.Level];
                _skill.Name = this.skill.Name;
                var context = this;
                if (context.candidate.Id > 0) {
                    _skill.CandidateId = this.candidate.Id;
                    $http.post("/Candidate/AddSkill", JSON.stringify(_skill), {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }).then((response) => {
                        if (response.data.Success === true) {
                            _skill.Id = response.data.Model.Id;
                            context.skillAdded({ skill: _skill });
                        }
                        else {
                            console.log(response.data.Trace);
                            alert(contexto.toMessageError(response.data.Erros));
                        }
                    }, function (response) {

                    });
                } else
                    this.skillAdded({ skill: _skill });
                //SkillService.addSkill(_skill);
                this.skill.Name = "";
                this.skill.Level = "";
            }
            this.remove = function (skill) {
                var context = this;
                if (skill.Id > 0)
                    $http.post("/Candidate/RemoveSkill", JSON.stringify(skill), {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }).then((response) => {
                        if (response.data.Success === true)
                            context.candidate.RemoveSkill(skill);
                        else {
                            console.log(response.data.Trace);
                            alert(contexto.toMessageError(response.data.Erros));
                        }
                    });
                else
                    this.candidate.RemoveSkill(skill);
            }
        },
        templateUrl: function () {
            return "/app/candidate/skill.html";
        }
    });

    angular.module("app").service("SkillService", function SkillService() {
        var _defaultOnSkillAdding = function (skill) { };
        var _onSkillAdding = _defaultOnSkillAdding;
        this.addSkill = function (skill) {
            (_onSkillAdding || _defaultOnSkillAdding)(skill);
        }

        this.onSkillAdding = function (skillAddingCallback) {
            _onSkillAdding = skillAddingCallback;
        }
    });
})(window.angular);