(function() {
  'use strict';

  angular
    .module('jogosDesejadosUi')
    .config(routerConfig);

  /** @ngInject */
  function routerConfig($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('main', {
        url: '/',
        templateUrl: 'app/main/main.html',
        controller: 'MainController',
        controllerAs: 'vm'
      })
      .state('login', {
        url: '/login',
        templateUrl: 'app/login/index.html',
        controller: 'LoginController',
        controllerAs: 'vm'
      })
      .state('adicionar', {
        url: '/adicionar',
        templateUrl: 'app/adicionar/index.html',
        controller: 'AdicionarController',
        controllerAs: 'vm'
      })
      .state('editar', {
        url: "/editar/:gameId",
        templateUrl: 'app/editar/index.html',
        controller: 'EditarController',
        controllerAs: 'vm'
      });

    $urlRouterProvider.otherwise('/');
  }

})();
