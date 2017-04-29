(function() {
  'use strict';

  angular
    .module('jogosDesejadosUi')
    .controller('EditarController', EditarController);

  /** @ngInject */
  function EditarController($http,$location,$window,$stateParams) {
    var vm = this;
    //var apiRoot = 'http://jogosdesejados.azurewebsites.net/';
    var apiRoot = 'http://localhost:50391/';
    vm.game = {
			id: $stateParams.gameId,
            nome: "",
			videogame: ""
		};

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
    vm.init();


    vm.editarGame = function (game) {
	    var data = game;
      $http.put(apiRoot + 'api/games',
					data,
          {
            headers: {'Authorization': 'Bearer ' + localStorage.getItem('token')}
        })
				.success(function (data) {
					$window.alert("Editado com sucesso");
                    $location.path("/");

				})
				.error(function (data) {
					$window.alert("Dados Incorretos");
				});

		};

    
  }
})();
