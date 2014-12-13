myApp.controller('recordCtrl', function ($scope, $modal, $log) {
   
    $scope.open = function (id, size) {

        findChild(id);

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
        $('#say').attr("disabled", "disabled");
    }
   
    function findChild(idTheme) {

        $scope.items = [];
        var find = false;
        for (var i = 0; i < $scope.treedata[0].children.length; i++) {
            
            for (var j = 0; j < $scope.treedata[0].children[i].children.length; j++) {

                if ($scope.treedata[0].children[i].children[j].id == "themes " + idTheme) {
                    find = true;

                    for (var k = 0; k < $scope.treedata[0].children[i].children[j].children.length; k++) {
                        if ($scope.treedata[0].children[i].children[j].children[k]["idRecord"] != $scope.record.ID) {
                            $scope.items.push({
                                name: $scope.treedata[0].children[i].children[j].children[k]["label"],
                                id: $scope.treedata[0].children[i].children[j].children[k]["idRecord"],
                                description: $scope.treedata[0].children[i].children[j].children[k]["description"]

                            });
                        }
                    }

                    break;
                }
            }
            if (find) {
                break;
            }
        }
        
    };
});