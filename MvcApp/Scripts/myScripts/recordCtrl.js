myApp.controller('recordCtrl', function ($scope, $modal, $log) {
   
    $scope.thankDisable = false;

    $scope.open = function (idCategory, size) {

        $scope.items = [];
        findChild(idCategory, $scope.treedata);

        var modalInstance = $modal.open({
            templateUrl: 'myModalContent.html',
            controller: 'modalCompareCtrl',
            size: size,
            resolve: {
                items: function () {
                    return $scope.items;
                },
                modal: function () {
                    return $modal;
                },
                mainRecord: function () {
                    return $scope.record;
                }
            }
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.sayThank = function (idRecord) {
        $scope.thankDisable = true;
    }
   
    function findChild(idCategory, category) {

        var find = false;
       
        for (var i = 0; i < category.length; i++) {
            if (category[i].id == idCategory) {
                if ((category[i].idNote) && ($scope.record.Id_Note != category[i].idNote))
                {
                    $scope.items.push({
                        name: category[i].label,
                        description: category[i].description,
                        id: category[i].idNote
                    });
                }
                else {
                    find = findChild(idCategory, category[i].children);
                }
                find = true;
            }
            else {
                if (find)
                    break;
                find = findChild(idCategory, category[i].children);
            }
        }
        return find;
    };
});