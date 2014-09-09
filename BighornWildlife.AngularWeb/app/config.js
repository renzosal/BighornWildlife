(function () {
    'use strict';

    var config = {
        appErrorPrefix: '[Auth Demo Error]: ',
        CachePrefix: '[Auth Demo Cache]: ',
        imagePath: '../assets/images/',
        appName: 'Auth Demo App',
        version: '1.0',
        apiUrl: 'http://localhost:49206/',
        clientId: 'Bighorns'
    };

    angular
		.module('app')
		.constant('config', config)
		.config(configuration);

    configuration.$inject = ['$logProvider', '$httpProvider'];

    function configuration($logProvider, $httpProvider) {

        configureLogging();
        configureLocalStorageInterceptor();

        function configureLogging() {
            if ($logProvider.debugEnabled)
                $logProvider.debugEnabled(true);
        }

        function configureLocalStorageInterceptor() {
           $httpProvider.interceptors.push('httpInterceptor');
        }

    }

})();