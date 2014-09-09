(function () {
    'use strict';

    var controllerId = 'login';

    angular
		.module('app')
		.controller(controllerId, login);

    login.$inject = ['$location', '$timeout', 'authenticationService'];

    function login($location, $timeout, authenticationService) {
        var vm = this;

        vm.message = '';
        vm.credentials = {
            userName: '',
            password: '',
            useRefreshTokens: false
        };

        vm.login = login;


        function login() {
            authenticationService.login(vm.credentials)
                .then(
                    function (response) {
                        $location.path('/wildlife');
                    },
                    function (error) {
                        vm.message = error.error_description;
                    });
        }

    }

})();