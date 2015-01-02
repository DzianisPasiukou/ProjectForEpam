myApp.controller('modalCharacteristic', function ($scope, $modalInstance, chacteristicService, note) {
    $scope.note = note;

    $scope.close = function () {
        $modalInstance.close();
    }

     function getCharacter() {
         chacteristicService.getCharacteristic().success(function (data) {
             $scope.allCharacteristics = data;
         });
     }
     getCharacter();

     $scope.dropdown = function (name) {
         $scope.myCharacteristicName = name;
     }

     $scope.save = function (name, value) {

         chacteristicService.putCharacteristic(name, value, $scope.note.Id_Note);
         $modalInstance.close();
     }
});