(function() {
  'use strict';

  angular
    .module('jogosDesejadosUi')
    .run(runBlock);

  /** @ngInject */
  function runBlock($log) {

    $log.debug('runBlock end');
  }

})();
