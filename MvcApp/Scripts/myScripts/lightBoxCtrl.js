myApp.controller('lightBoxCtrl', ['$scope', ' Lightbox', function ($scope, Lightbox) {

    $scope.openLightboxModal = function (index) {
        Lightbox.openModal($scope.images, index);
    };
}]);