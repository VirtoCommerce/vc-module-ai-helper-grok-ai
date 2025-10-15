// Call this to register your module to main application
var moduleName = 'VirtoCommerce.AiHelperGrokAi';

if (AppDependencies !== undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
    .config(['$stateProvider',
        function ($stateProvider) {
            //$stateProvider
            //    .state('workspace.AiHelperGrokAiState', {
            //        url: '/ai-helper-grok-ai',
            //        templateUrl: '$(Platform)/Scripts/common/templates/home.tpl.html',
            //        controller: [
            //            'platformWebApp.bladeNavigationService',
            //            function (bladeNavigationService) {
            //                var newBlade = {
            //                    id: 'blade1',
            //                    controller: 'VirtoCommerce.AiHelperGrokAi.helloWorldController',
            //                    template: 'Modules/$(VirtoCommerce.AiHelperGrokAi)/Scripts/blades/hello-world.html',
            //                    isClosingDisabled: true,
            //                };
            //                bladeNavigationService.showBlade(newBlade);
            //            }
            //        ]
            //    });
        }
    ])
    .run(['platformWebApp.mainMenuService', '$state',
        function (mainMenuService, $state) {
            //Register module in main menu
            //var menuItem = {
            //    path: 'browse/ai-helper-grok-ai',
            //    icon: 'fa fa-cube',
            //    title: 'AiHelperGrokAi',
            //    priority: 100,
            //    action: function () { $state.go('workspace.AiHelperGrokAiState'); },
            //    permission: 'ai-helper-grok-ai:access',
            //};
            //mainMenuService.addMenuItem(menuItem);
        }
    ]);
