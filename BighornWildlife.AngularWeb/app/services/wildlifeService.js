(function () {
    'use strict';

    var serviceId = 'wildlifeService';

    angular
        .module('app')
        .factory(serviceId, wildlifeService);

    wildlifeService.$inject = ['$http', '$q', 'config'];

    function wildlifeService($http, $q, config) {

        var serviceBase = config.apiUrl;

        var service = {

            getSpecies: getSpecies,
            getSpecieById: getSpecieById

        };

        return service;

        function getSpecies() {
            var promise = $http
                .get(serviceBase + 'api/Species')
                .then(function (response) {
                    return response.data;
                });

            return promise;
        }

        function getSpecieById(id) {
            var promise = $http
                .get(serviceBase + 'api/Species/' + id)
                .then(function (response) {
                    return response.data;
                });

            return promise;
        }
    }

})();