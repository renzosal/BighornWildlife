(function () {
    'use strict';

    var controllerId = 'signup';

    angular
		.module('app')
		.controller(controllerId, signup);

    signup.$inject = ['$location', '$timeout', 'authenticationService'];

    function signup($location, $timeout, authenticationService) {
        var vm = this;

        vm.savedSuccessfully = false;
        vm.message = '';
        vm.registration = {
            userName: '',
            password: '',
            confirmPassword: ''
        };
        vm.signUp = signUp;



        function signUp() {
            console.log(vm.registration);
            authenticationService.registerUser(vm.registration)
                .then(
                function (response) {
                    vm.savedSuccessfully = true;
                    vm.message = 'User registered successfully, you will be redirected to the login page.';
                    startTimer();
                },
                function (response) {
                    var errors = [];
                    for (var key in response.data.modelState) {
                        for (var i = 0; i < response.data.modelState[key].length; i++) {
                            errors.push(response.data.modelState[key][i]);
                        }
                    }

                    vm.message = 'Failed to register user due to: ' + errors.join(' ');
                });
        }

        function startTimer() {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/login');
            }, 2000);
        }
    }

})();