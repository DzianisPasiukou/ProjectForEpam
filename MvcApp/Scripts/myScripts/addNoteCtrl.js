myApp.controller('addNoteCtrl', function ($scope, $modalInstance, catalogData,fileUpload, chacteristicService) {

    $scope.characteristicsNewNote = [];
    $scope.photosNewNote = [];
    $scope.videosNewNote = [];
    $scope.documentsNewNote = [];

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

        var f = document.getElementById('avatarId').files[0];
        fileUpload.upload(f);
        $modalInstance.close();

    }

    $scope.cancel = function () {

        $modalInstance.close();

    };

    $scope.addPhoto = function () {
        $scope.photosNewNote.push({
            description: $scope.photoDescription
        });
    }
    $scope.addDocument = function () {
        $scope.documentsNewNote.push({
            description: $scope.docDescription
        });
    }
    $scope.addVideo = function () {
        $scope.videosNewNote.push({
            description: $scope.videoDescription
        });
    }
    $scope.addCharacteristic = function (myCharacteristicName, myCharacteristicValue) {
        $scope.characteristicsNewNote.push({
            name: myCharacteristicName,
            value: myCharacteristicValue
        });
    }
});