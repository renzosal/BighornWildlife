(function () {
    'use strict';

    var controllerId = 'home';

    angular
		.module('app')
		.controller(controllerId, home);

    home.$inject = [];

    function home() {
        var vm = this;
    }

})();