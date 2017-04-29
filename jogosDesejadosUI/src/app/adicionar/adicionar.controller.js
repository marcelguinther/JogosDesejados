(function() {
  'use strict';

  angular
    .module('jogosDesejadosUi')
    .controller('AdicionarController', AdicionarController);

  function AdicionarController($http,$location,$window) {
    var vm = this;
    //var apiRoot = 'http://jogosdesejados.azurewebsites.net/';
    var apiRoot = 'http://localhost:50391/';
    vm.game = null;
    vm.init = function () {
			
      $http.get(apiRoot + 'api/users', {
                    headers: {
                        'Authorization': 'Bearer ' + localStorage.getItem('token')
                    }
                })
        .success(function (data) {
					
				})
				.error(function (data) {
					$location.path("/login");
				});

		};

    vm.addGame = function (game) {
			var data = game;
      $http.post(apiRoot + 'api/games',
					data,
          {
            headers: {'Authorization': 'Bearer ' + localStorage.getItem('token')}
        })
				.success(function (data) {
					$window.alert("Adicionado com sucesso");

				})
				.error(function (data) {
					$window.alert("Dados Incorretos");
				});

		};

    vm.init();
  }
})();
