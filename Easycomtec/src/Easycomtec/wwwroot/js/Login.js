/// <reference path="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"/>
//http://stackoverflow.com/questions/24726105/how-to-show-form-input-errors-using-angularjs-ui-bootstrap-tooltip
var app = angular.module('myApp', []);

/*app.directive("isEmail", function () {
    return {
        require: "ngModel",
        link: function (scope, element, attr, myCtrl) {
            scope.isValid = function () {

            }
            var regex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            function validate(value) {
                if (!regex.test(value)) 
                    myCtrl.$setValidity('email', false);
                else
                    return true;
            }
            //myCtrl.$parsers.unshift(validate);
        }
    }
});*/


app.controller('Home', function ($scope) {
    $scope.Email = "";
    $scope.Password = "";
    $scope.$error = {};
    $scope.Autenticate = function () {

    }
});
