angular.module('VirtoCommerce.AiHelperGrokAi')
    .factory('VirtoCommerce.AiHelperGrokAi.webApi', ['$resource', function ($resource) {
        return $resource('api/ai-helper-grok-ai');
    }]);
