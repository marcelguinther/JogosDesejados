(function() {
  'use strict';

  angular
    .module('jogosDesejadosUi')
    .controller('MainController', MainController);

  function MainController($http,$location,$window) {
    var vm = this;   
    //var apiRoot = 'http://jogosdesejados.azurewebsites.net/';
    var apiRoot = 'http://localhost:50391/';
    vm.init = function () {
			
      $http.get(apiRoot + 'api/games', {
                    headers: {
                        'Authorization': 'Bearer ' + localStorage.getItem('token')
                    }
                })
        .success(function (data) {
					vm.games = data;
				})
				.error(function (data) {
					$location.path("/login");
				});

		};

    vm.init();

    vm.excluirGame = function (game) {
    var data = game.id;
    $http.post(apiRoot + 'api/games/' + data +'/delete/',
		data,
          {
            headers: {'Authorization': 'Bearer ' + localStorage.getItem('token'),'Content-Type': 'application/x-www-form-urlencoded'}
        })
				.success(function (data) {
					$window.alert("Removido com sucesso");
                    vm.init();

				})
				.error(function (data) {
				});
    };
  }
})();
