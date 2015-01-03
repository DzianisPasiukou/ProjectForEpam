myApp.controller('addFileCtrl', ['$scope', '$modalInstance', 'fileUpload', 'file', function ($scope, $modalInstance, fileUpload, file) {

    $scope.add = function () {

        var f = document.getElementById('fileInput').files[0];

        console.log(f);
        fileUpload.upload(f);
    }

    $scope.close = function () {

        $modalInstance.close();

    };
}]);