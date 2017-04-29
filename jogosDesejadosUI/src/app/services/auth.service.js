(function () {
	'use strict';

	angular
		.module('jogosDesejadosUi')
		.service('AuthService', AuthService);

	function AuthService($http,$location,$window) {
		var auth = this;

		auth.user = {
			name: "",
			email: "",
			password: ""
		};

		//var apiRoot = 'http://jogosdesejados.azurewebsites.net/';
		var apiRoot = 'http://localhost:50391/';
		auth.isAuthenticated = localStorage.getItem('isAuthenticated');
		auth.token = localStorage.getItem('token');

		function loginAcess() {
			var data = "grant_type=password&username=" + auth.email + "&password=" + auth.password;
			$http.post(apiRoot + 'api/security/token',
					data, {
						headers: {
							'Content-Type': 'application/x-www-form-urlencoded'
						}
					})
				.success(function (data) {
					auth.isAuthenticated = true;
					localStorage.setItem('token', data.access_token);
					localStorage.setItem('isAuthenticated', auth.isAuthenticated);
					$location.path("/adicionar");

				})
				.error(function (data) {
					$window.alert("Dados Incorretos");
				});
		}

		auth.loginAcess = function (login) {
			auth = login;
			loginAcess();
		};

		auth.logout = function () {
			auth.user = {
				email: '',
				password: ''
			};
			auth.isAuthenticated = false;
			auth.token = '';

			localStorage.setItem('token', auth.token);
			localStorage.setItem('isAuthenticated', auth.isAuthenticated);
		};
	}
})();