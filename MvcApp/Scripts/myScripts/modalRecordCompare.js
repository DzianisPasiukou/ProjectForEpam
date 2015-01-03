myApp.controller('modalRecordCompare', ['$scope', '$modalInstance', 'catalogData', 'chacteristicService', 'items', 'modal', 'comparer', 'mainRecord', function ($scope, $modalInstance, catalogData, chacteristicService, items, modal, comparer, mainRecord) {

    $scope.records = [];
    $scope.recordsCharacter = [];
    $scope.compareCharacter = [];
    var temp = 0;

    getRecord(mainRecord.Id_Note);
    getRecord(comparer);
    getCharacter(mainRecord.Id_Note);
    getCharacter(comparer);

    $scope.return = function () {
        $modalInstance.close();
        var modalInstance = modal.open({
            templateUrl: 'myModalContent.html',
            controller: 'modalCompareCtrl',
            resolve: {
                items: function () {
                    return items;
                },
                modal: function () {
                    return modal;
                },
                mainRecord: function () {
                    return mainRecord;
                }
            }
        });
    }

    $scope.close = function () {
        $modalInstance.close();
    };

    function getRecord(id) {
        catalogData.getRecord(id).success(function (data) {
            $scope.records.push(data);
        });
    };
    function getCharacter(id) {
        chacteristicService.getCharacteristicById(id).success(function (data) {
            $scope.recordsCharacter.push(data);
            temp = temp + 1;

            if (temp == 2)
                compareNotes();
        });


    }
    function compareNotes() {
        for (var i = 0; i < $scope.recordsCharacter[0].Characteristics.length; i++) {

            for (var j = 0; j < $scope.recordsCharacter[1].Characteristics.length; j++) {

                if ($scope.recordsCharacter[0].Characteristics[i].Id_Characteristic == $scope.recordsCharacter[1].Characteristics[j].Id_Characteristic) {
                    $scope.compareCharacter.push({
                        name: $scope.recordsCharacter[0].Characteristics[i].Name,
                        value1: findCharacterById($scope.recordsCharacter[0].Characteristics[i].Id_Characteristic, $scope.recordsCharacter[0].CharacteristicsOfNote),
                        value2: findCharacterById($scope.recordsCharacter[1].Characteristics[i].Id_Characteristic, $scope.recordsCharacter[1].CharacteristicsOfNote)
                    });
                }
            }
        }
    }
    function findCharacterById(id, array) {

        for (var i = 0; i < array.length; i++) {

            if (array[i].Id_Characteristic == id) {
                return array[i].Value;
            }
        }
    }
}]);