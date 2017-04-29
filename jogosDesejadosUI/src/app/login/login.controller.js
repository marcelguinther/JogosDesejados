(function() {
  'use strict';

  angular
    .module('jogosDesejadosUi')
    .controller('LoginController', LoginController);

  function LoginController(AuthService) {
    var vm = this;

    vm.user = {
            email: "",
            password: ""
        };
    
    vm.init = function () {
			vm.isAuthenticated = localStorage.getItem('isAuthenticated');
      if(vm.isAuthenticated){
        AuthService.logout();
      }

		};

    vm.init();

    vm.loginAcess = function () {
             
             AuthService.loginAcess(vm.user);
        };

  }
})();
