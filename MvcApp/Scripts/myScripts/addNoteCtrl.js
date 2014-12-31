myApp.controller('addNoteCtrl', function ($scope, $modalInstance, catalogData,fileUpload, chacteristicService) {

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

                var data = new FormData();

                var files = $("#uploadAvatar").get(0).files;

                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "/api/fileupload/Post",
                    contentType: false,
                    processData: false,
                    data: data
                });

                ajaxRequest.done(function (xhr, textStatus) {
                });

                $modalInstance.close();
    };

        $scope.cancel = function () {

            $modalInstance.close();

        };
    });