(function () {
    'use strict';

    angular.module('app', [
		//Angular modules
		'ngAnimate',
		'ngRoute',

		//Third Party
		'ui.bootstrap',
        'angular-loading-bar'

    ]).run(['$route', 'authenticationService', function ($route, authenticationService) {
        authenticationService.saveAuthentication();
    }]);

})();