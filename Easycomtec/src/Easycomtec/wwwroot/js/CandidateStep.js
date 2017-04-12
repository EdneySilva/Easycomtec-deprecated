
(function (angular) {
    var app = angular.module('app');
    app.component("candidateStep", {
        bindings: {
            candidateController: "="
        },
        controller: function () {
            var stepHandler = function () {
                this.currentStep = 0;
                this.steps = ["personal", "phone", "skill", "address"]
                var context = this;
                this.next = function () {
                    if (context.currentStep + 1 < context.steps.length)
                        context.currentStep += 1;
                    return context.steps[context.currentStep];
                }
                this.previous = function () {
                    if (context.currentStep - 1 >= 0)
                        context.currentStep -= 1;
                    return context.steps[context.currentStep];
                }
                this.current = function () {
                    return context.steps[context.currentStep];
                }
                this.hasNext = function () {
                    return context.currentStep + 1 < context.steps.length;
                }
                this.hasPrevious = function () {
                    return context.currentStep - 1 >= 0
                }
                return {
                    next: this.next,
                    previous: this.previous,
                    current: this.current,
                    hasPrevious: this.hasPrevious,
                    hasNext: this.hasNext
                }
            }
            this.step = new stepHandler();
            this.showStep = function (value) {
                return value == this.step.current();
            }
            this.next = this.step.next;
            this.previous = this.step.previous;
            this.hasNext = this.step.hasNext;
            this.hasPrevious = this.step.hasPrevious;
        },
        templateUrl: function () {
            return "/app/candidate/index.html";
        }
    })

})(window.angular);