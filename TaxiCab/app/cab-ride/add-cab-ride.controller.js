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
            if (!vm.myForm.$valid) {
                var errors = [];

                for (var key in vm.myForm.$error) {
                    for (var index = 0; index < vm.myForm.$error[key].length; index++) {
                        errors.push(vm.myForm.$error[key][index].$name + ' is required.');
                    }
                }

                toaster.pop('warning', 'Information Missing', 'The ' + errors[0]);

                return;
            }

            entity.dateTime = entity.date + ' ' + entity.time

            return dataService.getFare(entity).then(function (data) {
                toaster.pop('success', data);

                vm.result = data;
            }, function (errors) {
                toaster.pop('warning', 'Unable to continue.');
            });
        }

    }

})();