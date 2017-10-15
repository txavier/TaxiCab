(function () {
    'use strict';

    angular
        .module('app')
        .config(config);

    config.$inject = ['$routeProvider', '$locationProvider', '$httpProvider'];

    function config($routeProvider, $locationProvider, $httpProvider) {
        // Configure the security token bearer interceptor.
        $httpProvider.interceptors.push('authInterceptorService');

        $routeProvider
            .when('/add-cab-ride', {
                templateUrl: 'app/cab-ride/add-cab-ride.html',
                controller: 'AddCabRideController',
                controllerAs: 'vm'
            })
            .when('/dashboard', {
                templateUrl: 'app/user/dashboard.html',
                controller: 'DashboardController',
                controllerAs: 'vm'
            })
            .when('/home', {
                templateUrl: 'app/home/home.html',
                controller: 'HomeController',
                controllerAs: 'vm'
            })
            .otherwise({ redirectTo: 'home' });

    }

})();