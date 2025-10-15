angular.module('VirtoCommerce.AiHelperGrokAi')
    .controller('VirtoCommerce.AiHelperGrokAi.helloWorldController', ['$scope', 'VirtoCommerce.AiHelperGrokAi.webApi', function ($scope, api) {
        var blade = $scope.blade;
        blade.title = 'AiHelperGrokAi';

        blade.refresh = function () {
            api.get(function (data) {
                blade.title = 'AiHelperGrokAi.blades.hello-world.title';
                blade.data = data.result;
                blade.isLoading = false;
            });
        };

        blade.refresh();
    }]);
