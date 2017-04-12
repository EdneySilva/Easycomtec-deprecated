var Level;
(function (Level) {
    Level[Level["DONOT KNOW"] = 1] = "DONOT KNOW";
    Level[Level["KNOW"] = 2] = "KNOW";
    Level[Level["BASIC"] = 3] = "BASIC";
    Level[Level["INTERMEDIATE"] = 4] = "INTERMEDIATE";
    Level[Level["ADVANCED"] = 5] = "ADVANCED";
    Level[Level["EXPERT"] = 6] = "EXPERT";
})(Level || (Level = {}));

function Skill() {
    this.Id = 0;
    this.Name = "";
    this.Level = 0;
    this.LevelName = "";
    return this;
}

function PhoneNumber() {
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

function Account() {
    this.Email = "";
    this.Password = "";

    return this;
}

function User() {
    this.Id = 0;
    this.Name = "";
    this.BirthDate = new Date();
    this.Phones = [];
    this.Skills = [];
    this.Address = {};
    this.Account = {};
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
    //app.config(function ($routeProvider) {
    //    $routeProvider.when("/")
    //});
    app.factory("user", function () {
        return new User();
    });
    app.service("CandidateService", function (user) {
        this.currentUser = user;
        this.save = function () {

        }
    });
})(window.angular);