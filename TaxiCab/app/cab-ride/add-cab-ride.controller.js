(function () {
    'use strict';

    angular
        .module('app')
        .controller('AddCabRideController', AddCabRideController);

    AddCabRideController.$inject = ['$scope', '$routeParams', '$log', '$location', 'toaster', 'dataService'];

    function AddCabRideController($scope, $routeParams, $log, $location, toaster, dataService) {
        var vm = this;

        vm.entityDataStore = 'cabRides';
        vm.returnPath = '/home';
        vm.cabRide = {};
        vm.addEntity = addEntity;
        vm.result = '';

        activate();

        function activate() {
        }

        function addEntity(entity) {
            entity.fileModel = undefined;

            return dataService.getFare(vm.entityDataStore, entity).then(function (data) {
                toaster.pop('success', data);

                vm.result = data;
            }, function (errors) {
                toaster.pop('warning', 'Unable to continue.');
            });
        }

    }

})();