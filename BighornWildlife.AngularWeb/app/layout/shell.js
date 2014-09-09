(function () {
    'use strict';

    var controllerId = 'shell';

    angular
		.module('app')
		.controller(controllerId, shell);

    shell.$inject = ['$location', 'authenticationService'];

    function shell($location, authenticationService) {
        var vm = this;

        vm.authentication = authenticationService.authentication;
        vm.logout = logout;

        function logout() {
            authenticationService.logout();
            $location.path('/');
        }
    }

})();
