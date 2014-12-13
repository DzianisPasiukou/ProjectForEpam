myApp.controller('addNoteCtrl', function ($scope, $modalInstance, catalogData) {

    $scope.ok = function () {

        $modalInstance.close();

    }

    $scope.cancel = function () {

        $modalInstance.close();

    };
});