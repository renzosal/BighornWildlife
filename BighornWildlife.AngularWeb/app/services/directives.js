(function () {
    'use strict';

    /**
     * @desc spinner directive to display on route loading
     * @file directive.js
     * @example <div data-wc-spinner="spinnerOptions"></div>
     */

    angular
		.module('app')
		.directive('specieMap', specieMap);

    specieMap.$inject = ['$window'];

    function specieMap($window) {
        var directive = {
            link: link,
            replace: true,
            template: '<div id="map-canvas"></div>',
            restrict: 'EA'
        };

        return directive;

        function link(scope, element, attrs) {
            console.log(google);
            var startLat = new google.maps.LatLng(44.359826, -107.207805); //set Coordinates
            var options = {
                zoom: 10,
                center: startLat,
                mapTypeId: google.maps.MapTypeId.TERRAIN
            };

            var map = new google.maps.Map(document.getElementById('map-canvas'), options);

            var currentLocationImage = new google.maps.MarkerImage('/assets/images/red-marker.png', null, null, null, new google.maps.Size(50, 50));

            var currentLocationMarker = new google.maps.Marker({
                position: startLat,
                icon: currentLocationImage,
                map: map,
                title: 'Current Location'
            });


        }
    }
})();