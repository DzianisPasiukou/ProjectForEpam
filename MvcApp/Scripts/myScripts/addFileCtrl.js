myApp.controller('addFileCtrl', function ($scope, $modalInstance, fileUpload, file) {
   
    $scope.add = function () {
      
        var formData = new FormData();
        var imagefile = document.getElementById("fileInput").files[0];
        formData.append("imageFile", imageFile);
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/api/FileUpload", true);
        xhr.send(formData);

        $modalInstance.close();

    }

    $scope.close = function () {

        $modalInstance.close();

    };
});