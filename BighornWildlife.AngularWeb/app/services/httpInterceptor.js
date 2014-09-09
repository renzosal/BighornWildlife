(function () {
    'use strict';

    angular
		.module('app')
		.factory('httpInterceptor', httpInterceptor);

    httpInterceptor.$inject = ['$q', '$window', '$location', '$injector', 'config'];

    function httpInterceptor($q, $window, $location, $injector, config) {
        var interceptor = {
            request: request,
            responseError: responseError
        };

        return interceptor;

        function request(requestConfig) {

            requestConfig.headers = requestConfig.headers || {};

            var authData = JSON.parse($window.localStorage.getItem('authData'));
            
            if (authData) {
                console.log('token',authData.token);

                requestConfig.headers.Authorization = 'Bearer ' + authData.token;
            }

            return requestConfig || $q.when(requestConfig);
        }

        function responseError(response) {
            if (response.status === 401) {
                var authData = JSON.parse($window.localStorage.getItem('authData'));

                if (authData) {
                    if (authData.useRefreshTokens) {
                        $location.path('/refresh');
                        return $q.reject(response);
                    }
                }
                //Utilize injector to avoid Circular Dependency Error
                var authenticationService = $injector.get('authenticationService');
                authenticationService.logout();
                $location.path('/login');
            }
            return $q.reject(response);
        }
    }

})();