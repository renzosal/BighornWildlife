(function () {
    'use strict';

    angular
		.module('app')
		.constant('routes', getRoutes())
		.config(routeConfigurator);

    routeConfigurator.$inject = ['$routeProvider', 'routes'];

    //Configure the routes
    function routeConfigurator($routeProvider, routes) {
        _.each(routes, function (route) {
            $routeProvider.when(route.url, route.config);
        });

        $routeProvider.otherwise({ redirectTo: '/' });
    }

    //Define the routes
    function getRoutes() {
        return [
			{
			    url: '/',
			    config: {
			        templateUrl: 'app/home/home.html',
			        title: 'Home',
			        controller: 'home',
			        controllerAs: 'vm'
			    }
			},
			{
			    url: '/login',
			    config: {
			        templateUrl: 'app/authentication/login.html',
			        title: 'Login',
			        controller: 'login',
			        controllerAs: 'vm'
			    }
			},
			{
			    url: '/signup',
			    config: {
			        templateUrl: 'app/authentication/signup.html',
			        title: 'Sign Up',
			        controller: 'signup',
			        controllerAs: 'vm'
			    }
			},
			{
			    url: '/wildlife',
			    config: {
			        templateUrl: 'app/wildlife/wildlife.html',
			        title: 'Wildlife',
			        controller: 'wildlife',
			        controllerAs: 'vm'
			    }
			},
            {
                url: '/wildlife/:id',
                config: {
                    templateUrl: 'app/wildlife/specie.html',
                    title: 'Specie',
                    controller: 'specie',
                    controllerAs: 'vm'
                }
            }
        ];
    }

})();