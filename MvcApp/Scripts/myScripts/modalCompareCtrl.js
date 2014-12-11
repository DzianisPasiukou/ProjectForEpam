myApp.controller('modalCompareCtrl', function ($scope, $modalInstance, items, modal) {

    $scope.items = items;
    $scope.comparer = [];

    $scope.selected = {
        item: $scope.items[0]
    };
    $scope.compareRecords = function (idOneRecord, idTwoRecord) {
        $modalInstance.close($scope.selected.item);
        var modalInstance = modal.open({
            templateUrl: 'compareModal.html',
            controller: 'modalRecordCompare',
            resolve: {
                
            }
        });
    }
       
    $scope.ok = function () {
        $modalInstance.close($scope.selected.item);
    };

    $scope.cancel = function () { 
        $modalInstance.dismiss('cancel');
    };
});