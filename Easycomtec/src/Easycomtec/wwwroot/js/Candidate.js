function Skill() {
    this.Id = 0;
    this.Name = "";
    this.Level = 0;
    return this;
}

function Phone() {
    this.Id = 0;
    this.Number = "";
}

function Address() {
    this.Id = 0;
    this.City = "";
    this.State = "";
    this.Country = "";
    this.PostalCode = "";
    this.Latitude = "";
    this.Longitude = "";
    return this;
}

function User() {
    this.Id = 0;
    this.Name = "";
    this.BirthDate = new Date();
    this.Phones = [];
    this.Skills = [];
    this.Address = {};
    this.AddPhone = function (phone) {
        this.Phones.push(phone);
    }
    this.AddSkill = function (skill) {
        this.Skills.push(skill);
    }
    return this;
}

(function (angular) {
    var app = angular.module('app', []);
    app.factory("user", function () {
        return new User();
    });
    app.service("CandidateService", function (user) {
        this.currentUser = user;
        this.save = function () {

        }
    });
})(window.angular);