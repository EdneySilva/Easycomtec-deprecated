(function (angular) {
    'use-strict'
    angular.module("app").controller("SkillControl", function SkillControl() {
        this.skill = {};        
    }).component("skill", {
        bindings: {
            skill: '=',
            skillAdded: "&"
        },
        controller: function (SkillService, Step, $scope) {
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
                this.skillAdded({ skill: _skill });
                //SkillService.addSkill(_skill);
                this.skill.Name = "";
                this.skill.Level = "";
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