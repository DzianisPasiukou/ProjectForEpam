myApp.controller('resourceCtrl', ['$scope', '$modalInstance', 'userInfoData', 'resource', function ($scope, $modalInstance, userInfoData, resource) {
    $scope.resource = resource;
    $scope.close = function () {
        $modalInstance.close();
    }
    $scope.like = false;
    function likeEnabled() {
        userInfoData.getLikeEnable(resource.id, 'file').success(function (data) {
            if (data.Id) {
                $scope.like = true;
            }
        });
    };
    $scope.getLike = function () {
        $scope.like = true;
        userInfoData.putLike('file', resource.id);
    }
    likeEnabled();
}]);