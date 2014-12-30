myApp.controller('addNoteCtrl', function ($scope, $modalInstance, catalogData, chacteristicService) {

    function getCharacter() {
        chacteristicService.getCharacteristic().success(function (data) {
            $scope.allCharacteristics = data;
        });
    }

    getCharacter();

    $scope.dropdown = function (name) {
        $scope.myCharacteristicName = name;
    }

    $scope.addingNote = {};


    $scope.ok = function () {

        $modalInstance.close();

    }

    $scope.cancel = function () {

        $modalInstance.close();

    };
});