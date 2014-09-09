(function () {
    'use strict';

    /**
     * @desc filter to find starting point of array
     * @file filters.js
     * @example <li  ng-repeat="rows in foos | startFrom: 10"></li>
     */
    angular
		.module('app')
		.filter('startFrom', startFrom);

    function startFrom() {

        var filter = function (input, start) {
            start = +start;
            return input.slice(start);
        };
        return filter;
    }
})();