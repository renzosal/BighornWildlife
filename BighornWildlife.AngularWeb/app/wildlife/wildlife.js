(function () {
    'use strict';

    var controllerId = 'wildlife';

    angular
		.module('app')
		.controller(controllerId, wildlife);

    wildlife.$inject = ['$scope', 'filterFilter', 'wildlifeService'];

    function wildlife($scope, filter, wildlifeService) {
        var vm = this;
        vm.species = [];
        vm.filteredSpecies = [];
        vm.WildlifeTypes = [
            { wildlifeType: 0, name: 'Plants' },
            { wildlifeType: 1, name: 'Fish' },
            { wildlifeType: 2, name: 'Birds' },
            { wildlifeType: 3, name: 'Mammals' }
        ];
        vm.typeSelection = [0, 1, 2, 3];
        vm.toggleSelection = toggleSelection;

        vm.pageSize = 15;
        vm.currentPage = 1;

        activate();
        watchers();


        function activate() {
            getSpecies()
                .then(function () {
                    vm.filteredSpecies = vm.species;
                });
            
        }


        function getSpecies() {
            return wildlifeService
                .getSpecies()
                .then(function (data) {
                    vm.species = data;
                    return vm.species;
                });
        }

        function watchers() {
            $scope.$watch('[vm.wildlifeSearch, vm.typeSelection]', function (newVal) {
                var filteredByType = _.filter(vm.species, function (specie) {
                   return _.contains(newVal[1], specie.wildlifeType);
                });
                vm.filteredSpecies = filter(filteredByType, newVal[0]);
            }, true);
        }

        function toggleSelection(type) {
            var typeId = vm.typeSelection.indexOf(type);

            if (typeId > -1) {
                vm.typeSelection.splice(typeId, 1);
            } else {
                vm.typeSelection.push(type);
            }
        }
    }

})();