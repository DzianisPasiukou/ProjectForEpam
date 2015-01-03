myApp.controller('modalCompareCtrl', ['$scope', '$modalInstance', 'items', 'modal', 'mainRecord', function ($scope, $modalInstance, items, modal, mainRecord) {

    $scope.items = items;
    $scope.selected = {
        item: $scope.items[0]
    };
    $scope.compareRecords = function (idRecord) {

        $modalInstance.close($scope.selected.item);
        var modalInstance = modal.open({
            templateUrl: 'compareModal.html',
            controller: 'modalRecordCompare',
            resolve: {
                items: function () {
                    return items;
                },
                modal: function () {
                    return modal;
                },
                comparer: function () {
                    return idRecord;
                },
                mainRecord: function () {
                    return mainRecord;
                }
            }
        });
    }

    $scope.ok = function () {
        $modalInstance.close($scope.selected.item);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
}]);