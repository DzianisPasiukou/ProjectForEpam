myApp.controller('modalRecordCompare', function ($scope, $modalInstance,catalogData, items, modal, comparer, mainRecord) {

    $scope.records = [];

    getRecord(mainRecord.ID);
    getRecord(comparer);


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
});