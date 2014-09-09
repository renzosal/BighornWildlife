(function () {
    'use strict';

    var serviceId = 'authenticationService';

    angular
        .module('app')
        .factory(serviceId, authenticationService);

    authenticationService.$inject = ['$http', '$q', '$window', 'config'];

    function authenticationService($http, $q, $window, config) {

        var _authentication = {
            isAuth: false,
            userName: '',
            useRefreshTokens: true
        };

        var serviceBase = config.apiUrl;

        var service = {
            login: login,
            logout: logout,
            registerUser: registerUser,
            authentication: _authentication,
            saveAuthentication: saveAuthentication,
            refreshToken: refreshToken

        };

        return service;

        function login(credentials) {
            
            var deferred = $q.defer();
            var loginData = "grant_type=password&username=" + credentials.userName + "&password=" + credentials.password + "&client_id=" + config.clientId;

            $http
                .post(serviceBase + 'token', loginData, {
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
            .success(function (response) {
                $window.localStorage.setItem('authData', JSON.stringify({
                    token: response.access_token,
                    userName: credentials.userName,
                    refreshToken: response.refresh_token,
                    useRefreshTokens: true
                }));

                _authentication.isAuth = true;
                _authentication.userName = credentials.userName;

                deferred.resolve(response);
            })
            .error(function (error, status) {
                logout();
                deferred.reject(error);
            });

            return deferred.promise;
        }

        function logout () {

            $window.localStorage.removeItem('authData');
            _authentication.isAuth = false;
            _authentication.userName = '';
        }

        function registerUser (userRegistration) {
            logout();
            var promise = $http
                .post(serviceBase + 'api/account/register', userRegistration)
                .then(function (response) {
                    return response;
                });

            return promise;
        }

        function saveAuthentication () {

            var authData = JSON.parse($window.localStorage.getItem('authData'));
            if (authData) {
                _authentication.isAuth = true;
                _authentication.username = authData.userName;
                _authentication.useRefreshTokens = true;
            }
        }

        function refreshToken() {
            var deferred = $q.defer();

            var authData = JSON.parse($window.localStorage.getItem('authData'));
            if (authData) {
                if (authData.useRefreshTokens) {
                    var data = "grant_type=refresh_token&refresh_token=" + authData.refreshToken + "&client_id=" + ngAuthSettings.clientId;
                    $window.localStorage.removeItem('authData');

                    $http
                        .post(serviceBase + 'token', data, {
                            headers: {
                                'Content-Type': 'application/x-www-form-urlencoded'
                            }
                        })
                        .success(function (response) {
                            $window.localStorage.setItem('authData', JSON.stringify({
                                token: response.access_token,
                                userName: response.userName,
                                refreshToken: response.refresh_token,
                                useRefreshTokens: true
                            }));

                            deferred.resolve(response);
                        })
                        .error(function (error, status) {
                            logout();
                            deferred.reject(error);
                        });
                }
            }
        }
    }

})();