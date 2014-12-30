myApp.controller('lightBoxCtrl', function ($scope, Lightbox) {
  
    $scope.openLightboxModal = function (index) {
        Lightbox.openModal($scope.images, index);
    };
});