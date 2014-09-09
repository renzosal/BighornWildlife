(function () {
    'use strict';

    var controllerId = 'specie';

    angular
		.module('app')
		.controller(controllerId, specie);

    specie.$inject = ['$scope', '$routeParams', 'wildlifeService'];

    function specie($scope, $routeParams, wildlifeService) {
        var vm = this;
        vm.specie = {};
        vm.date = new Date();
        vm.dateOpened = false;
        vm.open = openDatePicker;

        activate();

        function activate() {
            console.log('route params', $routeParams);
            getSpecieById($routeParams.id);
        }


        function getSpecieById(id) {
            return wildlifeService
                .getSpecieById(id)
                .then(function (data) {
                    vm.specie = data;
                    return vm.specie;
                });
        }

        function openDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();
            vm.dateOpened = true;
        }
    }

})();